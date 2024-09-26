using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing
{
    public abstract class Option:IDerives
    {
        // Champs communs
        protected double strike;
        protected double maturity;

        // Propriétés communes
        public double Strike
        {
            get { return strike; }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException("Le strike doit être un nombre positif.");
                strike = value;
            }
        }

        public double Maturity
        {
            get { return maturity; }
            protected set  
            {
                if (value < 0)
                    throw new ArgumentException("La maturité ne peut pas être négative.");
                maturity = value;
            }
        }

        // Constructeur
        public Option(double strike, double maturity)
        {
            this.Strike = strike;
            this.Maturity = maturity;
        }

        // Méthodes communes
        public abstract double Payoff(double spot);

        // Méthode virtuelle pouvant être redéfinie
        public virtual void Afficher()
        {
            Console.WriteLine($"Cette option a un strike de {this.Strike} et une maturité de {this.Maturity}");
        }


    }
}
