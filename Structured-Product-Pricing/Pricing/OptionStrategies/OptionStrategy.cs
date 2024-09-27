using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Options;

namespace Pricing.OptionStrategies
{
    public abstract class OptionStrategy : IDerives
    {

        // Champs communs
        protected Dictionary<Option, int> options = new Dictionary<Option, int>();

        // Propriétés communes
        public Dictionary<Option, int> Options
        {
            get { return options; }
            protected set { options = value; }
        }

        protected void AddOption(Option option, int quantity)
        {
            if (options.ContainsKey(option))
            {

                Options[option] += quantity;

                if (Options[option] == 0)
                {
                    Options.Remove(option);
                }
            }
            else
            {

                Options.Add(option, quantity);
            }
        }

        public double Payoff(double spot)
        {
            double total = 0;
            foreach (var option in Options)
            {
                total += option.Key.Payoff(spot) * option.Value;
            }
            return total;
        }

        public string Afficher()
        {
            int callAchat = 0;
            int callVente = 0;
            int putAchat = 0;
            int putVente = 0;

            foreach (var entry in Options)
            {
                Option option = entry.Key;
                int quantity = entry.Value;

                switch (option)
                {
                    case CallOption _:
                        if (quantity > 0)
                        {
                            callAchat += quantity;
                        }
                        else
                        {
                            callVente += Math.Abs(quantity);
                        }
                        break;
                    case PutOption _:
                        if (quantity > 0)
                        {
                            putAchat += quantity;
                        }
                        else
                        {
                            putVente += Math.Abs(quantity);
                        }
                        break;
                }
            }
            List<string> messages = new List<string>();

            if (callAchat > 0)
            {
                messages.Add($"On achète {callAchat} call(s).");
            }
            if (callVente > 0)
            {
                messages.Add($"On vend {callVente} call(s).");
            }
            if (putAchat > 0)
            {
                messages.Add($"On achète {putAchat} put(s).");
            }
            if (putVente > 0)
            {
                messages.Add($"On vend {putVente} put(s).");
            }

            // Affichage sur la même ligne
            return string.Join(" ", messages);
        }
    }
}
