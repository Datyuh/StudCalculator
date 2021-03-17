using System.Windows;

namespace StudCalculator.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AboutProgram.xaml
    /// </summary>
    public partial class AboutProgram : Window
    {
        public AboutProgram()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
