using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:Structured-Product-Pricing/Pricing/Options/CallOption.cs
namespace Pricing.Options
========
namespace Pricing.Products
>>>>>>>> abcf84e17748316de47f213b6af1e3b67d07ed7d:Structured-Product-Pricing/Pricing/Products/CallOption.cs
{
    public class CallOption : Option
    {

        public CallOption(double strike, double maturity) : base(strike, maturity)
        {
        }
        // Implémentation de la méthode Payoff pour une option Call
        public override double Payoff(double spot)
        {
            // Payoff d'un call : max(spot - strike, 0)
            return Math.Max(spot - Strike, 0);
        }
    }
}
