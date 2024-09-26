using System.Windows.Forms;
namespace InterfaceProducts
{
    public partial class Pricing : Form
    {
        public Pricing()
        {
            InitializeComponent();
        }

        private void price_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ceci est un message de Windows Forms 2");
        }
    }
}
