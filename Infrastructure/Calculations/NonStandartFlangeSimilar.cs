using System;
using System.Collections.Generic;

namespace StudCalculator.Infrastructure.Calculations
{
    public class NonStandartFlangeSimilar
    {
        private Dictionary<string, object> DataFromReceiptAndDistribution { get; }
        public double B => NonStandartFlangeSimilars();

        public NonStandartFlangeSimilar(Dictionary<string, object> dataFromReceiptAndDistribution)
        {
            DataFromReceiptAndDistribution = dataFromReceiptAndDistribution;
        }

        private double NonStandartFlangeSimilars()
        {
            var b = DataFromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                DataFromReceiptAndDistribution["NonStandartPlugsChecked"] is true ?
                Convert.ToDouble(DataFromReceiptAndDistribution["NonStandartFlTextRead"]) :
                Convert.ToDouble(DataFromReceiptAndDistribution["NonStandartFlTextRead"]) * 2;
            return b;
        }
    }
}