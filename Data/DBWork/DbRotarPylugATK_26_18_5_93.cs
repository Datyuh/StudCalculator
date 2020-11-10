using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    public class DbRotarPylugATK_26_18_5_93
    {
        ApplicationContext db = new ApplicationContext();

        public ObservableCollection<string> ExecuteAtk_26_18_5_93()
        {
            var executeAtk2618593 = new ObservableCollection<string>(db.ATK_26_18_5_93.Select(p => p.Style)).Distinct().AsParallel();
            var executeSortAtk2618593 = new ObservableCollection<string>(executeAtk2618593.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortAtk2618593;
        }

        public double Executeb(string pn, string dn, string style)
        {
            try
            {
                var executedb = Convert.ToDouble(db.ATK_26_18_5_93.Where(p => p.PN == pn && p.DN == dn && p.Style == style).Select(p => p.b)
                    .First());
                return executedb;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Вы ввели неверные данные", "Упс!!!", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return 0;
            }
        }
    }
}