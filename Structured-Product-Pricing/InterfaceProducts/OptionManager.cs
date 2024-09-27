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
        public bool CheckOptionSelected(object selectedItem)
        {
            if (selectedItem == null)
            {
                MessageBox.Show("Vous n'avez pas choisi de produit à pricer !", "Erreur de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public IDerives CreateDerive(string selectedOption, List<double> strikeValues, string maturityText)
        { 
            double maturity = double.Parse(maturityText);
            return selectedOption switch
            {
                "Call Option" => new CallOption(strikeValues[0], maturity),
                "Put Option" => new PutOption(strikeValues[0], maturity),
                "Call Spread" => new CallSpread(strikeValues.Min(), strikeValues.Max(), maturity),
                "Put Spread" => new PutSpread(strikeValues.Min(), strikeValues.Max(), maturity),
                "Butterfly Spread" => new ButterflySpread(new[] { strikeValues[0], strikeValues[1], strikeValues[2] }, maturity),
                "Condor Spread" => new CondorSpread(strikeValues.ToArray(), maturity), // Utilisation du tableau directement
                "Strange" => new Strangle(strikeValues.Min(), strikeValues.Max(), maturity),
                "Straddle" => new Straddle(strikeValues[0], maturity),
                "Strip" => new Strip(strikeValues[0], maturity),
                "Strap" => new Strap(strikeValues[0], maturity),
                _ => throw new ArgumentException("Option non reconnue")
            };
        }
    }
}
