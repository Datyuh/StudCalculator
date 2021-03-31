using System.Collections.Generic;
using StudCalculator.Infrastructure.Commands;
using StudCalculator.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using StudCalculator.Data.DBWork;
using StudCalculator.Infrastructure.Calculations.ReceiptAndDistributionData;
using System.Windows.Media;
using StudCalculator.Infrastructure.ChoiceUsersCheckBox;
using StudCalculator.Infrastructure.EnterUsersData;
using StudCalculator.Model;
using StudCalculator.Views.Windows;

namespace StudCalculator.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private static readonly InitializationData InitializationData = new();

        #region Заголовок

        private string _title = "Калькулятор шпилек";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        #endregion

        #region Работа с базой и вставка в ComboBox

        #region Работа с основной базой ГОСТов

        private ObservableCollection<string> _allGost = InitializationData.AllGost.DbGost33259();
        public ObservableCollection<string> AllGost { get => _allGost; set => Set(ref _allGost, value); }

        private string _selectionGostFromCombobox;

        public string SelectionGostFromCombobox
        {
            get => _selectionGostFromCombobox;
            set
            {
                Set(ref _selectionGostFromCombobox, value);
                AddExecutionCombobox(SelectionGostFromCombobox);
            }
        }

        #endregion

        #region Работа с базой ГОСТов

        //Выборка из базы Исполнений
        private ObservableCollection<string> _execGost = new();
        public ObservableCollection<string> ExecGost { get => _execGost; set => Set(ref _execGost, value); }

        //Выборка из базы PN
        private ObservableCollection<string> _executionPn = new();
        public ObservableCollection<string> ExecutionPn { get => _executionPn; set => Set(ref _executionPn, value); }

        //Выборка из базы DN
        private ObservableCollection<string> _executionDn = new();
        public ObservableCollection<string> ExecutionDn { get => _executionDn; set => Set(ref _executionDn, value); }

        //Выборка из базы Типа фланцевого соединения
        private ObservableCollection<string> _executionType = new();
        public ObservableCollection<string> ExecutionType { get => _executionType; set => Set(ref _executionType, value); }

        #endregion

        #region Работа с базой крышек и заглушек

        //Выборка из базы норматива
        private ObservableCollection<string> _allCaps = new();
        public ObservableCollection<string> AllCaps { get => _allCaps; set => Set(ref _allCaps, value); }

        //Выборка из нормативов исполнений
        private ObservableCollection<string> _executePlugsCollection = new();
        public ObservableCollection<string> ExecutePlugsCollection { get => _executePlugsCollection; set => Set(ref _executePlugsCollection, value); }

        #endregion

        #region Работа с базой заглушек поворотных

        //Выборка из базы Исполнений заглушек поворотных
        private ObservableCollection<string> _executeRotaryPlugsCollection = new();
        public ObservableCollection<string> ExecuteRotaryPlugsCollection { get => _executeRotaryPlugsCollection; set => Set(ref _executeRotaryPlugsCollection, value); }

        #endregion

        #region Работа с базой гаек

        //Выборка из базы нормативной документации
        private ObservableCollection<string> _ostNutsCollection = InitializationData.OstNutsCollection.OstNutsCollection();
        public ObservableCollection<string> OstNutsCollection { get => _ostNutsCollection; set => Set(ref _ostNutsCollection, value); }

        //Выборка из базы резьб
        private ObservableCollection<string> _extractNutsCollection;
        public ObservableCollection<string> ExtractNutsCollection { get => _extractNutsCollection; set => Set(ref _extractNutsCollection, value); }

        #endregion

        #region Работа с базой Шпилек по материалам и исполнения

        //Выборка из базы материала шпилек
        private ObservableCollection<string> _extractMaterialStudCollection = InitializationData.ExtractMaterialAndExecutionStud.ExtractMaterialStud();
        public ObservableCollection<string> ExtractMaterialStud { get => _extractMaterialStudCollection; set => Set(ref _extractMaterialStudCollection, value); }

        //Выборка из базы исполнений шпилек
        private ObservableCollection<string> _extractExecutionStudCollection = InitializationData.ExtractMaterialAndExecutionStud.ExecutionStud();
        public ObservableCollection<string> ExtractExecutionStud { get => _extractExecutionStudCollection; set => Set(ref _extractExecutionStudCollection, value); }

        #endregion

        #endregion

        #region Биндинг работы функций контролов

        #region Функции проверки установки флага в Чекбоксах

        //Чекбокс для одинаковых нестандартных фланцев
        private bool _nonStandartSameFlangeChecked;
        public bool NonStandartSameFlangeChecked { get => _nonStandartSameFlangeChecked; set => Set(ref _nonStandartSameFlangeChecked, value); }

        //Чекбокс для разных нестандартных фланцев
        private bool _nonStandartDifferentFlangeChecked;
        public bool NonStandartDifferentFlangeChecked { get => _nonStandartDifferentFlangeChecked; set => Set(ref _nonStandartDifferentFlangeChecked, value); }

        //Чекбокс для стандартных заглушек
        private bool _standartPlugsChecked;
        public bool StandartPlugsChecked { get => _standartPlugsChecked; set => Set(ref _standartPlugsChecked, value); }

        //Чекбокс для нестандартных заглушек
        private bool _nonStandartPlugsChecked;
        public bool NonStandartPlugsChecked { get => _nonStandartPlugsChecked; set => Set(ref _nonStandartPlugsChecked, value); }

        //Чекбокс для стандартных заглушек поворотных
        private bool _standartRotaryPlugsChecked;
        public bool StandartRotaryPlugsChecked { get => _standartRotaryPlugsChecked; set => Set(ref _standartRotaryPlugsChecked, value); }

        //Чекбокс для нестандартных заглушек поворотных
        private bool _nonstandartRotaryPlugsChecked;
        public bool NonStandartRotaryPlugsChecked { get => _nonstandartRotaryPlugsChecked; set => Set(ref _nonstandartRotaryPlugsChecked, value); }

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

        #region Установка включение/отключение текстбоксов

        //Текстбокс для одинаковых нестандартных фланцев
        private bool _nonStandartFlTextIsEnabled;
        public bool NonStandartFlTextIsEnabled { get => _nonStandartFlTextIsEnabled; set => Set(ref _nonStandartFlTextIsEnabled, value); }

        //Текстбокс для разных нестандартных фланцев
        private bool _nonStandartDifferentFlangeTexboxIsEnabled;
        public bool NonStandartDifferentFlangeTexboxIsEnabled { get => _nonStandartDifferentFlangeTexboxIsEnabled; set => Set(ref _nonStandartDifferentFlangeTexboxIsEnabled, value); }

        //Текстбокс для нестандартных заглушек
        private bool _nonStandartPlugsTextboxEsInEnabled;
        public bool NonStandartPlugsTextboxIsEnabled { get => _nonStandartPlugsTextboxEsInEnabled; set => Set(ref _nonStandartPlugsTextboxEsInEnabled, value); }

        //Текстбокс для выставления количества шпилек
        private bool _numberOfNutsTextboxIsEnabled;
        public bool NumberOfNutsTextboxIsEnable { get => _numberOfNutsTextboxIsEnabled; set => Set(ref _numberOfNutsTextboxIsEnabled, value); }

        //Текстбокс для заглушек поворотных
        private bool _nonstandartRotaryPlugsTextboxIsEnabled;
        public bool NonStandartRotaryPlugsTextboxIsEnabled { get => _nonstandartRotaryPlugsTextboxIsEnabled; set => Set(ref _nonstandartRotaryPlugsTextboxIsEnabled, value); }

        //Текстбокс для шайб
        private bool _nonThicknessWasherTextboxIsEnabled;
        public bool NonThicknessWasherTextboxIsEnabled { get => _nonThicknessWasherTextboxIsEnabled; set => Set(ref _nonThicknessWasherTextboxIsEnabled, value); }

        //Текстбокс для прокладок
        private bool _nonStandartGasketsTextboxIsEnabled = true;
        public bool NonStandartGasketsTextboxIsEnabled { get => _nonStandartGasketsTextboxIsEnabled; set => Set(ref _nonStandartGasketsTextboxIsEnabled, value); }

        #endregion

        #region Установка включение/отключение комбобоксов

        //Комбобокс стандартные заглушки и крышки Основной
        private bool _standartPlugsComboboxIsEnabled;
        public bool StandartPlugsComboboxIsEnabled { get => _standartPlugsComboboxIsEnabled; set => Set(ref _standartPlugsComboboxIsEnabled, value); }

        //Комбобокс стандартные заглушки и крышки выбор исполнения
        private bool _standartPlugsExecutionComboboxIsEnabled;
        public bool StandartPlugsExecutionComboboxIsEnabled { get => _standartPlugsExecutionComboboxIsEnabled; set => Set(ref _standartPlugsExecutionComboboxIsEnabled, value); }

        //Комбобокс выбор резьбы на гайки для нестандартных фланцев
        private bool _choeseNutsThreadComboboxIsEnabled;
        public bool ChoeseNutsThreadComboboxIsEnabled { get => _choeseNutsThreadComboboxIsEnabled; set => Set(ref _choeseNutsThreadComboboxIsEnabled, value); }

        //Комбобокс стандартные заглушки поворотные выбор исполнения
        private bool _standartRotaryPlugsComboboxIsEnabled;
        public bool StandartRotaryPlugsComboboxIsEnabled { get => _standartRotaryPlugsComboboxIsEnabled; set => Set(ref _standartRotaryPlugsComboboxIsEnabled, value); }

        //Комбобокс типы фланцев по ГОСт 33259
        private bool _typeFlangeGostIsEnabled;
        public bool TypeFlangeGostIsEnabled { get => _typeFlangeGostIsEnabled; set => Set(ref _typeFlangeGostIsEnabled, value); }

        #endregion

        #region Установка включение/отключение Чекбоксов

        //Чекбокс для одинаковых нестандартных фланцев
        private bool _nonStandartStandartSameFlangeCheckedIsEnabled = true;
        public bool NonStandartStandartSameFlangeCheckedIsEnabled { get => _nonStandartStandartSameFlangeCheckedIsEnabled; set => Set(ref _nonStandartStandartSameFlangeCheckedIsEnabled, value); }

        //Чекбокс для разных нестандартных фланцев
        private bool _nonStandartDifferentFlangeCheckedIsEnabled = true;
        public bool NonStandartDifferentFlangeCheckedIsEnabled { get => _nonStandartDifferentFlangeCheckedIsEnabled; set => Set(ref _nonStandartDifferentFlangeCheckedIsEnabled, value); }

        //Чекбокс для стандартных заглушек
        private bool _standartPlugsCheckboxIsEnabled = true;
        public bool StandartPlugsCheckboxIsEnabled { get => _standartPlugsCheckboxIsEnabled; set => Set(ref _standartPlugsCheckboxIsEnabled, value); }

        //Чекбокс для нестандартных заглушек
        private bool _nonStandartPlugsCheckboxIsEnabled = true;
        public bool NonStandartPlugsCheckboxIsEnabled { get => _nonStandartPlugsCheckboxIsEnabled; set => Set(ref _nonStandartPlugsCheckboxIsEnabled, value); }

        //Чекбокс для стандартных заглушек поворотных
        private bool _standartRotaryPlugsCheckboxIsEnabled = true;
        public bool StandartRotaryPlugsCheckboxIsEnabled { get => _standartRotaryPlugsCheckboxIsEnabled; set => Set(ref _standartRotaryPlugsCheckboxIsEnabled, value); }

        //Чекбокс для нестандартных заглушек поворотных
        private bool _nonstandartRotaryPlugsCheckboxIsEnabled = true;
        public bool NonStandartRotaryPlugsCheckboxIsEnabled { get => _nonstandartRotaryPlugsCheckboxIsEnabled; set => Set(ref _nonstandartRotaryPlugsCheckboxIsEnabled, value); }

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

        #region Считывание текста с текстбоксов

        //Текстбокс для одинаковых нестандартных фланцев
        private double? _nonStandartFlTextRead;
        public double? NonStandartFlTextRead { get => _nonStandartFlTextRead; set => Set(ref _nonStandartFlTextRead, value); }

        //Текстбокс для не одинаковых нестандартных фланцев 1 фланец
        private double? _nonStandartFirstFlangeTextRead;
        public double? NonStandartFirstFlangeTextRead { get => _nonStandartFirstFlangeTextRead; set => Set(ref _nonStandartFirstFlangeTextRead, value); }

        //Текстбокс для не одинаковых нестандартных фланцев 2 фланец
        private double? _nonStandartSecondFlangeTextRead;
        public double? NonStandartSecondFlangeTextRead { get => _nonStandartSecondFlangeTextRead; set => Set(ref _nonStandartSecondFlangeTextRead, value); }

        //Текстбокс для нестандартных заглушек и крышек
        private double? _nonStandartPlugsTextRead; 
        public double? NonStandartPlugsTextRead { get => _nonStandartPlugsTextRead; set => Set(ref _nonStandartPlugsTextRead, value); }

        //Текстбокс для нестандартных заглушек поворотных
        private double? _nonStandartRotaryPlugsTextRead;
        public double? NonStandartRotaryPlugsTextRead { get => _nonStandartRotaryPlugsTextRead; set => Set(ref _nonStandartRotaryPlugsTextRead, value); }

        //Текстбокс для кол-ва фланцев
        private double? _sumFlangeTextRead;
        public double? SumFlangeTextRead { get => _sumFlangeTextRead; set => Set(ref _sumFlangeTextRead, value); }

        //Текстбокс для толщины шайб
        private double? _thicknessWasherTextRead;
        public double? ThicknessWasherTextRead { get => _thicknessWasherTextRead; set => Set(ref _thicknessWasherTextRead, value); }

        //Текстбокс для для толщины прокладок
        private double? _thicknessGasketTextRead;
        public double? ThicknessGasketTextRead { get => _thicknessGasketTextRead; set => Set(ref _thicknessGasketTextRead, value); }

        //Текстбокс для кол-ва шпилек
        private double? _sumStudTextRead;
        public double? SumStudTextRead { get => _sumStudTextRead; set => Set(ref _sumStudTextRead, value); }

        #endregion

        #region Получение значений с ComboBox

        //Получение значений для типа фланцев
        private string _typeSelectedFromComboBox;
        public string TypeSelectedFromComboBox { get => _typeSelectedFromComboBox; set => Set(ref _typeSelectedFromComboBox, value); }

        //Получение значений для Давления
        private string _pnSelectedFromComboBox;
        public string PnSelectedFromComboBox { get => _pnSelectedFromComboBox; set => Set(ref _pnSelectedFromComboBox, value); }

        //Получение значений для Исполнения
        private string _executionFromComboBox;
        public string ExecutionFromComboBox
        {
            get => _executionFromComboBox;
            set
            {
                Set(ref _executionFromComboBox, value);
                ExecutedTypeFlange(ExecutionFromComboBox);
            }
        }

        //Получение значений для Диаметра внутреннего
        private string _dnSelectedFromComboBox;
        public string DnSelectedFromComboBox { get => _dnSelectedFromComboBox; set => Set(ref _dnSelectedFromComboBox, value); }

        //Получение значений для заглушек поворотных
        private string _standartRotaryPlugFromComboBox;
        public string StandartRotaryPlugFromComboBox { get => _standartRotaryPlugFromComboBox; set => Set(ref _standartRotaryPlugFromComboBox, value); }

        //Получение значений для заглушек и крышек
        private string _standartPlugsFromComboBox;
        public string StandartPlugsFromComboBox { get => _standartPlugsFromComboBox; 
            set 
            { 
                Set(ref _standartPlugsFromComboBox, value); 
                AddCapsCombobox(StandartPlugsFromComboBox);
            }
        }

        //Получение значений исполнения для заглушек и крышек
        private string _standartPlugsExecutionFromComboBox;
        public string StandartPlugsExecutionFromComboBox { get => _standartPlugsExecutionFromComboBox; set => Set(ref _standartPlugsExecutionFromComboBox, value); }

        //Получение значений исполнения шпилек
        private string _executionStudFromCombobox;
        public string ExecutionStudFromCombobox { get => _executionStudFromCombobox; set => Set(ref _executionStudFromCombobox, value); }

        //Получение значений для материала шпилек
        private string _materialStudFromCombobox;
        public string MaterialStudFromCombobox { get => _materialStudFromCombobox; set => Set(ref _materialStudFromCombobox, value); }

        //Получение значений ОСТа на гайки
        private string _ostNutsFromComboBox;
        public string OstNutsFromComboBox { get => _ostNutsFromComboBox; set => Set(ref _ostNutsFromComboBox, value); }

        //Получение значений резьбы для шайб
        private string _threadNutsFromComboBox;
        public string ThreadNutsFromComboBox { get => _threadNutsFromComboBox; set => Set(ref _threadNutsFromComboBox, value); }

        #endregion

        #region Вставка текста в TextBox

        private string _resultTextEnter = "Вывод результатов...";
        public string ResultTextEnter { get => _resultTextEnter; set => Set(ref _resultTextEnter, value); }

        #endregion

        #region Цвет вывода результатов

        private Brush _colorTextBoxResult = Brushes.Gray;
        public Brush ColorTextBoxResult { get => _colorTextBoxResult; set => Set(ref _colorTextBoxResult, value); }

        #endregion

        #endregion

        #region Команды

        #region Команды для нестандартных фланцев

        //Включение работы с нестандартными фланцами одинаковыми
        public ICommand NonStandartSameFlangeCommand { get; }
        private bool CanNonStandartSameFlangeCommandExecute(object p) => true;

        private void OnNonStandartSameFlangeCommandExecuted(object p)
        {
            if (NonStandartSameFlangeChecked is true)
            {
                NonStandartFlTextIsEnabled = true;
                ChoeseNutsThreadComboboxIsEnabled = true;
                NumberOfNutsTextboxIsEnable = true;
                NonStandartDifferentFlangeCheckedIsEnabled = false;
                ExtractNutsCollection = new DbNutsOst26_2041_96().ExtractOst26_2041_96();
                NonStandartFlTextRead = null;
                SumStudTextRead = null;
                ThreadNutsFromComboBox = ExtractNutsCollection.Select(e => e).First();

            }
            else
            {
                NonStandartDifferentFlangeCheckedIsEnabled = true;
                NonStandartFlTextIsEnabled = false;
                ChoeseNutsThreadComboboxIsEnabled = false;
                NumberOfNutsTextboxIsEnable = false;
                ExtractNutsCollection.Clear();
                NonStandartFlTextRead = null;
                SumStudTextRead = null;
            }
        }

        //Включение работы с нестандартными фланцами разными
        public ICommand NonStandartDifferentFlangeCommand { get; }
        private bool CanNonStandartDifferentFlangeCommandExecute(object p) => true;

        private void OnNonStandartDifferentFlangeCommandExecuted(object p)
        {
            if (NonStandartDifferentFlangeChecked is true)
            {
                ChoeseNutsThreadComboboxIsEnabled = true;
                NumberOfNutsTextboxIsEnable = true;
                NonStandartDifferentFlangeTexboxIsEnabled = true;
                NonStandartStandartSameFlangeCheckedIsEnabled = false;
                StandartPlugsCheckboxIsEnabled = false;
                NonStandartPlugsCheckboxIsEnabled = false;
                StandartPlugsChecked = false;
                NonStandartPlugsChecked = false;
                NonStandartPlugsTextboxIsEnabled = false;
                StandartPlugsComboboxIsEnabled = false;
                StandartRotaryPlugsCheckboxIsEnabled = true;
                NonStandartRotaryPlugsCheckboxIsEnabled = true;
                StandartPlugsExecutionComboboxIsEnabled = false;
                ExtractNutsCollection = new DbNutsOst26_2041_96().ExtractOst26_2041_96();
                AllCaps.Clear();
                ExecutePlugsCollection.Clear();
                NonStandartFirstFlangeTextRead = null;
                NonStandartSecondFlangeTextRead = null;
                SumStudTextRead = null;
                ThreadNutsFromComboBox = ExtractNutsCollection.Select(e => e).First();
                if (StandartRotaryPlugsChecked) NonStandartRotaryPlugsCheckboxIsEnabled = false;
                if (NonStandartRotaryPlugsChecked) StandartRotaryPlugsCheckboxIsEnabled = false;
            }
            else
            {
                NonStandartStandartSameFlangeCheckedIsEnabled = true;
                StandartPlugsCheckboxIsEnabled = true;
                NonStandartPlugsCheckboxIsEnabled = true;
                ChoeseNutsThreadComboboxIsEnabled = false;
                NumberOfNutsTextboxIsEnable = false;
                NonStandartDifferentFlangeTexboxIsEnabled = false;
                ExtractNutsCollection.Clear();
                NonStandartFirstFlangeTextRead = null;
                NonStandartSecondFlangeTextRead = null;
                SumStudTextRead = null;
                if (StandartRotaryPlugsChecked)
                {
                    StandartPlugsCheckboxIsEnabled = false;
                    NonStandartPlugsCheckboxIsEnabled = false;
                }

                if (NonStandartRotaryPlugsChecked)
                {
                    StandartPlugsCheckboxIsEnabled = false;
                    NonStandartPlugsCheckboxIsEnabled = false;
                }
            }
        }

        #endregion

        #region Команды для заглушек и крышек

        public ICommand StandartPlugsCommand { get; }
        private bool CanStandartPlugsCommandExecute(object p) => true;

        private void OnStandartPlugsCommandExecuted(object p)
        {
            if (StandartPlugsChecked is true)
            {
                NonStandartPlugsCheckboxIsEnabled = false;
                StandartPlugsComboboxIsEnabled = true;
                StandartPlugsExecutionComboboxIsEnabled = true;
                StandartRotaryPlugsCheckboxIsEnabled = false;
                NonStandartRotaryPlugsCheckboxIsEnabled = false;
                StandartRotaryPlugsChecked = false;
                NonStandartRotaryPlugsChecked = false;
                NonStandartRotaryPlugsTextboxIsEnabled = false;
                ExecuteRotaryPlugsCollection.Clear();
                StandartRotaryPlugsComboboxIsEnabled = false;
                AllCaps = new DbCapsAtk242000290().DbCapsCollection();
                StandartPlugsFromComboBox = AllCaps.Select(s => s).First();
                StandartPlugsExecutionFromComboBox = ExecutePlugsCollection.Select(s => s).First();
                if (SelectionGostFromCombobox == "АТК-26-18-13-96")
                {
                    ExecGost.Clear();
                    ExecGost = new ObservableCollection<string>(new DbAtk26_18_13_96().ExecuteExecutionsCollectionForPlug());
                    ExecutionFromComboBox = ExecGost.Select(e => e).First();
                }
            }
            else
            {
                NonStandartPlugsCheckboxIsEnabled = true;
                StandartPlugsComboboxIsEnabled = false;
                StandartPlugsExecutionComboboxIsEnabled = false;
                StandartRotaryPlugsCheckboxIsEnabled = true;
                NonStandartRotaryPlugsCheckboxIsEnabled = true;
                AllCaps.Clear();
                ExecutePlugsCollection.Clear();
                if (SelectionGostFromCombobox == "АТК-26-18-13-96")
                {
                    ExecGost.Clear();
                    ExecGost = new ObservableCollection<string>(new DbAtk26_18_13_96().ExecuteExecutionsCollection());
                    ExecutionFromComboBox = ExecGost.Select(e => e).First();
                }
            }
        }

        public ICommand NonstandartPlugsCommand { get; }
        private bool CanNonstandartPlugsCommandExecute(object p) => true;

        private void OnNonstandartPlugsCommandExecuted(object p)
        {
            if (NonStandartPlugsChecked is true)
            {
                StandartPlugsCheckboxIsEnabled = false;
                NonStandartPlugsTextboxIsEnabled = true;
                StandartRotaryPlugsCheckboxIsEnabled = false;
                NonStandartRotaryPlugsCheckboxIsEnabled = false;
                NonStandartPlugsTextRead = null;
                ExecuteRotaryPlugsCollection.Clear();
                StandartRotaryPlugsChecked = false;
                StandartRotaryPlugsComboboxIsEnabled = false;
                if (SelectionGostFromCombobox != "АТК-26-18-13-96") return;
                ExecGost.Clear();
                ExecGost = new ObservableCollection<string>(new DbAtk26_18_13_96().ExecuteExecutionsCollectionForPlug());
                ExecutionFromComboBox = ExecGost.Select(e => e).First();
            }
            else
            {
                StandartPlugsCheckboxIsEnabled = true;
                NonStandartPlugsTextboxIsEnabled = false;
                StandartRotaryPlugsCheckboxIsEnabled = true;
                NonStandartRotaryPlugsCheckboxIsEnabled = true;
                NonStandartPlugsTextRead = null;
                if (SelectionGostFromCombobox != "АТК-26-18-13-96") return;
                ExecGost.Clear();
                ExecGost = new ObservableCollection<string>(new DbAtk26_18_13_96().ExecuteExecutionsCollection());
                ExecutionFromComboBox = ExecGost.Select(e => e).First();
            }
        }

        #endregion

        #region Команды для заглушек поворотных

        public ICommand StandartRotaryPlugsCommand { get; }
        private bool CanStandartRotaryPlugsCommandExecute(object p) => true;

        private void OnStandartRotaryPlugsCommandExecuted(object p)
        {
            if (StandartRotaryPlugsChecked is true)
            {
                NonStandartPlugsCheckboxIsEnabled = false;
                StandartPlugsCheckboxIsEnabled = false;
                NonStandartRotaryPlugsCheckboxIsEnabled = false;
                StandartRotaryPlugsComboboxIsEnabled = true;
                ExecuteRotaryPlugsCollection =
                    new ObservableCollection<string>(new DbRotarPylugATK_26_18_5_93().ExecuteAtk_26_18_5_93());
                StandartRotaryPlugFromComboBox = ExecuteRotaryPlugsCollection.Select(s => s).First();
            }

            else
            {
                NonStandartRotaryPlugsCheckboxIsEnabled = true;
                StandartRotaryPlugsComboboxIsEnabled = false;
                StandartPlugsCheckboxIsEnabled = true;
                NonStandartPlugsCheckboxIsEnabled = true;
                ExecuteRotaryPlugsCollection.Clear();
                if (!(NonStandartDifferentFlangeChecked is true)) return;
                StandartPlugsCheckboxIsEnabled = false;
                NonStandartPlugsCheckboxIsEnabled = false;
            }
        }

        public ICommand NonStandartRotaryPlugsCommand { get; }
        private bool CanNonStandartRotaryPlugsCommandExecute(object p) => true;

        private void OnNonStandartRotaryPlugsCommandExecuted(object p)
        {
            if (NonStandartRotaryPlugsChecked is true)
            {
                NonStandartPlugsCheckboxIsEnabled = false;
                StandartPlugsCheckboxIsEnabled = false;
                StandartRotaryPlugsCheckboxIsEnabled = false;
                NonStandartRotaryPlugsTextboxIsEnabled = true;
                NonStandartRotaryPlugsTextRead = null;
            }
            else
            {
                StandartRotaryPlugsCheckboxIsEnabled = true;
                NonStandartRotaryPlugsTextboxIsEnabled = false;
                NonStandartRotaryPlugsTextRead = null;
                StandartPlugsCheckboxIsEnabled = true;
                NonStandartPlugsCheckboxIsEnabled = true;
                if (NonStandartDifferentFlangeChecked is true)
                {
                    StandartPlugsCheckboxIsEnabled = false;
                    NonStandartPlugsCheckboxIsEnabled = false;
                }
            }
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
            if (NonStandartThicknessWasherCheckboxChecked is true)
            {
                StandartThicknessWasherCheckboxIsEnabled = false;
                NonThicknessWasherTextboxIsEnabled = true;
                ThicknessWasherTextRead = null;
            }
            else
            {
                StandartThicknessWasherCheckboxIsEnabled = true;
                NonThicknessWasherTextboxIsEnabled = false;
                ThicknessWasherTextRead = null;
            }
        }

        #endregion

        #region Команда для прокладок Овальных и Восьмигранных

        public ICommand StandartOvalGasketsCommand { get; }
        private bool CanStandartOvalGasketsCommandExecute(object p) => true;

        private void OnStandartOvalGasketsCommandExecuted(object p)
        {
            if (StandartOvalGasketsCheckboxChecked is true)
            {
                StandartOctahedralGasketsCheckboxIsEnabled = false;
                NonStandartGasketsTextboxIsEnabled = false;
                ThicknessGasketTextRead = null;
            }
            else
            {
                StandartOctahedralGasketsCheckboxIsEnabled = true;
                NonStandartGasketsTextboxIsEnabled = true;
                ThicknessGasketTextRead = null;
                if (SelectionGostFromCombobox != "ГОСТ 28759.4-90" && ExecutionFromComboBox != "Исполнение J") return;
                NonStandartGasketsTextboxIsEnabled = false;
                ThicknessGasketTextRead = null;

            }
        }

        public ICommand StandartOctahedralGasketsCommand { get; }
        private bool CanStandartOctahedralGasketsCommandExecute(object p) => true;

        private void OnStandartOctahedralGasketsCommandExecuted(object p)
        {
            if (StandartOctahedralGasketsCheckboxChecked is true)
            {
                StandartOvalGasketsCheckboxIsEnabled = false;
                NonStandartGasketsTextboxIsEnabled = false;
                ThicknessGasketTextRead = null;
            }
            else
            {
                StandartOvalGasketsCheckboxIsEnabled = true;
                NonStandartGasketsTextboxIsEnabled = true;
                ThicknessGasketTextRead = null;
                if (SelectionGostFromCombobox != "ГОСТ 28759.4-90" && ExecutionFromComboBox != "Исполнение J") return;
                NonStandartGasketsTextboxIsEnabled = false;
                ThicknessGasketTextRead = null;
            }
        }

        #endregion

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
            #region Choice user data for the calculation

            EnterUsersGostStandrt.GostNamber = SelectionGostFromCombobox;
            EnterUsersGostStandrt.TapeGost33259 = TypeSelectedFromComboBox;
            EnterUsersGostStandrt.Pn = PnSelectedFromComboBox;
            EnterUsersGostStandrt.ExecutionGost = ExecutionFromComboBox;
            EnterUsersGostStandrt.Dn = DnSelectedFromComboBox;
            EnterUsersNonStFlData.SimilarFlangeNonSt = NonStandartFlTextRead;
            EnterUsersNonStFlData.FirstFlangeNonSt = NonStandartFirstFlangeTextRead;
            EnterUsersNonStFlData.SecondFlangeNonSt = NonStandartSecondFlangeTextRead;
            EnterUsrsRotaryPlug.RotaryPlugNonSt = NonStandartRotaryPlugsTextRead;
            EnterUsrsRotaryPlug.RotaryPlugSt = StandartRotaryPlugFromComboBox;
            EnterUsersPlugAndCaps.PlugAndCapsNonSt = NonStandartPlugsTextRead;
            EnterUsersPlugAndCaps.PlugAndCapsStAtkOrOst = StandartPlugsFromComboBox;
            EnterUsersPlugAndCaps.PlugAndCapsStExecution = StandartPlugsExecutionFromComboBox;
            EnterUsersWashersAndGaskets.WashersNonSt = ThicknessWasherTextRead;
            EnterUsersWashersAndGaskets.GasketsNonSt = ThicknessGasketTextRead;
            EnterUsersStud.StudCount = SumStudTextRead;
            EnterUsersStud.StudExecution = ExecutionStudFromCombobox;
            EnterUsersStud.StudMaterial = MaterialStudFromCombobox;
            EnterUsersNuts.ChoiceNutsOst = OstNutsFromComboBox;
            EnterUsersNuts.ChoiceNutsThread = ThreadNutsFromComboBox;

            #endregion

            #region Setting the additional variables checkbox by the user

            ChoiceUsersStOrNotStFlang.ChoiceUsersSameNotStFlang = NonStandartSameFlangeChecked;
            ChoiceUsersStOrNotStFlang.ChoiceUsersDiffNonStFlang = NonStandartDifferentFlangeChecked;
            ChoiceUsersStOrNotStRotPlug.ChoiceUsersStRotPlug = StandartRotaryPlugsChecked;
            ChoiceUsersStOrNotStRotPlug.ChoiceUsersNotStRotPlug = NonStandartRotaryPlugsChecked;
            ChoiceUsersStNotStPlugAndCaps.ChoiceUsersStPulgAndCaps = StandartPlugsChecked;
            ChoiceUsersStNotStPlugAndCaps.ChoiceUsersNotStPlagAndCaps = NonStandartPlugsChecked;
            ChoiceUsersWashersAndGasket.ChoiceStWashers = StandartThicknessWasherCheckboxChecked;
            ChoiceUsersWashersAndGasket.ChoiceNotStWashers = NonStandartThicknessWasherCheckboxChecked;
            ChoiceUsersWashersAndGasket.ChoiceOvalGasket = StandartOvalGasketsCheckboxChecked;
            ChoiceUsersWashersAndGasket.ChoiceOctaGasket = StandartOctahedralGasketsCheckboxChecked;

            #endregion

            var receiptAndDistributionOfDatas = new Dictionary<string, object>
            {
                {"SelectionGostFromCombobox", SelectionGostFromCombobox},
                {"PnSelectedFromComboBox", PnSelectedFromComboBox},
                {"ExecutionFromComboBox", ExecutionFromComboBox},
                {"DnSelectedFromComboBox", DnSelectedFromComboBox},
                {"StandartRotaryPlugFromComboBox", StandartRotaryPlugFromComboBox},
                {"StandartPlugsFromComboBox", StandartPlugsFromComboBox},
                {"StandartPlugsExecutionFromComboBox", StandartPlugsExecutionFromComboBox},
                {"ExecutionStudFromCombobox", ExecutionStudFromCombobox},
                {"MaterialStudFromCombobox", MaterialStudFromCombobox}, 
                {"OstNutsFromComboBox", OstNutsFromComboBox},
                {"ThreadNutsFromComboBox", ThreadNutsFromComboBox},
                {"NonStandartFlTextRead", NonStandartFlTextRead},
                {"NonStandartFirstFlangeTextRead", NonStandartFirstFlangeTextRead},
                {"NonStandartSecondFlangeTextRead", NonStandartSecondFlangeTextRead},
                {"NonStandartPlugsTextRead", NonStandartPlugsTextRead},
                {"NonStandartRotaryPlugsTextRead", NonStandartRotaryPlugsTextRead},
                {"SumFlangeTextRead", SumFlangeTextRead}, 
                {"ThicknessWasherTextRead", ThicknessWasherTextRead},
                {"ThicknessGasketTextRead", ThicknessGasketTextRead}, 
                {"SumStudTextRead", SumStudTextRead},
            };

            var receiptAndDistributionOfDataCheckBox = new Dictionary<string, bool>
            {
                {"NonStandartSameFlangeChecked", NonStandartSameFlangeChecked},
                {"NonStandartDifferentFlangeChecked", NonStandartDifferentFlangeChecked},
                {"StandartPlugsChecked", StandartPlugsChecked}, 
                {"NonStandartPlugsChecked", NonStandartPlugsChecked},
                {"StandartRotaryPlugsChecked", StandartRotaryPlugsChecked},
                {"NonStandartRotaryPlugsChecked", NonStandartRotaryPlugsChecked},
                {"StandartThicknessWasherCheckboxChecked", StandartThicknessWasherCheckboxChecked},
                {"NonStandartThicknessWasherCheckboxChecked", NonStandartThicknessWasherCheckboxChecked},
                {"StandartOvalGasketsCheckboxChecked", StandartOvalGasketsCheckboxChecked},
                {"StandartOctahedralGasketsCheckboxChecked", StandartOctahedralGasketsCheckboxChecked},
            };

            var resultTextEnter = new ReceiptAndDistributionData(receiptAndDistributionOfDatas, receiptAndDistributionOfDataCheckBox)
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
            #region Чтобы не были пустые комбобоксы

            SelectionGostFromCombobox = AllGost.First();
            TypeSelectedFromComboBox = ExecutionType.First();
            PnSelectedFromComboBox = ExecutionPn.First();
            ExecutionFromComboBox = ExecGost.First();
            DnSelectedFromComboBox = ExecutionDn.First();
            OstNutsFromComboBox = OstNutsCollection.First();
            ExecutionStudFromCombobox = ExtractExecutionStud.First();
            MaterialStudFromCombobox = ExtractMaterialStud.First();

            #endregion

            #region Вызов команд

            //Нестандартные и стандартные фланцы
            NonStandartSameFlangeCommand = new LambdaCommand(OnNonStandartSameFlangeCommandExecuted, CanNonStandartSameFlangeCommandExecute);
            NonStandartDifferentFlangeCommand = new LambdaCommand(OnNonStandartDifferentFlangeCommandExecuted, CanNonStandartDifferentFlangeCommandExecute);
            //Нестандартные и стандартные заглушки и крышки
            StandartPlugsCommand = new LambdaCommand(OnStandartPlugsCommandExecuted, CanStandartPlugsCommandExecute);
            NonstandartPlugsCommand = new LambdaCommand(OnNonstandartPlugsCommandExecuted, CanNonstandartPlugsCommandExecute);
            //Нестандартные и стандартные поворотные заглушки
            StandartRotaryPlugsCommand = new LambdaCommand(OnStandartRotaryPlugsCommandExecuted, CanStandartRotaryPlugsCommandExecute);
            NonStandartRotaryPlugsCommand = new LambdaCommand(OnNonStandartRotaryPlugsCommandExecuted, CanNonStandartRotaryPlugsCommandExecute);
            //Нестандартные и стандартные шайбы
            StandartThicknessWasherCommand = new LambdaCommand(OnStandartThicknessWasherCommandExecuted, CanStandartThicknessWasherCommandExecute);
            NonStandartThicknessWasherCommand = new LambdaCommand(OnNonStandartThicknessWasherCommandExecuted, CanNonStandartThicknessWasherCommandExecute);
            //Прокладки овальные и восьмигранные
            StandartOvalGasketsCommand = new LambdaCommand(OnStandartOvalGasketsCommandExecuted, CanStandartOvalGasketsCommandExecute);
            StandartOctahedralGasketsCommand = new LambdaCommand(OnStandartOctahedralGasketsCommandExecuted, CanStandartOctahedralGasketsCommandExecute);
            //Вызов команды для проведения расчетов
            OutputValuesFromControlCommand = new LambdaCommand(OnOutputValuesFromControlCommandExecuted, CanOutputValuesFromControlCommandExecute);
            //
            ClearTextBoxResultCommand = new LambdaCommand(OnClearTextBoxResultCommandExecuted, CanClearTextBoxResultCommandExecute);
            //
            ShowWindowAboutProgram = new LambdaCommand(OnShowWindowAboutProgramExecuted, CanShowWindowAboutProgramExecute);

            #endregion
        }
        
        #region Добавление данных по АТК 24.200.02-90

        private void AddCapsCombobox(string allCapsSelectionCombobox)
        {
            var executeAtk242000290 = new DbCapsAtk242000290().ExecuteAtk24_200_02_90();
            var executeOst26200883 = new DbCapsOST26_2008_83().ExecuteOst26_2008_83();

            if (allCapsSelectionCombobox == "АТК 24.200.02-90" && StandartPlugsChecked is true)
            {
                ExecutePlugsCollection.Clear();
                foreach (var item in executeAtk242000290)
                    ExecutePlugsCollection.Add(item);
            }
            else if (allCapsSelectionCombobox == "OCT 26-2008-83" && StandartPlugsChecked is true)
            {
                ExecutePlugsCollection.Clear();
                foreach (var item in executeOst26200883)
                    ExecutePlugsCollection.Add(item);
            }
        }

        #endregion

        #region Добавление данных по ГОСТ в коллекцию из базы

        private void AddExecutionCombobox(string allGosts)
        {
           
            switch (allGosts)
            {
                #region Работа с ГОСТом 33259 добовление и изменение параметров контролов

                case "ГОСТ 33259-2015 Ряд 1":
                    ExecGost.Clear();
                    ExecutionPn.Clear();
                    ExecutionDn.Clear();
                    ExecGost = new ObservableCollection<string>(new DbWorkGost33259().ExecGost33259());
                    ExecutionPn = new ObservableCollection<string>(new DbWorkGost33259().ExecutionPn33259());
                    ExecutionDn = new ObservableCollection<string>(new DbWorkGost33259().ExecutionDn33259());
                    ExecutionType = new ObservableCollection<string>(new DbWorkGost33259().ExecutionType33259());
                    PnSelectedFromComboBox = ExecutionPn.First();
                    ExecutionFromComboBox = ExecGost.First();
                    DnSelectedFromComboBox = ExecutionDn.First();
                    TypeSelectedFromComboBox = ExecutionType.First();
                    ThicknessGasketTextRead = null;
                    StandartOvalGasketsCheckboxChecked = false;
                    StandartOctahedralGasketsCheckboxChecked = false;
                    TypeFlangeGostIsEnabled = true;
                    NonStandartGasketsTextboxIsEnabled = true;
                    StandartOvalGasketsCheckboxIsEnabled = true;
                    StandartOctahedralGasketsCheckboxIsEnabled = true;
                    break;
                
                #endregion

                #region Работа с ГОСТом 287593.3-90 добовление и изменение параметров контролов

                case "ГОСТ 28759.3-90":
                    ExecGost.Clear();
                    ExecutionPn.Clear();
                    ExecutionDn.Clear();
                    ExecutionType.Clear();
                    ExecGost = new ObservableCollection<string>(new DbGost28759_3_90().ExecuteExecutionsCollection());
                    ExecutionPn = new ObservableCollection<string>(new DbGost28759_3_90().ExecutePnCollection());
                    ExecutionDn = new ObservableCollection<string>(new DbGost28759_3_90().ExecuteDnCollection());
                    PnSelectedFromComboBox = ExecutionPn.First();
                    ExecutionFromComboBox = ExecGost.First();
                    DnSelectedFromComboBox = ExecutionDn.First();
                    ThicknessGasketTextRead = null;
                    StandartOvalGasketsCheckboxChecked = false;
                    StandartOctahedralGasketsCheckboxChecked = false;
                    TypeFlangeGostIsEnabled = false;
                    NonStandartGasketsTextboxIsEnabled = true;
                    StandartOvalGasketsCheckboxIsEnabled = false;
                    StandartOctahedralGasketsCheckboxIsEnabled = false;
                    break;
               
                #endregion

                #region Работа с ГОСТом 287593.4-90 добовление и изменение параметров контролов

                case "ГОСТ 28759.4-90":
                    ExecGost.Clear();
                    ExecutionPn.Clear();
                    ExecutionDn.Clear();
                    ExecutionType.Clear();
                    ExecGost = new ObservableCollection<string>(new DbGost28759_4_90().ExecuteExecutionsCollection());
                    ExecutionPn = new ObservableCollection<string>(new DbGost28759_4_90().ExecutePnCollection());
                    ExecutionDn = new ObservableCollection<string>(new DbGost28759_4_90().ExecuteDnCollection());
                    PnSelectedFromComboBox = ExecutionPn.First();
                    ExecutionFromComboBox = ExecGost.First();
                    DnSelectedFromComboBox = ExecutionDn.First();
                    ThicknessGasketTextRead = null;
                    StandartOvalGasketsCheckboxChecked = false;
                    StandartOctahedralGasketsCheckboxChecked = false;
                    TypeFlangeGostIsEnabled = false;
                    StandartOvalGasketsCheckboxIsEnabled = true;
                    StandartOctahedralGasketsCheckboxIsEnabled = true;
                    NonStandartGasketsTextboxIsEnabled = false;
                    break;

                #endregion

                #region Работа с АТК 26-18-13-96 добовление и изменение параметров контролов

                case "АТК-26-18-13-96":
                    ExecGost.Clear();
                    ExecutionPn.Clear();
                    ExecutionDn.Clear();
                    ExecutionType.Clear();
                    ExecutionPn = new ObservableCollection<string>(new DbAtk26_18_13_96().ExecutePnCollection());
                    ExecutionDn = new ObservableCollection<string>(new DbAtk26_18_13_96().ExecuteDnCollection());
                    ExecGost = new ObservableCollection<string>(new DbAtk26_18_13_96().ExecuteExecutionsCollection());
                    PnSelectedFromComboBox = ExecutionPn.First();
                    ExecutionFromComboBox = ExecGost.First();
                    DnSelectedFromComboBox = ExecutionDn.First();
                    ThicknessGasketTextRead = null;
                    StandartOvalGasketsCheckboxChecked = false;
                    StandartOctahedralGasketsCheckboxChecked = false;
                    TypeFlangeGostIsEnabled = false;
                    NonStandartGasketsTextboxIsEnabled = true;
                    StandartOvalGasketsCheckboxIsEnabled = true;
                    StandartOctahedralGasketsCheckboxIsEnabled = true;
                    break;
                #endregion
            }



        }

        #endregion

        #region Отключение ввода нестандартных прокладок при выборе исполнения J

        private void ExecutedTypeFlange(string typeFlange)
        {
            if (typeFlange == "Исполнение J")
            {
                ThicknessGasketTextRead = null;
                StandartOvalGasketsCheckboxChecked = false;
                StandartOctahedralGasketsCheckboxChecked = false;
                StandartOvalGasketsCheckboxIsEnabled = true;
                StandartOctahedralGasketsCheckboxIsEnabled = true;
                NonStandartGasketsTextboxIsEnabled = false;
            }
            else
            {
                StandartOvalGasketsCheckboxChecked = false;
                StandartOctahedralGasketsCheckboxChecked = false;
                NonStandartGasketsTextboxIsEnabled = true;
                StandartOvalGasketsCheckboxIsEnabled = true;
                StandartOctahedralGasketsCheckboxIsEnabled = true;
                ThicknessGasketTextRead = null;
            }
        }

        #endregion

    }
}
