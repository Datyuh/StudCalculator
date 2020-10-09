using StudCalculator.DBWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<string> GOSTsAll = new List<string>(new DbWork().DbGost().AsParallel());

        public MainWindow()
        {            
            InitializeComponent();
            //GOSTall.ItemsSource = GOSTsAll;
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OutputResult.Text = "Вывод результатов...";
            OutputResult.Foreground = Brushes.Gray;  
        }

        //private void Exec_GOST33259_DropDownOpened(object sender, EventArgs e)
        //{
        //    if (GOSTall.Text.ToString() == GOSTsAll[0])
        //    {
        //        Exec_GOST33259.ItemsSource = new List<string>(new DbWork().Exec_Gost33259().AsParallel());
        //        Execution_PN_Combo.ItemsSource = new List<string>(new DbWork().Execution_PN().AsParallel());
        //        Execution_DN_Combo.ItemsSource = new List<string>(new DbWork().Execution_DN().AsParallel());
        //        Type_GOST33259_Combo.ItemsSource = new List<string>(new DbWork().Execution_Type().AsParallel());
        //    }
        //}

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

        private void NonStandartFl_Click(object sender, RoutedEventArgs e)
        {
            if (NonStandartFl.IsChecked == true)
                NonStandartFl_Text.IsEnabled = true;
            else
            {
                NonStandartFl_Text.IsEnabled = false;
                NonStandartFl_Text.Text = "";
            }                
        }

        private void NonStandartDablFl_Click(object sender, RoutedEventArgs e)
        {
            if (NonStandartDablFl.IsChecked == true)
            {
                NonStandartDablFl_TextFirst.IsEnabled = true;
                NonStandartDablFl_TextSec.IsEnabled = true;
            }
            else
            {
                NonStandartDablFl_TextFirst.IsEnabled = false;
                NonStandartDablFl_TextSec.IsEnabled = false;
                NonStandartDablFl_TextFirst.Text = "";
                NonStandartDablFl_TextSec.Text = "";
            }
        }

        private void StandardRotaryPlug_Click(object sender, RoutedEventArgs e)
        {
            if (StandardRotaryPlug.IsChecked == true)
                StandardRotaryPlug_Combo.IsEnabled = true;
            else           
                StandardRotaryPlug_Combo.IsEnabled = false;      
        }

        private void NonStandardRotaryPlug_Click(object sender, RoutedEventArgs e)
        {
            if (NonStandardRotaryPlug.IsChecked == true)
                StandardRotaryPlug_Text.IsEnabled = true;
            else
            {
                StandardRotaryPlug_Text.IsEnabled = false;
                StandardRotaryPlug_Text.Text = "";
            }                
        }

        private void StandardPlug_Click(object sender, RoutedEventArgs e)
        {
            if (StandardPlug.IsChecked == true)
                StandardPlug_Combo.IsEnabled = true;
            else
                StandardPlug_Combo.IsEnabled = false;
        }

        private void NonStandardPlug_Click(object sender, RoutedEventArgs e)
        {
            if (NonStandardPlug.IsChecked == true)
                NonStandardPlug_Text.IsEnabled = true;
            else
            {
                NonStandardPlug_Text.IsEnabled = false;
                NonStandardPlug_Text.Text = "";
            }                
        }

        private void NonStandartThicknessWasher_Checked(object sender, RoutedEventArgs e)
        {
            if (StandartThicknessWasher.IsChecked == true && NonStandartThicknessWasher.IsChecked == true)
                Washer_Text.IsEnabled = false;

            else
                Washer_Text.IsEnabled = true;
        }

        private void NonStandartThicknessWasher_Unchecked(object sender, RoutedEventArgs e)
        {
            if (NonStandartThicknessWasher.IsChecked == false && StandartThicknessWasher.IsChecked == true)
                Washer_Text.IsEnabled = true;

            else
            {
                Washer_Text.IsEnabled = false;
                Washer_Text.Text = "";
            }
        }

        private void StandartThicknessWasher_Checked(object sender, RoutedEventArgs e)
        {
            if (StandartThicknessWasher.IsChecked == true && NonStandartThicknessWasher.IsChecked == true)          
                Washer_Text.IsEnabled = false;
            
            else
                Washer_Text.IsEnabled = true;
        }

        private void StandartThicknessWasher_Unchecked(object sender, RoutedEventArgs e)
        {
            if(StandartThicknessWasher.IsChecked == false && NonStandartThicknessWasher.IsChecked == true)            
                Washer_Text.IsEnabled = true;
            
            else
            {
                Washer_Text.IsEnabled = false;
                Washer_Text.Text = "";
            }
        }

        private void StandartThicknessStripOval_Checked(object sender, RoutedEventArgs e)
        {
            if(StandartThicknessStripOval.IsChecked == true && StandartThicknessStripOrtag.IsChecked == true)
                Strip_Text.IsEnabled = false;
            else
                Strip_Text.IsEnabled = true;
        }

        private void StandartThicknessStripOval_Unchecked(object sender, RoutedEventArgs e)
        {
            if (StandartThicknessStripOval.IsChecked == false && StandartThicknessStripOrtag.IsChecked == true)
                Strip_Text.IsEnabled = true;
            else
            {
                Strip_Text.IsEnabled = false;
                Strip_Text.Text = "";
            }
        }

        private void StandartThicknessStripOrtag_Checked(object sender, RoutedEventArgs e)
        {
            if (StandartThicknessStripOval.IsChecked == true && StandartThicknessStripOrtag.IsChecked == true)
                Strip_Text.IsEnabled = false;
            else
                Strip_Text.IsEnabled = true;
        }

        private void StandartThicknessStripOrtag_Unchecked(object sender, RoutedEventArgs e)
        {
            if (StandartThicknessStripOval.IsChecked == true && StandartThicknessStripOrtag.IsChecked == false)
                Strip_Text.IsEnabled = true;
            else
            {
                Strip_Text.IsEnabled = false;
                Strip_Text.Text = "";
            }
        }
    }
}
