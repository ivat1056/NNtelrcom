using NNtelrcom.Class;
using NNtelrcom.Windows;
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
    /// Логика взаимодействия для OrganizationPage.xaml
    /// </summary>
    public partial class OrganizationPage : Page
    {
        public OrganizationPage()
        {
            InitializeComponent();
            dbList.ItemsSource = Base.ep.Organizations.ToList();
            Back.MouseLeftButtonUp += Back_Click;

        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
           
          FrameClass.frameOrg.Visibility = Visibility.Collapsed;
          

        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new UPDADDOrganizationPage());
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Organizations hotel = Base.ep.Organizations.FirstOrDefault(x => x.IDOrganization == index);
            FrameClass.frameOrg.Navigate(new UPDADDOrganizationPage(hotel));
        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Organizations emp = Base.ep.Organizations.FirstOrDefault(x => x.IDOrganization == index);

            if (MessageBox.Show("Вы уверены что хотите удалить организацию: " + emp.Surname + " ?", "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Base.ep.Organizations.Remove(emp);
                Base.ep.SaveChanges();
                FrameClass.frameOrg.Navigate(new AdministrationPage());
            }
        }
    }
}
