using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using static System.Net.Mime.MediaTypeNames;

namespace InterfaceExcel
{
    internal class ExcelConnector
    {   
        private Excel.Application Application;
        private Excel.Workbook Workbook { get; set; }
        private Excel.Worksheet InputSheet { get; set; }
        private Excel.Worksheet OutputSheet { get; set; }

        public ExcelConnector(string excelFilePath)
        {
            Application = new Excel.Application();
            Workbook = Application.Workbooks.Open(excelFilePath);
            InputSheet = (Worksheet)Workbook.Sheets["Inputs"];
            OutputSheet = (Worksheet)Workbook.Sheets["Outputs"];
            Application.Visible = true;
        }
        public void WriteOutput(List<PricingJob> pricingJobs, string pathFile)
        {
            int currentColumn = 1;

            foreach (var job in pricingJobs)
            {
                int currentRow = 1;
                Type type = job.GetType();
                foreach (PropertyInfo prop in type.GetProperties())
                {
                    OutputSheet.Cells[currentRow, currentColumn].Value = prop.Name.ToString();
                    OutputSheet.Cells[currentRow, currentColumn+1].Value = prop.GetValue(job).ToString();

                    currentRow++;
                }

                currentColumn += 3;
            }
            //PrintExcel();
            CloseAndSave(pathFile);
        }

        public void PrintExcel()
        {
            for(int i=1; i<10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    var contenu = OutputSheet.Cells[i, j].Value;
                    if (contenu is not null) Console.WriteLine(contenu);
                }
            }
        }

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
