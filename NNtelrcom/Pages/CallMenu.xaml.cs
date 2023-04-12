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
    /// Логика взаимодействия для CallMenu.xaml
    /// </summary>
    public partial class CallMenu : Page
    {
        public CallMenu()
        {
            InitializeComponent();
        }

        private void CallTermination_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new CallTerminationPage());
        }

        private void Q931Cause_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new Q931CausePage());
        }

        private void TypeReleaseDirection_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new TypeReleaseDirectionPage());
        }

        private void TypeEstablishFlag_Click(object sender, RoutedEventArgs e)
        {
            // FrameClass.frame.Navigate(new TypeEstablishFlagPage());
        }

        private void TypeCause_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new TypeCausePage());
        }
    }
}
