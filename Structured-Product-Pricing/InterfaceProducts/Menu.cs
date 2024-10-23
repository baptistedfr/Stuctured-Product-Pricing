using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceProducts
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonPricing_Click(object sender, EventArgs e)
        {
            // Check if the form is already open to avoid multiple instances
            if (Application.OpenForms["Interface"] == null)
            {
                Interface pricingForm = new Interface();
                pricingForm.Show(); // Use Show() instead of Run()
            }
            else
            {
                Application.OpenForms["Interface"].Activate(); // Bring existing form to front
            }
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            // Similar approach for the Excel form
            if (Application.OpenForms["InteropExcel"] == null)
            {
                InteropExcel excelForm = new InteropExcel();
                excelForm.Show(); // Use Show() instead of Run()
            }
            else
            {
                Application.OpenForms["InteropExcel"].Activate(); // Bring existing form to front
            }
        }
    }
}
