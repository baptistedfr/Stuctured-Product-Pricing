using Pricing.Volatility.Models;
using Pricing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Volatility;
using OxyPlot;
using System.Xml.Linq;

namespace InterfaceProducts
{
    public class MarketManager
    {
        private TextBox textBoxSpot;
        private TextBox textBoxVol;
        private TextBox textBoxRf;
        private RadioButton radioButtonAuto;
        private RadioButton radioButtonManual;
        private RadioButton radioButtonVolSVI;
        private RadioButton radioButtonVolSto;
        private RadioButton radioButtonVolCste;
        private ComboBox comboBoxTicker;
        public MarketManager(TextBox textBoxSpot, TextBox textBoxVol, TextBox textBoxRf, RadioButton radioButtonAuto, RadioButton radioButtonManual,
            RadioButton radioButtonVolSto, RadioButton radioButtonVolCste, RadioButton radioButtonVolSVI, ComboBox comboBoxTicker)
        {
            this.textBoxSpot = textBoxSpot;
            this.textBoxVol = textBoxVol;
            this.textBoxRf = textBoxRf;
            this.radioButtonAuto = radioButtonAuto;
            this.radioButtonManual = radioButtonManual;
            this.radioButtonVolSto = radioButtonVolSto;
            this.radioButtonVolCste = radioButtonVolCste;
            this.radioButtonVolSVI = radioButtonVolSVI;
            this.comboBoxTicker = comboBoxTicker;
        }

        public bool CheckRadioButton()
        {
            if ((!radioButtonAuto.Checked && !radioButtonManual.Checked) || (!radioButtonVolSto.Checked && !radioButtonVolCste.Checked && !radioButtonVolSVI.Checked))
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
            if (!double.TryParse(textBoxSpot.Text, out double value2) || value2 <= 0)
            {
                MessageBox.Show($"Veuillez entrer une valeur positive valide pour le ticker.", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public bool CheckTicker()
        {
            if (comboBoxTicker.SelectedItem == null && comboBoxTicker.Visible == true)
            {
                MessageBox.Show("Vous n'avez pas choisi de Ticker !", "Erreur de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public Market CreateMarket()
        {
            double spot = Convert.ToDouble(textBoxSpot.Text);
            var volType = DetermineVolatilityType();
            double vol = volType == VolatilityType.Cste ? Convert.ToDouble(textBoxVol.Text) / 100 : 0;
            if (radioButtonAuto.Checked)
            {
                if (comboBoxTicker.Visible)
                {
                    return new Market(comboBoxTicker.SelectedItem.ToString(), volType, vol, spot);
                }
                else
                {
                    // Cas des Autocall
                    return new Market(volType, vol, spot);
                }
                
            }
            else
            {
                // Cas ou on cree son marche
                double rate = Convert.ToDouble(textBoxRf.Text) / 100;
                return new Market(rate, vol, spot);
            }
        }
        private VolatilityType DetermineVolatilityType()
        {
            if (radioButtonVolSVI.Checked) return VolatilityType.SVI;
            if (radioButtonVolSto.Checked) return VolatilityType.Heston;
            return VolatilityType.Cste;
        }
        public void ActualiseMarket(Market market)
        {
            textBoxSpot.Text = (Math.Round(market.Spot, 2).ToString());
            textBoxRf.Text = (Math.Round(market.Rate * 100, 2).ToString());
            if (market.VolType != VolatilityType.Heston) 
            { 
                textBoxVol.Text = (Math.Round(market.Volatility * 100, 2).ToString());
            } 
        }

        public void UpdateMarket(bool isAutocall)
        {
            if (radioButtonManual.Checked)
            {
                comboBoxTicker.Visible = false;
                radioButtonVolSto.Enabled = false;
                radioButtonVolSVI.Enabled = false;
                radioButtonVolCste.Checked = true;
                radioButtonVolCste.Enabled = false;
                textBoxSpot.Enabled = !isAutocall;
                textBoxVol.Enabled = true;
                textBoxRf.Enabled = true;
            }
            if (radioButtonAuto.Checked)
            {
                comboBoxTicker.Visible = !isAutocall;
                radioButtonVolCste.Enabled = true;
                radioButtonVolSto.Enabled = !isAutocall;
                radioButtonVolSVI.Enabled = true;
                textBoxRf.Text = "";
                if (isAutocall)
                {
                    textBoxSpot.Text = "100";
                }
                else{
                    textBoxSpot.Text = "";
                }
                textBoxSpot.Enabled = false;
                textBoxRf.Enabled = false;
            }
        }

        public void UpdateSpot()
        {
            GetLastSpot(comboBoxTicker.SelectedItem.ToString());
        }
        public async void GetLastSpot(string Ticker)
        {
            var data = await Task.Run(() => YahooFinance.Get(Ticker));
            double spot = 0;
            try
            {
                spot= data.chart.result.First().indicators.adjclose.First().adjclose.Last();
            }
            catch
            {
                MessageBox.Show($"Merci d'entrer un ticker correct", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBoxSpot.Text = spot.ToString();


        }
    }
}
