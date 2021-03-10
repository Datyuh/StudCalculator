using System;
using System.Collections.Generic;
using System.Windows;
using StudCalculator.Data.DbModelsFromLotsman;

namespace StudCalculator.Infrastructure.Calculations.ResultInViewModel
{
    public class ResultInViewModel
    {
        private double ResultFromGosts { get; set; }
        private Dictionary<string, object> FromViewModel { get; }
        private double FromResultGosts { get; set; }
        public string ReturnResultFromLotsman => ReturnFromLotsman();  
        private string DiametricStud { get; set; }

        public ResultInViewModel(Dictionary<string, object> resultFromReceipt)
        {
            FromViewModel = resultFromReceipt;
            FromResultGosts = Convert.ToDouble(FromViewModel["B"]); 
        }

        private string ReturnFromLotsman()
        {
            try
            {
                double result = FromResultGosts + Convert.ToDouble(FromViewModel["inResultPNuts"]) * 2 * 2 +
                                Convert.ToDouble(FromViewModel["inResultHNuts"]) * 2 + 4 +
                                //Convert.ToDouble(FromViewModel["ExecuteNonStandartGasket"]) +
                                Convert.ToDouble(FromViewModel["ExecuteOvalGasket"]) +
                                //Convert.ToDouble(FromViewModel["ExecuteOctagonalGasket"]) +
                                Convert.ToDouble(FromViewModel["ExrcuteAtk2618593b"]) +
                                //Convert.ToDouble(FromViewModel["ExrcuteAtk2618593bNonStandart"]) +
                                //Convert.ToDouble(FromViewModel["ExecuteNonStandartWashers"]) +
                                Convert.ToDouble(FromViewModel["ExecuteStandartWashers"]) +
                                Convert.ToDouble(FromViewModel["ExecuteAtk242000290b"]);
                                //Convert.ToDouble(FromViewModel["ExrcuteAtk2618593bNonStandart"]);
                
                DiametricStud = FromViewModel["SelectedTheard"].ToString();
                

                ResultFromGosts = (Math.Round(Math.Round(result) / 10)) * 10;

                string resultChoese =
                    $"Шпилька {FromViewModel["ExecutionStudFromCombobox"]}-[M, М]{DiametricStud.Substring(1)}%[x, х]{ResultFromGosts}%" +
                    $"{FromViewModel["MaterialStudFromCombobox"]}%[ОСТ, OCT] 26-2040-96";

                string resultInMainWindows =
                    $"Шпилька {FromViewModel["ExecutionStudFromCombobox"]}-М{DiametricStud.Substring(1)}х{ResultFromGosts}." +
                    $"{FromViewModel["MaterialStudFromCombobox"]}ОСТ 26-2040-96";


                if (FromViewModel["ExecutionStudFromCombobox"] != null &&
                    FromViewModel["MaterialStudFromCombobox"] != null)
                {
                    string resultInMainWindow = new DbModelsFromLotsman(resultChoese).ResultFromGost;

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