using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Autocalls
{
    public class AutocallAthena : Autocall
    {
        public AutocallAthena(double maturity, double freqObservation, double barrierCoupon, double barrierRappel, double barrierCapital) : base(maturity, freqObservation, barrierCoupon, barrierRappel, barrierCapital)
        {
        }

        public override double PayoffPath(double[] path, double rf)
        {
            double totalCoupon = 0.0;
            double dt = Maturity / path.Length;
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] >= BarrierRappel)
                {
                    double timeToMaturity = Maturity - i * dt; // Temps restant jusqu'à maturité
                    double reinvestedAmount = (totalCoupon + Coupon + Nominal) * Math.Exp(rf * timeToMaturity); // Réinvestissement au taux sans risque
                    return reinvestedAmount; // On retourne la valeur réinvestie jusqu'à maturité
                }
                if (path[i] >= BarrierCoupon)
                {
                    totalCoupon += Coupon;
                }
            }
            double finalPrice = path[path.Length - 1];

            double payoff = 0;
            if (finalPrice >= BarrierCapital)
            {
                payoff = Nominal;
            }
            else
            {
                payoff = Nominal * (finalPrice / Nominal);
            }
            return payoff;
        }
    }
}
