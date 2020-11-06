using System;
using System.Collections.Generic;
using System.Windows;
using StudCalculator.Data.DbModelsFromLotsman;

namespace StudCalculator.Infrastructure.Calculations.ResultInViewModel
{
    public class ResultInViewModel
    {
        private double ResultFromGosts;

        private Dictionary<string, object> FromViewModel;
        private double FromResultGosts;


        public string ReturnFromLotsman(Dictionary<string, object> resultFromReceipt)
        {
            FromViewModel = resultFromReceipt;
            FromResultGosts = Convert.ToDouble(FromViewModel["B"]);

            double result = FromResultGosts + Convert.ToDouble(FromViewModel["inResultPNuts"]) * 2 * 2 +
                            Convert.ToDouble(FromViewModel["inResultHNuts"]) * 2 + 4 +
                            Convert.ToDouble(FromViewModel["ExecuteNonStandartGasket"]) +
                            Convert.ToDouble(FromViewModel["ExecuteOvalGasket"]) +
                            Convert.ToDouble(FromViewModel["ExecuteOctagonalGasket"]) +
                            Convert.ToDouble(FromViewModel["ExrcuteAtk2618593b"]) +
                            Convert.ToDouble(FromViewModel["ExrcuteAtk2618593bNonStandart"]) +
                            Convert.ToDouble(FromViewModel["ExecuteNonStandartWashers"]) +
                            Convert.ToDouble(FromViewModel["ExecuteStandartWashers"]) +
                            Convert.ToDouble(FromViewModel["ExecuteAtk242000290b"]) +
                            Convert.ToDouble(FromViewModel["ExrcuteAtk2618593bNonStandart"]);

            string diametricStud = FromViewModel["SelectedTheard"].ToString();

            ResultFromGosts = (Math.Round(Math.Round(result) / 10)) * 10;

            string resultChoese =
                $"Шпилька {FromViewModel["ExecutionStudFromCombobox"]}-[M, М]{diametricStud.Substring(1)}%[x, х]{ResultFromGosts}." +
                $"{FromViewModel["MaterialStudFromCombobox"]}% ОСТ 26-2040-96";

            string resultInMainWindows =
                $"Шпилька {FromViewModel["ExecutionStudFromCombobox"]}-М{diametricStud.Substring(1)}х{ResultFromGosts}." +
                $"{FromViewModel["MaterialStudFromCombobox"]} ОСТ 26-2040-96";


            if (FromViewModel["ExecutionStudFromCombobox"] != null &&
                FromViewModel["MaterialStudFromCombobox"] != null)
            {
                string resultInMainWindow = new DbModelsFromLotsman().ReturnFromLotsman(resultChoese);

                return resultInMainWindow == string.Empty ? resultInMainWindows : resultInMainWindow;
            }
            else
            {
                MessageBox.Show("Не все данные были введены", "Упс! Ошибочка", MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return "Вывод результатов...";
            }
        }
    }
}