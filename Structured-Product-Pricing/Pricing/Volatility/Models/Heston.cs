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

        public Heston(double spot, double rate, double volatility, double kappa, double theta, double volOfVol, double rho)
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

        /// <summary>
        /// Function use to calibrate the Heston models to fit the best the Market Data.
        /// The model has to be calibrated at market initialisation.
        /// Once calibrated, one can directly use the model to have a volatility estimation by calling "GetVolatility" method.
        /// </summary>
        public override void Calibrate(ICalibrationParams parameters)
        {
            Kappa = 0.1;
            Theta = 0.1;
            VolOfVol = 0.1;
            Rho = 0.8;
        }
    }
}
