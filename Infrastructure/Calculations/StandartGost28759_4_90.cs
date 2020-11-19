using System;
using System.Collections.Generic;

namespace StudCalculator.Infrastructure.Calculations
{
    public class StandartGost28759_4_90
    {
        private Dictionary<string, object> DataFromReceiptAndDistribution { get; }
        private string SelectedExecutionFlange { get; }
        public double B => StandartGosts28759_4_90();

        public StandartGost28759_4_90(Dictionary<string, object> dataFromReceiptAndDistribution)
        {
            DataFromReceiptAndDistribution = dataFromReceiptAndDistribution;
            SelectedExecutionFlange = dataFromReceiptAndDistribution["SelectedExecutionFlange"].ToString();
        }

        private double StandartGosts28759_4_90()
        {
            return SelectedExecutionFlange switch
            {
                "Исполнение 1" =>
                DataFromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                DataFromReceiptAndDistribution["NonStandartPlugsChecked"] is true ?
                (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"])) :
                Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) * 2,

                "Исполнение 2" =>
                DataFromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                DataFromReceiptAndDistribution["NonStandartPlugsChecked"] is true ?
                (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) + 3) :
                (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) + 3) * 2,

                _ => double.NaN
            };
        }
    }
}