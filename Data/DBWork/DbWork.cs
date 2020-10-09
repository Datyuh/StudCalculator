using System.Collections.Generic;
using System.Linq;
using System;
using NaturalSort.Extension;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.DBWork
{
    internal class DbWork : BaseViewModel
    {
        

        internal List<string> _AllGost;
        internal List<string> _Exec_Gost33259;


        public List<string> AllGost { get => _AllGost; set => Set(ref _AllGost, value); }
        public List<string> Exec_Gost33259 { get => _Exec_Gost33259; set => Set(ref _Exec_Gost33259, value); }

        public DbWork()
        {
            ApplicationContext db = new ApplicationContext();
            _AllGost = db.GOSTs.Where(p => p.GOST != null && p.GOST != "ГОСТ 33259-2015 Ряд 2").Select(p => p.GOST).AsParallel().ToList();
            _Exec_Gost33259 = db.GOSTs.Where(p => p.Exec_GOST33259 != null).Select(p => p.Exec_GOST33259).AsParallel().ToList();
        }



        //public List<string> DbGost()
        //{  
        //    var _AllGosts = db.GOSTs.Where(p => p.GOST != null && p.GOST != "ГОСТ 33259-2015 Ряд 2").Select(p => p.GOST).AsParallel().ToList();
        //    return _AllGosts;            
        //}

        //public List<string> Exec_Gost33259()
        //{
        //    var Execution_33259 = db.GOSTs.Where(p => p.Exec_GOST33259 != null).Select(p => p.Exec_GOST33259).AsParallel().ToList();
        //    return Execution_33259;
        //}

        //public List<string> Execution_PN()
        //{
        //    //var PN = execution_All.Execution_All.GroupBy(p => p.PN).Where(p => p.Count() > 1).Select(p => p.Key).ToList(); 
        //    var PN = db.Execution_All.Select(p => p.PN).Distinct().AsParallel().ToList();
        //    var PN_1 = PN.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel().ToList();
        //    return PN_1;
        //}

        //public List<string> Execution_DN()
        //{
        //    //var DN = execution_All.Execution_All.GroupBy(p => p.DN).Where(p => p.Count() > 1).Select(p => p.Key).ToList();
        //    var DN = db.Execution_All.Select(p => p.DN).Distinct().AsParallel().ToList();
        //    var DN_1 = DN.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel().ToList();
        //    return DN_1;
        //}
        //public List<string> Execution_Type()
        //{
        //    var Type_GOST33259 = db.GOSTs.Select(p => p.Style).Where(p => p == "Тип 11").AsParallel().ToList();
        //    return Type_GOST33259;
        //}
    }
}
