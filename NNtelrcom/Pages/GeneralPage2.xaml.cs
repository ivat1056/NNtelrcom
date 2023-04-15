using NNtelrcom.Class;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
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
    /// Логика взаимодействия для GeneralPage2.xaml
    /// </summary>
    public partial class GeneralPage2 : Page
    {
        public GeneralPage2()
        {
            InitializeComponent();
            dgGeneral.ItemsSource = Base.ep.ATC.ToList();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked.IsChecked == true) 
            {
                Check38.Visibility = Visibility.Visible;
            }
            
            
        }

        private void Checked_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked.IsChecked == false)
            {
                Check38.Visibility = Visibility.Collapsed;
            }
            
        }
    }
}
