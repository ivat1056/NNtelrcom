﻿using NNtelrcom.Class;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NNtelrcom.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPBXPage.xaml
    /// </summary>
    public partial class MainPBXPage : Page
    {
        public MainPBXPage()
        {
            InitializeComponent();
            dgGeneral.ItemsSource = Base.ep.MainPBX.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
