using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:Structured-Product-Pricing/Pricing/Options/PutOption.cs
namespace Pricing.Options
========
namespace Pricing.Products
>>>>>>>> abcf84e17748316de47f213b6af1e3b67d07ed7d:Structured-Product-Pricing/Pricing/Products/PutOption.cs
{
    public class PutOption : Option
    {
        public PutOption(double strike, double maturity) : base(strike, maturity)
        {
        }
        // Implémentation de la méthode Payoff pour une option Put
        public override double Payoff(double spot)
        {
            return Math.Max(Strike - spot, 0);
        }
    }
}
