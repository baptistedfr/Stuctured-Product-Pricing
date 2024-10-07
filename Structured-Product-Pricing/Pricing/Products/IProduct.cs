using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products
{
    public interface IProduct
    {
        double Payoff(double spot);
        double GetMaturity();
        double CalculateVolSVI(Market market);
    }
}
