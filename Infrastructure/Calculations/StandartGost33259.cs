using System;
using System.Collections.Generic;

namespace StudCalculator.Infrastructure.Calculations
{
    public class StandartGost33259
    {
        private Dictionary<string, object> FromReceiptAndDistribution { get; }
        private string SelectedExecutionFlange { get; }
        public double B => StandartGosts33259();

        public StandartGost33259(Dictionary<string, object> fromReceiptAndDistribution)
        {
            FromReceiptAndDistribution = fromReceiptAndDistribution;
            //Получение исполнений ГОСТов и тд. введенных пользователем
            SelectedExecutionFlange = fromReceiptAndDistribution["SelectedExecutionFlange"].ToString();
        }

        private double StandartGosts33259()
        {   
            return SelectedExecutionFlange switch
            {
                "Исполнение A" or "Исполнение B" or "Исполнение J" or "Исполнение K" => 
                FromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"])
                : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) * 2,

                "Исполнение C и D" or "Исполнение E и F" => FromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                Convert.ToDouble(FromReceiptAndDistribution["inResulth2"])
                : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) +
                (Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                Convert.ToDouble(FromReceiptAndDistribution["inResulth2"])),

                "Исполнение L и M" => FromReceiptAndDistribution["StandartPlugsChecked"] is true ||
                FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
                ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                Convert.ToDouble(FromReceiptAndDistribution["inResulth5"])
                : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) +
                (Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
                Convert.ToDouble(FromReceiptAndDistribution["inResulth5"])),
                _ => double.NaN,
            };
            #region Старый код
            //if (SelectedExecutionFlange == "Исполнение A" || SelectedExecutionFlange == "Исполнение B" || 
            //    SelectedExecutionFlange == "Исполнение J" || SelectedExecutionFlange == "Исполнение K")
            //{
            //    double b = FromReceiptAndDistribution["StandartPlugsChecked"] is true || 
            //        FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
            //        ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"])
            //        : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) * 2;
            //    return b;
            //}
            //if (SelectedExecutionFlange == "Исполнение C и D" || SelectedExecutionFlange == "Исполнение E и F")
            //{
            //    double b = FromReceiptAndDistribution["StandartPlugsChecked"] is true ||
            //              FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
            //        ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
            //          Convert.ToDouble(FromReceiptAndDistribution["inResulth2"])
            //        : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) +
            //          (Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
            //           Convert.ToDouble(FromReceiptAndDistribution["inResulth2"]));
            //    return b;
            //}
            //if (SelectedExecutionFlange == "Исполнение L и M")
            //{
            //    double b = FromReceiptAndDistribution["StandartPlugsChecked"] is true ||
            //              FromReceiptAndDistribution["NonStandartPlugsChecked"] is true
            //        ? Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
            //          Convert.ToDouble(FromReceiptAndDistribution["inResulth5"])
            //        : Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) +
            //          (Convert.ToDouble(FromReceiptAndDistribution["inResultb1"]) -
            //           Convert.ToDouble(FromReceiptAndDistribution["inResulth5"]));
            //    return b;
            //}
            //return double.NaN;
            #endregion
        }
    }
}