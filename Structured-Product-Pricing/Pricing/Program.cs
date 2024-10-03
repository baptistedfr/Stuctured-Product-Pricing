using Pricing.MarketData;
using Pricing;
using Pricing.Volatility;
using Pricing.MonteCarlo;
using Pricing.Products.Strategies;

internal class Program
{
    private static void Main(string[] args)
    {
        var lastSpot = YahooFinance.GetLastSpot("AAPL");
        Console.WriteLine("Last spot : " + lastSpot);

        var market = new Market("AAPL", VolatilityType.SVI);
        CallSpread call = new CallSpread(100, 110, 1);
        MonteCarloSimulator mc = new MonteCarloSimulator(call, market, 1000000);
    }
}