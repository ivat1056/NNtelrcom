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
    /// Логика взаимодействия для HostPortAPage.xaml
    /// </summary>
    public partial class HostPortAPage : Page
    {
        public HostPortAPage()
        {
            InitializeComponent();
            DataList.ItemsSource = Base.ep.HostA.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new AddMenu());
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new UPDADDIPAPage());
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            HostA hotel = Base.ep.HostA.FirstOrDefault(x => x.IDHostA == index);
            FrameClass4.frame4.Navigate(new UPDADDIPAPage(hotel));
        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            HostA emp = Base.ep.HostA.FirstOrDefault(x => x.IDHostA == index);

            if (MessageBox.Show("Вы уверены что хотите удалить : " + emp.Name + " ?", "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Base.ep.HostA.Remove(emp);
                Base.ep.SaveChanges();
                FrameClass4.frame4.Navigate(new HostPortAPage());
            }
        }
    }
}
