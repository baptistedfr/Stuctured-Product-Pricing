using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing
{
    public interface IDerives
    {
        double Payoff(double spot);

        string Afficher();
    }
}
