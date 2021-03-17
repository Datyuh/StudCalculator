using System.Linq;

namespace StudCalculator.Data.DBWork
{
    public class DbExecutionGost33259
    {
        readonly DbModelFromVnmData.DbModelFromVnmData db = new();

        public double? ExecutionGost33259CE(string pn, string dn)
        {
            var executionGost33259CE =
               db.OGK_StudCalculator_Execution_All.Where(p => p.PN == pn && p.DN == dn).Select(p => p.h1).First();
            return executionGost33259CE;
        }

        public double? ExecutionGost33259DF(string pn, string dn)
        {
            var executionGost33259DF =
                db.OGK_StudCalculator_Execution_All.Where(p => p.PN == pn && p.DN == dn).Select(p => p.h2).First();
            return executionGost33259DF;
        }

        public double? ExecutionGost33259L(string pn, string dn)
        {
            var executionGost33259L =
                db.OGK_StudCalculator_Execution_All.Where(p => p.PN == pn && p.DN == dn).Select(p => p.h4).First();
            return executionGost33259L;
        }

        public double? ExecutionGost33259M(string pn, string dn)
        {
            var executionGost33259M =
               db.OGK_StudCalculator_Execution_All.Where(p => p.PN == pn && p.DN == dn).Select(p => p.h5).First();
            return executionGost33259M;
        }
    }
}