using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Options;

namespace Pricing.OptionStrategies
{
    public class CondorSpread : OptionStrategy
    {
        public CondorSpread(double[] strikes, double maturity)
        {
            if (strikes.Length != 4)
            {
                throw new ArgumentException("Il faut 4 strikes pour composer un condor spread");
            }

            Array.Sort(strikes);
            AddOption(new CallOption(strikes[0], maturity), 1);
            AddOption(new CallOption(strikes[1], maturity), -1);
            AddOption(new CallOption(strikes[2], maturity), -1);
            AddOption(new CallOption(strikes[3], maturity), -1);
        }
    }
}
