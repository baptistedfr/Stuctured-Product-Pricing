using Pricing;
using Pricing.Products;
using System.CodeDom;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace InterfaceProducts
{
    public partial class Interface : Form
    {
        private StrikeManager strikeManager;
        private OptionManager optionManager;
        public Interface()
        {

            InitializeComponent();
            strikeManager = new StrikeManager(new System.Windows.Forms.TextBox[] { textBoxStrike1, textBoxStrike2, textBoxStrike3, textBoxStrike4 },
                                          new Label[] { labelStrike1, labelStrike2, labelStrike3, labelStrike4 });
            optionManager = new OptionManager();

        }

        private void price_Click(object sender, EventArgs e)
        {

            if (!optionManager.CheckOptionSelected(comboBoxOptions.SelectedItem) ||
            !strikeManager.CheckVisibleStrikeValues() ||
            !strikeManager.CheckMaturityValues(textBoxMaturity.Text))
            {
                return;
            }

            string selectedOption = comboBoxOptions.SelectedItem.ToString();
            MessageBox.Show("Vous avez sélectionné : " + selectedOption);
            IDerives derive = optionManager.CreateDerive(selectedOption, strikeManager.GetStrikeValues(), textBoxMaturity.Text);
            
        }

        private void comboBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOptions.SelectedItem != null)
            {
                strikeManager.UpdateStrikeVisibility(comboBoxOptions.SelectedItem.ToString());
            }
        }


    }
}
