using Pricing.Products;
using Pricing.Products.Options;
using Pricing.Volatility;
using Pricing.Volatility.Models;
using Pricing.Volatility.Parameters;

namespace Pricing.MonteCarlo
{
    public class MonteCarloSimulator
    {
        public IDerives Derive;
        public Market Market;
        public double Maturity;

        public int NbSimulation;
        public int NbSteps;
        public double Dt;

        public MonteCarloSimulator(IDerives derive, Market market, int nbSim = 100000)
        {
            Derive = derive;
            Market = market;
            NbSimulation = nbSim;
            Maturity = derive.GetMaturity();
            NbSteps = Convert.ToInt32(Maturity * 252);
            Dt = Maturity / NbSteps;

            if (market.VolModel as SVI !=null)
            {
                market.Volatility = derive.CalculateVolSVI(market);
            }
            if (market.RateModel != null) {
                market.Rate = market.RateModel.GetRate(Maturity) / 100;
            }
        }

        /// <summary>
        /// Monte-Carlo pricer for regular option strategies
        /// </summary>
        /// <returns></returns>
        public double Price()
        {
            double[] payoffs = new double[NbSimulation];

            BrownianGenerator brownianGenerator = new BrownianGenerator();
            BarrierOption? barrierOption = Derive as BarrierOption;

            Parallel.For(0, NbSimulation, i =>
            {
                BarrierOption? barrierOption = Derive as BarrierOption;

                if (barrierOption != null)
                {
                    barrierOption.Activated = false; 
                }

                double simPrice = Market.Spot;

                // Pricing with Heston discretisation
                if (Market.VolType == VolatilityType.Heston)
                {
                    double[] varianceSimulated = [];
                    varianceSimulated[0] = 0.2;
                    var hestonModel = Market.VolModel as Heston;
                    var (dW1, dW2) = brownianGenerator.GenerateBrownian(NbSteps, hestonModel.Rho);

                    for (int j = 1; j < NbSteps+1; j++)
                    {
                        HestonParams volParams = new HestonParams(varianceSimulated[j-1], Dt, dW2[j]);
                        var hestonVariance = Math.Max(0, hestonModel.GetVolatility(volParams));

                        double drift = (Market.Rate - 0.5 * hestonVariance) * Dt;
                        double diffusion = Math.Sqrt(hestonVariance * Dt) * dW1[j];

                        simPrice *= Math.Exp(drift + diffusion);

                        if (barrierOption != null && barrierOption.BarrierOut(simPrice))
                        {
                            break;
                        }
                    }
                    payoffs[i] = Derive.Payoff(simPrice);
                }
                // Pricing without Heston : Volatility is either constant or calculated from the SVI in the constructor
                else
                {
                    var (dW1, _) = brownianGenerator.GenerateBrownian(NbSteps, 0);

                    double drift = (Market.Rate - 0.5 * Market.Volatility) * Dt;
                    double diffusion = Math.Sqrt(Market.Volatility * Dt);

                    for (int j = 1; j < NbSteps + 1; j++)
                    {
                        simPrice *= Math.Exp(drift + diffusion * dW1[j]);
                        if (barrierOption != null && barrierOption.BarrierOut(simPrice))
                        {
                            break;
                        }
                    }
                    payoffs[i] = Derive.Payoff(simPrice);
                }
            });

            return Math.Exp(-Market.Rate * Maturity) * payoffs.Average();
        }

        /// <summary>
        /// Monte-Carlo pricer for structured products
        /// </summary>
        /// <returns></returns>
        public double PriceStructu()
        {
            return 0.0;
        }

        /// <summary>
        /// Compute option greeks with finite difference method
        /// </summary>
        public Dictionary<string, double> ComputeGreeks(double priceOption)
        {
            Dictionary<string, double> greeks = new Dictionary<string, double>();

            double deltaS = Market.Spot * 0.01;
            Market.Spot += deltaS;
            double priceDeltaSpotPos = Price();
            double delta = (priceDeltaSpotPos - priceOption) / deltaS;
            Market.Spot -= deltaS;
            greeks.Add("Delta", delta);

            Market.Spot -= deltaS;
            double priceDeltaSpotNeg = Price();
            double gamma = (priceDeltaSpotPos - 2 * priceOption + priceDeltaSpotNeg) / (deltaS * deltaS);
            Market.Spot += deltaS;
            greeks.Add("Gamma", gamma);

            double deltaSigma = 0.01;
            Market.Volatility += deltaSigma;
            double vega = (Price() - priceOption) / deltaSigma;
            Market.Volatility -= deltaSigma;
            greeks.Add("Vega", vega);

            double deltaMaturity = 10.0 / 252;
            Maturity -= deltaMaturity;
            double theta = (Price() - priceOption) / deltaMaturity;
            Maturity = Derive.GetMaturity();
            greeks.Add("Theta", theta);

            double deltaRho = 0.01;
            Market.Rate += deltaRho;
            double rho = (Price() - priceOption) / deltaRho;
            Market.Rate -= deltaRho;
            greeks.Add("Rho", rho);

            return greeks;
        }
    }
}
