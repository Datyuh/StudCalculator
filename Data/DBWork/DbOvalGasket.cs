using System;
using System.Linq;

namespace StudCalculator.Data.DBWork
{
    public class DbOvalGasket
    {
        ApplicationContext db = new ApplicationContext();

        public double ExecutedOvalGasket(string pn, string dn)
        {
            var executedOvalGasket =
                Convert.ToDouble(db.Oval_Gasket.Where(p => p.PN == pn && p.DN == dn).Select(p => p.c).AsParallel());
            return executedOvalGasket;
        }
    }
}