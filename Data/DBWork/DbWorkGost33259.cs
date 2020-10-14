using System.Collections.Generic;
using System.Linq;
using System;
using NaturalSort.Extension;
using StudCalculator.ViewModel.Base;
using System.Collections.ObjectModel;

namespace StudCalculator.DBWork
{
    internal class DbWorkGost33259 : BaseViewModel
    {
        ApplicationContext db = new ApplicationContext();
        public DbWorkGost33259()
        {
                  
        }

        public ObservableCollection<string> DbGost33259()
        {
            var _AllGosts = new ObservableCollection<string>(db.GOSTs.Where(p => p.GOST != null && p.GOST != "ГОСТ 33259-2015 Ряд 2").Select(p => p.GOST).AsParallel());
            return _AllGosts;
        }

        public ObservableCollection<string> ExecGost33259()
        {
            var Execution_33259 = new ObservableCollection<string>(db.GOSTs.Where(p => p.Exec_GOST33259 != null).Select(p => p.Exec_GOST33259).AsParallel()); ;
            return Execution_33259;
        }

        public ObservableCollection<string> ExecutionPN33259()
        {
            //var PN = execution_All.Execution_All.GroupBy(p => p.PN).Where(p => p.Count() > 1).Select(p => p.Key).ToList(); 
            var PN = new ObservableCollection<string>(db.Execution_All.Select(p => p.PN).Distinct().AsParallel());
            var PN_1 = new ObservableCollection<string>(PN.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return PN_1;
        }

        public ObservableCollection<string> ExecutionDN33259()
        {
            //var DN = execution_All.Execution_All.GroupBy(p => p.DN).Where(p => p.Count() > 1).Select(p => p.Key).ToList();
            var DN = new ObservableCollection<string>(db.Execution_All.Select(p => p.DN).Distinct().AsParallel());
            var DN_1 = new ObservableCollection<string>(DN.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return DN_1;
        }

        public ObservableCollection<string> ExecutionType33259()
        {
            var Type_GOST33259 = new ObservableCollection<string>(db.GOSTs.Select(p => p.Style).Where(p => p == "Тип 11").AsParallel());
            return Type_GOST33259;
        }
    }
}
