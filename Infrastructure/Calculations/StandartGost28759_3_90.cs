using System;
using System.Collections.Generic;

namespace StudCalculator.Infrastructure.Calculations
{
    public class StandartGost28759_3_90
    {
        private Dictionary<string, object> DataFromReceiptAndDistribution { get; }
        private string SelectedExecutionFlange { get; }
        public double B => StandartGosts28759_3_90();

        public StandartGost28759_3_90(Dictionary<string, object> dataFromReceiptAndDistribution)
        {
            DataFromReceiptAndDistribution = dataFromReceiptAndDistribution;
            SelectedExecutionFlange = dataFromReceiptAndDistribution["SelectedExecutionFlange"].ToString();
        }

        private double StandartGosts28759_3_90()
        {
            return SelectedExecutionFlange switch
            {
                "Исполнение 1 и 2" or "Исполнение 3 и 4" or "Исполнение 11 и 12" =>
                DataFromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                DataFromReceiptAndDistribution["NonStandartPlugsChecked"] is true ?
                (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) - 5) :
                (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) +
                Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) - 5),

                "Исполнение 5 и 6" or "Исполнение 7 и 8" =>
                DataFromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                DataFromReceiptAndDistribution["NonStandartPlugsChecked"] is true ?
                (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) + 12 - 5) :
                (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) + 12) +
                (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) + 12 - 5),

                "Исполнение 9 и 10" =>
                DataFromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                DataFromReceiptAndDistribution["NonStandartPlugsChecked"] is true ?
                (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) - 3) :
                (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) - 3) +
                Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]),

                _ => double.NaN
            };
        }
    }
}