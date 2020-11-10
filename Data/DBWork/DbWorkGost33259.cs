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
            var pn = new ObservableCollection<string>(db.Execution_All.Select(p => p.PN).Distinct().AsParallel());
            var pnSort = new ObservableCollection<string>(pn.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return pnSort;
        }

        public ObservableCollection<string> ExecutionDn33259()
        {
            var dn = new ObservableCollection<string>(db.Execution_All.Select(p => p.DN).Distinct().AsParallel());
            var dnSort = new ObservableCollection<string>(dn.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return dnSort;
        }

        public ObservableCollection<string> ExecutionType33259()
        {
            var typeGost33259 = new ObservableCollection<string>(db.GOSTs.Select(p => p.Style).Where(p => p == "Тип 11").AsParallel());
            return typeGost33259;
        }

        public string ExecutionThicknessFlangeTheard1(string pn, string dn)
        {
            var executionThicknessFlangeTheard1 = db.Type_11.Where(p => p.PN == pn && p.DN == dn).Select(p => p.Thread_1).First().ToString();
            return executionThicknessFlangeTheard1;
        }

        public double ExecutionThicknessFlangeb1(string pn, string dn)
        {
            var executionThicknessFlangeb1 = Convert.ToDouble(db.Type_11.Where(p => p.PN == pn && p.DN == dn).Select(p => p.b_1).First());
            return executionThicknessFlangeb1;
        }

        public double ExecutionThicknessFlangen_type1(string pn, string dn)
        {
            var executionThicknessFlangenType1 = Convert.ToDouble(db.Type_11.Where(p => p.PN == pn && p.DN == dn).Select(p => p.n_type1).First());
            return executionThicknessFlangenType1;
        }
    }
}
