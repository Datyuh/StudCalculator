using System.Windows.Input;
using StudCalculator.Infrastructure.Commands;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.ViewModel
{
    internal class WashAndGasWindowViewModel : BaseViewModel
    {
        #region Функции проверки установки флага в Чекбоксах

        //Чекбокс для нестандартных толщина шайб
        private bool _standartThicknessWasherCheckboxChecked;
        public bool StandartThicknessWasherCheckboxChecked { get => _standartThicknessWasherCheckboxChecked; set => Set(ref _standartThicknessWasherCheckboxChecked, value); }

        //Чекбокс для стандартных шайб
        private bool _nonStandartThicknessWasherCheckboxChecked;
        public bool NonStandartThicknessWasherCheckboxChecked { get => _nonStandartThicknessWasherCheckboxChecked; set => Set(ref _nonStandartThicknessWasherCheckboxChecked, value); }

        //Чекбокс для овальных прокладок
        private bool _standartOvalGasketsCheckboxChecked;
        public bool StandartOvalGasketsCheckboxChecked { get => _standartOvalGasketsCheckboxChecked; set => Set(ref _standartOvalGasketsCheckboxChecked, value); }

        //Чекбокс для восьмигранных прокладок
        private bool _standartOctahedralGasketsCheckboxChecked;
        public bool StandartOctahedralGasketsCheckboxChecked { get => _standartOctahedralGasketsCheckboxChecked; set => Set(ref _standartOctahedralGasketsCheckboxChecked, value); }

        #endregion

        #region Установка включение/отключение Чекбоксов

        //Чекбокс для нестандартных шайб
        private bool _standartThicknessWasherCheckboxIsEnabled = true;
        public bool StandartThicknessWasherCheckboxIsEnabled { get => _standartThicknessWasherCheckboxIsEnabled; set => Set(ref _standartThicknessWasherCheckboxIsEnabled, value); }

        //Чекбокс для стандартных шайб
        private bool _nonStandartThicknessWasherCheckboxIsEnabled = true;
        public bool NonStandartThicknessWasherCheckboxIsEnabled { get => _nonStandartThicknessWasherCheckboxIsEnabled; set => Set(ref _nonStandartThicknessWasherCheckboxIsEnabled, value); }

        //Чекбокс для овальных прокладок
        private bool _standartOvalGasketsCheckboxIsEnabled = true;
        public bool StandartOvalGasketsCheckboxIsEnabled { get => _standartOvalGasketsCheckboxIsEnabled; set => Set(ref _standartOvalGasketsCheckboxIsEnabled, value); }

        //Чекбокс для восьмигранных прокладок
        private bool _standartOctahedralGasketsCheckboxIsEnabled = true;
        public bool StandartOctahedralGasketsCheckboxIsEnabled { get => _standartOctahedralGasketsCheckboxIsEnabled; set => Set(ref _standartOctahedralGasketsCheckboxIsEnabled, value); }

        #endregion

        #region Установка включение/отключение текстбоксов

        //Текстбокс для шайб
        private bool _nonThicknessWasherTextboxIsEnabled;
        public bool NonThicknessWasherTextboxIsEnabled { get => _nonThicknessWasherTextboxIsEnabled; set => Set(ref _nonThicknessWasherTextboxIsEnabled, value); }

        //Текстбокс для прокладок
        private bool _nonStandartGasketsTextboxIsEnabled = true;
        public bool NonStandartGasketsTextboxIsEnabled { get => _nonStandartGasketsTextboxIsEnabled; set => Set(ref _nonStandartGasketsTextboxIsEnabled, value); }

        #endregion

        #region Считывание текста с текстбоксов

        //Текстбокс для толщины шайб
        private double? _thicknessWasherTextRead;
        public double? ThicknessWasherTextRead { get => _thicknessWasherTextRead; set => Set(ref _thicknessWasherTextRead, value); }

        //Текстбокс для для толщины прокладок
        private double? _thicknessGasketTextRead;
        public double? ThicknessGasketTextRead { get => _thicknessGasketTextRead; set => Set(ref _thicknessGasketTextRead, value); }

        #endregion

        #region Команда для прокладок Овальных и Восьмигранных

        public ICommand StandartOvalGasketsCommand { get; }
        private bool CanStandartOvalGasketsCommandExecute(object p) => true;

        private void OnStandartOvalGasketsCommandExecuted(object p)
        {
        }

        public ICommand StandartOctahedralGasketsCommand { get; }
        private bool CanStandartOctahedralGasketsCommandExecute(object p) => true;

        private void OnStandartOctahedralGasketsCommandExecuted(object p)
        {
        }

        #endregion

        #region Команда для шайб

        public ICommand StandartThicknessWasherCommand { get; }
        private bool CanStandartThicknessWasherCommandExecute(object p) => true;

        private void OnStandartThicknessWasherCommandExecuted(object p)
        {
            NonStandartThicknessWasherCheckboxIsEnabled = !(StandartThicknessWasherCheckboxChecked is true);
        }

        public ICommand NonStandartThicknessWasherCommand { get; }
        private bool CanNonStandartThicknessWasherCommandExecute(object p) => true;

        private void OnNonStandartThicknessWasherCommandExecuted(object p)
        {
        }

        #endregion

        public WashAndGasWindowViewModel()
        {
            //Нестандартные и стандартные шайбы
            StandartThicknessWasherCommand = new LambdaCommand(OnStandartThicknessWasherCommandExecuted, CanStandartThicknessWasherCommandExecute);
            NonStandartThicknessWasherCommand = new LambdaCommand(OnNonStandartThicknessWasherCommandExecuted, CanNonStandartThicknessWasherCommandExecute);
            //Прокладки овальные и восьмигранные
            StandartOvalGasketsCommand = new LambdaCommand(OnStandartOvalGasketsCommandExecuted, CanStandartOvalGasketsCommandExecute);
            StandartOctahedralGasketsCommand = new LambdaCommand(OnStandartOctahedralGasketsCommandExecuted, CanStandartOctahedralGasketsCommandExecute);
        }
    }
}
