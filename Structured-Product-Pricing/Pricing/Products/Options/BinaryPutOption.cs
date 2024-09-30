using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Options
{
    public class BinaryPutOption : BinaryOption
    {
        public BinaryPutOption(double strike, double maturity, double coupon) : base(strike, maturity, coupon)
        {
        }
        public override double Payoff(double spot)
        {
            // Payoff d'un  binary put : 
            if (spot < Strike)
            {
                return coupon;
            }
            return 0;
        }
    }
}
