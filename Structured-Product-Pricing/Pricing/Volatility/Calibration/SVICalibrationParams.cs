using Pricing.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Volatility.Calibration
{
    class SVICalibrationParams : ICalibrationParams
    {
        public List<OptionData> OptData { get; set; }
        public double Spot {  get; set; }

        public SVICalibrationParams(List<OptionData> optData, double spot)
        {
            OptData = optData;
            Spot = spot;
        }
    }
}
