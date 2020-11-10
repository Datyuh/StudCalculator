using System;
using System.Collections.Generic;

namespace StudCalculator.Infrastructure.Calculations
{
    public class StandartGost33259
    {
        public Dictionary<string, object> FromReceiptAndDistribution;

 
        public string SelectedExecutionFlange;


        public double StandartGosts33259(Dictionary<string, object> fromReceiptAndDistribution)
        {
            FromReceiptAndDistribution = fromReceiptAndDistribution;
            //Получение исполнений ГОСТов и тд. введенных пользователем
            SelectedExecutionFlange = FromReceiptAndDistribution["SelectedExecutionFlange"].ToString();

            if (SelectedExecutionFlange == "Исполнение A" || SelectedExecutionFlange == "Исполнение B" || 
                SelectedExecutionFlange == "Исполнение J" || SelectedExecutionFlange == "Исполнение K")
            {
                double b = FromReceiptAndDistribution["StandartPlugsChecked"] is true || 
                    FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                    ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"])
                    : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) * 2;
                return b;
            }
            if (SelectedExecutionFlange == "Исполнение C и D" || SelectedExecutionFlange == "Исполнение E и F")
            {
                double b = FromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                          FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                    ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                      Convert.ToDouble(FromReceiptAndDistribution["inResulth2"])
                    : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) +
                      (Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                       Convert.ToDouble(FromReceiptAndDistribution["inResulth2"]));
                return b;
            }
            if (SelectedExecutionFlange == "Исполнение L и M")
            {
                double b = FromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                          FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                    ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                      Convert.ToDouble(FromReceiptAndDistribution["inResulth5"])
                    : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) +
                      (Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                       Convert.ToDouble(FromReceiptAndDistribution["inResulth5"]));
                return b;
            }
            return 0;
        }
    }
}