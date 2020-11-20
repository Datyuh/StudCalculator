using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    public class DbCapsAtk242000290
    {
        readonly DbModelFromVnmData db = new DbModelFromVnmData();

        public ObservableCollection<string> DbCapsCollection()
        {
            var allCaps = new ObservableCollection<string>(db.OGK_StudCalculator_GOSTs.Where(p => true).Select(p => p.Caps));
            return allCaps;
        }

        public ObservableCollection<string> ExecuteAtk24_200_02_90()
        {
            var executeAtk242000290 = new ObservableCollection<string>(db.OGK_StudCalculator_ATK_24_200_02_90.Select(p => p.Style)).Distinct();
            var executeSortAtk242000290 = new ObservableCollection<string>(executeAtk242000290.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortAtk242000290;
        }

        public double Executedb(string pn, string dn, string style)
        {
            try
            {
                var executeAtk242000290B = Convert.ToDouble(db.OGK_StudCalculator_ATK_24_200_02_90.Where(p => p.PN == pn && p.DN == dn && p.Style == style)
                    .Select(p => p.b).First());
                return executeAtk242000290B;
            }
            catch (InvalidOperationException)
            {
                return double.NaN;
            }
        }
    }
}