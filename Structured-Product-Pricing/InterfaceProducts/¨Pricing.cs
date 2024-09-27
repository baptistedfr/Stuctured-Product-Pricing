using Pricing;
using Pricing.OptionStrategies;
using System.CodeDom;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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

            if (!CheckMarket() || !CheckOptions())
            {
                return; // Quitter la fonction si une vérification échoue
            }

            string selectedOption = comboBoxOptions.SelectedItem.ToString();
            MessageBox.Show("Vous avez sélectionné : " + selectedOption);
        }

        private bool CheckMarket()
        {
            if (!double.TryParse(textBoxVolatility.Text, out _) || !double.TryParse(textBoxSpot.Text, out _) || !double.TryParse(textBoxRf.Text, out _))
            {
                MessageBox.Show("Veuillez entrer une valeur numérique pour le spot, la volatilé et le taux sans risque !");
                textBoxVolatility.Clear(); // Efface le contenu incorrect
                textBoxSpot.Clear();
                textBoxRf.Clear();
                return false;
            }
            return true;
        }
        private bool CheckOptions()
        {
            try
            {
                if (comboBoxOptions.SelectedItem == null)
                {
                    throw new ArgumentNullException("Vous n'avez pas choisi de produit à pricer !");
                }

            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void comboBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOptions.SelectedItem != null)
            {
                // Récupérer la valeur sélectionnée
                string selectedOption = comboBoxOptions.SelectedItem.ToString();

                // Réinitialiser l'état de visibilité des TextBox
                ResetTextBoxVisibility();

                // Afficher les TextBox en fonction de l'option sélectionnée
                switch (selectedOption)
                {
                    case "Call Spread":
                    case "Put Spread":
                    case "Strange":
                        ShowTextBoxes(1, 2); // Afficher textBoxStrike1 et textBoxStrike2
                        break;

                    case "Butterfly Spread":
                        ShowTextBoxes(1, 2, 3); // Afficher textBoxStrike1, textBoxStrike2 et textBoxStrike3
                        break;

                    case "Condor Spread":
                        ShowTextBoxes(1, 2, 3, 4); // Afficher tous les TextBox
                        break;

                    default:
                        // Option par défaut, afficher uniquement textBoxStrike1
                        ShowTextBoxes(1);
                        break;
                }
            }
        }

        private void ResetTextBoxVisibility()
        {
            // Masquer toutes les TextBox
            textBoxStrike1.Visible = false;
            labelStrike1.Visible = false;
            textBoxStrike2.Visible = false;
            labelStrike2.Visible = false;
            textBoxStrike3.Visible = false;
            labelStrike3.Visible = false;
            textBoxStrike4.Visible = false;
            labelStrike4.Visible = false;
        }

        private void ShowTextBoxes(params int[] textBoxIndices)
        {
            // Afficher les TextBox spécifiées
            foreach (int index in textBoxIndices)
            {
                switch (index)
                {
                    case 1:
                        textBoxStrike1.Visible = true;
                        labelStrike1.Visible = true;
                        break;
                    case 2:
                        textBoxStrike2.Visible = true;
                        labelStrike2.Visible = true;
                        break;
                    case 3:
                        textBoxStrike3.Visible = true;
                        labelStrike3.Visible = true;
                        break;
                    case 4:
                        textBoxStrike4.Visible = true;
                        labelStrike4.Visible = true;
                        break;
                }
            }
        }
    }
}
