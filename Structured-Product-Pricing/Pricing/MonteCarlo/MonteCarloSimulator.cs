using Microsoft.VisualBasic.FileIO;
using Pricing.Products;
using Pricing.Products.Options;
using Pricing.Volatility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.MonteCarlo
{
    public class MonteCarloSimulator
    {
        public IDerives derive;
        public Market market;
        public int nbSim;
        public double maturity;

        public MonteCarloSimulator(IDerives derive, Market market, int nbSim = 100000)
        {
            this.derive = derive;
            this.market = market;
            this.nbSim = nbSim;
            this.maturity = derive.GetMaturity(); // Fonction qui recupere la maturité de l'option

            
            if (market.VolModel as SVI !=null)
            {
                market.Volatility = derive.CalculateVolSVI(market);
            }
            // Dans le cas où on a un marché automatique, on doit calibrer le taux sans risque
            if (market.RateModel != null) {
                market.Rate = market.RateModel.Rate(maturity) / 100; // On calcule le taux sans risque à partir de la maturité
            }
        }

        public double Price()
        {
            int nbSteps = Convert.ToInt32(maturity * 252);
            double dt = maturity / nbSteps;
            double[] payoffs = new double[nbSim];

            double drift = (market.Rate - 0.5 * Math.Pow(market.Volatility, 2)) * dt;
            double diffusion = market.Volatility * Math.Sqrt(dt);

            BarrierOption? barrierOption = derive as BarrierOption;

            Parallel.For(0, nbSim, i =>
            {
                BarrierOption? barrierOption = derive as BarrierOption;
                double simPrice = market.Spot;

                if (barrierOption != null)
                {
                    barrierOption.Activated = false; 
                }

                double[] normalVariables = GenerateNormal(nbSteps);

                for (int j = 0; j < nbSteps; j++)
                {
                    simPrice *= Math.Exp(drift + diffusion * normalVariables[j]);

                    if (barrierOption != null && barrierOption.BarrierOut(simPrice))
                    {
                        break;
                    }
                }
                payoffs[i] = derive.Payoff(simPrice);
            });

            return Math.Exp(-market.Rate * maturity) * payoffs.Average();
        }
        //public Dictionary<string, double> ComputeGreeks(double priceOption)
        //{
        //    Dictionary<string, double> greeks = new Dictionary<string, double>();

        //    // Delta
        //    double deltaS = market.Spot * 0.01;
        //    market.Spot += deltaS;
        //    double priceDeltaSpotPos = Price();
        //    double delta = (priceDeltaSpotPos - priceOption) / deltaS;
        //    market.Spot -= deltaS; //On remet le spot à normale
        //    greeks.Add("Delta", delta);

        //    // Gamma
        //    market.Spot -= deltaS;
        //    double priceDeltaSpotNeg = Price();
        //    double gamma = (Price(spot + deltaS) - 2 * priceOption + Price(spot - deltaS)) / (deltaS * deltaS);
        //    market.Spot -= deltaS;
        //    greeks.Add("Gamma", gamma);

        //    // Vega
        //    double deltaSigma = 0.01;
        //    market.Volatility += deltaSigma;
        //    double vega = (Price(spot) - priceOption) / deltaSigma;
        //    market.Volatility -= deltaSigma; // On remet la vol à son niveau d'avant
        //    greeks.Add("Vega", vega);

        //    // Theta
        //    double deltaMaturity = 10.0 / 252; // on diminue de 10 jour (10/252 an)
        //    maturity -= deltaMaturity;
        //    double theta = (Price(spot) - priceOption) / deltaMaturity;
        //    maturity = derive.GetMaturity(); // On remet la maturité comme avant
        //    greeks.Add("Theta", theta);

        //    // Rho
        //    double deltaRho = 0.01;
        //    market.Rate += deltaRho;
        //    double rho = (Price(spot) - priceOption) / deltaRho;
        //    market.Rate -= deltaRho; // On remet la vol à son niveau d'avant
        //    greeks.Add("Rho", rho);

        //    return greeks;
        //}
        public double[] GenerateNormal(int nb)
        {
            double [] normalVariables = new double[nb];
            double u1, u2;
            Random aleatoire = new Random();
            for (int i = 0; i < nb; i++)
            {
                u1 = aleatoire.NextDouble();
                u2 = aleatoire.NextDouble();
                normalVariables[i] = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            }
            return normalVariables;
        }
        public void DisplayStatistics(double[] data)
        {
            double mean = data.Average();
            double variance = data.Select(val => (val - mean) * (val - mean)).Average();
            double stddev = Math.Sqrt(variance);

            Console.WriteLine($"Moyenne : {mean}");
            Console.WriteLine($"Variance : {variance}");
            Console.WriteLine($"Écart-type : {stddev}");
        }
    }
}
