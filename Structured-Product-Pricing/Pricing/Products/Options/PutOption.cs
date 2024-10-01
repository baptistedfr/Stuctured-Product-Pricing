using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Options
{
    public class PutOption : Option
    {
        public PutOption(double strike, double maturity) : base(strike, maturity)
        {
        }
        // Implémentation de la méthode Payoff pour une option Put
        public override double Payoff(double spot)
        {
            return Math.Max(Strike - spot, 0);
        }

        public override double CloseFormula(Market market)
        {
            double d1 = (Math.Log(market.Spot / Strike) + (market.Rate + Math.Pow(market.Volatility, 2) / 2.0) * Maturity) / (market.Volatility * Math.Sqrt(Maturity));
            double d2 = d1 - market.Volatility * Math.Sqrt(Maturity);

            double putPrice = Strike * Math.Exp(-market.Rate * Maturity) * Normal.CDF(0, 1, -d2) - market.Spot * Normal.CDF(0, 1, -d1);
            return putPrice;
        }
    }
}
