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
    /// Логика взаимодействия для CallTerminationPage.xaml
    /// </summary>
    public partial class CallTerminationPage : Page
    {
        public CallTerminationPage()
        {
            InitializeComponent();
            dgGeneral.ItemsSource = Base.ep.CallTermination.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass2.frame2.Navigate(new CallMenu());
        }
    }
}
