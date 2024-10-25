﻿using Microsoft.VisualBasic.FileIO;
using Pricing.MarketData;
using Pricing.Products.Options;
using Pricing.Products;
using Pricing.Rate;
using Pricing.Volatility;
using Pricing.Volatility.Calibration;
using Pricing.Volatility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pricing.Products.Strategies;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Pricing
{
    public class Market
    {
        public string Ticker { get; set; }
        public VolatilityType VolType { get; set; }
        public VolatilityModel VolModel { get; set; }
        public NelsonSiegel RateModel { get; set; }
        public double Spot { get; set; }
        public double Volatility { get; set; }
        public double Rate { get; set; }
        public double Dividende { get; private set; }

        /// <summary>
        /// Case of Automaticaly calibrated Market
        /// </summary>
        public Market(string ticker, VolatilityType volType, double CsteVol = 0, double spot = 100)
        {
            Spot = spot;
            Ticker = ticker;
            VolType = volType;
            GetLastSpot();
            CalibrateVol(CsteVol);
            CalibrateRate();
        }
        /// <summary>
        /// Market For autocall Products 
        /// </summary>
        public Market(VolatilityType volType, double CsteVol = 0, double spot = 100)
        {
            Spot = spot;
            VolType = volType;
            CalibrateVol(CsteVol);
            CalibrateRate();
        }


        /// <summary>
        /// Case of custom Market
        /// </summary>
        public Market(double rate, double CsteVol, double spot)
        {
            Spot = spot;
            VolType = VolatilityType.Cste;
            CalibrateVol(CsteVol); //On peut quand meme utiliser cette fonction
            Rate = rate;
        }
        public async void GetLastSpot()
        {
            var data = await Task.Run(() => YahooFinance.Get(Ticker));
            Spot = data.chart.result.First().indicators.adjclose.First().adjclose.Last();
        }

        public string GetDataPath(string fileName)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string solutionRoot = Directory.GetParent(currentDir).Parent.Parent.Parent.Parent.FullName;
            return Path.Combine(solutionRoot, "CsvData", fileName);
        }
        /// <summary>
        /// Instantiate the calibration of the vol depending on the vol method
        /// </summary>
        public void CalibrateVol(double CsteVol = 0)
        {
            if (VolType == VolatilityType.Cste)
            {
                var parameters = new CsteCalibrationParams(CsteVol);
                var volCste = new CsteVolatility();
                volCste.Calibrate((ICalibrationParams)parameters);
                VolModel = volCste;
                Volatility = VolModel.GetVolatility();
            }
            else if (VolType == VolatilityType.SVI)
            {
                var filePath = GetDataPath("sp500_data.csv");
                var optData = new CsvReader().ReadOptionData(filePath);
                var parameters = new SVICalibrationParams(optData, Spot);
                var SVI = new SVI();
                SVI.Calibrate((ICalibrationParams)parameters);
                VolModel = SVI;
            }
            else if (VolType == VolatilityType.Heston)
            {
                var heston = new Heston();
                VolModel = heston;
            }
        }
        /// <summary>
        /// Instantiate the calibration of the rate using Nelson Siegel
        /// </summary>
        public void CalibrateRate()
        {
            var filePath = GetDataPath("yield_us.csv");
            var curveData = new CsvReader().ReadRateCurve(filePath);
            var nelsonSiegel = new NelsonSiegel();
            nelsonSiegel.Calibrate(curveData);
            RateModel = nelsonSiegel;
        }
    }
}