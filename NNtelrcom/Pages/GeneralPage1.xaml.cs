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
    /// Логика взаимодействия для GeneralPage1.xaml
    /// </summary>
    public partial class GeneralPage1 : Page
    {
        public GeneralPage1()
        {
            InitializeComponent();
            lvProduct.ItemsSource = Base.ep.ATC.ToList();
        }



    }
}