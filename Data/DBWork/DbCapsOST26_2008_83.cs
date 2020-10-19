using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    public class DbCapsOST26_2008_83
    {
        ApplicationContext db = new ApplicationContext();

        public ObservableCollection<string> ExecuteOst26_2008_83()
        {
            var executeOst26200883 = new ObservableCollection<string>(db.OST26_2008_83.Select(p => p.Figure)).Distinct().AsParallel();
            var executeSortOst26200883 = new ObservableCollection<string>(executeOst26200883.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortOst26200883;
        }
    }
}