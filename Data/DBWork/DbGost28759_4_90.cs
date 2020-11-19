using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    class DbGost28759_4_90
    {
        ApplicationContext db = new ApplicationContext();

        public ObservableCollection<string> ExecutePnCollection()
        {
            var executePnCollection = new ObservableCollection<string>(db.GOST_28759_4_90.Select(p => p.PN).Distinct().AsParallel());
            var executeSortPnCollection = new ObservableCollection<string>(executePnCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortPnCollection;
        }

        public ObservableCollection<string> ExecuteExecutionsCollection()
        {
            var executeExecutionsCollection = new ObservableCollection<string>(db.GOSTs.Select(p => p.Exec_GOST28759_4).Where(p => p != null)).AsParallel();
            var executeSortExecutionsCollection = new ObservableCollection<string>(executeExecutionsCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortExecutionsCollection;
        }

        public ObservableCollection<string> ExecuteDnCollection()
        {
            var executeDnCollection = new ObservableCollection<string>(db.GOST_28759_4_90.Select(p => p.DN)).Distinct().AsParallel();
            var executeSortDnCollection = new ObservableCollection<string>(executeDnCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortDnCollection;
        }

        public double ExecutedBFromGost28759490(string pn, string dn)
        {
            var executedBFromGost28759390 = Convert.ToDouble(db.GOST_28759_4_90.Where(p => p.PN == pn && p.DN == dn).Select(p => p.b).First());
            return executedBFromGost28759390;
        }

        public string ExecutionThicknessFlangeTheard(string pn, string dn)
        {
            var executionThicknessFlangeTheard = db.GOST_28759_4_90.Where(p => p.PN == pn && p.DN == dn).Select(p => p.Thread).First();
            return executionThicknessFlangeTheard;
        }

        public double ExecutionThicknessFlangeN(string pn, string dn)
        {
            var executionThicknessFlangenType1 = Convert.ToDouble(db.GOST_28759_4_90.Where(p => p.PN == pn && p.DN == dn).Select(p => p.n).First());
            return executionThicknessFlangenType1;
        }
    }
}
