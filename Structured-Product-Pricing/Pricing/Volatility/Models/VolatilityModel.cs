using Pricing.Volatility.Calibration;
using Pricing.Volatility.Parameters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Volatility.Models
{
    public abstract class VolatilityModel
    {
        public abstract void Calibrate(ICalibrationParams parameters);

        public abstract double GetVolatility(IVolatilityParams parameters = null);
    }
}
