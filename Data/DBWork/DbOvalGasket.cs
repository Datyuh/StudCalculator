using System;
using System.Linq;

namespace StudCalculator.Data.DBWork
{
    public class DbOvalGasket
    {
        readonly DbModelFromVnmData db = new DbModelFromVnmData();

        public double ExecutedOvalGasket(string pn, string dn)
        {
            var executedOvalGasket =
                Convert.ToDouble(db.OGK_StudCalculator_Oval_Gasket.Where(p => p.PN == pn && p.DN == dn).Select(p => p.c).First());
            return executedOvalGasket;
        }
    }
}