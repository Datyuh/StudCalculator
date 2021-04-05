using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using StudCalculator.Infrastructure.ChoiceUsersCheckBox;
using StudCalculator.Infrastructure.Commands;
using StudCalculator.Infrastructure.EnterUsersData;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.ViewModel
{
    class RotarPlugWindowViewModel : BaseViewModel
    {
        //Получение значений для заглушек поворотных
        private string _standartRotaryPlugFromComboBox;
        public string StandartRotaryPlugFromComboBox { get => _standartRotaryPlugFromComboBox; set
            {
                Set(ref _standartRotaryPlugFromComboBox, value);
                EnterUsrsRotaryPlug.RotaryPlugSt = StandartRotaryPlugFromComboBox;
            }
        }

        //Комбобокс стандартные заглушки поворотные выбор исполнения
        private bool _standartRotaryPlugsComboboxIsEnabled;
        public bool StandartRotaryPlugsComboboxIsEnabled { get => _standartRotaryPlugsComboboxIsEnabled;
            set => Set(ref _standartRotaryPlugsComboboxIsEnabled, value);
        }

        //Текстбокс для нестандартных заглушек поворотных
        private double? _nonStandartRotaryPlugsTextRead;
        public double? NonStandartRotaryPlugsTextRead
        { get => _nonStandartRotaryPlugsTextRead; set
            {
                Set(ref _nonStandartRotaryPlugsTextRead, value);
                EnterUsrsRotaryPlug.RotaryPlugNonSt = NonStandartRotaryPlugsTextRead;
            }
        }

        //Текстбокс для заглушек поворотных
        private bool _nonstandartRotaryPlugsTextboxIsEnabled;
        public bool NonStandartRotaryPlugsTextboxIsEnabled { get => _nonstandartRotaryPlugsTextboxIsEnabled;
            set => Set(ref _nonstandartRotaryPlugsTextboxIsEnabled, value);
        }
        
        #region Работа с базой заглушек поворотных

        //Выборка из базы Исполнений заглушек поворотных
        private ObservableCollection<string> _executeRotaryPlugsCollection = new();
        public ObservableCollection<string> ExecuteRotaryPlugsCollection { get => _executeRotaryPlugsCollection;
            set => Set(ref _executeRotaryPlugsCollection, value);
        }

        #endregion

        #region Функции проверки установки флага в Чекбоксах

        //Чекбокс для стандартных заглушек поворотных
        private bool _standartRotaryPlugsChecked;
        public bool StandartRotaryPlugsChecked { get => _standartRotaryPlugsChecked; set
            {
                Set(ref _standartRotaryPlugsChecked, value);
                ChoiceUsersStOrNotStRotPlug.ChoiceUsersStRotPlug = StandartRotaryPlugsChecked;
            }
        }

        //Чекбокс для нестандартных заглушек поворотных
        private bool _nonstandartRotaryPlugsChecked;
        public bool NonStandartRotaryPlugsChecked { get => _nonstandartRotaryPlugsChecked; set
            {
                Set(ref _nonstandartRotaryPlugsChecked, value);
                ChoiceUsersStOrNotStRotPlug.ChoiceUsersNotStRotPlug = NonStandartRotaryPlugsChecked;
            }
        }

        #endregion

        #region Установка включение/отключение Чекбоксов

        //Чекбокс для стандартных заглушек поворотных
        private bool _standartRotaryPlugsCheckboxIsEnabled = true;
        public bool StandartRotaryPlugsCheckboxIsEnabled { get => _standartRotaryPlugsCheckboxIsEnabled;
            set => Set(ref _standartRotaryPlugsCheckboxIsEnabled, value);
        }

        //Чекбокс для нестандартных заглушек поворотных
        private bool _nonstandartRotaryPlugsCheckboxIsEnabled = true;
        public bool NonStandartRotaryPlugsCheckboxIsEnabled { get => _nonstandartRotaryPlugsCheckboxIsEnabled;
            set => Set(ref _nonstandartRotaryPlugsCheckboxIsEnabled, value);
        }

        #endregion

        #region Команды для заглушек поворотных

        public ICommand StandartRotaryPlugsCommand { get; }
        private bool CanStandartRotaryPlugsCommandExecute(object p) => true;

        private void OnStandartRotaryPlugsCommandExecuted(object p)
        {
            new ChoiceUsersStOrNotStRotPlug().CheckedUsersChoiceChBoxStRot();
            ExecuteRotaryPlugsCollection = new EnterUsrsRotaryPlug().RotaryPlugsStFromBase();
            StandartRotaryPlugFromComboBox = ExecuteRotaryPlugsCollection.FirstOrDefault();
            NonStandartRotaryPlugsCheckboxIsEnabled = ChoiceUsersStOrNotStRotPlug.NonStandartRotaryPlugsCheckboxIsEnabled;
            StandartRotaryPlugsComboboxIsEnabled = ChoiceUsersStOrNotStRotPlug.StandartRotaryPlugsComboboxIsEnabled;
        }

        public ICommand NonStandartRotaryPlugsCommand { get; }
        private bool CanNonStandartRotaryPlugsCommandExecute(object p) => true;

        private void OnNonStandartRotaryPlugsCommandExecuted(object p)
        {
            new ChoiceUsersStOrNotStRotPlug().CheckedUsersChoiceChBoxNotRot();
            NonStandartRotaryPlugsTextboxIsEnabled = ChoiceUsersStOrNotStRotPlug.NonStandartRotaryPlugsTextboxIsEnabled;
            StandartRotaryPlugsCheckboxIsEnabled = ChoiceUsersStOrNotStRotPlug.StandartRotaryPlugsCheckboxIsEnabled;
        }

        #endregion

        public RotarPlugWindowViewModel()
        {
            //Нестандартные и стандартные поворотные заглушки
            StandartRotaryPlugsCommand = new LambdaCommand(OnStandartRotaryPlugsCommandExecuted, CanStandartRotaryPlugsCommandExecute);
            NonStandartRotaryPlugsCommand = new LambdaCommand(OnNonStandartRotaryPlugsCommandExecuted, CanNonStandartRotaryPlugsCommandExecute);
        }
    }
}
