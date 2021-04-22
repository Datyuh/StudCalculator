using System.Windows;
using StudCalculator.ViewModel;

namespace StudCalculator.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для OvalOrOctagGasketView.xaml
    /// </summary>
    public partial class OvalOrOctagGasketView : Window
    {
        public OvalOrOctagGasketView(string gasket, string title)
        {
            InitializeComponent();
            DataContext = new OvalOrOctagGasketViewModel(gasket, title);
        }
    }
}
