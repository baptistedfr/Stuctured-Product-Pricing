using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products
{
    public interface IDerives : IProduct
    {

        string Afficher();

        /// <summary>
        /// Calculate the derivative price with a close formula
        /// </summary>
        double CloseFormula(Market market);

        


    }
}
