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
    /// Логика взаимодействия для UPDADDGaneOutPage.xaml
    /// </summary>
    public partial class UPDADDGaneOutPage : Page
    {
        GateOut gateOut;
        public UPDADDGaneOutPage()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
        }
        public UPDADDGaneOutPage(GateOut gateOut)
        {
            InitializeComponent();
            this.gateOut = gateOut;
            btnSave.Visibility = Visibility.Visible;
            Name.Text = gateOut.Name;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                gateOut.Name = Name.Text;
                Base.ep.SaveChanges();
                MessageBox.Show(gateOut.Name + " изменен");
                FrameClass4.frame4.Navigate(new GateOutPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                GateOut cat = new GateOut()
                {
                    Name = Name.Text
                };
                Base.ep.GateOut.Add(cat);
                Base.ep.SaveChanges();
                MessageBox.Show(cat.Name + " добавлен");
                FrameClass4.frame4.Navigate(new GateOutPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new GateOutPage());
        }
    }
}
