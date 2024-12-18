﻿using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Options
{
    public class BinaryPutOption : BinaryOption
    {
        public BinaryPutOption(double strike, double maturity, double coupon) : base(strike, maturity, coupon)
        {
        }
        public override double Payoff(double spot)
        {
            // Payoff d'un  binary put : 
            if (spot < Strike)
            {
                return coupon;
            }
            return 0;
        }

        public override double CloseFormula(Market market)
        {
            double d1 = (Math.Log(market.Spot / Strike) + (market.Rate + Math.Pow(market.Volatility, 2) / 2.0) * Maturity) / (market.Volatility * Math.Sqrt(Maturity));
            double d2 = d1 - market.Volatility * Math.Sqrt(Maturity);
            double binaryPutPrice = Coupon * Math.Exp(-market.Rate * Maturity) * Normal.CDF(0, 1, -d2);
            return binaryPutPrice;
        }
    }
}
