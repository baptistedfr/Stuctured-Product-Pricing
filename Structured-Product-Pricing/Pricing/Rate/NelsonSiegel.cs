using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Optimization;
using Pricing.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Rate
{
    public class NelsonSiegel
    {
        private double Beta0 { get; set; }
        private double Beta1 { get; set; }
        private double Beta2 { get; set; }
        private double Tau { get; set; }

        public double Rate(double maturity)
        {
            if (maturity == 0) return Beta0;
            return Beta0 + Beta1 * (1 - Math.Exp(-maturity / Tau)) / (maturity / Tau) + Beta2 * ((1 - Math.Exp(-maturity / Tau)) / (maturity / Tau) - Math.Exp(-maturity / Tau));
        }

        public void Calibrate(List<RateCurveData> rateCurveData)
        {
            double initialBeta0 = rateCurveData.Average(x => x.Rate);
            double initialBeta1 = 0.1;
            double initialBeta2 = -0.1;
            double initialTau = 1.0;

            Func<Vector<double>, double> objectiveFunction = parameters =>
            {
                Beta0 = parameters[0];
                Beta1 = parameters[1];
                Beta2 = parameters[2];
                Tau = parameters[3];

                return rateCurveData.Sum(data =>
                {
                    double estimatedRate = Rate(data.Maturity);
                    return Math.Pow(estimatedRate - data.Rate, 2);
                });
            };

            var initialGuess = new double[] { initialBeta0, initialBeta1, initialBeta2, initialTau };
            var initialGuessVector = Vector<double>.Build.DenseOfArray(initialGuess);

            IObjectiveFunction func = ObjectiveFunction.Value(objectiveFunction);
            var optimizer = new NelderMeadSimplex(1e-3, 100000);
            var result = optimizer.FindMinimum(func, initialGuessVector);

            Beta0 = result.MinimizingPoint[0];
            Beta1 = result.MinimizingPoint[1];
            Beta2 = result.MinimizingPoint[2];
            Tau = result.MinimizingPoint[3];
        }
    }
}
