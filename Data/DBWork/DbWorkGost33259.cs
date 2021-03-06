﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.Data.DBWork
{
    internal class DbWorkGost33259 : BaseViewModel
    {
        readonly DbModelFromVnmData.DbModelFromVnmData _db = new();
        
        public ObservableCollection<string> DbGost33259()
        {
            var allGosts = new ObservableCollection<string>(_db.OGK_StudCalculator_GOSTs.Where(p => p.GOST != "ГОСТ 33259-2015 Ряд 2").Select(p => p.GOST));
            return allGosts;
        }

        public ObservableCollection<string> ExecGost33259()
        {
            var execution33259 = new ObservableCollection<string>(_db.OGK_StudCalculator_GOSTs.Where(p => true).Select(p => p.Exec_GOST33259)); ;
            return execution33259;
        }

        public ObservableCollection<string> ExecutionPn33259()
        {
            var pn = new ObservableCollection<string>(_db.OGK_StudCalculator_Execution_All.Select(p => p.PN).Distinct());
            var pnSort = new ObservableCollection<string>(pn.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return pnSort;
        }

        public ObservableCollection<string> ExecutionDn33259()
        {
            var dn = new ObservableCollection<string>(_db.OGK_StudCalculator_Execution_All.Select(p => p.DN).Distinct());
            var dnSort = new ObservableCollection<string>(dn.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return dnSort;
        }

        public ObservableCollection<string> ExecutionType33259()
        {
            var typeGost33259 = new ObservableCollection<string>(_db.OGK_StudCalculator_GOSTs.Select(p => p.Style).Where(p => p == "Тип 11"));
            return typeGost33259;
        }

        public string ExecutionThicknessFlangeTheard1(string pn, string dn)
        {
            var executionThicknessFlangeTheard1 = _db.OGK_StudCalculator_Type_11.Where(p => p.PN == pn && p.DN == dn).Select(p => p.Thread_1).First().ToString();
            return executionThicknessFlangeTheard1;
        }

        public double ExecutionThicknessFlangeb1(string pn, string dn)
        {
            var executionThicknessFlangeb1 = Convert.ToDouble(_db.OGK_StudCalculator_Type_11.Where(p => p.PN == pn && p.DN == dn).Select(p => p.b_1).First());
            return executionThicknessFlangeb1;
        }

        public double ExecutionThicknessFlangen_type1(string pn, string dn)
        {
            var executionThicknessFlangenType1 = Convert.ToDouble(_db.OGK_StudCalculator_Type_11.Where(p => p.PN == pn && p.DN == dn).Select(p => p.n_type1).First());
            return executionThicknessFlangenType1;
        }
    }
}
