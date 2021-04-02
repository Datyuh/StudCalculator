using System.Collections.ObjectModel;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.ViewModel
{
    internal class StudWindowViewModel : BaseViewModel
    {

        //Выборка из базы материала шпилек
        private ObservableCollection<string> _extractMaterialStudCollection;
        public ObservableCollection<string> ExtractMaterialStud { get => _extractMaterialStudCollection; set => Set(ref _extractMaterialStudCollection, value); }

        //Выборка из базы исполнений шпилек
        private ObservableCollection<string> _extractExecutionStudCollection;
        public ObservableCollection<string> ExtractExecutionStud { get => _extractExecutionStudCollection; set => Set(ref _extractExecutionStudCollection, value); }

        #region Установка включение/отключение текстбоксов

        //Текстбокс для выставления количества шпилек
        private bool _numberOfNutsTextboxIsEnabled;
        public bool NumberOfNutsTextboxIsEnable { get => _numberOfNutsTextboxIsEnabled; set => Set(ref _numberOfNutsTextboxIsEnabled, value); }

        #endregion

        //Текстбокс для кол-ва шпилек
        private double? _sumStudTextRead;
        public double? SumStudTextRead { get => _sumStudTextRead; set => Set(ref _sumStudTextRead, value); }

        #region Получение значений с ComboBox

        //Получение значений исполнения шпилек
        private string _executionStudFromCombobox;
        public string ExecutionStudFromCombobox { get => _executionStudFromCombobox; set => Set(ref _executionStudFromCombobox, value); }

        //Получение значений для материала шпилек
        private string _materialStudFromCombobox;
        public string MaterialStudFromCombobox { get => _materialStudFromCombobox; set => Set(ref _materialStudFromCombobox, value); }

        #endregion
    }
}
