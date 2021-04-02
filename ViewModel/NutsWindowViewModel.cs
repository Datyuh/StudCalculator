using System.Collections.ObjectModel;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.ViewModel
{
    internal class NutsWindowViewModel : BaseViewModel
    {
        #region Adding nut data to the ComboBox

        //Выборка из базы нормативной документации
        private ObservableCollection<string> _ostNutsCollection;
        public ObservableCollection<string> OstNutsCollection { get => _ostNutsCollection; set => Set(ref _ostNutsCollection, value); }

        //Выборка из базы резьб
        private ObservableCollection<string> _extractNutsCollection;
        public ObservableCollection<string> ExtractNutsCollection { get => _extractNutsCollection; set => Set(ref _extractNutsCollection, value); }

        #endregion

        #region Getting values from a ComboBox

        //Получение значений ОСТа на гайки
        private string _ostNutsFromComboBox;
        public string OstNutsFromComboBox { get => _ostNutsFromComboBox; set => Set(ref _ostNutsFromComboBox, value); }

        //Получение значений резьбы для шайб
        private string _threadNutsFromComboBox;
        public string ThreadNutsFromComboBox { get => _threadNutsFromComboBox; set => Set(ref _threadNutsFromComboBox, value); }

        #endregion

        #region Installing enabling/disabling comboboxes

        //Комбобокс выбор резьбы на гайки для нестандартных фланцев
        private bool _choeseNutsThreadComboboxIsEnabled;
        public bool ChoeseNutsThreadComboboxIsEnabled { get => _choeseNutsThreadComboboxIsEnabled; set => Set(ref _choeseNutsThreadComboboxIsEnabled, value); }

        #endregion
    }
}
