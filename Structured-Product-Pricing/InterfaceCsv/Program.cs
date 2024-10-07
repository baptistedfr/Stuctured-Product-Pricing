using InterfaceExcel;

namespace InterfaceCsv
{
    internal class Program
    {
        public static string GetExcelPath(string fileName)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string solutionRoot = Directory.GetParent(currentDir).Parent.Parent.Parent.Parent.Parent.FullName;
            return Path.Combine(solutionRoot, fileName);
        }
        static void Main(string[] args)
        {
            string fileName = GetExcelPath("PricingWithExcel.xlsx");
            ExcelConnector excel = new ExcelConnector(fileName);

            PricingJob job1 = new PricingJob(1, "Athena", 5.05, 0.3);
            PricingJob job2 = new PricingJob(2, "Phoenix", 10.2, 1.2);
            List<PricingJob> jbList = new List<PricingJob> { job1, job2 };

            excel.WriteOutput(jbList, fileName);
            Console.WriteLine("end");
        }
    }
}
