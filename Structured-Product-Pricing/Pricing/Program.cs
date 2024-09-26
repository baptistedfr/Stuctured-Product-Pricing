// See https://aka.ms/new-console-template for more information
using Pricing;

Straddle str = new Straddle(100, 1);
double pay = str.Payoff(95);
Console.WriteLine(pay);
str.Afficher();

OptionStrategy bs = new CallSpread(90,100,1);
Console.WriteLine(bs.Payoff(92));
bs.Afficher();