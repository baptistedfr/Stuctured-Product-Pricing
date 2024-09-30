using Pricing.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.MonteCarlo
{
    public class MonteCarloSimulator
    {
        private IDerives derive;
        private Market market;
        private int nbSteps;
        private double maturity;

        public MonteCarloSimulator(IDerives derive, Market market, int nbSteps = 1000000)
        {
            this.derive = derive;
            this.market = market;
            this.nbSteps = nbSteps;

            this.maturity = derive.GetMaturity(); // Fonction qui recupere la maturité de l'option
            market.Rate = market.RateModel.Rate(maturity) / 100; // On calcule le taux sans risque à partir de la maturité

            Console.WriteLine($"Rate : {market.Rate} ");
            Console.WriteLine($"Volatility  : {market.Volatility}");
            Console.WriteLine($"Maturity : maturity");

        }

        public double Price(double spot = 0)
        {
            market.Spot = spot; // On recupere le spot A CHANGER AVEC AUTOMATISATION
   
            double[] normalVariables = GenerateNormal();
            double[] payoffs = new double[nbSteps];
            double simPrice;
            double exponent;
            for (int i = 0; i < nbSteps; i++)
            {
                exponent = (market.Rate - 0.5 * market.Volatility * market.Volatility) * maturity + market.Volatility * Math.Sqrt(maturity) * normalVariables[i];
                simPrice = market.Spot*Math.Exp(exponent);
                payoffs[i] = derive.Payoff(simPrice);
            }
            
            return Math.Exp(-market.Rate * maturity) * payoffs.Average();
        }
        public Dictionary<string, double > ComputeGreeks(double priceOption, double spot)
        {
            Dictionary<string, double> greeks = new Dictionary<string, double>();

            // Delta
            double deltaS = spot * 0.01;
            double delta = (Price(spot + deltaS) - priceOption) / deltaS;
            greeks.Add("Delta", delta);

            // Gamma
            double gamma = (Price(spot + deltaS) - 2* priceOption + Price(spot - deltaS)) / (deltaS*deltaS);
            greeks.Add("Gamma", gamma);

            // Vega
            double deltaSigma = 0.01;
            market.Volatility += deltaSigma;
            double vega = (Price(spot) - priceOption) / (deltaSigma*100);
            market.Volatility -= deltaSigma; // On remet la vol à son niveau d'avant
            greeks.Add("Vega", vega);

            // Theta
            double deltaMaturity = 1.0 / 252; // on diminue de 1 jour (1/252 an)
            maturity -= deltaMaturity;
            double theta = (Price(spot) - priceOption) / deltaMaturity;
            maturity += deltaMaturity; // On remet la maturité comme avant
            greeks.Add("Theta", theta);

            // Rho
            double deltaRho = 0.01;
            market.Rate += deltaRho;
            double rho = (Price(spot) - priceOption) / (deltaRho*100);
            market.Rate -= deltaRho; // On remet la vol à son niveau d'avant
            greeks.Add("Rho", rho);

            return greeks;
        }
        public double[] GenerateNormal()
        {
            double [] normalVariables = new double[nbSteps];
            double u1, u2;
            Random aleatoire = new Random();
            for (int i = 0; i < nbSteps; i++)
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
