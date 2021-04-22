using System.Windows.Input;
using StudCalculator.Infrastructure.Commands;
using StudCalculator.ViewModel.Base;
using StudCalculator.Views.Windows;

namespace StudCalculator.ViewModel
{
    class InfoNotStFlange : BaseViewModel
    {

        public ICommand OvalGasketCommand { get; }
        private bool CanOvalGasketCommandExecute(object p) => true;

        private void OnOvalGasketCommandExecuted(object p)
        {
            var ovalOrOctagGasketView = new OvalOrOctagGasketView("Oval", "Овальная прокладка");
            ovalOrOctagGasketView.ShowDialog();
        }

        public ICommand OctagonalGasketCommand { get; }
        private bool CanOctagonalGasketCommandExecute(object p) => true;

        private void OnOctagonalGasketCommandExecuted(object p)
        {
            var ovalOrOctagGasketView = new OvalOrOctagGasketView("Octagonal", "Восьмигранная прокладка");
            ovalOrOctagGasketView.ShowDialog();
        }

        public InfoNotStFlange()
        {
            OvalGasketCommand = new LambdaCommand(OnOvalGasketCommandExecuted, CanOvalGasketCommandExecute);
            OctagonalGasketCommand =
                new LambdaCommand(OnOctagonalGasketCommandExecuted, CanOctagonalGasketCommandExecute);
        }
    }
}
