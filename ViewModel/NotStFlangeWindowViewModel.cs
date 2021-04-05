using System.Windows.Input;
using StudCalculator.Infrastructure.ChoiceUsersCheckBox;
using StudCalculator.Infrastructure.Commands;
using StudCalculator.Infrastructure.EnterUsersData;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.ViewModel
{
    internal class NotStFlangeWindowViewModel : BaseViewModel
    {
        #region Считывание текста с текстбоксов
        //Текстбокс для одинаковых нестандартных фланцев
        private double? _nonStandartFlTextRead;
        public double? NonStandartFlTextRead { get => _nonStandartFlTextRead;
            set
            {
                Set(ref _nonStandartFlTextRead, value);
                EnterUsersNonStFlange.SimilarFlangeNonSt = NonStandartFlTextRead;
            }
        }

        //Текстбокс для не одинаковых нестандартных фланцев 1 фланец
        private double? _nonStandartFirstFlangeTextRead;
        public double? NonStandartFirstFlangeTextRead { get => _nonStandartFirstFlangeTextRead; 
            set
            {
                Set(ref _nonStandartFirstFlangeTextRead, value);
                EnterUsersNonStFlange.FirstFlangeNonSt = NonStandartFirstFlangeTextRead;
            }
        }

        //Текстбокс для не одинаковых нестандартных фланцев 2 фланец
        private double? _nonStandartSecondFlangeTextRead;
        public double? NonStandartSecondFlangeTextRead { get => _nonStandartSecondFlangeTextRead; set 
            {
                Set(ref _nonStandartSecondFlangeTextRead, value);
                EnterUsersNonStFlange.SecondFlangeNonSt = NonStandartSecondFlangeTextRead;
            }
        }

        #endregion

        #region Установка включение/отключение текстбоксов

        //Текстбокс для одинаковых нестандартных фланцев
        private bool _nonStandartFlTextIsEnabled;
        public bool NonStandartFlTextIsEnabled { get => _nonStandartFlTextIsEnabled; set
            {
                Set(ref _nonStandartFlTextIsEnabled, value);
            }
        }

        //Текстбокс для разных нестандартных фланцев
        private bool _nonStandartDifferentFlangeTexboxIsEnabled;
        public bool NonStandartDifferentFlangeTexboxIsEnabled { get => _nonStandartDifferentFlangeTexboxIsEnabled; set
            {
                Set(ref _nonStandartDifferentFlangeTexboxIsEnabled, value);
            }
        }

        #endregion

        #region Функции проверки установки флага в Чекбоксах

        //Чекбокс для одинаковых нестандартных фланцев
        private bool _nonStandartSameFlangeChecked;
        public bool NonStandartSameFlangeChecked { get => _nonStandartSameFlangeChecked; 
            set
            {
                Set(ref _nonStandartSameFlangeChecked, value);
                ChoiceUsersNotStFlang.ChoiceUsersSameNotStFlang = NonStandartSameFlangeChecked;
            }
        }

        //Чекбокс для разных нестандартных фланцев
        private bool _nonStandartDifferentFlangeChecked;
        public bool NonStandartDifferentFlangeChecked { get => _nonStandartDifferentFlangeChecked; 
            set
            {
                Set(ref _nonStandartDifferentFlangeChecked, value);
                ChoiceUsersNotStFlang.ChoiceUsersDiffNonStFlang = NonStandartDifferentFlangeChecked;
            }
        }

        #endregion

        #region Установка включение/отключение Чекбоксов

        //Чекбокс для одинаковых нестандартных фланцев
        private bool _nonStandartStandartSameFlangeCheckedIsEnabled = true;
        public bool NonStandartStandartSameFlangeCheckedIsEnabled { get => _nonStandartStandartSameFlangeCheckedIsEnabled; set
            {
                Set(ref _nonStandartStandartSameFlangeCheckedIsEnabled, value);
            }
        }

        //Чекбокс для разных нестандартных фланцев
        private bool _nonStandartDifferentFlangeCheckedIsEnabled = true;
        public bool NonStandartDifferentFlangeCheckedIsEnabled { get => _nonStandartDifferentFlangeCheckedIsEnabled; set
            {
                Set(ref _nonStandartDifferentFlangeCheckedIsEnabled, value);
            }
        }

        #endregion

        #region Команды для нестандартных фланцев

        //Включение работы с нестандартными фланцами одинаковыми
        public ICommand NonStandartSameFlangeCommand { get; }
        private bool CanNonStandartSameFlangeCommandExecute(object p) => true;

        private void OnNonStandartSameFlangeCommandExecuted(object p)
        {
            new ChoiceUsersNotStFlang().NonStSameFlanges();
            NonStandartFlTextIsEnabled = ChoiceUsersNotStFlang.NonStandartSameFlangeTexboxIsEnabled;
            NonStandartDifferentFlangeCheckedIsEnabled = ChoiceUsersNotStFlang.NonStandartDifferentFlangeCheckedIsEnabled;
            NonStandartFlTextRead = EnterUsersNonStFlange.SimilarFlangesNonSt();
        }

        //Включение работы с нестандартными фланцами разными
        public ICommand NonStandartDifferentFlangeCommand { get; }
        private bool CanNonStandartDifferentFlangeCommandExecute(object p) => true;

        private void OnNonStandartDifferentFlangeCommandExecuted(object p)
        {
            new ChoiceUsersNotStFlang().NonStDifferentFlanges();
            NonStandartStandartSameFlangeCheckedIsEnabled = ChoiceUsersNotStFlang.NonStandartSameFlangeCheckedIsEnabled;
            NonStandartDifferentFlangeTexboxIsEnabled = ChoiceUsersNotStFlang.NonStandartDifferentFlangeTexboxIsEnabled;
            NonStandartFirstFlangeTextRead = NonStandartSecondFlangeTextRead =
                EnterUsersNonStFlange.DifferentFlangesNonSt();
        }

        #endregion

        public NotStFlangeWindowViewModel()
        {
            //Нестандартные и стандартные фланцы
            NonStandartSameFlangeCommand = new LambdaCommand(OnNonStandartSameFlangeCommandExecuted, CanNonStandartSameFlangeCommandExecute);
            NonStandartDifferentFlangeCommand = new LambdaCommand(OnNonStandartDifferentFlangeCommandExecuted, CanNonStandartDifferentFlangeCommandExecute);
        }
    }
}
