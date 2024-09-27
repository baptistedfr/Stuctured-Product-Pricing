using Newtonsoft.Json;
using Pricing.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.OptionStrategies;

ButterflySpread bs = new ButterflySpread([90, 100, 110,120],1);
Console.WriteLine(bs.Payoff(111));
Console.WriteLine(bs.Afficher());
//var lastSpot = YahooFinance.GetLastSpot("GLE.PA");
//Console.WriteLine("Last spot : " + lastSpot);
