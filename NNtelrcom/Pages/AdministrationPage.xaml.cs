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
    /// Логика взаимодействия для AdministrationPage.xaml
    /// </summary>
    public partial class AdministrationPage : Page
    {
        public AdministrationPage()
        {
            InitializeComponent();
            Users.MouseLeftButtonUp += TypeRatebtn_MouseLeftButtonUp;
            Organisation.MouseLeftButtonUp += TypeRatebtn2_MouseLeftButtonUp;
        }

        private void TypeRatebtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameClass.administrationf.Navigate(new EmployPage());
        }

        private void TypeRatebtn2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameClass.administrationf.Navigate(new InfoOrgan());
        }
    }
}
