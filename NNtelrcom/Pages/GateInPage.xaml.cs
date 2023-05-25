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
    /// Логика взаимодействия для GateInPage.xaml
    /// </summary>
    public partial class GateInPage : Page
    {
        public GateInPage()
        {
            InitializeComponent();
            DataList.ItemsSource = Base.ep.GateIN.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new AddMenu());
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new UPDADDGateInpage());
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            GateIN hotel = Base.ep.GateIN.FirstOrDefault(x => x.IDGateIN == index);
            FrameClass4.frame4.Navigate(new UPDADDGateInpage(hotel));
        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);
            GateIN emp = Base.ep.GateIN.FirstOrDefault(x => x.IDGateIN == index);

            if (MessageBox.Show("Вы уверены что хотите удалить : " + emp.Name + " ?", "Системное сообщение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Base.ep.GateIN.Remove(emp);
                Base.ep.SaveChanges();
                FrameClass4.frame4.Navigate(new GateInPage());
            }
        }
    }
}
