using Pricing.Volatility.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Autocalls
{
    public abstract class Autocall : IProduct
    {
        public double Maturity { get; private set; }

        public double FreqObservation { get; private set; }
        public double Coupon { get; set; }
        public double BarrierCoupon { get; private set; }
        public double BarrierRappel { get; private set; }
        public double BarrierCapital { get; private set; }

        public double Nominal { get; private set; }

        /// <summary>
        /// Autocall Constructor
        /// </summary>
        public Autocall(double maturity, double freqObservation, double barrierCoupon, double barrierRappel, double barrierCapital)
        {
            Maturity = maturity;
            FreqObservation = freqObservation;
            BarrierCoupon = barrierCoupon;
            BarrierRappel = barrierRappel;
            BarrierCapital = barrierCapital;
            Nominal = 100;
        }

        /// <summary>
        /// Fonction that send back the maturity of the autocall
        /// </summary>
        /// <returns></returns>
        public double GetMaturity()
        {
            return Maturity;
        }

        public abstract double PayoffPath(double[] paths, double rf);
        public double CalculateVolSVI(Market market)
        {
            return market.VolModel.GetVolatility(new SVIParams(Nominal, Maturity, market.Spot));
        }
        public virtual double Payoff(double spot)
        {
            return 0;
        }
    }
}
