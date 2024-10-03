using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Volatility.Parameters
{
    public interface IVolatilityParams
    {
        //Basis class to be overloaded by specific volatility model parameters, provide a single way to provide params into GetVolatility method for every vol models
    }
}
