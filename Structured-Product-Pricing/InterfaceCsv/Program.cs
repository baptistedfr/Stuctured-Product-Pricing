using InterfaceExcel;
using Pricing;
using Pricing.MonteCarlo;
using Pricing.Products;

namespace InterfaceCsv
{
    internal class Program
    {   
        /// <summary>
        /// Get the complete and relative path to the Excel file
        /// </summary>
        private static string GetExcelPath(string fileName)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string solutionRoot = Directory.GetParent(currentDir).Parent.Parent.Parent.Parent.Parent.FullName;
            return Path.Combine(solutionRoot, fileName);
        }

       
        static void Main(string[] args)
        {
            string fileName = GetExcelPath("PricingWithExcel.xlsx");
            ExcelConnector excel = new ExcelConnector(fileName);

            List<PricingJob> jobList = excel.GetInput();
            foreach (PricingJob job in jobList)
            {
                job.PriceJob();
            }
            excel.WriteOutput(jobList, fileName);
        }
    }
}
