using Pricing.MonteCarlo;
using Pricing;
using Pricing.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Products.Autocalls;

namespace InterfaceExcel
{
    /// <summary>
    /// Generic architecture for structured product pricing job
    /// </summary>
    internal class PricingJob
    {
        public Int16 JobNumber { get; set; }

        public string ProductType { get; set; }
        public double Maturity { get; set; }
        public char ObsFrequency { get; set; }

        public double BarrierCapital { get; set; }
        public double BarrierCoupon { get; set; }
        public double BarrierCall { get; set; }

        public double Price { get; set; }
        public double PricingTime { get; set; }

        public PricingJob(Int16 number, string type, char obsfreq, double maturity, double barcapital, double barcoupon, double barcall)
        {
            JobNumber = number;
            ProductType = type;
            ObsFrequency = obsfreq;
            Maturity = maturity;
            BarrierCapital = barcapital;
            BarrierCoupon = barcoupon;
            BarrierCall = barcall;
        }

        /// <summary>
        /// Parse the information about observation frequency and type of product and returns the right type of Autocall product
        /// </summary>
        private Autocall ParseAutocall()
        {
            string selectedProduct = ProductType;
            char freqObservationText = ObsFrequency;

            Autocall autocall;
            double freqObservation = 1;

            switch (freqObservationText)
            {
                case 'A':
                    freqObservation = 1;
                    break;
                case 'S':
                    freqObservation = 2;
                    break;
                case 'T':
                    freqObservation = 4;
                    break;
                case 'M':
                    freqObservation = 12;
                    break;
            }
            autocall = selectedProduct switch
            {
                "Phoenix" => new AutocallPhoenix(Maturity, freqObservation, BarrierCoupon, BarrierCall, BarrierCapital),
                "Athena" => new AutocallAthena(Maturity, freqObservation, BarrierCoupon, BarrierCall, BarrierCapital),
                _ => throw new ArgumentException("Option non reconnue")
            };

            return autocall;
        }

        /// <summary>
        /// Calls the Pricer project with a market and a autocall object an price the job
        /// </summary>
        public void PriceJob()
        {
            Market market = new Market(5.0, 20.0, 100.0);   //Just for the example, need a reel market declaration
            var autocall = ParseAutocall();
            MonteCarloSimulator mc = new MonteCarloSimulator(autocall, market);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            Price = mc.FindCouponAutocall();
            watch.Stop();
            PricingTime = Math.Round(watch.ElapsedMilliseconds / 1000.0, 3);
        }
    }
}
