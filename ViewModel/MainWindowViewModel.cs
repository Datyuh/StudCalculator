using StudCalculator.Infrastructure.Commands;
using StudCalculator.ViewModel.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;

namespace StudCalculator.ViewModel
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Заголовок
        private string _Title = "Калькулятор шпилек";

        public string Title { get => _Title; set => Set(ref _Title, value); }
        #endregion

        #region Работа с базой
        private List<string> _AllGost;
        private List<string> _Exec_Gost33259;

        public List<string> AllGost { get => _AllGost; set => Set(ref _AllGost, value); }
        public List<string> Exec_Gost33259 { get => _Exec_Gost33259; set => Set(ref _AllGost, value); }
        #endregion

        public MainWindowViewModel()
        {
            ApplicationContext db = new ApplicationContext();
            _AllGost = db.GOSTs.Where(p => p.GOST != null && p.GOST != "ГОСТ 33259-2015 Ряд 2").Select(p => p.GOST).AsParallel().ToList();
            _Exec_Gost33259 = db.GOSTs.Where(p => p.Exec_GOST33259 != null).Select(p => p.Exec_GOST33259).AsParallel().ToList();
        }
    }
}
