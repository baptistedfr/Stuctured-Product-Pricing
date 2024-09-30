using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Products.Options;

namespace Pricing.Products.Strategies
{
    public class Strangle : OptionStrategy
    {
        public Strangle(double lowerStrike, double upperStrike, double maturity)
        {
            AddOption(new PutOption(lowerStrike, maturity), 1);
            AddOption(new CallOption(upperStrike, maturity), 1);

        }
    }
}
