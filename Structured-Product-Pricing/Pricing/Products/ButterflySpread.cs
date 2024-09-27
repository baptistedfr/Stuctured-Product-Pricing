using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products
{
    public class ButterflySpread : OptionStrategy
    {
        public ButterflySpread(double[] strikes, double maturity)
        {
            if (strikes.Length != 3)
            {
                throw new ArgumentException("Il faut 3 strikes différents pour composer un butterfly spread.");
            }

            Array.Sort(strikes);
            AddOption(new CallOption(strikes[0], maturity), 1);
            AddOption(new CallOption(strikes[1], maturity), -2);
            AddOption(new CallOption(strikes[2], maturity), 1);
        }
    }
}
