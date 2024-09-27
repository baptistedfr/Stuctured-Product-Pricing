using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Volatility.Calibration
{
    class CsteCalibrationParams : ICalibrationParams
    {
        public double VolLevel;

        public CsteCalibrationParams(double volLevel)
        {
            VolLevel = volLevel;
        }
    }
}
