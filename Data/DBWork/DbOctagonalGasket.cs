using System;
using System.Linq;

namespace StudCalculator.Data.DBWork
{
    public class DbOctagonalGasket
    {
        ApplicationContext db = new ApplicationContext();

        public double ExecutedOctogonalGasket(string pn, string dn)
        {
            var executedOctogonalGasket =
                Convert.ToDouble(db.Octagonal_Gasket.Where(p => p.PN == pn && p.DN == dn).Select(p => p.c).AsParallel());
            return executedOctogonalGasket;
        }
    }
}