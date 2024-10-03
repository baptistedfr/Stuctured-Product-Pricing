using Pricing.Volatility.Calibration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Volatility.Models
{
    public enum VolatilityType
    {
        Cste,
        SVI
    }

    public abstract class VolatilityModel
    {
        public abstract void Calibrate(ICalibrationParams parameters);

        public abstract double GetVolatility(double strike=0, double maturity=0, double spot=0);
    }

    
}
