using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.MarketData
{
    internal class CsvReader
    {   
        /// <summary>
        /// Reader for Option Data CSV to calibrate the volatility models
        /// </summary>
        public List<OptionData> ReadOptionData(string filePath)
        {
            var optionDataList = new List<OptionData>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',');

                double strike = double.Parse(values[1], CultureInfo.InvariantCulture);
                double impliedVolatility = double.Parse(values[4], CultureInfo.InvariantCulture);
                double maturity = double.Parse(values[5], CultureInfo.InvariantCulture);
                double volume = double.Parse(values[3], CultureInfo.InvariantCulture);

                optionDataList.Add(new OptionData
                {
                    Strike = strike,
                    ImpliedVolatility = impliedVolatility,
                    Maturity = maturity,
                    Volume = volume
                });
            }

            return optionDataList;
        }

        /// <summary>
        /// CSV Reader for Yield Curve data to calibrate Nelson-Siegel model
        /// </summary>
        public List<RateCurveData> ReadRateCurve(string filePath)
        {
            var rateCurve = new List<RateCurveData>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',');

                string maturityStr = values[0];
                double maturity;

                if (maturityStr.EndsWith("M", StringComparison.OrdinalIgnoreCase))
                {
                    double months = double.Parse(maturityStr.Substring(0, maturityStr.Length - 1), CultureInfo.InvariantCulture);
                    maturity = (months * 30.44);
                }
                else if (maturityStr.EndsWith("Y", StringComparison.OrdinalIgnoreCase))
                {
                    double years = double.Parse(maturityStr.Substring(0, maturityStr.Length - 1), CultureInfo.InvariantCulture);
                    maturity = years * 356;
                }
                else
                {
                    maturity = double.Parse(maturityStr, CultureInfo.InvariantCulture);
                }

                double rate = double.Parse(values[1], CultureInfo.InvariantCulture);
                rateCurve.Add(new RateCurveData
                {
                    Maturity = maturity,
                    Rate = rate,
                });
            }

            return rateCurve;
        }
    }
}
