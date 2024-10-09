using Pricing.Products.Options;
using Pricing.Products.Strategies;
using Pricing.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceProducts
{
    // Classe pour gérer la logique des options
    public class OptionManager
    {
        private RadioButton radioButtonAutocall;
        private RadioButton radioButtonDerive;
        private ComboBox comboBoxProduct;

        private static List<string> Options = new List<string>
        {
            "Call Option",
            "Put Option",
            "Binary Call",
            "Binary Put",
            "Call Up And In",
            "Call Up And Out",
            "Call Down And In",
            "Call Down And Out",
            "Put Up And In",
            "Put Up And Out",
            "Put Down And In",
            "Put Down And Out",
            "Call Spread",
            "Put Spread",
            "Butterfly Spread",
            "Condor Spread",
            "Straddle",
            "Strangle",
            "Strip",
            "Strap"
        };

        private static List<string> Autocalls = new List<string>
        {
            "Autocall Phoenix",
            "Autocall Athena"
        };
        public OptionManager(RadioButton Autocall, RadioButton Derivative, ComboBox product)
        {
            this.radioButtonAutocall = Autocall;
            this.radioButtonDerive = Derivative;
            this.comboBoxProduct = product;
        }
        public bool CheckOptionSelected()
        {
            if (comboBoxProduct.SelectedItem == null)
            {
                MessageBox.Show("Vous n'avez pas choisi de produit à pricer !", "Erreur de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public IDerives CreateDerive(List<double> strikeValues, string maturityText, string binaryText, string barrierText)
        {
            string selectedProduct = comboBoxProduct.SelectedItem.ToString();
            double maturity = double.Parse(maturityText);
            return selectedProduct switch
            {
                "Call Option" => new CallOption(strikeValues[0], maturity),
                "Put Option" => new PutOption(strikeValues[0], maturity),
                "Binary Call" => new BinaryCallOption(strikeValues[0], maturity, double.Parse(binaryText)),
                "Binary Put" => new BinaryPutOption(strikeValues[0], maturity, double.Parse(binaryText)),
                "Call Up And In" => new CallUpAndIn(strikeValues[0], maturity, double.Parse(barrierText)),
                "Call Up And Out" => new CallUpAndOut(strikeValues[0], maturity, double.Parse(barrierText)),
                "Call Down And Out" => new CallDownAndOut(strikeValues[0], maturity, double.Parse(barrierText)),
                "Call Down And In" => new CallDownAndIn(strikeValues[0], maturity, double.Parse(barrierText)),
                "Put Down And In" => new PutDownAndIn(strikeValues[0], maturity, double.Parse(barrierText)),
                "Put Down And Out" => new PutDownAndOut(strikeValues[0], maturity, double.Parse(barrierText)),
                "Put Up And In" => new PutUpAndIn(strikeValues[0], maturity, double.Parse(barrierText)),
                "Put Up And Out" => new PutUpAndOut(strikeValues[0], maturity, double.Parse(barrierText)),
                "Call Spread" => new CallSpread(strikeValues.Min(), strikeValues.Max(), maturity),
                "Put Spread" => new PutSpread(strikeValues.Min(), strikeValues.Max(), maturity),
                "Butterfly Spread" => new ButterflySpread(new[] { strikeValues[0], strikeValues[1], strikeValues[2] }, maturity),
                "Condor Spread" => new CondorSpread(strikeValues.ToArray(), maturity), // Utilisation du tableau directement
                "Strangle" => new Strangle(strikeValues.Min(), strikeValues.Max(), maturity),
                "Straddle" => new Straddle(strikeValues[0], maturity),
                "Strip" => new Strip(strikeValues[0], maturity),
                "Strap" => new Strap(strikeValues[0], maturity),
                _ => throw new ArgumentException("Option non reconnue")
            };
        }
        public Autocall CreateAutocall(string maturityText, string freqObservationText, string barrierRappel, string barrierCoupon, string barrierCapital)
        {
            string selectedProduct = comboBoxProduct.SelectedItem.ToString();
            double freqObservation=1;
            switch (freqObservationText)
            {
                case "Annuelle":
                    freqObservation = 1;
                    break;
                case "Semestrielle":
                    freqObservation = 2;
                    break;
                case "Trimestrielle":
                    freqObservation = 4;
                    break;
                case "Mensuelle":
                    freqObservation = 12;
                    break;
            }
            double maturity = double.Parse(maturityText);
            return selectedProduct switch
            {
                "Autocall Phoenix" => new AutocallPhoenix(double.Parse(maturityText), freqObservation, double.Parse(barrierCoupon), double.Parse(barrierRappel), double.Parse(barrierCapital)),
                "Autocall Athena" => new AutocallAthena(double.Parse(maturityText), freqObservation, double.Parse(barrierCoupon), double.Parse(barrierRappel), double.Parse(barrierCapital)),
                _ => throw new ArgumentException("Option non reconnue")
            };
        }
        public bool CheckProduct()
        {
            if ((!radioButtonAutocall.Checked && !radioButtonDerive.Checked))
            {
                MessageBox.Show($"Veuillez cocher un produit (Autocall ou Derivé).", "Valeur Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void UpdateProduct(Button bouttonPrice, Button bouttonCoupon, TextBox textBoxSpot, ComboBox ticker, bool isAuto, RadioButton volSto)
        {
            
            comboBoxProduct.Items.Clear(); // On vide les éléments actuels de la ComboBox
            if (radioButtonAutocall.Checked)
            {   
                comboBoxProduct.Items.AddRange(Autocalls.ToArray()); // Ajouter les nouveaux éléments  
                bouttonPrice.Visible = false;
                bouttonCoupon.Visible = true;
                textBoxSpot.Text = "100";
                textBoxSpot.Enabled = false;
                ticker.Visible = false;
                volSto.Enabled = false;
                volSto.Checked = false;
            }
            else
            {
                
                
                if (isAuto)
                {
                    ticker.Visible = true;
                    textBoxSpot.Enabled = false;
                    volSto.Enabled = true;
                }
                else
                {
                    textBoxSpot.Text = "";
                    ticker.Visible = false;
                    textBoxSpot.Enabled = true;
                }
                comboBoxProduct.Items.AddRange(Options.ToArray()); // Ajouter les nouveaux éléments
                bouttonPrice.Visible = true;
                bouttonCoupon.Visible = false; 
            }
            comboBoxProduct.SelectedIndex = 0; // Sélectionner automatiquement le premier élément
        }
    }
}
