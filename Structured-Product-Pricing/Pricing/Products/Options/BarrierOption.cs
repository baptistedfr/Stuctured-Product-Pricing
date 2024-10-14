using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Products.Options
{
    public abstract class BarrierOption : Option
    {
        protected double barrier;
        protected bool activated;

        // Propriétés communes
        public double Barrier
        {
            get { return barrier; }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException("La barrière doit être un nombre positif.");
                barrier = value;
            }
        }
        public bool Activated
        {
            get { return activated; }
            set { activated = value; }
        }
        public BarrierOption(double strike, double maturity, double barrier) : base(strike, maturity)
        {
            Barrier = barrier;
            Activated = false;
        }
        public override double CloseFormula(Market market)
        {
            return 0;
        }

        public override string Afficher()
        {
            return $"Cette option à barrière a un strike de {Strike}, une maturité de {Maturity} et une barrière de {Barrier}";
        }

        /// <summary>
        /// Tells if the option is breached in case of Out Barrier Options
        /// </summary>
        public abstract bool BarrierOut(double value);
    }
}
