﻿using StudCalculator.Infrastructure.Commands;
using StudCalculator.ViewModel.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;
using StudCalculator.Data.DBWork;

namespace StudCalculator.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Заголовок

        private string _title = "Калькулятор шпилек";
        public string Title { get => _title; set => Set(ref _title, value); }

        #endregion

        #region Работа с базой и вставка в ComboBox

        private ObservableCollection<string> _allGost;
        public ObservableCollection<string> AllGost { get => _allGost; set => Set(ref _allGost, value); }

        private string _selectionFromCombobox;
        public string SelectionFromCombobox
        {
            get => _selectionFromCombobox;
            set { Set(ref _selectionFromCombobox, value); AddExecutionCombobox(SelectionFromCombobox); }
        }

        private ObservableCollection<string> _execGost33259 = new ObservableCollection<string>();
        public ObservableCollection<string> ExecGost33259 { get => _execGost33259; set => Set(ref _execGost33259, value); }

        private ObservableCollection<string> _executionPn33259 = new ObservableCollection<string>();
        public ObservableCollection<string> ExecutionPn33259 { get => _executionPn33259; set => Set(ref _executionPn33259, value); }

        private ObservableCollection<string> _executionDn33259 = new ObservableCollection<string>();
        public ObservableCollection<string> ExecutionDn33259 { get => _executionDn33259; set => Set(ref _executionDn33259, value); }

        private ObservableCollection<string> _executionType33259 = new ObservableCollection<string>();
        public ObservableCollection<string> ExecutionType33259 { get => _executionType33259; set => Set(ref _executionType33259, value); }

        #endregion

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

        #region Считывание текста с текст боксов

        //Текстбокс для одинаковых нестандартных фланцев
        private string _nonStandartFlText;
        public string NonStandartFlText { get => _nonStandartFlText; set => Set(ref _nonStandartFlText, value); }

        #endregion

        #region Команды

        #region Команды для нестандартных фланцев

        //Включение работы с нестандартными фланцами одинаковыми
        public ICommand NonStandartSameFlangeCommand { get; }
        private bool CanNonStandartSameFlangeCommandExecute(object p) => true;

        private void OnNonStandartSameFlangeCommandExecuted(object p)
        {
          if(NonStandartSameFlangeChecked is true)
          {
              NonStandartFlTextIsEnabled = true;
              ChoeseNutsThreadComboboxIsEnabled = true;
              NumberOfNutsTextboxIsEnable = true;
              NonStandartDifferentFlangeCheckedIsEnabled = false;
          }
          else
          {
              NonStandartDifferentFlangeCheckedIsEnabled = true;
              NonStandartFlTextIsEnabled = false;
              ChoeseNutsThreadComboboxIsEnabled = false;
              NumberOfNutsTextboxIsEnable = false;
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
                NonStandartRotaryPlugsCheckboxIsEnabled = true;
                StandartRotaryPlugsCheckboxIsEnabled = true;
            }
            else
            {
                NonStandartStandartSameFlangeCheckedIsEnabled = true;
                StandartPlugsCheckboxIsEnabled = true;
                NonStandartPlugsCheckboxIsEnabled = true;
                ChoeseNutsThreadComboboxIsEnabled = false;
                NumberOfNutsTextboxIsEnable = false;
                NonStandartDifferentFlangeTexboxIsEnabled = false;
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
               StandartRotaryPlugsCheckboxIsEnabled = false;
               NonStandartRotaryPlugsCheckboxIsEnabled = false;
           }
           else
           {
               NonStandartPlugsCheckboxIsEnabled = true;
               StandartPlugsComboboxIsEnabled = false;
               StandartPlugsExecutionComboboxIsEnabled = false;
               StandartRotaryPlugsCheckboxIsEnabled = true;
               NonStandartRotaryPlugsCheckboxIsEnabled = true;
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
               StandartRotaryPlugsCheckboxIsEnabled = false;
               NonStandartRotaryPlugsCheckboxIsEnabled = false;
           }
           else
           {
               StandartPlugsCheckboxIsEnabled = true;
               NonStandartPlugsTextboxIsEnabled = false;
               StandartRotaryPlugsCheckboxIsEnabled = true;
               NonStandartRotaryPlugsCheckboxIsEnabled = true;
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
            }
            else
            {
                NonStandartRotaryPlugsCheckboxIsEnabled = true;
                StandartRotaryPlugsComboboxIsEnabled = false;
                if (NonStandartDifferentFlangeChecked is true)
                {
                    StandartPlugsCheckboxIsEnabled = false;
                    NonStandartPlugsCheckboxIsEnabled = false;
                }
                else
                {
                    NonStandartPlugsCheckboxIsEnabled = true;
                    StandartPlugsCheckboxIsEnabled = true;
                }
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
                
            }
            else
            {
                StandartRotaryPlugsCheckboxIsEnabled = true;
                NonStandartRotaryPlugsTextboxIsEnabled = false;
                if (NonStandartDifferentFlangeChecked is true)
                {
                    StandartPlugsCheckboxIsEnabled = false;
                    NonStandartPlugsCheckboxIsEnabled = false;
                }
                else
                {
                    NonStandartPlugsCheckboxIsEnabled = true;
                    StandartPlugsCheckboxIsEnabled = true;
                }
            }
        }


        #endregion

        #region Команда для шайб

        public ICommand StandartThicknessWasherCommand { get; }
        private bool CanStandartThicknessWasherCommandExecute(object p) => true;

        private void OnStandartThicknessWasherCommandExecuted(object p)
        {
            if (StandartThicknessWasherCheckboxChecked is true)
                NonStandartThicknessWasherCheckboxIsEnabled = false;
            else
            {
                NonStandartThicknessWasherCheckboxIsEnabled = true;
            }
        }

        public ICommand NonStandartThicknessWasherCommand { get; }
        private bool CanNonStandartThicknessWasherCommandExecute(object p) => true;

        private void OnNonStandartThicknessWasherCommandExecuted(object p)
        {
            if (NonStandartThicknessWasherCheckboxChecked is true)
            {
                StandartThicknessWasherCheckboxIsEnabled = false;
                NonThicknessWasherTextboxIsEnabled = true;
            }
            else
            {
                StandartThicknessWasherCheckboxIsEnabled = true;
                NonThicknessWasherTextboxIsEnabled = false;
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
            }
            else
            {
                StandartOctahedralGasketsCheckboxIsEnabled = true;
                NonStandartGasketsTextboxIsEnabled = true;
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
            }
            else
            {
                StandartOvalGasketsCheckboxIsEnabled = true;
                NonStandartGasketsTextboxIsEnabled = true;
            }
        }

        #endregion

        #endregion

        public MainWindowViewModel()
        {
            AllGost = new DbWorkGost33259().DbGost33259();

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

            #endregion
        }


        private void AddExecutionCombobox(string allGosts)
        {
            #region Добавление данных в коллекцию из базы

            ObservableCollection<string> execGost33259Add = new DbWorkGost33259().ExecGost33259();
            ObservableCollection<string> execGost33259PnAdd = new DbWorkGost33259().ExecutionPn33259();
            ObservableCollection<string> execGost33259DnAdd = new DbWorkGost33259().ExecutionDn33259();
            ObservableCollection<string> execGost33259TypeAdd = new DbWorkGost33259().ExecutionType33259();

            #endregion

            if (allGosts == "ГОСТ 33259-2015 Ряд 1")
            {
                foreach (var item in execGost33259Add)
                    ExecGost33259.Add(item);
                foreach (var item in execGost33259PnAdd)
                    ExecutionPn33259.Add(item);
                foreach (var item in execGost33259DnAdd)
                    ExecutionDn33259.Add(item);
                foreach (var item in execGost33259TypeAdd)
                    ExecutionType33259.Add(item);
            }
            else
            {
                ExecGost33259.Clear();
                ExecutionPn33259.Clear();
                ExecutionDn33259.Clear();
                ExecutionType33259.Clear();
            }
        }
    }
}
