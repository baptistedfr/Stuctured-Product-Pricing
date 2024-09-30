using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pricing.Products.Options
{
    public abstract class BinaryOption : Option
    {
        protected double coupon;

        // Propriétés communes
        public double Coupon
        {
            get { return coupon; }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException("Le coupon doit être un nombre positif.");
                coupon = value;
            }
        }

        public BinaryOption(double strike, double maturity, double coupon) : base(strike, maturity)
        {
            Coupon = coupon;
        }

        public override string Afficher()
        {
            return $"Cette option binaire a un strike de {Strike}, une maturité de {Maturity} et un coupon de {Coupon}";
        }

    }
}
