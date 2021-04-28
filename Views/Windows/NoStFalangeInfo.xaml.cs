﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudCalculator.ViewModel;

namespace StudCalculator.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для NoStFalangeInfo.xaml
    /// </summary>
    public partial class NoStFalangeInfo : Window
    {
        public NoStFalangeInfo()
        {
            InitializeComponent();
            InfoNotStFlange infoNotStFlange = new InfoNotStFlange();
            DataContext = infoNotStFlange;
            infoNotStFlange.CloseAction = Close;

        }
    }
}