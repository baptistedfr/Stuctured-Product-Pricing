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
        private TextBox maturity;
        private TextBox binary;
        private Label binaryLabel;
        private TextBox barrier;
        private Label barrierLabel;
        public ParamsManager(TextBox[] textBoxes, Label[] labels, TextBox maturity, TextBox binary, Label binaryLabel, TextBox barrier, Label barrierLabel)
        {
            this.strikeTextBoxes = textBoxes;
            this.strikeLabels = labels;
            this.maturity = maturity;
            this.binary = binary;
            this.binaryLabel = binaryLabel;
            this.barrier = barrier;
            this.barrierLabel = barrierLabel;
        }

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
        public void UpdateBinary(string selectedOption)
        {
            if (selectedOption == "Binary Call" || selectedOption == "Binary Put")
            {
                binary.Visible = true;
                binaryLabel.Visible = true;
            }
            else
            {
                binary.Visible = false;
                binaryLabel.Visible = false;
            }
        }
        public void UpdateBarrier(string selectedOption)
        {
            bool isBarrierOption = (selectedOption.Contains("Up") || selectedOption.Contains("Down"));
            barrier.Visible = isBarrierOption;
            barrierLabel.Visible = isBarrierOption;
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

        public bool CheckMaturityValues()
        {
            if (!double.TryParse(maturity.Text, out double value) || value <= 0)
            {
                MessageBox.Show($"Veuillez entrer une valeur positive valide pour la maturité.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool CheckBinary()
        {
            if (binary.Visible == true && (!double.TryParse(binary.Text, out double value) || value <= 0))
            {
                MessageBox.Show($"Veuillez entrer une valeur positive valide pour le coupon de l'option binaire.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool CheckBarrier()
        {
            if (barrier.Visible == true && (!double.TryParse(barrier.Text, out double value) || value <= 0))
            {
                MessageBox.Show($"Veuillez entrer une valeur positive valide pour le niveau de la barrière.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
