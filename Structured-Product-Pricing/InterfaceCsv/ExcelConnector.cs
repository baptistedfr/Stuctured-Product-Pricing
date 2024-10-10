using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Net.Mime.MediaTypeNames;

namespace InterfaceExcel
{
    internal class ExcelConnector
    {   
        private Excel.Application Application;
        private Workbook Workbook { get; set; }
        private Worksheet InputSheet { get; set; }
        private Worksheet OutputSheet { get; set; }

        public ExcelConnector(string excelFilePath)
        {
            Application = new Excel.Application();
            Workbook = Application.Workbooks.Open(excelFilePath);
            InputSheet = (Worksheet)Workbook.Sheets["Inputs"];
            OutputSheet = (Worksheet)Workbook.Sheets["Outputs"];
            Application.Visible = true;
        }

        /// <summary>
        /// Parse the excel input sheet and convert it to pricing jobs
        /// </summary>
        public List<PricingJob> GetInput()
        {
            List<PricingJob> pricingJobs = new List<PricingJob>();

            int startRow = 2;
            int currentRow = startRow;

            while (InputSheet.Cells[currentRow, 1].Value != null)
            {
                var jobNumber = Convert.ToInt16(InputSheet.Cells[currentRow, 1].Value);
                var productType = InputSheet.Cells[currentRow, 2].Value.ToString();
                var maturity = Convert.ToDouble(InputSheet.Cells[currentRow, 3].Value);
                var barrierCapital = Convert.ToDouble(InputSheet.Cells[currentRow, 4].Value);
                var barrierCoupon = Convert.ToDouble(InputSheet.Cells[currentRow, 5].Value);
                var barrierCall = Convert.ToDouble(InputSheet.Cells[currentRow, 6].Value);
                var obsFrequency = Convert.ToChar(InputSheet.Cells[currentRow, 7].Value.ToString());

                PricingJob job = new PricingJob(jobNumber, productType, obsFrequency, maturity, barrierCapital, barrierCoupon, barrierCall);
                pricingJobs.Add(job);

                currentRow++;
            }
            return pricingJobs;
        }

        /// <summary>
        /// Write in the output sheet of the excel file all the attributes of the pricing tasks
        /// </summary>
        public void WriteOutput(List<PricingJob> pricingJobs, string excelPath)
        {
            int startRow = 2;
            int currentRow = startRow;

            while (InputSheet.Cells[currentRow, 1].Value != null)
            {
                InputSheet.Cells[currentRow, 8].Value = pricingJobs[currentRow - 2].Price;
                InputSheet.Cells[currentRow, 9].Value = pricingJobs[currentRow - 2].PricingTime;
                currentRow++;
            }

            CloseAndSave(excelPath);
        }
        
        /// <summary>
        /// Save the excel workbook and close the program
        /// </summary>
        private void CloseAndSave(string oldPath)
        {
            try
            {
                string newFilePath = oldPath.Substring(0, oldPath.Length - 5) + "_Outputs.xlsx";
                Workbook.SaveAs(newFilePath);
                Workbook.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving : " + ex.Message);
            }
            finally
            {
                Application.Quit();
            }
        }
    }
}
