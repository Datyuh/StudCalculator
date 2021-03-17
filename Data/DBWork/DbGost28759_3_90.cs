using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    class DbGost28759_3_90
    {
        readonly DbModelFromVnmData.DbModelFromVnmData db = new();

        public ObservableCollection<string> ExecutePnCollection()
        {
            var executePnCollection = new ObservableCollection<string>(db.OGK_StudCalculator_GOST_28759_3_90.Select(p => p.PN).Where(p => p != null).Distinct());
            var executeSortPnCollection = new ObservableCollection<string>(executePnCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortPnCollection;
        }

        public ObservableCollection<string> ExecuteExecutionsCollection()
        {
            var executeExecutionsCollection = new ObservableCollection<string>(db.OGK_StudCalculator_GOSTs.Select(p => p.Exec_GOST28759_3).Where(p => p != null));
            var executeSortExecutionsCollection = new ObservableCollection<string>(executeExecutionsCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortExecutionsCollection;
        }

        public ObservableCollection<string> ExecuteDnCollection()
        {
            var executeDnCollection = new ObservableCollection<string>(db.OGK_StudCalculator_GOST_28759_3_90.Select(p => p.DN).Where(p => p != null).Distinct());
            var executeSortDnCollection = new ObservableCollection<string>(executeDnCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortDnCollection;
        }

        public double ExecutedBFromGost28759390(string pn, string dn)
        {
            var executedBFromGost28759390 = Convert.ToDouble(db.OGK_StudCalculator_GOST_28759_3_90.Where(p => p.PN == pn && p.DN == dn).Select(p => p.b).First());
            return executedBFromGost28759390;
        }

        public string ExecutionThicknessFlangeTheard(string pn, string dn)
        {
            var executionThicknessFlangeTheard = db.OGK_StudCalculator_GOST_28759_3_90.Where(p => p.PN == pn && p.DN == dn).Select(p => p.Thread).First();
            return executionThicknessFlangeTheard;
        }

        public double ExecutionThicknessFlangeN(string pn, string dn)
        {
            var executionThicknessFlangenType1 = Convert.ToDouble(db.OGK_StudCalculator_GOST_28759_3_90.Where(p => p.PN == pn && p.DN == dn).Select(p => p.n).First());
            return executionThicknessFlangenType1;
        }
    }
}
