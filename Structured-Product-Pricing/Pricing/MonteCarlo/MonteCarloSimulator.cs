﻿using Pricing.Products;
using Pricing.Products.Options;
using Pricing.Volatility;
using Pricing.Volatility.Models;
using Pricing.Volatility.Parameters;

namespace Pricing.MonteCarlo
{
    public class MonteCarloSimulator
    {
        public IProduct Product;
        public Market Market;
        public double Maturity;

        public int NbSimulation;
        public int NbSteps;
        public double Dt;

        public MonteCarloSimulator(IProduct derive, Market market, int nbSim = 100000)
        {
            Product = derive;
            Market = market;
            NbSimulation = nbSim;
            Maturity = derive.GetMaturity();
            NbSteps = Convert.ToInt32(Maturity * 252);
            Dt = Maturity / NbSteps;

            if (market.VolModel as SVI != null)
            {
                IDerives? derivative = Product as IDerives;
                market.Volatility = derivative.CalculateVolSVI(market);
            }
            if (market.RateModel != null)
            {
                market.Rate = market.RateModel.GetRate(Maturity) / 100;
            }
        }
        public MonteCarloSimulator(Autocall autocall, Market market, int nbSim = 100000)
        {
            Product = autocall as IProduct;
            Market = market;
            NbSimulation = nbSim;
            Maturity = autocall.Maturity;
            NbSteps = Convert.ToInt32(Maturity * autocall.FreqObservation);
            Dt = Maturity / NbSteps;
            if (market.VolModel as SVI != null)
            {
                market.Volatility = Product.CalculateVolSVI(market);
            }
            if (Market.RateModel != null)
            {
                Market.Rate = Market.RateModel.GetRate(Maturity) / 100;
            }
        }

        /// <summary>
        /// Monte-Carlo pricer for regular option strategies
        /// </summary>
        /// <returns></returns>
        public (double price, double interval) Price(int? seed=null)
        {
            
            double[] payoffs = new double[NbSimulation];
            BrownianGenerator brownianGenerator = new BrownianGenerator();
            bool isBarrier = (Product as BarrierOption != null); // On regarde si c est une option barrière, dans ce cas il faudra discretiser
            bool isHeston = Market.VolType == VolatilityType.Heston; // On regarde si le calcul de la volatilité est stochastique
            bool isAutocall = (Product as Autocall != null);
            Parallel.For(0, NbSimulation, i =>
            {
                if (seed != null)
                {
                    seed += 1; // Si il y a une seed on la change a chaque iteration
                }
                double simPrice = Market.Spot;
                if (isAutocall)
                {
                    payoffs[i] = GenerateAutocallPayoff(simPrice, seed);
                }
                else
                {
                    payoffs[i] = GenerateDerivativePayoff(simPrice, isBarrier, isHeston, seed);
                }
                
            });
            double confidenceInterval = ConfidenceInterval(payoffs);
            double price = Math.Exp(-Market.Rate * Maturity) * payoffs.Average();
            return (price, confidenceInterval);
        }
        public double GenerateDerivativePayoff(double simPrice, bool isBarrier, bool isHeston, int? seed = null)
        {
            BrownianGenerator brownianGenerator = new BrownianGenerator();
            BarrierOption? barrierOption = Product as BarrierOption;

            if (isHeston)
            {
                double[] varianceSimulated = new double[NbSteps];
                varianceSimulated[0] = 0.2;
                var hestonModel = Market.VolModel as Heston;
                var (dW1, dW2) = brownianGenerator.GenerateBrownian(NbSteps, hestonModel.Rho);

                for (int j = 1; j < NbSteps + 1; j++)
                {
                    HestonParams volParams = new HestonParams(varianceSimulated[j - 1], Dt, dW2[j - 1]);
                    var hestonVariance = Math.Max(0, hestonModel.GetVolatility(volParams));

                    double hestonDrift = (Market.Rate - 0.5 * Math.Pow(hestonVariance, 2)) * Dt;
                    double hestonDiffusion = hestonVariance * Math.Sqrt(Dt);

                    simPrice *= Math.Exp(hestonDrift + hestonDiffusion * dW1[j-1]);

                    if (barrierOption != null && barrierOption.BarrierOut(simPrice))
                    {
                        break;
                    }
                }
            }
            else
            {
                if (isBarrier) // Cas de vol SVI ou vol constante, on doit quand meme discretiser pour les barrières
                {
                    double drift = (Market.Rate - 0.5 * Math.Pow(Market.Volatility, 2)) * Dt;
                    double diffusion = Market.Volatility * Math.Sqrt(Dt);
                    double[] dW1 = brownianGenerator.GenerateNormal(NbSteps, seed);
                    for (int j = 0; j < NbSteps; j++)
                    {
                        simPrice *= Math.Exp(drift + diffusion * dW1[j]);

                        if (barrierOption != null && barrierOption.BarrierOut(simPrice))
                        {
                            break;
                        }
                    }
                }
                else
                {
                    double drift = (Market.Rate - 0.5 * Math.Pow(Market.Volatility, 2)) * Maturity;
                    double diffusion = Market.Volatility * Math.Sqrt(Maturity);
                    double[] dW1 = brownianGenerator.GenerateNormal(1, seed);
                    simPrice *= Math.Exp(drift + diffusion * dW1[0]);
                }
            }

            return Product.Payoff(simPrice);
        }

