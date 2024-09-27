using Pricing.MarketData;
using Pricing.Rate;
using Pricing.Volatility;
using Pricing.Volatility.Calibration;
using Pricing.Volatility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing
{
    public class Market
    {
        public string Ticker { get; set; }
        public VolatilityType VolType { get; set; }
        public VolatilityModel VolModel { get; set; }
        public NelsonSiegel RateModel { get; set; }
        public double Spot { get; set; }
        public double Volatility { get; private set; }
        public double Rate { get; private set; }
        public double Dividende { get; private set; }

        public Market(string ticker, VolatilityType volType)
        {
            Ticker = ticker;
            VolType = volType;
        }

        public void CalibrateVol()
        {
            if (VolType == VolatilityType.Cste)
            {
                var parameters = new CsteCalibrationParams(0.15);
                var volCste = new CsteVolatility();
                volCste.Calibrate((ICalibrationParams)parameters);
                VolModel = volCste;
            }
            else if (VolType == VolatilityType.SVI)
            {
                var optData = new CsvReader().ReadOptionData("C:\\Users\\thibc\\OneDrive\\Documents\\Dev\\Stuctured-Product-Pricing\\option_data.csv");
                var parameters = new SVICalibrationParams(optData, Spot);
                var SVI = new SVI();
                SVI.Calibrate((ICalibrationParams)parameters);
                VolModel = SVI;
            }
        }

        public void CalibrateRate()
        {
            var curveData = new CsvReader().ReadRateCurve("C:\\Users\\thibc\\OneDrive\\Documents\\Dev\\Stuctured-Product-Pricing\\yield_us.csv");
            var nelsonSiegel = new NelsonSiegel();
            nelsonSiegel.Calibrate(curveData);
            RateModel = nelsonSiegel;
        }
        
        public void Initialize()
        {
            Spot = YahooFinance.GetLastSpot(Ticker);
            CalibrateVol();
            CalibrateRate();
        }
    }
}