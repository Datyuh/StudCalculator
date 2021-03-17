using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    class DbAtk26_18_13_96
    {
        readonly DbModelFromVnmData.DbModelFromVnmData db = new();

        public ObservableCollection<string> ExecutePnCollection()
        {
            var executePnCollection = new ObservableCollection<string>(db.OGK_StudCalculator_ATK_26_18_13_96.Select(p => p.PN).Distinct());
            var executeSortPnCollection = new ObservableCollection<string>(executePnCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortPnCollection;
        }

        public ObservableCollection<string> ExecuteExecutionsCollectionForPlug()
        {
            var executeExecutionsCollection = new ObservableCollection<string>(db.OGK_StudCalculator_ATK_26_18_13_96.Select(p => p.Execution_Caps).Where(p => p != null).Distinct());
            var executeSortExecutionsCollection = new ObservableCollection<string>(executeExecutionsCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortExecutionsCollection;
        }

        public ObservableCollection<string> ExecuteExecutionsCollection()
        {
            var executeExecutionsCollection = new ObservableCollection<string>(db.OGK_StudCalculator_GOSTs.Select(p => p.Exec_ATK_26_18_13_96).Where(p => p != null));
            var executeSortExecutionsCollection = new ObservableCollection<string>(executeExecutionsCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortExecutionsCollection;
        }

        public ObservableCollection<string> ExecuteDnCollection()
        {
            var executeDnCollection = new ObservableCollection<string>(db.OGK_StudCalculator_ATK_26_18_13_96.Select(p => p.DN)).Distinct();
            var executeSortDnCollection = new ObservableCollection<string>(executeDnCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortDnCollection;
        }

        public double ExecutionThicknessFlangeB(string pn, string dn)
        {
            var executionThicknessFlangeB = Convert.ToDouble(db.OGK_StudCalculator_ATK_26_18_13_96.Where(p => p.PN == pn && p.DN == dn).Select(p => p.b).First());
            return executionThicknessFlangeB;
        }

        public double ExecutionGost26181396H1(string pn, string dn)
        {
            var executionThicknessFlangeB = Convert.ToDouble(db.OGK_StudCalculator_ATK_26_18_13_96.Where(p => p.PN == pn && p.DN == dn).Select(p => p.h1).First());
            return executionThicknessFlangeB;
        }

        public double ExecutionGost26181396H2(string pn, string dn)
        {
            var executionThicknessFlangeB = Convert.ToDouble(db.OGK_StudCalculator_ATK_26_18_13_96.Where(p => p.PN == pn && p.DN == dn).Select(p => p.h2).First());
            return executionThicknessFlangeB;
        }

        public double ExecutionThicknessFlangeN(string pn, string dn)
        {
            var executionThicknessFlangeB = Convert.ToDouble(db.OGK_StudCalculator_ATK_26_18_13_96.Where(p => p.PN == pn && p.DN == dn).Select(p => p.n).First());
            return executionThicknessFlangeB;
        }

        public string ExecutionThicknessFlangeTheard(string pn, string dn)
        {
            var executionThicknessFlangeB = db.OGK_StudCalculator_ATK_26_18_13_96.Where(p => p.PN == pn && p.DN == dn).Select(p => p.Thread).First();
            return executionThicknessFlangeB;
        }
    }
}
