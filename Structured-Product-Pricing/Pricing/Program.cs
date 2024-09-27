using Newtonsoft.Json;
using Pricing.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
using Pricing.OptionStrategies;

ButterflySpread bs = new ButterflySpread([90, 100, 110,120],1);
Console.WriteLine(bs.Payoff(111));
Console.WriteLine(bs.Afficher());
//var lastSpot = YahooFinance.GetLastSpot("GLE.PA");
//Console.WriteLine("Last spot : " + lastSpot);
=======
using Pricing.Products;
using Pricing;
using Pricing.Volatility.Models;

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
>>>>>>> abcf84e17748316de47f213b6af1e3b67d07ed7d
