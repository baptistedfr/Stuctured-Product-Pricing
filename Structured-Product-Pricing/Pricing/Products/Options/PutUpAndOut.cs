using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Options
{
    public class PutUpAndOut : BarrierOption
    {
        public PutUpAndOut(double strike, double maturity, double barrier) : base(strike, maturity, barrier)
        {
        }
        public override double Payoff(double spot)
        {
            if (Activated == false) // Cas ou la barriere n'est pas franchi
            {
                return Math.Max(Strike - spot, 0);
            }
            else
            {
                Activated = false;
                return 0;
            }

        }

        public override bool BarrierOut(double spot)
        {
            if (spot >= Barrier)
            {
                Activated = true;
                return true; // La barriere est activé donc c'est la fin de l'option
            }
            return false;

        }
    }
}
