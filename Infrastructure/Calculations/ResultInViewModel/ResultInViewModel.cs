using System;
using System.Collections.Generic;
using StudCalculator.Data.DbModelsFromLotsman;
using StudCalculator.ViewModel;

namespace StudCalculator.Infrastructure.Calculations.ResultInViewModel
{
    public class ResultInViewModel
    {
        public double ResultFromGosts;

        public Dictionary<string, object> FromViewModel;
        public double FromResultGosts;


        public string ReturnFromLotsman(Dictionary<string, object> resultFromReceipt)
        {
            FromViewModel = resultFromReceipt;
            FromResultGosts = Convert.ToDouble(FromViewModel["result"]);
            string diametricStud = FromViewModel["SelectedTheard"].ToString();

            ResultFromGosts = (Math.Round(Math.Round(FromResultGosts) / 10)) * 10;

            var resultChoese =
                $"Шпилька {FromViewModel["ExecutionStudFromCombobox"]}-[M, М]{diametricStud.Substring(1)}%[x, х]{ResultFromGosts}." +
                $"{FromViewModel["MaterialStudFromCombobox"]}% ОСТ 26-2040-96";

            string resultInMainWindow = new DbModelsFromLotsman().ReturnFromLotsman(resultChoese);
            if (resultInMainWindow != string.Empty)
            {
                return resultInMainWindow;
            }
            else
            {
                string resultInMainWindows =
                    $"Шпилька {FromViewModel["ExecutionStudFromCombobox"]}-М{diametricStud.Substring(1)}х{ResultFromGosts}." +
                    $"{FromViewModel["MaterialStudFromCombobox"]} ОСТ 26-2040-96";
                return resultInMainWindows;
            }
        }
    }
}