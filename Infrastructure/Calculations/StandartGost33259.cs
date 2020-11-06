using System;
using System.Collections.Generic;

namespace StudCalculator.Infrastructure.Calculations
{
    public class StandartGost33259
    {
        public Dictionary<string, object> FromReceiptAndDistribution;

        public double B;
        public string SelectedExecutionFlange;


        public double StandartGosts33259(Dictionary<string, object> fromReceiptAndDistribution)
        {
            FromReceiptAndDistribution = fromReceiptAndDistribution;
            //Получение исполнений ГОСТов и тд. введенных пользователем
            SelectedExecutionFlange = FromReceiptAndDistribution["SelectedExecutionFlange"].ToString();

            if (SelectedExecutionFlange == "Исполнение A" || SelectedExecutionFlange == "Исполнение B" || 
                SelectedExecutionFlange == "Исполнение J" || SelectedExecutionFlange == "Исполнение K")
            {
                B = FromReceiptAndDistribution["StandartPlugsChecked"] is true || 
                    FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                    ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"])
                    : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) * 2;
            }
            else if (SelectedExecutionFlange == "Исполнение C и D" || SelectedExecutionFlange == "Исполнение E и F")
            {
                B = FromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                    FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                    ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                      Convert.ToDouble(FromReceiptAndDistribution["inResulth2"])
                    : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) +
                      (Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                       Convert.ToDouble(FromReceiptAndDistribution["inResulth2"]));
            }
            else if (SelectedExecutionFlange == "Исполнение L и M")
            {
                B = FromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                    FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                    ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                      Convert.ToDouble(FromReceiptAndDistribution["inResulth5"])
                    : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) +
                      (Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                       Convert.ToDouble(FromReceiptAndDistribution["inResulth5"]));
            }
            return B;
        }
    }
}