using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products

{
    /// <summary>
    /// Un straddle est une stratégie qui consiste à acheter un call et un put de même strike et même maturité
    /// </summary>
    public class Straddle : OptionStrategy
    {

        public Straddle(double strike, double maturity)
        {
            AddOption(new PutOption(strike, maturity), 1);
            AddOption(new CallOption(strike, maturity), 1);

        }
    }
}
