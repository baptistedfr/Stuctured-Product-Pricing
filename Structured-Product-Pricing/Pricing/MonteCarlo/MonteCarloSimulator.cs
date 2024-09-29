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

        public MonteCarloSimulator(IDerives derive, Market market, int nbSteps = 100000)
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
