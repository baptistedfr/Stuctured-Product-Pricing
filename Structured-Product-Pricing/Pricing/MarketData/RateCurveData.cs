using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.MarketData
{
    /// <summary>
    /// Generic structure for yield curve data
    /// </summary>
    public class RateCurveData
    {
        public double Maturity { get; set; }
        public double Rate { get; set; }
    }
}
