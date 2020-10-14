using System;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OutputResult.Text = "Вывод результатов...";
            OutputResult.Foreground = Brushes.Gray;  
        }


        //Подсчёт числа вхождений десятичного разделителя для проверки его
        public int DS_Count(string s)
        {
            string substr = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString();
            int count = (s.Length - s.Replace(substr, "").Length) / substr.Length;
            return count;
        }

        //Ввод только цифр десятичных или дробных
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !((Char.IsDigit(e.Text, 0) || ((e.Text == System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0].ToString()) && (DS_Count(((TextBox)sender).Text) < 1))));
        }
        //Ввод только целых цифр
        private void TextBox_PreviewTextInputWhole(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }

        private void ClearOutputResult_Click(object sender, RoutedEventArgs e)
        {
            OutputResult.Text = "";
            if (string.IsNullOrEmpty(OutputResult.Text = ""))
            {
                OutputResult.Text = "Вывод результатов...";

            }
        }        
    }
}
