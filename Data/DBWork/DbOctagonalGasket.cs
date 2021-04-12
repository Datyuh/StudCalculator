using System;
using System.Linq;

namespace StudCalculator.Data.DBWork
{
    public class DbOctagonalGasket
    {
        readonly DbModelFromVnmData.DbModelFromVnmData _db = new();

        public double ExecutedOctogonalGasket(string pn, string dn)
        {
            var executedOctogonalGasket =
                Convert.ToDouble(_db.OGK_StudCalculator_Octagonal_Gasket.Where(p => p.PN == pn && p.DN == dn)
                    .Select(p => p.c).First());
            return executedOctogonalGasket;
        }
    }
}