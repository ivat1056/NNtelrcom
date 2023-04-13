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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NNtelrcom.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddMenu.xaml
    /// </summary>
    public partial class AddMenu : Page
    {
        public AddMenu()
        {
            InitializeComponent();
        }

        private void MKDIDBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new MKDIDPage());
        }

        private void EventBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new EventPage());
        }

        private void Type_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new TypePage());
        }

        private void HostPortABtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new HostPortAPage());
        }

        private void CatBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new CatPage());
        }

        private void HostPortBBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new HostPortBPage());
        }

        private void FaxBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new FaxPage());
        }

        private void GetInBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new GateInPage());
        }

        private void GetOunBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new GateOutPage());
        }

        private void RecordBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new RecordPage());
        }
    }
}
