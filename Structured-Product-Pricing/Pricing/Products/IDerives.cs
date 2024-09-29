using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products
{
    public interface IDerives
    {
        double Payoff(double spot);

        string Afficher();

        double GetMaturity();
    }
}
