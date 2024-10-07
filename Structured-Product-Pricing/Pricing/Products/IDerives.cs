﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products
{
    public interface IDerives : IProduct
    {
        string Afficher();

        double CloseFormula(Market market);

        double CalculateVolSVI(Market market);


    }
}
