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
        public bool CheckOptionSelected(object selectedItem)
        {
            if (selectedItem == null)
            {
                MessageBox.Show("Vous n'avez pas choisi de produit à pricer !", "Erreur de sélection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public IDerives CreateDerive(string selectedOption, List<double> strikeValues, string maturityText, string binaryText, string barrierText)
        { 
            double maturity = double.Parse(maturityText);
            return selectedOption switch
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
    }
}
