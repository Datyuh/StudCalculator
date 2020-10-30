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

        //Result_Choese = ("Шпилька " + Style_Stud + "-" + "[M, М]" + self.Threads_non_st[1:3] + (
        //"%[x, х]" + str(Result_Fl) + "." + Material_Stud) + " ОСТ 26-2040-96")

        public ResultInViewModel(Dictionary<string, object> resultFromReceipt)
        {
            FromViewModel = resultFromReceipt;
            FromResultGosts = Convert.ToDouble(FromViewModel["result"]);
            string diametricStud = FromViewModel["SelectedTheard"].ToString();

            ResultFromGosts = Math.Round(FromResultGosts);

            var resultChoese =
                $"Шпилька {FromViewModel["ExecutionStudFromCombobox"]}-[M, М]{diametricStud.Substring(1)}%[x, х]{FromResultGosts}.{FromViewModel["MaterialStudFromCombobox"]}% ОСТ 26-2040-96";
            new DbModelsFromLotsman(resultChoese);
            

        }
    }
}