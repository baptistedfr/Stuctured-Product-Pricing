using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Options
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
