using Newtonsoft.Json;
using Pricing.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing;
using Pricing.Volatility;
using Pricing.Volatility.Models;
using Pricing.MonteCarlo;
using System.Runtime.InteropServices;
using Pricing.Products.Strategies;

//ButterflySpread bs = new ButterflySpread([90, 100, 110],1);
//Console.WriteLine(bs.Payoff(111));
//Console.WriteLine(bs.Afficher());
//var lastSpot = YahooFinance.GetLastSpot("GLE.PA");
//Console.WriteLine("Last spot : " + lastSpot);



//Straddle str = new Straddle(100, 1);
//double pay = str.Payoff(95);
//Console.WriteLine(pay);
//str.Afficher();

//OptionStrategy bs = new CallSpread(90,100,1);
//Console.WriteLine(bs.Payoff(92));
//bs.Afficher();

var lastSpot = YahooFinance.GetLastSpot("AAPL");
Console.WriteLine("Last spot : " + lastSpot);

//var market = new Market("AAPL", VolatilityType.SVI);
//market.Initialize();
//CallSpread call = new CallSpread(100,110, 1);
//MonteCarloSimulator mc = new MonteCarloSimulator(call, market, 1000000);
//Console.WriteLine(market.VolModel.GetVolatility(110, 1, 100));
//Console.WriteLine(mc.Price(100));


//Console.WriteLine("Last market spot : " + market.Spot);

