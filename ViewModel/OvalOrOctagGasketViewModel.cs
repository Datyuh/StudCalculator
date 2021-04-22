using System.Collections.ObjectModel;
using StudCalculator.Data.DBWork;
using StudCalculator.ViewModel.Base;

namespace StudCalculator.ViewModel
{
    class OvalOrOctagGasketViewModel : BaseViewModel
    {
        private string _title;
        public string Title { get => _title; set => Set(ref _title, value); }

        private ObservableCollection<object> _ovalOrOctagGasket;
        public ObservableCollection<object> OvalOrOctagGasket { get => _ovalOrOctagGasket; set => Set(ref _ovalOrOctagGasket, value); }


        public OvalOrOctagGasketViewModel(string gasket, string title)
        {
            Title = title;
            OvalOrOctagGasket = gasket == "Oval"
                ? new ObservableCollection<object>(new DbOvalGasket().OvalGasketsCollection())
                : new ObservableCollection<object>(new DbOctagonalGasket().OctagonalGasketsCollection());
        }
    }
}
