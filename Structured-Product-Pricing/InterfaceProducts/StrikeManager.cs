using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProducts
{
    // Classe pour gérer la logique des strikes
    public class StrikeManager
    {
        private TextBox[] strikeTextBoxes;
        private Label[] strikeLabels;

        public StrikeManager(TextBox[] textBoxes, Label[] labels)
        {
            strikeTextBoxes = textBoxes;
            strikeLabels = labels;
        }

        public void UpdateStrikeVisibility(string selectedOption)
        {
            HideAllStrikes();
            int count = selectedOption switch
            {
                "Call Spread" => 2,
                "Put Spread" => 2,
                "Strange" => 2,
                "Butterfly Spread" => 3,
                "Condor Spread" => 4,
                _ => 1
            };
            ShowStrikes(count);
        }

        private void HideAllStrikes()
        {
            foreach (var tb in strikeTextBoxes) tb.Visible = false;
            foreach (var label in strikeLabels) label.Visible = false;
        }

        private void ShowStrikes(int count)
        {
            for (int i = 0; i < count; i++)
            {
                strikeTextBoxes[i].Visible = true;
                strikeLabels[i].Visible = true;
            }
        }

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

        public bool CheckMaturityValues(string maturityText)
        {
            if (!double.TryParse(maturityText, out double value) || value <= 0)
            {
                MessageBox.Show($"Veuillez entrer une valeur positive valide pour la maturité.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
