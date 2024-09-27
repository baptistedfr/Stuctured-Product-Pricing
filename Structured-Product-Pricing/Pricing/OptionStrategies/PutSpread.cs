﻿using System;
using Pricing.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.OptionStrategies
{
    public class PutSpread : OptionStrategy
    {
        public PutSpread(double lowerStrike, double upperStrike, double maturity)
        {
            AddOption(new PutOption(lowerStrike, maturity), -1);
            AddOption(new PutOption(upperStrike, maturity), 1);
        }
    }
}