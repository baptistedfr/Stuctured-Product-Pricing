using Pricing.Products;
using Pricing.Products.Options;
using Pricing.Volatility;
using Pricing.Volatility.Models;
using Pricing.Volatility.Parameters;

namespace Pricing.MonteCarlo
{
    public class MonteCarloSimulator
    {
        public IDerives Derive;
        public Market Market;
        public double Maturity;

        public int NbSimulation;
        public int NbSteps;
        public double Dt;

        public MonteCarloSimulator(IDerives derive, Market market, int nbSim = 100000)
        {
            Derive = derive;
            Market = market;
            NbSimulation = nbSim;
            Maturity = derive.GetMaturity();
            NbSteps = Convert.ToInt32(Maturity * 252);
            Dt = Maturity / NbSteps;

            if (market.VolModel as SVI != null)
            {
                market.Volatility = derive.CalculateVolSVI(market);
            }
            if (market.RateModel != null)
            {
                market.Rate = market.RateModel.GetRate(Maturity) / 100;
            }
        }


        /// <summary>
        /// Monte-Carlo pricer for regular option strategies
        /// </summary>
        /// <returns></returns>
        public (double price, double interval) Price()
        {
            double[] payoffs = new double[NbSimulation];
            //double[] prices = new double[NbSimulation];
            BrownianGenerator brownianGenerator = new BrownianGenerator();
            BarrierOption? barrierOption = Derive as BarrierOption;
            bool isHeston = Market.VolType == VolatilityType.Heston;
            Parallel.For(0, NbSimulation, i =>
            {

                if (barrierOption != null)
                {
                    barrierOption.Activated = false;
                }

                double simPrice = Market.Spot;
                // Pricing with Heston discretisation
                if (isHeston)
                {
                    double[] varianceSimulated = new double[NbSteps];
                    varianceSimulated[0] = 0.2;
                    var hestonModel = Market.VolModel as Heston;
                    var (dW1, dW2) = brownianGenerator.GenerateBrownian(NbSteps, hestonModel.Rho);

                    for (int j = 1; j < NbSteps + 1; j++)
                    {
                        HestonParams volParams = new HestonParams(varianceSimulated[j - 1], Dt, dW2[j-1]);
                        var hestonVariance = Math.Max(0, hestonModel.GetVolatility(volParams));

                        double hestonDrift = (Market.Rate - 0.5 * Math.Pow(hestonVariance,2)) * Dt;
                        double hestonDiffusion = hestonVariance*Math.Sqrt(Dt);

                        simPrice *= Math.Exp(hestonDrift + hestonDiffusion * dW1[j]);

                        if (barrierOption != null && barrierOption.BarrierOut(simPrice))
                        {
                            break;
                        }
                    }
                }
                // Pricing without Heston : Volatility is either constant or calculated from the SVI in the constructor
                else
                {
                    double drift = (Market.Rate - 0.5 * Math.Pow(Market.Volatility, 2)) * Dt;
                    double diffusion = Market.Volatility * Math.Sqrt(Dt);
                    double[] dW1 = brownianGenerator.GenerateNormal(NbSteps);

                    for (int j = 0; j < NbSteps; j++)
                    {
                        simPrice *= Math.Exp(drift + diffusion * dW1[j]);
                        if (barrierOption != null && barrierOption.BarrierOut(simPrice))
                        {
                            break;
                        }
                    }
                }
                payoffs[i] = Derive.Payoff(simPrice);
                //prices[i] = Math.Exp(-Market.Rate * Maturity) * payoffs.Take(i + 1).Average();
            });
            double confidenceInterval = ConfidenceInterval(payoffs);
            double price = Math.Exp(-Market.Rate * Maturity) * payoffs.Average();
            return (price, confidenceInterval);
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
        /// Monte-Carlo pricer for structured products
        /// </summary>
        /// <returns></returns>
        public double PriceStructu()
        {
            return 0.0;
        }

        /// <summary>
        /// Compute option greeks with finite difference method
        /// </summary>
        public Dictionary<string, double> ComputeGreeks()
        {
            // On fixe la seed
            double priceOption = Price().price; // Prix initial
            Dictionary<string, double> greeks = new Dictionary<string, double>();

            // Sauvegarde des valeurs initiales
            double originalSpot = Market.Spot;
            double originalVolatility = Market.Volatility;
            double originalMaturity = Maturity;
            double originalRate = Market.Rate;

            // Calcul du Delta
            double deltaS = originalSpot * 0.01;  // Variation du spot
            Market.Spot += deltaS;
            double priceDeltaSpotPos = Price().price;  
            double delta = (priceDeltaSpotPos - priceOption) / deltaS;
            Market.Spot = originalSpot;  // Réinitialise le spot
            greeks.Add("Delta", delta);

            // Calcul du Gamma
            Market.Spot = originalSpot - deltaS;
            double priceDeltaSpotNeg = Price().price;  
            double gamma = (priceDeltaSpotPos - 2 * priceOption + priceDeltaSpotNeg) / (deltaS * deltaS);
            Market.Spot = originalSpot;  // Réinitialise le spot
            greeks.Add("Gamma", gamma);

            // Calcul du Vega
            double deltaSigma = 0.01;  // Variation de la volatilité
            Market.Volatility += deltaSigma;
            double vega = (Price().price - priceOption) / deltaSigma;  
            Market.Volatility = originalVolatility;  // Réinitialise la volatilité
            greeks.Add("Vega", vega);

            // Calcul du Theta
            double deltaMaturity = 10.0 / 252;  // Variation de la maturité, ici 10 jours
            Maturity -= deltaMaturity;
            double theta = (Price().price - priceOption) / deltaMaturity;  
            Maturity = originalMaturity;  // Réinitialise la maturité
            greeks.Add("Theta", theta);

            // Calcul du Rho
            double deltaRho = 0.01;  // Variation du taux d'intérêt
            Market.Rate += deltaRho;
            double rho = (Price().price - priceOption) / deltaRho; 
            Market.Rate = originalRate;  // Réinitialise le taux d'intérêt
            greeks.Add("Rho", rho);
         
            return greeks;
        }
    }
}