        public double GenerateAutocallPayoff(double simPrice, int? seed = null)
        {
            BrownianGenerator brownianGenerator = new BrownianGenerator();
            Autocall? autocall = Product as Autocall;
            double drift = (Market.Rate - 0.5 * Math.Pow(Market.Volatility, 2)) * Dt;
            double diffusion = Market.Volatility * Math.Sqrt(Dt);
            double[] dW1 = brownianGenerator.GenerateNormal(NbSteps, seed);
            double[] paths = new double[NbSteps];
            for (int i = 0; i < NbSteps; i++)
            {
                simPrice *= Math.Exp(drift + diffusion * dW1[i]);
                paths[i] = simPrice;
            }
            return autocall.PayoffPath(paths, Market.Rate);
        }

        public double FindCouponAutocall(double tolerance = 0.0001)
        {
            Autocall? autocall = Product as Autocall;
            double lowerBound = 0.0; // Borne inférieure du coupon
            double upperBound = 50; // Borne supérieure du coupon
            double coupon = 0.0;

            while (upperBound - lowerBound > tolerance)
            {
                coupon = (lowerBound + upperBound) / 2; // Point médian
                autocall.Coupon = coupon;

                // Simulez un chemin (path) pour obtenir le payoff avec ce coupon
                
                (double price, double _) = Price();

                if (price < autocall.Nominal)
                {
                    lowerBound = coupon; 
                }
                else
                {
                    upperBound = coupon; 
                }
            }

            return coupon; // Retourne le coupon qui donne un nominal de 100
        }
        public double ConfidenceInterval(double[] payoffs)
        {
            double meanPrice = payoffs.Average();
            double variance = payoffs.Select(p => Math.Pow(p - meanPrice, 2)).Average();
            double standardDeviation = Math.Sqrt(variance);
            double confidenceLevel = 1.96; // Pour un intervalle de confiance de 95%
            return (confidenceLevel * (standardDeviation / Math.Sqrt(NbSimulation)));
        }


        /// <summary>
        /// Compute option greeks with finite difference method
        /// </summary>
        public Dictionary<string, double> ComputeGreeks()
        {
            // On fixe la seed
            int seedInitial = 1;
            double priceOption = Price(seedInitial).price; // Prix initial
            Dictionary<string, double> greeks = new Dictionary<string, double>();

            // Sauvegarde des valeurs initiales
            double originalSpot = Market.Spot;
            double originalVolatility = Market.Volatility;
            double originalMaturity = Maturity;
            double originalRate = Market.Rate;

            // Calcul du Delta
            double deltaS = originalSpot * 0.01;  // Variation du spot
            Market.Spot += deltaS;
            double priceDeltaSpotPos = Price(seedInitial).price;  
            double delta = (priceDeltaSpotPos - priceOption) / deltaS;
            Market.Spot = originalSpot;  // Réinitialise le spot
            greeks.Add("Delta", delta);

            // Calcul du Gamma
            Market.Spot = originalSpot - deltaS;
            double priceDeltaSpotNeg = Price(seedInitial).price;  
            double gamma = (priceDeltaSpotPos - 2 * priceOption + priceDeltaSpotNeg) / (deltaS * deltaS);
            Market.Spot = originalSpot;  // Réinitialise le spot
            greeks.Add("Gamma", gamma);

            // Calcul du Vega
            double deltaSigma = 0.01;  // Variation de la volatilité
            Market.Volatility += deltaSigma;
            double vega = (Price(seedInitial).price - priceOption) / deltaSigma;  
            Market.Volatility = originalVolatility;  // Réinitialise la volatilité
            greeks.Add("Vega", vega);

            // Calcul du Theta
            double deltaMaturity = 10.0 / 252;  // Variation de la maturité, ici 10 jours
            Maturity -= deltaMaturity;
            double theta = (Price(seedInitial).price - priceOption) / deltaMaturity;  
            Maturity = originalMaturity;  // Réinitialise la maturité
            greeks.Add("Theta", theta);

            // Calcul du Rho
            double deltaRho = 0.01;  // Variation du taux d'intérêt
            Market.Rate += deltaRho;
            double rho = (Price(seedInitial).price - priceOption) / deltaRho; 
            Market.Rate = originalRate;  // Réinitialise le taux d'intérêt
            greeks.Add("Rho", rho);
         
            return greeks;
        }
    }
}