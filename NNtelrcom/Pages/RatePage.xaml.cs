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
    /// Логика взаимодействия для RatePage.xaml
    /// </summary>
    public partial class RatePage : Page
    {
        public RatePage()
        {
            InitializeComponent();
            dbList.ItemsSource = Base.ep.Rate.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frameOrg.Visibility = Visibility.Hidden;

        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new UPDADDRate());
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Rate hotel = Base.ep.Rate.FirstOrDefault(x => x.IDRate == index);
            FrameClass.frameOrg.Navigate(new UPDADDRate(hotel));
        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Rate emp = Base.ep.Rate.FirstOrDefault(x => x.IDRate == index);

            if (MessageBox.Show("Вы уверены что хотите удалить тариф: " + emp.Name + " ?", "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Base.ep.Rate.Remove(emp);
                Base.ep.SaveChanges();
                FrameClass.frameOrg.Navigate(new RatePage());
            }
        }
    }
}
