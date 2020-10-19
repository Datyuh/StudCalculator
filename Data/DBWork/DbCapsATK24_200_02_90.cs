using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    public class DbCapsATK24_200_02_90
    {
        ApplicationContext db = new ApplicationContext();

        public ObservableCollection<string> DbCapsCollection()
        {
            var allCaps = new ObservableCollection<string>(db.GOSTs.Where(p => p.Caps != null).Select(p => p.Caps).AsParallel());
            return allCaps;
        }

        public ObservableCollection<string> ExecuteAtk24_200_02_90()
        {
            var executeAtk242000290 = new ObservableCollection<string>(db.ATK_24_200_02_90.Select(p=>p.Style)).Distinct().AsParallel();
            var executeSortAtk242000290 = new ObservableCollection<string>(executeAtk242000290.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortAtk242000290;
        }
    }
}