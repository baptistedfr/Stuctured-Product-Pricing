using Pricing.Volatility.Models;
using Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Volatility;

namespace InterfaceProducts
{
    public class MarketManager
    {
        private TextBox textBoxSpot;
        private TextBox textBoxVol;
        private TextBox textBoxRf;
        private RadioButton radioButtonAuto;
        private RadioButton radioButtonManual;
        private RadioButton radioButtonVolSto;
        private RadioButton radioButtonVolCste;
        public MarketManager(TextBox textBoxSpot, TextBox textBoxVol, TextBox textBoxRf, RadioButton radioButtonAuto, RadioButton radioButtonManual,
            RadioButton radioButtonVolSto, RadioButton radioButtonVolCste)
        {
            this.textBoxSpot = textBoxSpot;
            this.textBoxVol = textBoxVol;
            this.textBoxRf = textBoxRf;
            this.radioButtonAuto = radioButtonAuto;
            this.radioButtonManual = radioButtonManual;
            this.radioButtonVolSto = radioButtonVolSto;
            this.radioButtonVolCste = radioButtonVolCste;
        }

        public bool CheckRadioButton()
        {
            if ((!radioButtonAuto.Checked && !radioButtonManual.Checked) || (!radioButtonVolSto.Checked && !radioButtonVolCste.Checked))
            {
                MessageBox.Show($"Veuillez cocher un marché et une volatilité.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool CheckMarket()
        {
            TextBox[] textBoxes = { textBoxSpot, textBoxVol, textBoxRf };
            foreach (var element in textBoxes.Where(element => element.Enabled))
            {
                if (!double.TryParse(element.Text, out double value) || value <= 0)
                {
                    MessageBox.Show($"Veuillez entrer une valeur positive valide pour {element.Name.Replace("textBox", "")}.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    element.Focus();
                    return false;
                }
            }
            return true;
        }
        public Market CreateMarket()
        {
            double spot = Convert.ToDouble(textBoxSpot.Text);
            VolatilityType volType = radioButtonVolCste.Checked ? VolatilityType.Cste : VolatilityType.SVI;
            double vol = 0;
            if (volType == VolatilityType.Cste)
            {
                vol = Convert.ToDouble(textBoxVol.Text) / 100;
            }
            if (radioButtonAuto.Checked)
            {
                return new Market("AAPL", volType, vol, spot);
            }
            else
            {
                // Cas ou on cree son marche
                double rate = Convert.ToDouble(textBoxRf.Text) / 100;
                return new Market(rate, vol, spot);
            }
        }
        public void ActualiseMarket(Market market)
        {
            textBoxRf.Text = (Math.Round(market.Rate * 100, 2).ToString());
            textBoxVol.Text = (Math.Round(market.Volatility * 100, 2).ToString());
        }

        public void UpdateMarket()
        {
            if (radioButtonManual.Checked)
            {
                radioButtonVolSto.Enabled = false;
                radioButtonVolCste.Checked = true;
                radioButtonVolCste.Enabled = false;
                //textBoxSpot.Enabled = true;
                textBoxVol.Enabled = true;
                textBoxRf.Enabled = true;
            }
            if (radioButtonAuto.Checked)
            {
                radioButtonVolCste.Enabled = true;
                radioButtonVolSto.Enabled = true;
                //textBoxSpot.Text = "100";
                textBoxRf.Text = "";
                //textBoxSpot.Enabled = false;
                textBoxRf.Enabled = false;
            }
        }
    }
}
