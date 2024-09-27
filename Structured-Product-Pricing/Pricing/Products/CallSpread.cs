using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products
{
    public class CallSpread : OptionStrategy
    {
        public CallSpread(double lowerStrike, double upperStrike, double maturity)
        {
            AddOption(new CallOption(lowerStrike, maturity), 1);
            AddOption(new CallOption(upperStrike, maturity), -1);

        }
    }
}
