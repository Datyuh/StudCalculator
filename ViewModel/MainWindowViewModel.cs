using StudCalculator.DBWork;
using StudCalculator.Infrastructure.Commands;
using StudCalculator.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StudCalculator.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Заголовок

        private string _Title = "Калькулятор шпилек";
        public string Title { get => _Title; set => Setref(ref _Title, value); }

        #endregion

        #region Работа с базой и вставка в ComboBox

        private ObservableCollection<string> _allGost;
        public ObservableCollection<string> AllGost { get => _allGost; set => Set(_allGost, value); }

        private string _selectionFromCombobox;
        public string SelectionFromCombobox
        {
            get => _selectionFromCombobox;
            set { Setref(ref _selectionFromCombobox, value); AddExecutionCombobox(_selectionFromCombobox); }
        }

        private ObservableCollection<string> _execGost33259 = new ObservableCollection<string>();
        public ObservableCollection<string> ExecGost33259 { get => _execGost33259; set => Set(_execGost33259, value); }

        private ObservableCollection<string> _executionPN33259 = new ObservableCollection<string>();
        public ObservableCollection<string> ExecutionPN33259 { get => _executionPN33259; set => Set(_executionPN33259, value); }

        private ObservableCollection<string> _executionDN33259 = new ObservableCollection<string>();
        public ObservableCollection<string> ExecutionDN33259 { get => _executionDN33259; set => Set(_executionDN33259, value); }

        private ObservableCollection<string> _executionType33259 = new ObservableCollection<string>();
        public ObservableCollection<string> ExecutionType33259 { get => _executionType33259; set => Set(_executionType33259, value); }

        #endregion

        #region Функции проверки установки флага в чекбоксах

        //Чекбокс для одинаковых нестандартных фланцев
        private bool _nonStandartSameFlangChecked;
        public bool NonStandartSameFlangChecked { get => _nonStandartSameFlangChecked; set => Setref(ref _nonStandartSameFlangChecked, value); }
        //Чекбокс для разных нестандартных фланцев
        private bool _nonStandartDifferentFlangeChecked;
        public bool NonStandartDifferentFlangeChecked { get => _nonStandartDifferentFlangeChecked; set => Setref(ref _nonStandartDifferentFlangeChecked, value); }
        //Чекбокс для стандартных заглушек
        private bool _standartPlugsChecked;
        public bool StandartPlugsChecked { get => _standartPlugsChecked; set => Setref(ref _standartPlugsChecked, value); }
        //Чекбокс для нестандартных заглушек
        private bool _nonStandartPlugsChecked;
        public bool NonStandartPlugsChecked { get => _nonStandartPlugsChecked; set => Setref(ref _nonStandartPlugsChecked, value); }

        #endregion

        #region Установка включение/отключение текстбоксов

        //Текстбокс для одинаковых нестандартных фланцев
        private bool _nonStandartFlTextIsEnabled;
        public bool NonStandartFlTextIsEnabled { get => _nonStandartFlTextIsEnabled; set => Setref(ref _nonStandartFlTextIsEnabled, value); }
        //Текстбокс для разных нестандартных фланцев
        private bool _nonStandartDifferentFlangeTexboxIsEnabled;
        public bool NonStandartDifferentFlangeTexboxIsEnabled { get => _nonStandartDifferentFlangeTexboxIsEnabled; set => Setref(ref _nonStandartDifferentFlangeTexboxIsEnabled, value); }
        //Текстбокс для нестандартных заглушек
        private bool _nonStandartPlugsTextboxEsInabled;
        public bool NonStandartPlugsTextboxIsEnabled { get => _nonStandartPlugsTextboxEsInabled; set => Setref(ref _nonStandartPlugsTextboxEsInabled, value); }

        #endregion

        #region Установка включение/отключение комбобоксов

        //Комбобокс стандартые заглушки и крышки Основной
        private bool _standartPlugsComboboxIsEnabled;
        public bool StandartPlugsComboboxIsEnabled { get => _standartPlugsComboboxIsEnabled; set => Setref(ref _standartPlugsComboboxIsEnabled, value); }
        //Комбобокс стандартные заглушки и крышки выбор исполнения
        private bool _standartPlugsExecutionComboboxIsEnabled;
        public bool StandartPlugsExecutionComboboxIsEnabled { get => _standartPlugsExecutionComboboxIsEnabled; set => Setref(ref _standartPlugsExecutionComboboxIsEnabled, value); }
        //Комбобокс выбор резьбы на гайки для нестандартных фланцев
        private bool _choeseNutsThreadComboboxIsEnable;
        public bool ChoeseNutsThreadComboboxIsEnable { get => _choeseNutsThreadComboboxIsEnable; set => Setref(ref _choeseNutsThreadComboboxIsEnable, value); }

        #endregion

        #region Установка включение/отключение чекбоксов

        //Чекбокс для одинаковых нестандартных фланцев
        private bool _nonStandartStandartSameFlangCheckedIsEnabled = true;
        public bool NonStandartStandartSameFlangCheckedIsEnabled { get => _nonStandartStandartSameFlangCheckedIsEnabled; set => Setref(ref _nonStandartStandartSameFlangCheckedIsEnabled, value); }
        //Чекбокс для разных нестандартных фланцев
        private bool _nonStandartStandartDifferentFlangCheckedIsEnabled = true;      
        public bool NonStandartStandartDifferentFlangCheckedIsEnabled { get => _nonStandartStandartDifferentFlangCheckedIsEnabled; set => Setref(ref _nonStandartStandartDifferentFlangCheckedIsEnabled, value); }
        //Чекбокс для стандартных заглушек
        private bool _standartPlugsCheckboxIsEnabled = true;
        public bool StandartPlugsCheckboxIsEnabled { get => _standartPlugsCheckboxIsEnabled; set => Setref(ref _standartPlugsCheckboxIsEnabled, value); }       
        //Чекбокс для нестандартных заглушек
        private bool _nonStandartPlugsCheckboxIsEnabled = true;
        public bool NonStandartPlugsCheckboxIsEnabled { get => _nonStandartPlugsCheckboxIsEnabled; set => Setref(ref _nonStandartPlugsCheckboxIsEnabled, value); }

        #endregion

        #region Считывание текста с текст боксов

        //Текстбокс для одинаковых нестандартных фланцев
        private string _nonStandartFlText;
        public string NonStandartFlText { get => _nonStandartFlText; set => Setref(ref _nonStandartFlText, value); }

        #endregion

        #region Команды

        #region Команды для нестандартных фланцев

        //Включение работы с нестандартными фланцами одинаковыми
        public ICommand NonStandartSameFlangeCommand { get; }
        private bool CanNonStandartSameFlangCommandExecute(object p) => true;

        private void OnNonStandartSameFlangCommandExecuted(object p)
        {
          if(NonStandartSameFlangChecked is true)
            {
                NonStandartFlTextIsEnabled = true;
                NonStandartStandartDifferentFlangCheckedIsEnabled = false;
                ChoeseNutsThreadComboboxIsEnable = true;
            }
            else
            {
                NonStandartFlTextIsEnabled = false;
                NonStandartStandartDifferentFlangCheckedIsEnabled = true;
                ChoeseNutsThreadComboboxIsEnable = false;
            }
        }
        //Включение работы с нестандартными фланцами разными
        public ICommand NonStandartDifferentFlangeCommand { get; }
        private bool CanNonStandartDifferentFlangeCommandExecute(object p) => true;

        private void OnNonStandartDifferentFlangeCommandExecuted(object p)
        {
            if (NonStandartDifferentFlangeChecked is true)
            {
                NonStandartDifferentFlangeTexboxIsEnabled = true;
                NonStandartStandartSameFlangCheckedIsEnabled = false;
                StandartPlugsCheckboxIsEnabled = false;
                NonStandartPlugsCheckboxIsEnabled = false;
                StandartPlugsChecked = false;
                NonStandartPlugsChecked = false;
                NonStandartPlugsTextboxIsEnabled = false;
                StandartPlugsComboboxIsEnabled = false;
                ChoeseNutsThreadComboboxIsEnable = true;
            }
            else
            {
                NonStandartDifferentFlangeTexboxIsEnabled = false;
                NonStandartStandartSameFlangCheckedIsEnabled = true;
                StandartPlugsCheckboxIsEnabled = true;
                NonStandartPlugsCheckboxIsEnabled = true;
                ChoeseNutsThreadComboboxIsEnable = false;
            }
        }

        #endregion

        #region Команды для заглушек и крышек

        public ICommand StandartPlugsCommand { get; }
        private bool CanStandartPlugsCommandExecute(object p) => true;
        
        private void OnStandartPlugsCommandExecuted(object p)
        {
           if(StandartPlugsChecked is true)
            {
                NonStandartPlugsCheckboxIsEnabled = false;
                StandartPlugsComboboxIsEnabled = true;
                StandartPlugsExecutionComboboxIsEnabled = true;
            }
            else
            {
                NonStandartPlugsCheckboxIsEnabled = true;
                StandartPlugsComboboxIsEnabled = false;
                StandartPlugsExecutionComboboxIsEnabled = false;
            }
        }

        public ICommand NonstandartPlugsCommand { get; }
        private bool CanNonstandartPlugsCommandExecute(object p) => true;
        
        private void OnNonstandartPlugsCommandExecuted(object p)
        {
           if(NonStandartPlugsChecked is true)
            {
                StandartPlugsCheckboxIsEnabled = false;
                NonStandartPlugsTextboxIsEnabled = true;
            }
            else
            {
                StandartPlugsCheckboxIsEnabled = true;
                NonStandartPlugsTextboxIsEnabled = false;
            }
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            _allGost = new DbWorkGost33259().DbGost33259();

            #region Вызов команд
            NonStandartSameFlangeCommand = new LambdaCommand(OnNonStandartSameFlangCommandExecuted, CanNonStandartSameFlangCommandExecute);
            NonStandartDifferentFlangeCommand = new LambdaCommand(OnNonStandartDifferentFlangeCommandExecuted, CanNonStandartDifferentFlangeCommandExecute);

            StandartPlugsCommand = new LambdaCommand(OnStandartPlugsCommandExecuted, CanStandartPlugsCommandExecute);
            NonstandartPlugsCommand = new LambdaCommand(OnNonstandartPlugsCommandExecuted, CanNonstandartPlugsCommandExecute);
            #endregion

        }


        private void AddExecutionCombobox(string allGosts)
        {
            #region Добавление данных в коллекцию из базы

            ObservableCollection<string> execGost33259Add = new DbWorkGost33259().ExecGost33259();
            ObservableCollection<string> execGost33259PNAdd = new DbWorkGost33259().ExecutionPN33259();
            ObservableCollection<string> execGost33259DNAdd = new DbWorkGost33259().ExecutionDN33259();
            ObservableCollection<string> execGost33259TypeAdd = new DbWorkGost33259().ExecutionType33259();

            #endregion

            if (allGosts == "ГОСТ 33259-2015 Ряд 1")
            {
                foreach (var item in execGost33259Add)
                    _execGost33259.Add(item);
                foreach (var item in execGost33259PNAdd)
                    _executionPN33259.Add(item);
                foreach (var item in execGost33259DNAdd)
                    _executionDN33259.Add(item);
                foreach (var item in execGost33259TypeAdd)
                    _executionType33259.Add(item);
            }
            else
            {
                _execGost33259.Clear();
                _executionPN33259.Clear();
                _executionDN33259.Clear();
                _executionType33259.Clear();
            }
        }
    }
}
