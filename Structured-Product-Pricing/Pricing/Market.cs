using Pricing.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing
{
    public enum VolatilityType
    {
        Cste,
        SVI
    }

    public class Market
    {
        private string Ticker;
        private VolatilityType volType;
        private double spot;
        private double volatility;
        private double rate;
        private double dividende;

        public double Spot
        {
            get { return spot; }
            set { spot = value; }
        }

        public VolatilityType VolType
        {
            get { return volType; }
            set { volType = value; }

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

        public Market(string ticker, VolatilityType volType)
        {
            this.Ticker = ticker;
        }

        public void AfficherMarket()
        {
            Console.WriteLine($"Spot : {this.spot}, Volatility : {this.volatility} Rate : {this.rate}");
        }

        public double CalibrateVol()
        {
            Console.WriteLine("To Do");
            return 0.0;
        }
        public void Initialize()
        {
            this.Spot = YahooFinance.GetLastSpot(this.Ticker);
            this.Volatility = CalibrateVol();
        }
    }
}
