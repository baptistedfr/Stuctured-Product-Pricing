using System;
using Pricing.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:Structured-Product-Pricing/Pricing/OptionStrategies/PutSpread.cs
namespace Pricing.OptionStrategies
========
namespace Pricing.Products
>>>>>>>> abcf84e17748316de47f213b6af1e3b67d07ed7d:Structured-Product-Pricing/Pricing/Products/PutSpread.cs
{
    public class PutSpread : OptionStrategy
    {
        public PutSpread(double lowerStrike, double upperStrike, double maturity)
        {
            AddOption(new PutOption(lowerStrike, maturity), -1);
            AddOption(new PutOption(upperStrike, maturity), 1);
        }
    }
}
