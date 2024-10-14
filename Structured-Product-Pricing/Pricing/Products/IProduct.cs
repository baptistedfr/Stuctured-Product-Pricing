using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products
{
    public interface IProduct
    {
        /// <summary>
        ///  Calculate the payoff of the product
        /// </summary>
        double Payoff(double spot);

        /// <summary>
        ///  Get the maturity of the product
        /// </summary>
        double GetMaturity();

        /// <summary>
        /// Calculate the SVI Vol of the product depending of the market
        /// </summary>
        double CalculateVolSVI(Market market);
    }
}
