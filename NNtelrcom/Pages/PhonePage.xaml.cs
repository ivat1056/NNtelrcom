using NNtelrcom.Class;
using System;
using System.Collections;
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
    /// Логика взаимодействия для PhonePage.xaml
    /// </summary>
    public partial class PhonePage : Page
    {
        public PhonePage()
        {
            InitializeComponent();
            dbList.ItemsSource = Base.ep.PhonesOrganizations.ToList();
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frameOrg.Visibility = Visibility.Hidden;

        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new UPDADDPhonesPage());
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            PhonesOrganizations phones = Base.ep.PhonesOrganizations.FirstOrDefault(x => x.IDPhoneOrganozation == index);
            FrameClass.frameOrg.Navigate(new UPDADDPhonesPage(phones));
        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            PhonesOrganizations phones = Base.ep.PhonesOrganizations.FirstOrDefault(x => x.IDPhoneOrganozation == index);

            if (MessageBox.Show("Вы уверены что хотите удалить телефон: " + phones.Phone + " ?", "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Base.ep.PhonesOrganizations.Remove(phones);
                Base.ep.SaveChanges();
                FrameClass.frameOrg.Navigate(new PhonePage());
            }
        }
    }
}
