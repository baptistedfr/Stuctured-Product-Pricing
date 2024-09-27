using Newtonsoft.Json;
using Pricing.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Products;
using Pricing;

//Straddle str = new Straddle(100, 1);
//double pay = str.Payoff(95);
//Console.WriteLine(pay);
//str.Afficher();

//OptionStrategy bs = new CallSpread(90,100,1);
//Console.WriteLine(bs.Payoff(92));
//bs.Afficher();

//var lastSpot = YahooFinance.GetLastSpot("GLE.PA");
//Console.WriteLine("Last spot : " + lastSpot);

var market = new Market("GLE.PA", VolatilityType.SVI);
market.Initialize();

Console.WriteLine("Last market spot : " + market.Spot);