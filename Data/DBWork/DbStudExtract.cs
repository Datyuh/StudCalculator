﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    public class DbStudExtract
    {
        ApplicationContext db = new ApplicationContext();

        public ObservableCollection<string> ExtractMaterialStud()
        {
            var extractMaterialStud = new ObservableCollection<string>(db.GOSTs.Select(p => p.Material_Stud)).Distinct().AsParallel();
            var extractSortMaterialStud = new ObservableCollection<string>(extractMaterialStud.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return extractSortMaterialStud;
        }

        public ObservableCollection<string> ExecutionStud()
        {
            var executionStud = new ObservableCollection<string>(db.GOSTs.Select(p => p.Style_Stud).Where(p => p != null)).AsParallel();
            var executionSortStud = new ObservableCollection<string>(executionStud.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return executionSortStud;
        }
    }
}