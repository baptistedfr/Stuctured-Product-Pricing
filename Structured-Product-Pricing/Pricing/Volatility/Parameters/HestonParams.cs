using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Volatility.Parameters
{
    public class HestonParams : IVolatilityParams
    {
        public double PreviousVariance { get; set; }
        public double BrownianMotion { get; set; }
        public double Dt { get; set; }

        public HestonParams(double previousVariance, double dt, double brownianMotion)
        {
            PreviousVariance = previousVariance;
            BrownianMotion = brownianMotion;
            Dt = dt;
        }
    }
}
