using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products
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
