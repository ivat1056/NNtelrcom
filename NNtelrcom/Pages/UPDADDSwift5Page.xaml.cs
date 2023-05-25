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
    /// Логика взаимодействия для UPDADDSwift5Page.xaml
    /// </summary>
    public partial class UPDADDSwift5Page : Page
    {
        MKD_ID mKD;
        public UPDADDSwift5Page()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
        }
        public UPDADDSwift5Page(MKD_ID mKD)
        {
            InitializeComponent();
            this.mKD = mKD;
            btnSave.Visibility = Visibility.Visible;
            Name.Text = mKD.Name;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                mKD.Name = Name.Text;
                Base.ep.SaveChanges();
                MessageBox.Show(mKD.Name + " изменен");
                FrameClass4.frame4.Navigate(new MKDIDPage());
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
                MKD_ID cat = new MKD_ID()
                {
                    Name = Name.Text
                };
                Base.ep.MKD_ID.Add(cat);
                Base.ep.SaveChanges();
                MessageBox.Show(cat.Name + " добавлен");
                FrameClass4.frame4.Navigate(new MKDIDPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new MKDIDPage());
        }
    }
}
