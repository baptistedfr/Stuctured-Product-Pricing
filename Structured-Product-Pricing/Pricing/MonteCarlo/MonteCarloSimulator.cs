using Microsoft.VisualBasic.FileIO;
using Pricing.Products;
using Pricing.Products.Options;
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
        private IDerives derive;
        private Market market;
        private int nbSim;
        private double maturity;

        public MonteCarloSimulator(IDerives derive, Market market, int nbSim = 100000)
        {
            this.derive = derive;
            this.market = market;
            this.nbSim = nbSim;
            this.maturity = derive.GetMaturity(); // Fonction qui recupere la maturité de l'option
            market.Rate = market.RateModel.Rate(maturity) / 100; // On calcule le taux sans risque à partir de la maturité
        }

        public double Price(double spot = 0)
        {
            int nbSteps = Convert.ToInt32(maturity * 252);
            double dt = maturity / nbSteps;
            market.Spot = spot; // On recupere le spot A CHANGER AVEC AUTOMATISATION
            double[] normalVariables;
            double[] payoffs = new double[nbSim];
            double simPrice;

            double drift = (market.Rate - 0.5 * Math.Pow(market.Volatility, 2)) * dt;
            double diffusion = market.Volatility * Math.Sqrt(dt);

            BarrierOption? barrierOption = derive as BarrierOption;
            for (int i = 0; i < nbSim; i++)
            {
                if (barrierOption != null)
                {
                    barrierOption.Activated = false; // On remet la barriere à faux
                }
                simPrice = market.Spot;
                normalVariables = GenerateNormal(nbSteps);
                for (int j=0;j<nbSteps; j++)
                {
                    simPrice*= Math.Exp(drift + diffusion * normalVariables[j]);
                    if (barrierOption != null && barrierOption.BarrierOut(simPrice))
                    {
                        break; // Pas besoin de continuer cette trajectoire, la barrière Out est franchis
                    }
                }
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
            double vega = (Price(spot) - priceOption) / deltaSigma;
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
            double rho = (Price(spot) - priceOption) / deltaRho;
            market.Rate -= deltaRho; // On remet la vol à son niveau d'avant
            greeks.Add("Rho", rho);

            return greeks;
        }
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
