using System;
using System.Collections.Generic;

namespace StudCalculator.Infrastructure.Calculations
{
    public class StandartGost33259
    {
        public Dictionary<string, object> FromReceiptAndDistribution;

        public double B;
        public string SelectedExecutionFlange;


        public string StandartGosts33259(Dictionary<string, object> fromReceiptAndDistribution)
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

            double result = B + Convert.ToDouble(FromReceiptAndDistribution["inResultPNuts"]) * 2 * 2 +
                            Convert.ToDouble(FromReceiptAndDistribution["inResultHNuts"]) * 2 + 4 +
                            Convert.ToDouble(FromReceiptAndDistribution["ExecuteNonStandartGasket"]) +
                            Convert.ToDouble(FromReceiptAndDistribution["ExecuteOvalGasket"]) +
                            Convert.ToDouble(FromReceiptAndDistribution["ExecuteOctagonalGasket"]) +
                            Convert.ToDouble(FromReceiptAndDistribution["ExrcuteAtk2618593b"]) +
                            Convert.ToDouble(FromReceiptAndDistribution["ExrcuteAtk2618593bNonStandart"]) +
                            Convert.ToDouble(FromReceiptAndDistribution["ExecuteNonStandartWashers"]) +
                            Convert.ToDouble(FromReceiptAndDistribution["ExecuteStandartWashers"]) +
                            Convert.ToDouble(FromReceiptAndDistribution["ExecuteAtk242000290b"]) + 
                            Convert.ToDouble(FromReceiptAndDistribution["ExrcuteAtk2618593bNonStandart"]);

            var resultToResultInViewModels = new Dictionary<string, object>
            {
                {"result", result}, {"MaterialStudFromCombobox", FromReceiptAndDistribution["MaterialStudFromCombobox"]}, 
                {"ExecutionStudFromCombobox", FromReceiptAndDistribution["ExecutionStudFromCombobox"]}, {"SelectedTheard", FromReceiptAndDistribution["SelectedTheard"]}
            };

            string resultInMainWindow = new ResultInViewModel.ResultInViewModel().ReturnFromLotsman(resultToResultInViewModels);
            return resultInMainWindow;
        }
    }
}