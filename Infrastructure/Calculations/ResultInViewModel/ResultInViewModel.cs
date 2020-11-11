using System;
using System.Collections.Generic;
using System.Windows;
using StudCalculator.Data.DbModelsFromLotsman;

namespace StudCalculator.Infrastructure.Calculations.ResultInViewModel
{
    public class ResultInViewModel
    {
        private double _resultFromGosts;
        private Dictionary<string, object> _fromViewModel;
        private double _fromResultGosts;


        public string ReturnFromLotsman(Dictionary<string, object> resultFromReceipt)
        {
            try
            {
                _fromViewModel = resultFromReceipt;
                _fromResultGosts = Convert.ToDouble(_fromViewModel["B"]);

                double result = _fromResultGosts + Convert.ToDouble(_fromViewModel["inResultPNuts"]) * 2 * 2 +
                                Convert.ToDouble(_fromViewModel["inResultHNuts"]) * 2 + 4 +
                                Convert.ToDouble(_fromViewModel["ExecuteNonStandartGasket"]) +
                                Convert.ToDouble(_fromViewModel["ExecuteOvalGasket"]) +
                                Convert.ToDouble(_fromViewModel["ExecuteOctagonalGasket"]) +
                                Convert.ToDouble(_fromViewModel["ExrcuteAtk2618593b"]) +
                                Convert.ToDouble(_fromViewModel["ExrcuteAtk2618593bNonStandart"]) +
                                Convert.ToDouble(_fromViewModel["ExecuteNonStandartWashers"]) +
                                Convert.ToDouble(_fromViewModel["ExecuteStandartWashers"]) +
                                Convert.ToDouble(_fromViewModel["ExecuteAtk242000290b"]) +
                                Convert.ToDouble(_fromViewModel["ExrcuteAtk2618593bNonStandart"]);

                string diametricStud = _fromViewModel["SelectedTheard"].ToString();

                _resultFromGosts = (Math.Round(Math.Round(result) / 10)) * 10;

                string resultChoese =
                    $"Шпилька {_fromViewModel["ExecutionStudFromCombobox"]}-[M, М]{diametricStud.Substring(1)}%[x, х]{_resultFromGosts}." +
                    $"{_fromViewModel["MaterialStudFromCombobox"]}% ОСТ 26-2040-96";

                string resultInMainWindows =
                    $"Шпилька {_fromViewModel["ExecutionStudFromCombobox"]}-М{diametricStud.Substring(1)}х{_resultFromGosts}." +
                    $"{_fromViewModel["MaterialStudFromCombobox"]} ОСТ 26-2040-96";


                if (_fromViewModel["ExecutionStudFromCombobox"] != null &&
                    _fromViewModel["MaterialStudFromCombobox"] != null)
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
            catch (NullReferenceException)
            {
                MessageBox.Show("А кто это у нас не смотрит в ГОСТы?", "Упс! Ошибочка", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return "Вывод результатов...";
            }
        }
    }
}