using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Options;

<<<<<<<< HEAD:Structured-Product-Pricing/Pricing/OptionStrategies/CallSpread.cs
namespace Pricing.OptionStrategies
========
namespace Pricing.Products
>>>>>>>> abcf84e17748316de47f213b6af1e3b67d07ed7d:Structured-Product-Pricing/Pricing/Products/CallSpread.cs
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
