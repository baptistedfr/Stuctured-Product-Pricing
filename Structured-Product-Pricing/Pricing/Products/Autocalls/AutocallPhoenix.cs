using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Autocalls
{
    public class AutocallPhoenix : Autocall
    {
        public AutocallPhoenix(double maturity, double freqObservation, double barrierCoupon, double barrierRappel, double barrierCapital) : base(maturity, freqObservation, barrierCoupon, barrierRappel, barrierCapital)
        {
        }

        public override double PayoffPath(double[] path, double rf)
        {
            double totalCoupon = 0.0;
            double dt = Maturity / path.Length;
            for (int i = 0; i < path.Length; i++)
            {
                double timeToMaturity = Maturity - i * dt; // Temps restant jusqu'à maturité double timeToMaturity = Maturity - i * dt; // Temps restant jusqu'à maturité
                if (path[i] >= BarrierRappel)
                {
                    double reinvestedAmount = (totalCoupon + Coupon + Nominal) * Math.Exp(rf * timeToMaturity); // Réinvestissement au taux sans risque
                    return reinvestedAmount; // On retourne la valeur réinvestie jusqu'à maturité
                }
                if (path[i] >= BarrierCoupon)
                {
                    //totalCoupon += Coupon;
                    totalCoupon += Coupon * Math.Exp(rf * timeToMaturity); // Pour le cas d un Phoenix le coupon est directement remboursé donc on considère que on l investit au taux sans risque
                }
            }
            double finalPrice = path[path.Length - 1];

            double payoff = 0;
            if (finalPrice >= BarrierCapital)
            {
                payoff = Nominal + totalCoupon;
            }
            else
            {
                payoff = totalCoupon + Nominal * (finalPrice / Nominal);
            }
            return payoff;
        }
    }
}
