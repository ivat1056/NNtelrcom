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
    /// Логика взаимодействия для UPDADDTypeCallPage.xaml
    /// </summary>
    public partial class UPDADDTypeCallPage : Page
    {
        Type type;
        public UPDADDTypeCallPage()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
        }
        public UPDADDTypeCallPage(Type type)
        {
            InitializeComponent();
            this.type = type;
            btnSave.Visibility = Visibility.Visible;
            Name.Text = type.Name;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new TypePage());
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                Type cat = new Type()
                {
                    Name = Name.Text
                };
                Base.ep.Type.Add(cat);
                Base.ep.SaveChanges();
                MessageBox.Show(cat.Name + " добавлен");
                FrameClass4.frame4.Navigate(new TypePage());
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
                type.Name = Name.Text;
                Base.ep.SaveChanges();
                MessageBox.Show(type.Name + " изменен");
                FrameClass4.frame4.Navigate(new TypePage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
    }
}
