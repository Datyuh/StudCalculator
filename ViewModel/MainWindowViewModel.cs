using System.Collections.Generic;
using StudCalculator.Infrastructure.Commands;
using StudCalculator.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using StudCalculator.Data.DBWork;
using StudCalculator.Infrastructure.Calculations.ReceiptAndDistributionData;
using System.Windows.Media;
using StudCalculator.Views.Windows;

namespace StudCalculator.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {

        #region Заголовок

        private string _title = "Калькулятор шпилек";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion

        #region Вставка текста в TextBox

        private string _resultTextEnter = "Вывод результатов...";
        public string ResultTextEnter { get => _resultTextEnter; set => Set(ref _resultTextEnter, value); }

        #endregion

        #region Цвет вывода результатов

        private Brush _colorTextBoxResult = Brushes.Gray;
        public Brush ColorTextBoxResult { get => _colorTextBoxResult; set => Set(ref _colorTextBoxResult, value); }

        #endregion

        #region Команды

        #region Вызов окна "О программе"

        public ICommand ShowWindowAboutProgram { get; }
        private bool CanShowWindowAboutProgramExecute(object p) => true;
        private void OnShowWindowAboutProgramExecuted(object p)
        {
            var aboutProgram = new AboutProgram();
            aboutProgram.ShowDialog();
        }

        #endregion

        #region Команда на вывод введенных данных с контролов

        public ICommand OutputValuesFromControlCommand { get; }
        private bool CanOutputValuesFromControlCommandExecute(object p) => true;

        private void OnOutputValuesFromControlCommandExecuted(object p)
        {
            //#region Choice user data for the calculation

            //EnterUsersGostStandrt.GostNamber = SelectionGostFromCombobox;
            //EnterUsersGostStandrt.TapeGost33259 = TypeSelectedFromComboBox;
            //EnterUsersGostStandrt.Pn = PnSelectedFromComboBox;
            //EnterUsersGostStandrt.ExecutionGost = ExecutionFromComboBox;
            //EnterUsersGostStandrt.Dn = DnSelectedFromComboBox;
            //EnterUsersNonStFlData.SimilarFlangeNonSt = NonStandartFlTextRead;
            //EnterUsersNonStFlData.FirstFlangeNonSt = NonStandartFirstFlangeTextRead;
            //EnterUsersNonStFlData.SecondFlangeNonSt = NonStandartSecondFlangeTextRead;
            //EnterUsrsRotaryPlug.RotaryPlugNonSt = NonStandartRotaryPlugsTextRead;
            //EnterUsrsRotaryPlug.RotaryPlugSt = StandartRotaryPlugFromComboBox;
            //EnterUsersPlugAndCaps.PlugAndCapsNonSt = NonStandartPlugsTextRead;
            //EnterUsersPlugAndCaps.PlugAndCapsStAtkOrOst = StandartPlugsFromComboBox;
            //EnterUsersPlugAndCaps.PlugAndCapsStExecution = StandartPlugsExecutionFromComboBox;
            //EnterUsersWashersAndGaskets.WashersNonSt = ThicknessWasherTextRead;
            //EnterUsersWashersAndGaskets.GasketsNonSt = ThicknessGasketTextRead;
            //EnterUsersStud.StudCount = SumStudTextRead;
            //EnterUsersStud.StudExecution = ExecutionStudFromCombobox;
            //EnterUsersStud.StudMaterial = MaterialStudFromCombobox;
            //EnterUsersNuts.ChoiceNutsOst = OstNutsFromComboBox;
            //EnterUsersNuts.ChoiceNutsThread = ThreadNutsFromComboBox;

            //#endregion

            //#region Setting the additional variables checkbox by the user

            //ChoiceUsersStOrNotStFlang.ChoiceUsersSameNotStFlang = NonStandartSameFlangeChecked;
            //ChoiceUsersStOrNotStFlang.ChoiceUsersDiffNonStFlang = NonStandartDifferentFlangeChecked;
            //ChoiceUsersStOrNotStRotPlug.ChoiceUsersStRotPlug = StandartRotaryPlugsChecked;
            //ChoiceUsersStOrNotStRotPlug.ChoiceUsersNotStRotPlug = NonStandartRotaryPlugsChecked;
            //ChoiceUsersStNotStPlugAndCaps.ChoiceUsersStPulgAndCaps = StandartPlugsChecked;
            //ChoiceUsersStNotStPlugAndCaps.ChoiceUsersNotStPlagAndCaps = NonStandartPlugsChecked;
            //ChoiceUsersWashersAndGasket.ChoiceStWashers = StandartThicknessWasherCheckboxChecked;
            //ChoiceUsersWashersAndGasket.ChoiceNotStWashers = NonStandartThicknessWasherCheckboxChecked;
            //ChoiceUsersWashersAndGasket.ChoiceOvalGasket = StandartOvalGasketsCheckboxChecked;
            //ChoiceUsersWashersAndGasket.ChoiceOctaGasket = StandartOctahedralGasketsCheckboxChecked;

            //#endregion

            var resultTextEnter = new ReceiptAndDistributionData()
                .ResultAllGostAndNonGosts;

            if (resultTextEnter == "Вывод результатов...")
            {
                if (ResultTextEnter != "Вывод результатов...")
                {
                    ResultTextEnter += "\r\n" + "";
                }
                else
                {
                    ResultTextEnter = resultTextEnter;
                    ColorTextBoxResult = Brushes.Gray;
                }
            }
            else
            {
                ColorTextBoxResult = Brushes.Black;
                if (ResultTextEnter == "Вывод результатов...")
                {
                    ResultTextEnter = resultTextEnter;
                }
                else
                {
                    ResultTextEnter += "\r\n" + resultTextEnter;
                }
            }
        }

        #endregion

        #region Команда для очистки поля результатов

        public ICommand ClearTextBoxResultCommand { get; }
        private bool CanClearTextBoxResultCommandExecute(object p) => true;

        private void OnClearTextBoxResultCommandExecuted(object p)
        {
            ColorTextBoxResult = Brushes.Gray;
            ResultTextEnter = "Вывод результатов...";
        }

        #endregion        

        #endregion

        public MainWindowViewModel()
        {

            #region Вызов команд

            //Вызов команды для проведения расчетов
            OutputValuesFromControlCommand = new LambdaCommand(OnOutputValuesFromControlCommandExecuted, CanOutputValuesFromControlCommandExecute);
            //Очистка поля результатов
            ClearTextBoxResultCommand = new LambdaCommand(OnClearTextBoxResultCommandExecuted, CanClearTextBoxResultCommandExecute);
            //Показ окна о программе
            ShowWindowAboutProgram = new LambdaCommand(OnShowWindowAboutProgramExecuted, CanShowWindowAboutProgramExecute);

            #endregion
        }
        
    }
}
