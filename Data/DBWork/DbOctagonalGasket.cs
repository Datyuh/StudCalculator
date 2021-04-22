using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace StudCalculator.Data.DBWork
{
    public class DbOctagonalGasket
    {
        readonly DbModelFromVnmData.DbModelFromVnmData _db = new();

        public double ExecutedOctogonalGasket(string pn, string dn)
        {
            try
            {
                var executedOctogonalGasket =
                Convert.ToDouble(_db.OGK_StudCalculator_Octagonal_Gasket.Where(p => p.PN == pn && p.DN == dn)
                    .Select(p => p.c).First());
                return executedOctogonalGasket;
            }
            catch (Exception)
            {
                return double.NaN;
            }
        }

        public ObservableCollection<object> OctagonalGasketsCollection()
        {
            var octagonalGasketsCollection = new ObservableCollection<object>(_db.OGK_StudCalculator_Octagonal_Gasket.Select(p => p).Where(p => p != null));
            return octagonalGasketsCollection;
        }
    }
}