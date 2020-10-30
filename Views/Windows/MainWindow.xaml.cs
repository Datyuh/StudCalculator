using System;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using StudCalculator.ViewModel;

namespace StudCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    OutputResult.Text = "Вывод результатов...";
        //    OutputResult.Foreground = Brushes.Gray;  
        //}


        //Подсчёт числа вхождений десятичного разделителя для проверки его
        public int DS_Count(string s)
        {
            string substr = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString();
            int count = (s.Length - s.Replace(substr, "").Length) / substr.Length;
            return count;
        }

        //Ввод только цифр десятичных или дробных
        private void TextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !((Char.IsDigit(e.Text, 0) || ((e.Text == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString()) && (DS_Count(((TextBox)sender).Text) < 1))));
        }
        //Ввод только целых цифр
        private void TextBox_PreviewTextInputWhole(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void ClearOutputResultClick(object sender, RoutedEventArgs e)
        {
            OutputResult.Text = "";
            if (string.IsNullOrEmpty(OutputResult.Text = ""))
            {
                OutputResult.Text = "Вывод результатов...";

            }
        }

        private void NonStandartFlText_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            NonStandartFlText.BorderBrush = NonStandartFlText.IsEnabled == false ? Brushes.Gray : new SolidColorBrush(Color.FromRgb(78, 238, 53));
        }

        private void NonStandartDablFlTextFirst_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            NonStandartDablFlTextFirst.BorderBrush = NonStandartDablFlTextFirst.IsEnabled == false ? Brushes.Gray : new SolidColorBrush(Color.FromRgb(78, 238, 53));
        }

        private void NonStandartDablFlTextSec_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            NonStandartDablFlTextSec.BorderBrush = NonStandartDablFlTextSec.IsEnabled == false ? Brushes.Gray : new SolidColorBrush(Color.FromRgb(78, 238, 53));
        }

        private void NumberSudText_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            NumberSudText.BorderBrush = NumberSudText.IsEnabled == false ? Brushes.Gray : new SolidColorBrush(Color.FromRgb(78, 238, 53));
        }

        private void NonStandardPlugText_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            NonStandardPlugText.BorderBrush = NonStandardPlugText.IsEnabled == false ? Brushes.Gray : new SolidColorBrush(Color.FromRgb(78, 238, 53));
        }

        private void StandardRotaryPlugText_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            StandardRotaryPlugText.BorderBrush = StandardRotaryPlugText.IsEnabled == false ? Brushes.Gray : new SolidColorBrush(Color.FromRgb(78, 238, 53));
        }

        private void WasherText_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            WasherText.BorderBrush = WasherText.IsEnabled == false ? Brushes.Gray : new SolidColorBrush(Color.FromRgb(78, 238, 53));
        }

        private void StripText_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            StripText.BorderBrush = StripText.IsEnabled == false ? Brushes.Gray : new SolidColorBrush(Color.FromRgb(238, 135, 32));
        }
    }
}
