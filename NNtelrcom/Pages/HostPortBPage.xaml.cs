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
    /// Логика взаимодействия для HostPortBPage.xaml
    /// </summary>
    public partial class HostPortBPage : Page
    {
        public HostPortBPage()
        {
            InitializeComponent();
            DataList.ItemsSource = Base.ep.HostB.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new AddMenu());
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new UPDADDIPBPage());
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            HostB hotel = Base.ep.HostB.FirstOrDefault(x => x.IDHostB == index);
            FrameClass4.frame4.Navigate(new UPDADDIPBPage(hotel));
        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            HostB emp = Base.ep.HostB.FirstOrDefault(x => x.IDHostB == index);

            if (MessageBox.Show("Вы уверены что хотите удалить : " + emp.Name + " ?", "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Base.ep.HostB.Remove(emp);
                Base.ep.SaveChanges();
                FrameClass4.frame4.Navigate(new HostPortBPage());
            }
        }
    }
}
