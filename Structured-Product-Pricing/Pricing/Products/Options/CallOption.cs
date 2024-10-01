using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Options
{
    public class CallOption : Option
    {

        public CallOption(double strike, double maturity) : base(strike, maturity)
        {
        }
        // Implémentation de la méthode Payoff pour une option Call
        public override double Payoff(double spot)
        {
            // Payoff d'un call : max(spot - strike, 0)
            return Math.Max(spot - Strike, 0);
        }
        public override double CloseFormula(Market market)
        {
            double d1 = (Math.Log(market.Spot / Strike) + (market.Rate + Math.Pow(market.Volatility, 2) / 2.0) * Maturity) / (market.Volatility * Math.Sqrt(Maturity));
            double d2 = d1 - market.Volatility * Math.Sqrt(Maturity);

            double callPrice = market.Spot * Normal.CDF(0, 1, d1) - Strike * Math.Exp(-market.Rate * Maturity) * Normal.CDF(0, 1, d2);
            return callPrice;
        }
    }
}
