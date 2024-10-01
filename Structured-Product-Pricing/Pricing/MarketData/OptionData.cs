using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.MarketData
{
    internal class OptionData
    {
        public double Strike { get; set; }
        public double ImpliedVolatility { get; set; }
        public double Maturity { get; set; }
        public double Volume { get; set; }
    }
}
