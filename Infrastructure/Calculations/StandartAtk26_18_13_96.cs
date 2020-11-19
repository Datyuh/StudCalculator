using System;
using System.Collections.Generic;

namespace StudCalculator.Infrastructure.Calculations
{
    public class StandartAtk26_18_13_96
    {
        private Dictionary<string, object> DataFromReceiptAndDistribution { get; }
        private string SelectedExecutionFlange { get; }
        public double B => StandartAtk26181396();

        public StandartAtk26_18_13_96(Dictionary<string, object> fromReceiptAndDistribution)
        {
            DataFromReceiptAndDistribution = fromReceiptAndDistribution;
            SelectedExecutionFlange = fromReceiptAndDistribution["SelectedExecutionFlange"].ToString();
        }
        private double StandartAtk26181396() => SelectedExecutionFlange switch
        {
            "Исполнение 1" or "Исполнение 6" =>
            DataFromReceiptAndDistribution["StandartPlugsChecked"] is true ||
            DataFromReceiptAndDistribution["NonStandartPlugsChecked"] is true ?
            Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) + 
            Convert.ToDouble(DataFromReceiptAndDistribution["inResultH1"]) :
            (Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) + 
            Convert.ToDouble(DataFromReceiptAndDistribution["inResultH1"])) * 2,

            "Исполнение 2 и 3" or "Исполнение 4 и 5" =>
            DataFromReceiptAndDistribution["StandartPlugsChecked"] is true ||
            DataFromReceiptAndDistribution["NonStandartPlugsChecked"] is true ?
            Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) -
            Convert.ToDouble(DataFromReceiptAndDistribution["inResultH1"]) :
            Convert.ToDouble(DataFromReceiptAndDistribution["inResultB"]) * 2 +
            (Convert.ToDouble(DataFromReceiptAndDistribution["inResultH1"]) -
            Convert.ToDouble(DataFromReceiptAndDistribution["inResultH2"])),

            _ => double.NaN
        };
    }
}