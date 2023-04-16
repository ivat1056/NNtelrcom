using NNtelrcom.Class;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NNtelrcom.Windows
{
    /// <summary>
    /// Логика взаимодействия для GeneralWindow.xaml
    /// </summary>
    public partial class GeneralWindow : Window
    {
        public GeneralWindow()
        {
            InitializeComponent();
            dgGeneral.ItemsSource = Base.ep.ATC.ToList();
            MenuNave.Click += MenuNave_Click;
            btnclose.MouseLeftButtonUp += btnclose_Click;
        }

        private void MenuNave_Click(object sender, RoutedEventArgs e)
        {
            Nav.Opacity = 0.3;
            Storyboard sb = Resources["OpenMenu"] as Storyboard;
            sb.Begin(LeftMenu);
            Nav.Visibility = Visibility.Collapsed;
            dgGeneral.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked38.IsChecked == true)
            {
                Check38.Visibility = Visibility.Visible;
            }


        }

        private void Checked_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked38.IsChecked == false)
            {
                Check38.Visibility = Visibility.Collapsed;
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Checked38_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked38.IsChecked == true)
            {
                Check38.Visibility = Visibility.Visible;
            }
        }

        private void Checked38_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked38.IsChecked == false)
            {
                Check38.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked1_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked1.IsChecked == true)
            {
                Check1.Visibility = Visibility.Visible;
            }
        }

        private void Checked1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked1.IsChecked == false)
            {
                Check1.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked2_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked2.IsChecked == true)
            {
                Check2.Visibility = Visibility.Visible;
            }
        }

        private void Checked2_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked2.IsChecked == false)
            {
                Check2.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked3_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked3.IsChecked == true)
            {
                Check3.Visibility = Visibility.Visible;
            }
        }

        private void Checked3_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked3.IsChecked == false)
            {
                Check3.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked4_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked4.IsChecked == true)
            {
                Check4.Visibility = Visibility.Visible;
            }
        }

        private void Checked4_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked4.IsChecked == false)
            {
                Check4.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked5_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked5.IsChecked == true)
            {
                Check5.Visibility = Visibility.Visible;
            }
        }

        private void Checked5_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked5.IsChecked == false)
            {
                Check5.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked6_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked6.IsChecked == true)
            {
                Check6.Visibility = Visibility.Visible;
            }
        }

        private void Checked6_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked6.IsChecked == false)
            {
                Check6.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked7_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked7.IsChecked == true)
            {
                Check8.Visibility = Visibility.Visible;
            }
        }

        private void Checked7_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked7.IsChecked == false)
            {
                Check7.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked8_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked8.IsChecked == false)
            {
                Check8.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked8_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked8.IsChecked == true)
            {
                Check8.Visibility = Visibility.Visible;
            }
        }

        private void Checked9_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked9.IsChecked == true)
            {
                Check9.Visibility = Visibility.Visible;
            }
        }

        private void Checked9_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked9.IsChecked == false)
            {
                Check9.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked10_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked10.IsChecked == true)
            {
                Check10.Visibility = Visibility.Visible;
            }
        }

        private void Checked10_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked10.IsChecked == false)
            {
                Check10.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked11_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked11.IsChecked == true)
            {
                Check11.Visibility = Visibility.Visible;
            }
        }

        private void Checked11_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked11.IsChecked == false)
            {
                Check11.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked12_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked12.IsChecked == true)
            {
                Check12.Visibility = Visibility.Visible;
            }
        }

        private void Checked12_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked12.IsChecked == false)
            {
                Check12.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked13_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked13.IsChecked == true)
            {
                Check13.Visibility = Visibility.Visible;
            }
        }

        private void Checked13_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked13.IsChecked == false)
            {
                Check13.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked14_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked14.IsChecked == true)
            {
                Check14.Visibility = Visibility.Visible;
            }
        }

        private void Checked14_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked14.IsChecked == false)
            {
                Check14.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked15_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked15.IsChecked == true)
            {
                Check15.Visibility = Visibility.Visible;
            }
        }

        private void Checked15_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked15.IsChecked == false)
            {
                Check15.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked16_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked16.IsChecked == true)
            {
                Check16.Visibility = Visibility.Visible;
            }
        }

        private void Checked16_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked16.IsChecked == false)
            {
                Check16.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked17_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked17.IsChecked == true)
            {
                Check17.Visibility = Visibility.Visible;
            }
        }

        private void Checked17_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked17.IsChecked == false)
            {
                Check17.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked18_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked18.IsChecked == true)
            {
                Check18.Visibility = Visibility.Visible;
            }
        }

        private void Checked18_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked18.IsChecked == false)
            {
                Check18.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked19_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked19.IsChecked == true)
            {
                Check19.Visibility = Visibility.Visible;
            }
        }

        private void Checked19_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked19.IsChecked == false)
            {
                Check19.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked20_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked20.IsChecked == true)
            {
                Check20.Visibility = Visibility.Visible;
            }
        }

        private void Checked20_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked20.IsChecked == false)
            {
                Check20.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked21_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked21.IsChecked == true)
            {
                Check21.Visibility = Visibility.Visible;
            }
        }

        private void Checked21_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked21.IsChecked == false)
            {
                Check21.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked22_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked22.IsChecked == true)
            {
                Check22.Visibility = Visibility.Visible;
            }
        }

        private void Checked22_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked22.IsChecked == false)
            {
                Check22.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked24_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked24.IsChecked == true)
            {
                Check24.Visibility = Visibility.Visible;
            }
        }

        private void Checked24_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked24.IsChecked == false)
            {
                Check24.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked23_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked23.IsChecked == false)
            {
                Check23.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked23_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked24.IsChecked == true)
            {
                Check24.Visibility = Visibility.Visible;
            }
        }

        private void Checked25_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked25.IsChecked == true)
            {
                Check25.Visibility = Visibility.Visible;
            }
        }

        private void Checked25_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked25.IsChecked == false)
            {
                Check25.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked26_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked26.IsChecked == true)
            {
                Check26.Visibility = Visibility.Visible;
            }
        }

        private void Checked26_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked26.IsChecked == false)
            {
                Check26.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked27_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked27.IsChecked == true)
            {
                Check27.Visibility = Visibility.Visible;
            }
        }

        private void Checked27_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked27.IsChecked == false)
            {
                Check27.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked28_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked28.IsChecked == true)
            {
                Check28.Visibility = Visibility.Visible;
            }
        }

        private void Checked28_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked28.IsChecked == false)
            {
                Check28.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked29_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked29.IsChecked == true)
            {
                Check29.Visibility = Visibility.Visible;
            }
        }

        private void Checked29_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked29.IsChecked == false)
            {
                Check29.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked30_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked30.IsChecked == true)
            {
                Check30.Visibility = Visibility.Visible;
            }
        }

        private void Checked30_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked30.IsChecked == false)
            {
                Check30.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked31_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked31.IsChecked == true)
            {
                Check31.Visibility = Visibility.Visible;
            }
        }

        private void Checked31_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked31.IsChecked == false)
            {
                Check31.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked32_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked32.IsChecked == true)
            {
                Check32.Visibility = Visibility.Visible;
            }
        }

        private void Checked32_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked32.IsChecked == false)
            {
                Check32.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked33_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked33.IsChecked == true)
            {
                Check33.Visibility = Visibility.Visible;
            }
        }

        private void Checked33_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked33.IsChecked == false)
            {
                Check33.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked34_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked34.IsChecked == true)
            {
                Check34.Visibility = Visibility.Visible;
            }
        }

        private void Checked34_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked34.IsChecked == false)
            {
                Check34.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked35_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked35.IsChecked == true)
            {
                Check35.Visibility = Visibility.Visible;
            }
        }

        private void Checked35_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked35.IsChecked == false)
            {
                Check35.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked36_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked36.IsChecked == true)
            {
                Check36.Visibility = Visibility.Visible;
            }
        }

        private void Checked36_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked36.IsChecked == false)
            {
                Check36.Visibility = Visibility.Collapsed;
            }
        }

        private void Checked37_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked37.IsChecked == true)
            {
                Check37.Visibility = Visibility.Visible;
            }
        }

        private void Checked37_Unchecked(object sender, RoutedEventArgs e)
        {
            if (Checked37.IsChecked == false)
            {
                Check37.Visibility = Visibility.Collapsed;
            }
        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = Resources["CloseMenu"] as Storyboard;
            sb.Begin(LeftMenu);
            Nav.Opacity = 1;
            Nav.Visibility = Visibility.Visible;
            dgGeneral.Visibility = Visibility.Visible;
        }

        private void MenuNave_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
