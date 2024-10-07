using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExcel
{
    internal class PricingJob
    {
        public Int16 JobNumber { get; set; }
        public string ProductType { get; set; }
        public double Price { get; set; }
        public double PricingTime { get; set; }

        public PricingJob(Int16 number, string type, double price, double pricingtime)
        {
            JobNumber = number;
            ProductType = type;
            Price = price;
            PricingTime = pricingtime;
        }
    }
}
