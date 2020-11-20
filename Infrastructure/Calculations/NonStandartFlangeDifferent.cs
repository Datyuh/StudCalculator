using System;
using System.Collections.Generic;

namespace StudCalculator.Infrastructure.Calculations
{
    public class NonStandartFlangeDifferent
    {
        private Dictionary<string, object> DataFromReceiptAndDistribution { get; }
        public double B => NonStandartFlangeDifferents();

        public NonStandartFlangeDifferent(Dictionary<string, object> dataFromReceiptAndDistribution)
        {
            DataFromReceiptAndDistribution = dataFromReceiptAndDistribution;
        }

        private double NonStandartFlangeDifferents()
        {
            var b = 
                Convert.ToDouble(DataFromReceiptAndDistribution["NonStandartFirstFlangeTextRead"]) + 
                Convert.ToDouble(DataFromReceiptAndDistribution["NonStandartFirstFlangeTextRead"]);
            return b;
        }
    }
}