using System;
using System.Collections.ObjectModel;
using System.Linq;
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
    }
}