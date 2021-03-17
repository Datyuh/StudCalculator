using System.Collections.ObjectModel;
using System.Linq;
using StudCalculator.Data.DBWork;

namespace StudCalculator.Model
{
    internal class InitializationData
    {
        public ObservableCollection<string> AllGost = new DbWorkGost33259().DbGost33259();
        public ObservableCollection<string> OstNutsCollection = new DbNutsOst26_2041_96().OstNutsCollection();
        public ObservableCollection<string> ExtractMaterialStud = new DbStudExtract().ExtractMaterialStud();
        public ObservableCollection<string> ExtractExecutionStud = new DbStudExtract().ExecutionStud();
       

        #region Чтобы не были пустые комбобоксы
    
        public string InitializationDataGost => AllGost.FirstOrDefault()!;
        public string InitializationDataOstNuts => OstNutsCollection.FirstOrDefault()!;
        public string InitializationDataExecutionStud => ExtractExecutionStud.FirstOrDefault()!;
        public string InitializationDataMaterialStud => ExtractMaterialStud.FirstOrDefault()!;

        #endregion

        public InitializationData()
        {
            
        }
    }
}
