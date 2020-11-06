using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace StudCalculator.Data.DbModelsFromLotsman
{
    internal class DbModelsFromLotsman

    {
        ModelsFromLotsman.ModelsFromLotsman dbLotsman = new ModelsFromLotsman.ModelsFromLotsman();

        public string ReturnFromLotsman(string resultFromGosts)
        {
            try
            {
                var inResultInViewModel = from m in dbLotsman.stMain
                    join v in dbLotsman.stVersions on m.inId equals v.inIdMain
                    join a in dbLotsman.stAttributes on v.inId equals a.inIdVersion
                    join ta in dbLotsman.rlTypesAndAttributes on a.inIdTypeAttr equals ta.inId
                    join da in dbLotsman.dsAttributes on ta.inIdAttribute equals da.inId
                    join a1 in dbLotsman.stAttributes on v.inId equals a1.inIdVersion
                    join ta1 in dbLotsman.rlTypesAndAttributes on a1.inIdTypeAttr equals ta1.inId
                    join da1 in dbLotsman.dsAttributes on ta1.inIdAttribute equals da1.inId
                    where da1.stName == "Диаметр резьбы" && da.stName == "Наименование" &&
                          DbFunctions.Like(a.stValue, resultFromGosts) && m.inIdType == 2 && v.inIdState == 2
                    select new { Обозначение = m.stKeyAttr, Наименование = a.stValue };
                string resultTextEnter =
                    $"{inResultInViewModel.Select(p => p.Обозначение).First()} {inResultInViewModel.Select(s => s.Наименование).First()}";
                return resultTextEnter;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Проверьте правильно ли введены данные", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return string.Empty;
            }
        }
    }
}