using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Linq;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.LinearAlgebra;
using Pricing.MarketData;
using Pricing.Volatility.Calibration;

namespace Pricing.Volatility.Models
{
    public class SVI : VolatilityModel
    {
        private double Alpha { get; set; }
        private double Beta { get; set; }
        private double Rho { get; set; }
        private double M { get; set; }
        private double Sigma { get; set; }

        public SVI(double alpha = 0.1, double beta = 0.1, double rho = 0.1, double m = 0.1, double sigma = 0.1)
        {
            Alpha = alpha;
            Beta = beta;
            Rho = rho;
            M = m;
            Sigma = sigma;
        }

        private double TotalVariance(double logMoneyness)
        {
            return Alpha + Beta * (Rho * (logMoneyness - M) + Math.Sqrt(Math.Pow(logMoneyness - M, 2) + Math.Pow(Sigma, 2)));
        }

        public override double GetVolatility(double strike, double maturity, double spot)
        {
            var totalVariance = TotalVariance(Math.Log(strike / spot));
            return Math.Sqrt(totalVariance / maturity);
        }

        private void SetParameters(double[] parameters)
        {
            Alpha = parameters[0];
            Beta = parameters[1];
            Rho = parameters[2];
            M = parameters[3];
            Sigma = parameters[4];
        }

        public override void Calibrate(ICalibrationParams parameters)
        {
            var SVIParams = parameters as SVICalibrationParams;
            var optData = SVIParams.OptData;
            var spot = SVIParams.Spot;

            Func<Vector<double>, double> objectiveFunction = parameters =>
            {
                SetParameters(parameters.ToArray());
                return optData.Sum(data => Math.Pow(GetVolatility(data.Strike, data.Maturity, spot) - data.ImpliedVolatility, 2));
            };

            double[] initialGuess = new double[] { Alpha, Beta, Rho, M, Sigma };
            var initialGuessVector = Vector<double>.Build.DenseOfArray(initialGuess);

            IObjectiveFunction func = ObjectiveFunction.Value(objectiveFunction);
            var optimizer = new NelderMeadSimplex(1e-3, 100000);
            var result = optimizer.FindMinimum(func, initialGuessVector);

            var optParams = result.MinimizingPoint.ToArray();
            SetParameters(optParams);
        }
    }
}
