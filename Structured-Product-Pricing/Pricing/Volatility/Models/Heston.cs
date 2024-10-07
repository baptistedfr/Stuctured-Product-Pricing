using Pricing.Volatility.Calibration;
using Pricing.Volatility.Parameters;

namespace Pricing.Volatility.Models
{
    internal class Heston : VolatilityModel
    {
        public double Kappa { get; set; }
        public double Theta { get; set; }
        public double VolOfVol { get; set; }
        public double Rho { get; set; }

        public Heston(double kappa = 0.1, double theta = 0.1, double volOfVol = 0.1, double rho = 0.8)
        {
            Kappa = kappa;
            Theta = theta;
            VolOfVol = volOfVol;
            Rho = rho;
        }

        /// <summary>
        /// Compute the next volatility according to Euler Discretisation of Heston model with positivity ajustment of previous variance to avoid discretisation error
        /// </summary>
        public override double GetVolatility(IVolatilityParams parameters)
        {
            var hestonParams = parameters as HestonParams;
            if (hestonParams == null) throw new ArgumentException("Invalid calibration parameters for Heston model");

            var prevVar = hestonParams.PreviousVariance;
            return prevVar + Kappa * (Theta - Math.Max(prevVar, 0) * hestonParams.Dt) + VolOfVol * Math.Sqrt(Math.Max(prevVar, 0)) * hestonParams.BrownianMotion;
        }

        public override void Calibrate(ICalibrationParams parameters)
        {

        }
    }
}
