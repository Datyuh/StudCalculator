using System.Collections.ObjectModel;
using System.Linq;
using StudCalculator.Data.DBWork;

namespace StudCalculator.Model
{
    internal class InitializationData
    {
        public readonly DbWorkGost33259 AllGost = new();
        public readonly DbNutsOst26_2041_96 OstNutsCollection = new();
        public readonly DbStudExtract ExtractMaterialAndExecutionStud = new();
       
        public InitializationData()
        {
            
        }
    }
}
