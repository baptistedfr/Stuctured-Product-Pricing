using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Options
{
    public class CallUpAndIn : BarrierOption
    {
        public CallUpAndIn(double strike, double maturity, double barrier) : base(strike, maturity, barrier)
        {
        }
        public override double Payoff(double spot)
        {
            if (Activated)
            {
                Activated = false; // On desactive l'option
                return Math.Max(spot - Strike, 0);
            }
            else
            {
                return 0;
            }

        }

        public override bool BarrierOut(double spot)
        {
            if (spot >= Barrier)
            {
                Activated = true;
            }
            return false; // La barrière ne désactive pas, mais active l'option
        }
    }
}
