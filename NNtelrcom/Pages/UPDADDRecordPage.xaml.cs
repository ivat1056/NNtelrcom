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
    /// Логика взаимодействия для UPDADDRecordPage.xaml
    /// </summary>
    public partial class UPDADDRecordPage : Page
    {
        RecordNumber RecordNumber;
        public UPDADDRecordPage()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
        }
        public UPDADDRecordPage(RecordNumber RecordNumber)
        {
            InitializeComponent();
            this.RecordNumber = RecordNumber;
            btnSave.Visibility = Visibility.Visible;
            Name.Text = RecordNumber.Name;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                RecordNumber.Name = Name.Text;
                Base.ep.SaveChanges();
                MessageBox.Show(RecordNumber.Name + " изменен");
                FrameClass4.frame4.Navigate(new RecordPage());
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
                RecordNumber cat = new RecordNumber()
                {
                    Name = Name.Text
                };
                Base.ep.RecordNumber.Add(cat);
                Base.ep.SaveChanges();
                MessageBox.Show(cat.Name + " добавлен");
                FrameClass4.frame4.Navigate(new RecordPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new RecordPage());
        }
    }
}
