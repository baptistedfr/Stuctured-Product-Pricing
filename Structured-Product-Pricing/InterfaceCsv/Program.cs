using InterfaceExcel;
using Pricing;
using Pricing.MonteCarlo;
using Pricing.Products;

namespace InterfaceCsv
{
    internal class Program
    {
        private static string GetExcelPath(string fileName)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string solutionRoot = Directory.GetParent(currentDir).Parent.Parent.Parent.Parent.Parent.FullName;
            return Path.Combine(solutionRoot, fileName);
        }

        private static Autocall GetAutocall(PricingJob job)
        {
            string selectedProduct = job.ProductType;
            char freqObservationText = job.ObsFrequency;

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
            autocall =  selectedProduct switch
            {
                "Autocall Phoenix" => new AutocallPhoenix(job.Maturity, freqObservation, job.BarrierCoupon, job.BarrierCall, job.BarrierCapital),
                "Autocall Athena" => new AutocallAthena(job.Maturity, freqObservation, job.BarrierCoupon, job.BarrierCall, job.BarrierCapital),
                _ => throw new ArgumentException("Option non reconnue")
            };

            return autocall;
        }
        private static void PriceJobs(List<PricingJob> jobListInput)
        {
            foreach (PricingJob job in jobListInput)
            {
                Market market = new Market(5.0, 20.0, 100.0);
                var autocall = GetAutocall(job);
                MonteCarloSimulator mc = new MonteCarloSimulator(autocall, market);

                var watch = System.Diagnostics.Stopwatch.StartNew();
                job.Price = mc.PriceStructu();
                watch.Stop();
                job.PricingTime = watch.ElapsedMilliseconds * 1000;
            }
        }

        static void Main(string[] args)
        {
            string fileName = GetExcelPath("PricingWithExcel.xlsx");
            ExcelConnector excel = new ExcelConnector(fileName);

            List<PricingJob> jobList = excel.GetInput();
            PriceJobs(jobList);
            excel.WriteOutput(jobList, fileName);

        }
    }
}
