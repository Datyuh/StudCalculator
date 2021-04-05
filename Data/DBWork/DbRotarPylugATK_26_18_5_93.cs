using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    public class DbRotarPylugATK_26_18_5_93
    {
        readonly DbModelFromVnmData.DbModelFromVnmData _db = new();

        public ObservableCollection<string> ExecuteAtk_26_18_5_93()
        {
            var executeAtk2618593 = new ObservableCollection<string>(_db.OGK_StudCalculator_ATK_26_18_5_93.Select(p => p.Style)).Distinct().AsParallel();
            var executeSortAtk2618593 = new ObservableCollection<string>(executeAtk2618593.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortAtk2618593;
        }

        public double Executeb(string pn, string dn, string style)
        {
            try
            {
                var executedb = Convert.ToDouble(_db.OGK_StudCalculator_ATK_26_18_5_93.Where(p => p.PN == pn && p.DN == dn && p.Style == style).Select(p => p.b)
                    .First());
                return executedb;
            }
            catch (InvalidOperationException)
            {
                return double.NaN;
            }
        }
    }
}