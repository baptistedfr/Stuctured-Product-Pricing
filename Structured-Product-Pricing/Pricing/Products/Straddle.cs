using System;
using Pricing.Options;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:Structured-Product-Pricing/Pricing/OptionStrategies/Straddle.cs
namespace Pricing.OptionStrategies
========
namespace Pricing.Products
>>>>>>>> abcf84e17748316de47f213b6af1e3b67d07ed7d:Structured-Product-Pricing/Pricing/Products/Straddle.cs
{
    /// <summary>
    /// Un straddle est une stratégie qui consiste à acheter un call et un put de même strike et même maturité
    /// </summary>
    public class Straddle : OptionStrategy
    {

        public Straddle(double strike, double maturity)
        {
            AddOption(new PutOption(strike, maturity), 1);
            AddOption(new CallOption(strike, maturity), 1);

        }
    }
}
