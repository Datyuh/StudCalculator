using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    public class DbStudExtract
    {
        readonly DbModelFromVnmData.DbModelFromVnmData db = new();

        public ObservableCollection<string> ExtractMaterialStud()
        {
            var extractMaterialStud = new ObservableCollection<string>(db.OGK_StudCalculator_GOSTs.Select(p => p.Material_Stud).Where(p => p != null).Distinct());
            var extractSortMaterialStud = new ObservableCollection<string>(extractMaterialStud.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return extractSortMaterialStud;
        }

        public ObservableCollection<string> ExecutionStud()
        {
            var executionStud = new ObservableCollection<string>(db.OGK_StudCalculator_GOSTs.Select(p => p.Style_Stud).Where(p => p != null));
            var executionSortStud = new ObservableCollection<string>(executionStud.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()));
            return executionSortStud;
        }
    }
}