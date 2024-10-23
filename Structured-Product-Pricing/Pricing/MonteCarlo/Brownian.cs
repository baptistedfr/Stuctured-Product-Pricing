using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.MonteCarlo
{
    internal class BrownianGenerator
    {
        /// <summary>
        /// Generate two independant draws from a normal distribution through a Box-Muller transform
        /// </summary>
        private (double, double) GenerateTwoNormal()
        {
            Random random = new Random();
            double u1 = random.NextDouble();
            double u2 = random.NextDouble();

            var dZ1 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
            var dZ2 = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);

            return (dZ1,  dZ2);
        }

        /// <summary>
        /// Generate two lists of Brownian as : dW1[i] and dW2[i] have a given correlation
        /// </summary>
        public (double[], double[]) GenerateBrownian(int nbSteps, double correlation)
        {
            double[] dW1 = new double[nbSteps];
            double[] dW2 = new double[nbSteps];

            for (int i = 0; i < nbSteps; i += 1)
            {
                var (dZ1, dZ2) = GenerateTwoNormal();               
                dW1[i] = dZ1;
                dW2[i] = correlation * dZ1 + Math.Sqrt(1 - Math.Pow(correlation, 2)) * dZ2;
            }

            return (dW1, dW2);
        }

        /// <summary>
        /// Generate n independant draws from a normal distribution through a Box-Muller transform
        /// </summary>
        public double[] GenerateNormal(int nb, Random aleatoire)
        {
            double[] normalVariables = new double[nb];
            double u1, u2;

            // Si une seed est fournie, on l'utilise, sinon on utilise le temps système
            //Random aleatoire = (seed.HasValue) ? new Random(seed.Value) : new Random();

            for (int i = 0; i < nb; i++)
            {
                u1 = aleatoire.NextDouble();
                u2 = aleatoire.NextDouble();
                normalVariables[i] = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            }

            return normalVariables;
        }
    }
}
