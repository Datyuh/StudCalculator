using System.Collections.ObjectModel;
using System.Linq;
using StudCalculator.Data.DBWork;
using StudCalculator.Infrastructure.EnterUsersData;
using StudCalculator.Model;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.ViewModel
{ 
    class GostsWindowViewModel : BaseViewModel
    {
        #region Работа с базой ГОСТов

        private ObservableCollection<string> _allGost = new DbWorkGost33259().DbGost33259();
        public ObservableCollection<string> AllGost { get => _allGost; set => Set(ref _allGost, value); }

        //Выборка из базы Исполнений
        private ObservableCollection<string> _execGost;
        public ObservableCollection<string> ExecGost { get => _execGost; set => Set(ref _execGost, value); }

        //Выборка из базы PN
        private ObservableCollection<string> _executionPn;
        public ObservableCollection<string> ExecutionPn { get => _executionPn; set => Set(ref _executionPn, value); }

        //Выборка из базы DN
        private ObservableCollection<string> _executionDn;
        public ObservableCollection<string> ExecutionDn { get => _executionDn; set => Set(ref _executionDn, value); }

        //Выборка из базы Типа фланцевого соединения
        private ObservableCollection<string> _executionType;
        public ObservableCollection<string> ExecutionType { get => _executionType; set => Set(ref _executionType, value); }

        #endregion

        #region Item from ComboBox

        private string _selectionGostFromCombobox;
        public string SelectionGostFromCombobox { get => _selectionGostFromCombobox;
            set 
            {
                Set(ref _selectionGostFromCombobox, value);
                EnterUsersGostStandrt.GostNamber = SelectionGostFromCombobox;
                EnterUsersGostStandrt.EnterUsersGostStandrts();
                ExecutionType = EnterUsersGostStandrt.TapeGost();
                TypeSelectedFromComboBox = ExecutionType.FirstOrDefault();
                ExecGost = EnterUsersGostStandrt.ExecutionGostData;
                ExecutionFromComboBox = ExecGost.FirstOrDefault();
                ExecutionDn = EnterUsersGostStandrt.ExecutionDnData;
                DnSelectedFromComboBox = ExecutionDn.FirstOrDefault();
                ExecutionPn = EnterUsersGostStandrt.ExecutionPnData;
                PnSelectedFromComboBox = ExecutionPn.FirstOrDefault();
                TypeFlangeGostIsEnabled = EnterUsersGostStandrt.TypeFlangesIsEnabled();
            }
        }

        //Получение значений для типа фланцев
        private string _typeSelectedFromComboBox;
        public string TypeSelectedFromComboBox { get => _typeSelectedFromComboBox; set
            {
                Set(ref _typeSelectedFromComboBox, value);
                EnterUsersGostStandrt.TapeGost33259 = TypeSelectedFromComboBox;
            }
        }

        //Получение значений для Давления
        private string _pnSelectedFromComboBox;
        public string PnSelectedFromComboBox { get => _pnSelectedFromComboBox; set
            {
                Set(ref _pnSelectedFromComboBox, value);
                EnterUsersGostStandrt.Pn = PnSelectedFromComboBox;
            }
        }

        //Получение значений для Исполнения
        private string _executionFromComboBox;
        public string ExecutionFromComboBox { get => _executionFromComboBox; set
            {
                Set(ref _executionFromComboBox, value);
                EnterUsersGostStandrt.ExecutionGost = ExecutionFromComboBox;
            }
        }

        //Получение значений для Диаметра внутреннего
        private string _dnSelectedFromComboBox;
        public string DnSelectedFromComboBox { get => _dnSelectedFromComboBox; set
            {
                Set(ref _dnSelectedFromComboBox, value);
                EnterUsersGostStandrt.Dn = DnSelectedFromComboBox;
            }
        }

        //Комбобокс типы фланцев по ГОСт 33259
        private bool _typeFlangeGostIsEnabled;
        public bool TypeFlangeGostIsEnabled { get => _typeFlangeGostIsEnabled; set
            {
                Set(ref _typeFlangeGostIsEnabled, value);
                EnterUsersGostStandrt.TypeFlangeIsEnabled = TypeFlangeGostIsEnabled;
            }
        }

        #endregion


        public GostsWindowViewModel()
        {
            SelectionGostFromCombobox = AllGost.FirstOrDefault();
        }
    }
}
