﻿using Pricing.Volatility.Calibration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Volatility.Models
{
    public class CsteVolatility : VolatilityModel
    {
        public double VolLevel { get; set; }

        public override void Calibrate(ICalibrationParams parameters)
        {
            var param = parameters as CsteCalibrationParams;
            VolLevel = param.VolLevel;
        }
    }
}
