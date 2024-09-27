using Pricing.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.OptionStrategies
{
    public class Strap : OptionStrategy
    {
        public Strap(double strike, double maturity)
        {
            AddOption(new PutOption(strike, maturity), 1);
            AddOption(new CallOption(strike, maturity), 2);
        }

    }
}
