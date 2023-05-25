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
    /// Логика взаимодействия для MKDIDPage.xaml
    /// </summary>
    public partial class MKDIDPage : Page
    {
        public MKDIDPage()
        {
            InitializeComponent();
            MKDList.ItemsSource = Base.ep.MKD_ID.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new AddMenu());
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new UPDADDSwift5Page());
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            MKD_ID hotel = Base.ep.MKD_ID.FirstOrDefault(x => x.MKD_ID1 == index);
            FrameClass4.frame4.Navigate(new UPDADDSwift5Page(hotel));
        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            MKD_ID emp = Base.ep.MKD_ID.FirstOrDefault(x => x.MKD_ID1 == index);

            if (MessageBox.Show("Вы уверены что хотите удалить : " + emp.Name + " ?", "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Base.ep.MKD_ID.Remove(emp);
                Base.ep.SaveChanges();
                FrameClass4.frame4.Navigate(new MKDIDPage());
            }
        }
    }
}
