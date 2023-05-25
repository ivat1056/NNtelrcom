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
    /// Логика взаимодействия для UPDADDIPAPage.xaml
    /// </summary>
    public partial class UPDADDIPAPage : Page
    {
        HostA hostA;
        public UPDADDIPAPage()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
        }
        public UPDADDIPAPage(HostA hostA)
        {
            InitializeComponent();
            this.hostA = hostA;
            btnSave.Visibility = Visibility.Visible;
            Name.Text = hostA.Name;

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new HostPortAPage());
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                HostA cat = new HostA()
                {
                    Name = Name.Text
                };
                Base.ep.HostA.Add(cat);
                Base.ep.SaveChanges();
                MessageBox.Show(cat.Name + " добавлен");
                FrameClass4.frame4.Navigate(new HostPortAPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                hostA.Name = Name.Text;
                Base.ep.SaveChanges();
                MessageBox.Show(hostA.Name + " изменен");
                FrameClass4.frame4.Navigate(new HostPortAPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
    }
}
