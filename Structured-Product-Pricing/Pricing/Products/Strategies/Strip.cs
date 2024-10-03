using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Products.Options;
namespace Pricing.Products.Strategies
{
    public class Strip : OptionStrategy
    {
        public Strip(double strike, double maturity)
        {
            AddOption(new PutOption(strike, maturity), 2);
            AddOption(new CallOption(strike, maturity), 1);
        }

    }
}
