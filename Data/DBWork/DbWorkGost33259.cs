using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.Data.DBWork
{
    internal class DbWorkGost33259 : BaseViewModel
    {
        ApplicationContext db = new ApplicationContext();
        
        public ObservableCollection<string> DbGost33259()
        {
            var allGosts = new ObservableCollection<string>(db.GOSTs.Where(p => p.GOST != null && p.GOST != "ГОСТ 33259-2015 Ряд 2").Select(p => p.GOST).AsParallel());
            return allGosts;
        }

        public ObservableCollection<string> ExecGost33259()
        {
            var execution33259 = new ObservableCollection<string>(db.GOSTs.Where(p => p.Exec_GOST33259 != null).Select(p => p.Exec_GOST33259).AsParallel()); ;
            return execution33259;
        }

        public ObservableCollection<string> ExecutionPn33259()
        {
            //var PN = execution_All.Execution_All.GroupBy(p => p.PN).Where(p => p.Count() > 1).Select(p => p.Key).ToList(); 
            var pn = new ObservableCollection<string>(db.Execution_All.Select(p => p.PN).Distinct().AsParallel());
            var pn1 = new ObservableCollection<string>(pn.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return pn1;
        }

        public ObservableCollection<string> ExecutionDn33259()
        {
            //var DN = execution_All.Execution_All.GroupBy(p => p.DN).Where(p => p.Count() > 1).Select(p => p.Key).ToList();
            var dn = new ObservableCollection<string>(db.Execution_All.Select(p => p.DN).Distinct().AsParallel());
            var dn1 = new ObservableCollection<string>(dn.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return dn1;
        }

        public ObservableCollection<string> ExecutionType33259()
        {
            var typeGost33259 = new ObservableCollection<string>(db.GOSTs.Select(p => p.Style).Where(p => p == "Тип 11").AsParallel());
            return typeGost33259;
        }
    }
}
