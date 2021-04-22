using System;
using System.Collections.ObjectModel;
using System.Linq;
using StudCalculator.Data.Models;

namespace StudCalculator.Data.DBWork
{
    public class DbOvalGasket
    {
        readonly DbModelFromVnmData.DbModelFromVnmData _db = new();

        public double ExecutedOvalGasket(string pn, string dn)
        {
            try
            {
                var executedOvalGasket =
                    Convert.ToDouble(_db.OGK_StudCalculator_Oval_Gasket.Where(p => p.PN == pn && p.DN == dn).Select(p => p.c).First());
                return executedOvalGasket;
            }
            catch (Exception)
            {
                return double.NaN;
            }
        }

        public ObservableCollection<object> OvalGasketsCollection()
        {
            var ovalGasketsCollection = new ObservableCollection<object>(_db.OGK_StudCalculator_Oval_Gasket.Select(p => p).Where(p => p != null));
            return ovalGasketsCollection;
        }
    }
}