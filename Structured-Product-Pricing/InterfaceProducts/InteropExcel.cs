using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfaceExcel;
namespace InterfaceProducts
{
    public partial class InteropExcel : Form
    {
        public InteropExcel()
        {
            InitializeComponent();
        }
        private static string GetExcelPath(string fileName)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string solutionRoot = Directory.GetParent(currentDir).Parent.Parent.Parent.Parent.Parent.FullName;
            return Path.Combine(solutionRoot, fileName);
        }
        private void radioButtonFile_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFile.Checked)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Fichiers Excel (*.xlsx)|*.xlsx|Tous les fichiers (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    MessageBox.Show("Fichier sélectionné : " + selectedFilePath);
                    labelFile.Text = selectedFilePath;
                }
            }
            else
            {
                labelFile.Text = GetExcelPath("PricingWithExcel.xlsx");
            }

        }

        private void radioButtonDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDefault.Checked)
            {

                labelFile.Text = GetExcelPath("PricingWithExcel.xlsx");
            }
        }

        private void buttonPrice_Click(object sender, EventArgs e)
        {
            if (!radioButtonDefault.Checked && !radioButtonFile.Checked)
            {
                return;
            }
            MessageBox.Show(labelFile.Text);
            try
            {
                ExcelConnector excel = new ExcelConnector(labelFile.Text);
   
                List<PricingJob> jobList = excel.GetInput();
                foreach (PricingJob job in jobList)
                {
                    job.PriceJob();
                }
                excel.WriteOutput(jobList, labelFile.Text);
            }
            catch
            {
                MessageBox.Show($"Veuillez selectionner un fichier avec une structure valide !", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


    }
}

