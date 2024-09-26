using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing
{
    public class Market
    {
        // Champs
        private double spot;
        private double volatility;
        private double rate;
        private double dividende;

        // Propriétés
        public double Spot
        {
            get { return spot; }
            private set { spot = value; }
        }
        public double Volatility
        {
            get { return volatility; }
            private set { volatility = value; } // La vol ne peut être modifié que par les méthodes internes
        }
        public double Rate
        {
            get { return rate; }
            private set { rate = value; } // La vol ne peut être modifié que par les méthodes internes
        }
        public double Dividende
        {
            get { return dividende; }
            private set { dividende = value; } // La vol ne peut être modifié que par les méthodes internes
        }

        // Constructeur
        public Market(double spot, double volatility, double rate, double dividende = 0)
        {
            this.spot = spot;
            this.volatility = volatility;
            this.rate = rate;
            this.dividende = dividende;
        }

        // MéthodesS
        public void AfficherMarket()
        {
            Console.WriteLine($"Spot : {this.spot}, Volatility : {this.volatility} Rate : {this.rate}");
        }
    }
}
