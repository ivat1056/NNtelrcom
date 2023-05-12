using MaterialDesignThemes.Wpf;
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
    /// Логика взаимодействия для EmployPage.xaml
    /// </summary>
    public partial class EmployPage : Page
    {
        
        public EmployPage()
        {
            InitializeComponent();
            DbList.ItemsSource = Base.ep.Employ.ToList();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Employ hotel = Base.ep.Employ.FirstOrDefault(x => x.IDEmploy == index);
            FrameClass.administrationf.Navigate(new UPDADDEmploy(hotel));
        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Employ emp = Base.ep.Employ.FirstOrDefault(x => x.IDEmploy == index);
           
            if (MessageBox.Show("Вы уверены что хотите удалить сотрудника: " + emp.Surname + " ?", "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {   
                Base.ep.Employ.Remove(emp);
                Base.ep.SaveChanges();
                FrameClass.administrationf.Navigate(new EmployPage());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.administrationf.Navigate(new AdministrationPage());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.administrationf.Navigate(new UPDADDEmploy());
        }
    }
}
