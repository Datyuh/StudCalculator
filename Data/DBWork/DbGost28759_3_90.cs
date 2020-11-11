using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    class DbGost28759_3_90
    {
        ApplicationContext db = new ApplicationContext();

        public ObservableCollection<string> ExecutePnCollection()
        {
            var executePnCollection = new ObservableCollection<string>(db.GOST_28759_3_90.Select(p => p.PN).Where(p => p != null).Distinct());
            var executeSortPnCollection = new ObservableCollection<string>(executePnCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortPnCollection;
        }

        public ObservableCollection<string> ExecuteExecutionsCollection()
        {
            var executeExecutionsCollection = new ObservableCollection<string>(db.GOSTs.Select(p => p.Exec_GOST28759_3).Where(p => p != null));
            var executeSortExecutionsCollection = new ObservableCollection<string>(executeExecutionsCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortExecutionsCollection;
        }

        public ObservableCollection<string> ExecuteDnCollection()
        {
            var executeDnCollection = new ObservableCollection<string>(db.GOST_28759_3_90.Select(p => p.DN).Where(p => p != null).Distinct());
            var executeSortDnCollection = new ObservableCollection<string>(executeDnCollection.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executeSortDnCollection;
        }
    }
}
