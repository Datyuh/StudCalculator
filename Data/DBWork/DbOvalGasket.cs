using System;
using System.Linq;

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
            catch (InvalidOperationException)
            {
                return double.NaN;
            }
        }
    }
}