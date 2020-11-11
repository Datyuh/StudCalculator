using System;
using System.Collections.ObjectModel;
using System.Linq;
using NaturalSort.Extension;

namespace StudCalculator.Data.DBWork
{
    public class DbNutsOst26_2041_96
    {
        ApplicationContext db = new ApplicationContext();

        public ObservableCollection<string> ExtractOst26_2041_96()
        {
            var extractOst26204196 = new ObservableCollection<string>(db.OST_26_2041_96.Select(p => p.Thread)).Distinct().AsParallel();
            var extractSortOst26204196 = new ObservableCollection<string>(extractOst26204196.OrderBy(p => p, StringComparison.OrdinalIgnoreCase.WithNaturalSort()).AsParallel());
            return extractSortOst26204196;
        }

        public ObservableCollection<string> OstNutsCollection()
        {
            var ostNutsCollection = new ObservableCollection<string>(db.GOSTs.Select(p => p.Nuts).Where(p=> p != null && p != "ОСТ 26-2038-96").AsParallel());
            return ostNutsCollection;
        }

        public double ExtractThicknessPLarge(string thread)
        {
            switch (thread)
            {
                case null:
                    return double.NaN;
                default:
                {
                    var extractThicknessPLarge = Convert.ToDouble(db.OST_26_2041_96.Where(p => p.Thread == thread).Select(p => p.Р_Large).First());
                    return extractThicknessPLarge;
                }
            }
        }

        public double ExtractThicknessHLarge(string thread)
        {
            switch (thread)
            {
                case null:
                    return double.NaN;
                default:
                {
                    var extractThicknessHLarge =
                        Convert.ToDouble(db.OST_26_2041_96.Where(p => p.Thread == thread).Select(p => p.H).First());
                    return extractThicknessHLarge;
                }
            }
        }
    }
}