using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
