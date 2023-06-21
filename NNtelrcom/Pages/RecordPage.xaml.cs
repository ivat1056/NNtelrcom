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
    /// Логика взаимодействия для RecordPage.xaml
    /// </summary>
    public partial class RecordPage : Page
    {
        public RecordPage()
        {
            InitializeComponent();
            DataList.ItemsSource = Base.ep.RecordNumber.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new AddMenu());
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            //FrameClass4.frame4.Navigate(new UPDADDRecordPage());
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            Fax hotel = Base.ep.Fax.FirstOrDefault(x => x.IDFax == index);
            //FrameClass4.frame4.Navigate(new UPDADDRecordPage(hotel));
        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            RecordNumber emp = Base.ep.RecordNumber.FirstOrDefault(x => x.IDRecordNumber == index);

            if (MessageBox.Show("Вы уверены что хотите удалить : " + emp.Name + " ?", "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Base.ep.RecordNumber.Remove(emp);
                Base.ep.SaveChanges();
                FrameClass4.frame4.Navigate(new RecordPage());
            }
        }
    }
}
