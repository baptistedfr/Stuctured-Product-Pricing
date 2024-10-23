using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProducts
{
    // Classe pour gérer la logique des strikes
    public class ParamsManager
    {
        private TextBox[] strikeTextBoxes;
        private Label[] strikeLabels;
        private TextBox maturityTextBox;
        private TextBox couponTextBox;
        private Label binaryLabel;
        private TextBox barrierTextBox;
        private Label barrierLabel;
        private TextBox[] autocallBarriersTextbox;
        private Label[] autocallBarriersLabel;
        private ComboBox freqObservationComboBox;
        private Label freqObservationLabel;

        public ParamsManager(TextBox[] textBoxes, Label[] labels, TextBox maturity, TextBox binary, Label binaryLabel, TextBox barrier, Label barrierLabel, TextBox[] autocallBarriersTextbox, Label[] autocallBarriersLabel, ComboBox freqObservationComboBox, Label freqObservationLabel)
        {
            this.strikeTextBoxes = textBoxes;
            this.strikeLabels = labels;
            this.maturityTextBox = maturity;
            this.couponTextBox = binary;
            this.binaryLabel = binaryLabel;
            this.barrierTextBox = barrier;
            this.barrierLabel = barrierLabel;
            this.autocallBarriersTextbox = autocallBarriersTextbox;
            this.autocallBarriersLabel = autocallBarriersLabel;
            this.freqObservationComboBox = freqObservationComboBox;
            this.freqObservationLabel = freqObservationLabel;
        }
        /// <summary>
        /// On update la visibilité des paramètres des strikes selin le produit
        /// </summary>
        public void UpdateStrikeVisibility(string selectedOption)
        {
            HideAllStrikes();
            int count = selectedOption switch
            {
                "Call Spread" => 2,
                "Put Spread" => 2,
                "Strangle" => 2,
                "Butterfly Spread" => 3,
                "Condor Spread" => 4,
                "Autocall Phoenix" => 0,
                "Autocall Athena" => 0,
                _ => 1
            };
            ShowStrikes(count);
        }
        /// <summary>
        /// On réinitialise la visibilité des strikes
        /// </summary>
        private void HideAllStrikes()
        {
            foreach (var tb in strikeTextBoxes) tb.Visible = false;
            foreach (var label in strikeLabels) label.Visible = false;
        }
        /// <summary>
        /// Affichage des strikes selon le produit
        /// </summary>
        private void ShowStrikes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                strikeTextBoxes[i].Visible = true;
                strikeLabels[i].Visible = true;
            }
        }
        /// <summary>
        /// Affichage du coupon si une option binaire est sélectionner
        /// </summary>
        public void UpdateBinary(string selectedOption)
        {
            bool isBinaryOption = selectedOption == "Binary Call" || selectedOption == "Binary Put";
            couponTextBox.Visible = isBinaryOption || selectedOption.Contains("Autocall");
            binaryLabel.Visible = couponTextBox.Visible;

            if (isBinaryOption)
            {
                couponTextBox.Enabled = true;
                couponTextBox.Text = "";
            }
            else if (selectedOption.Contains("Autocall"))
            {
                couponTextBox.Enabled = false;
                couponTextBox.Text = "";
            }
            else
            {
                couponTextBox.Visible = false;
                binaryLabel.Visible = false;
            }
        }
        /// <summary>
        /// On update la visibilité des barrières selon le produit
        /// </summary>
        public void UpdateBarrier(string selectedOption, bool isAutocall)
        {
            bool isBarrierOption = (selectedOption.Contains("Up") || selectedOption.Contains("Down"));
            if (isBarrierOption)
            {
                barrierLabel.Text = "Barriere";
                barrierLabel.Location = new Point(371, 193); // On remet bien la position
                barrierTextBox.Visible = isBarrierOption;
                barrierLabel.Visible = isBarrierOption;
                for (int i = 1; i < 3; i++)
                {
                    autocallBarriersTextbox[i].Visible = isAutocall;
                    autocallBarriersLabel[i].Visible = isAutocall;
                }
            }
            else
            {
                autocallBarriersLabel[0].Text = "Barrière Rappel";
                barrierLabel.Location = new Point(343, 193); // On change la position 
                for (int i = 0; i < 3; i++)
                {
                    autocallBarriersTextbox[i].Visible = isAutocall;
                    autocallBarriersLabel[i].Visible = isAutocall;
                }
                freqObservationComboBox.Visible = isAutocall;
                freqObservationLabel.Visible = isAutocall;
            } 
        }
        /// <summary>
        /// Récupération de la valeur des strikes lorsqu'ils sont visibles
        /// </summary>
        public List<double> GetStrikeValues()
        {
            List<double> strikeValues = new List<double>();
            foreach (var textBox in strikeTextBoxes.Where(tb => tb.Visible))
            {
                if (double.TryParse(textBox.Text, out double value) && value > 0)
                {
                    strikeValues.Add(value);
                }
            }
            return strikeValues;
        }
        /// <summary>
        /// Vérification si les strikes ont une valeur positive pour ceux devant être sélectionnés
        /// </summary>
        public bool CheckVisibleStrikeValues()
        {
            foreach (var textBox in strikeTextBoxes.Where(tb => tb.Visible))
            {
                if (!double.TryParse(textBox.Text, out double value) || value <= 0)
                {
                    MessageBox.Show($"Veuillez entrer une valeur positive valide pour {textBox.Name.Replace("textBox", "")}.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Focus();
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Vérification de la maturité
        /// </summary>
        public bool CheckMaturityValues()
        {
            if (!double.TryParse(maturityTextBox.Text, out double value) || value <= 0)
            {
                MessageBox.Show($"Veuillez entrer une valeur positive valide pour la maturité.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Vérification de la sélection du coupon
        /// </summary>
        public bool CheckBinary()
        {
            if (couponTextBox.Visible == true && (!double.TryParse(couponTextBox.Text, out double value) || value <= 0) && couponTextBox.Enabled)
            {
                MessageBox.Show($"Veuillez entrer une valeur positive valide pour le coupon de l'option binaire.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Vérification de la sélection des barrières
        /// </summary>
        public bool CheckBarrier()
        {
            foreach (var barrier in autocallBarriersTextbox.Where(tb => tb.Visible))
            {
                if (!double.TryParse(barrier.Text, out double value) || value <= 0)
                {
                    MessageBox.Show($"Veuillez entrer une valeur positive valide pour {barrier.Name.Replace("textBox", "")}.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    barrier.Focus();
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Vérification des paramètres de l'autocall
        /// </summary>
        public bool CheckAutocall()
        {
            if (freqObservationComboBox.Visible)
            {
                if (freqObservationComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner une fréquence d'observation.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                string selectedFrequency = freqObservationComboBox.SelectedItem.ToString();

                if (selectedFrequency != "Annuelle" && selectedFrequency != "Semestrielle" && selectedFrequency != "Trimestrielle" && selectedFrequency != "Mensuelle")
                {
                    MessageBox.Show($"Veuillez sélectionner une fréquence d'observation valide (Annuelle, Trimestrielle, ou Mensuelle).", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true; 
        }
    }
}
