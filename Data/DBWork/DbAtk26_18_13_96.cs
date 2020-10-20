using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    class DbAtk26_18_13_96
    {
        ApplicationContext db = new ApplicationContext();

        public ObservableCollection<string> ExecutePnCollection()
        {
            var executePnCollection = new ObservableCollection<string>(db.ATK_26_18_13_96.Select(p => p.PN).Distinct().AsParallel());
            var executeSortPnCollection = new ObservableCollection<string>(executePnCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortPnCollection;
        }

        public ObservableCollection<string> ExecuteExecutionsCollection()
        {
            var executeExecutionsCollection = new ObservableCollection<string>(db.GOSTs.Select(p => p.Exec_ATK_26_18_13_96).Where(p => p != null)).AsParallel();
            var executeSortExecutionsCollection = new ObservableCollection<string>(executeExecutionsCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortExecutionsCollection;
        }

        public ObservableCollection<string> ExecuteExecutionsForCapsCollection()
        {
            var executeExecutionsForCapsCollection = new ObservableCollection<string>(db.GOSTs.Select(p => p.Exec_ATK_26_18_13_96_Caps).Where(p => p != null)).AsParallel();
            var executeSortExecutionsForCapsCollection = new ObservableCollection<string>(executeExecutionsForCapsCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortExecutionsForCapsCollection;
        }

        public ObservableCollection<string> ExecuteDnCollection()
        {
            var executeDnCollection = new ObservableCollection<string>(db.ATK_26_18_13_96.Select(p => p.DN)).Distinct().AsParallel();
            var executeSortDnCollection = new ObservableCollection<string>(executeDnCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executeSortDnCollection;
        }
    }
}
