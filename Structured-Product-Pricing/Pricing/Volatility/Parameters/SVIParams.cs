using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Volatility.Parameters
{
    public class SVIParams : IVolatilityParams
    {
        public double Strike { get; set; }
        public double Maturity { get; set; }
        public double Spot { get; set; }

        public SVIParams(double strike, double maturity, double spot)
        {
            Strike = strike;
            Maturity = maturity;
            Spot = spot;
        }
    }
}
