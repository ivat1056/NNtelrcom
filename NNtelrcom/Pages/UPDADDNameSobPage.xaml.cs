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
    /// Логика взаимодействия для UPDADDNameSobPage.xaml
    /// </summary>
    public partial class UPDADDNameSobPage : Page
    {
        Event Event;
        public UPDADDNameSobPage()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
        }
        public UPDADDNameSobPage(Event Event)
        {
            InitializeComponent();
            this.Event = Event;
            btnSave.Visibility = Visibility.Visible;
            Name.Text = Event.Name;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new EventPage());
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                Event cat = new Event()
                {
                    Name = Name.Text
                };
                Base.ep.Event.Add(cat);
                Base.ep.SaveChanges();
                MessageBox.Show(cat.Name + " добавлен");
                FrameClass4.frame4.Navigate(new EventPage());
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
                Event.Name = Name.Text;
                Base.ep.SaveChanges();
                MessageBox.Show(Event.Name + " изменен");
                FrameClass4.frame4.Navigate(new EventPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
    }
}
