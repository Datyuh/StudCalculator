using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using StudCalculator.Infrastructure.ChoiceUsersCheckBox;
using StudCalculator.Infrastructure.Commands;
using StudCalculator.Infrastructure.EnterUsersData;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.ViewModel
{
    internal class PlugAndCapsWindowViewModel : BaseViewModel
    {
        private EnterUsersPlugAndCaps _enterDataInComboBox = new();

        #region Функции проверки установки флага в Чекбоксах

        //Чекбокс для стандартных заглушек
        private bool _standartPlugsChecked;

        public bool StandartPlugsChecked { get => _standartPlugsChecked; set
            {
                Set(ref _standartPlugsChecked, value);
                ChoiceUsersStNotStPlugAndCaps.ChoiceUsersStPulgAndCaps = StandartPlugsChecked;
            }
        }

        //Чекбокс для нестандартных заглушек
        private bool _nonStandartPlugsChecked;
        public bool NonStandartPlugsChecked { get => _nonStandartPlugsChecked; set
            {
                Set(ref _nonStandartPlugsChecked, value);
                ChoiceUsersStNotStPlugAndCaps.ChoiceUsersNotStPlagAndCaps = NonStandartPlugsChecked;
            }
        }

        #endregion

        #region Установка включение/отключение Чекбоксов

        //Чекбокс для стандартных заглушек
        private bool _standartPlugsCheckboxIsEnabled = true;
        public bool StandartPlugsCheckboxIsEnabled { get => _standartPlugsCheckboxIsEnabled; set => Set(ref _standartPlugsCheckboxIsEnabled, value); }

        //Чекбокс для нестандартных заглушек
        private bool _nonStandartPlugsCheckboxIsEnabled = true;
        public bool NonStandartPlugsCheckboxIsEnabled { get => _nonStandartPlugsCheckboxIsEnabled; set => Set(ref _nonStandartPlugsCheckboxIsEnabled, value); }

        #endregion

        #region Установка включение/отключение комбобоксов

        //Комбобокс стандартные заглушки и крышки Основной
        private bool _standartPlugsComboboxIsEnabled;
        public bool StandartPlugsComboboxIsEnabled { get => _standartPlugsComboboxIsEnabled; set => Set(ref _standartPlugsComboboxIsEnabled, value); }

        //Комбобокс стандартные заглушки и крышки выбор исполнения
        private bool _standartPlugsExecutionComboboxIsEnabled;
        public bool StandartPlugsExecutionComboboxIsEnabled { get => _standartPlugsExecutionComboboxIsEnabled; set => Set(ref _standartPlugsExecutionComboboxIsEnabled, value); }

        #endregion

        #region Работа с базой крышек и заглушек

        //Выборка из базы норматива
        private ObservableCollection<string> _allCaps = new();

        public ObservableCollection<string> AllCaps { get => _allCaps; set => Set(ref _allCaps, value); }

        //Выборка из нормативов исполнений
        private ObservableCollection<string> _executePlugsCollection = new();
        public ObservableCollection<string> ExecutePlugsCollection { get => _executePlugsCollection; set
            {
                Set(ref _executePlugsCollection, value);
                StandartPlugsExecutionFromComboBox = ExecutePlugsCollection.FirstOrDefault();
            }
        }

        #endregion

        #region Получение значений с ComboBox

        //Получение значений для заглушек и крышек
        private string _standartPlugsFromComboBox;
        public string StandartPlugsFromComboBox { get => _standartPlugsFromComboBox; set
            {
                Set(ref _standartPlugsFromComboBox, value);
                EnterUsersPlugAndCaps.PlugAndCapsStAtkOrOst = StandartPlugsFromComboBox;
                ExecutePlugsCollection = _enterDataInComboBox.ExecutePlugsCollections();
            }
        }

        //Получение значений исполнения для заглушек и крышек
        private string _standartPlugsExecutionFromComboBox;
        public string StandartPlugsExecutionFromComboBox { get => _standartPlugsExecutionFromComboBox; set
            {
                Set(ref _standartPlugsExecutionFromComboBox, value);
                EnterUsersPlugAndCaps.PlugAndCapsStExecution = StandartPlugsExecutionFromComboBox;
            }
        }

        #endregion

        #region Считывание текста с текстбоксов

        //Текстбокс для нестандартных заглушек
        private bool _nonStandartPlugsTextboxEsInEnabled;
        public bool NonStandartPlugsTextboxIsEnabled { get => _nonStandartPlugsTextboxEsInEnabled;
            set => Set(ref _nonStandartPlugsTextboxEsInEnabled, value);
        }

        //Текстбокс для нестандартных заглушек и крышек
        private double? _nonStandartPlugsTextRead;
        public double? NonStandartPlugsTextRead { get => _nonStandartPlugsTextRead; set
            {
                Set(ref _nonStandartPlugsTextRead, value);
                EnterUsersPlugAndCaps.PlugAndCapsNonSt = NonStandartPlugsTextRead;
            }
        }

        //Текстбокс для кол-ва фланцев
        private double? _sumFlangeTextRead;

        public double? SumFlangeTextRead { get => _sumFlangeTextRead; set
            {
                Set(ref _sumFlangeTextRead, value);
                EnterUsersPlugAndCaps.SumFlangeTextRead = SumFlangeTextRead;
            }
        }

        #endregion

        #region Команды для заглушек и крышек

        public ICommand StandartPlugsCommand { get; }
        private bool CanStandartPlugsCommandExecute(object p) => true;

        private void OnStandartPlugsCommandExecuted(object p)
        {
            new ChoiceUsersStNotStPlugAndCaps().ChoicesUsersStPulgAndCaps();
            AllCaps = _enterDataInComboBox.AllCapsCollection();
            StandartPlugsFromComboBox = AllCaps.FirstOrDefault();
            NonStandartPlugsCheckboxIsEnabled = ChoiceUsersStNotStPlugAndCaps.NonStandartPlugsCheckboxIsEnabled;
            StandartPlugsComboboxIsEnabled = ChoiceUsersStNotStPlugAndCaps.StandartPlugsComboboxIsEnabled;
            StandartPlugsExecutionComboboxIsEnabled = ChoiceUsersStNotStPlugAndCaps.StandartPlugsExecutionComboboxIsEnabled;
        }

        public ICommand NonstandartPlugsCommand { get; }
        private bool CanNonstandartPlugsCommandExecute(object p) => true;

        private void OnNonstandartPlugsCommandExecuted(object p)
        {
            new ChoiceUsersStNotStPlugAndCaps().ChoicesUsersNotStPulgAndCaps();
            NonStandartPlugsTextboxIsEnabled = ChoiceUsersStNotStPlugAndCaps.NonStandartPlugsTextboxIsEnabled;
            StandartPlugsCheckboxIsEnabled = ChoiceUsersStNotStPlugAndCaps.StandartPlugsCheckboxIsEnabled;
        }

        #endregion

        public PlugAndCapsWindowViewModel()
        {
            //Нестандартные и стандартные заглушки и крышки
            StandartPlugsCommand = new LambdaCommand(OnStandartPlugsCommandExecuted, CanStandartPlugsCommandExecute);
            NonstandartPlugsCommand = new LambdaCommand(OnNonstandartPlugsCommandExecuted, CanNonstandartPlugsCommandExecute);
        }
    }
}
