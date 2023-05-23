using NNtelrcom.Class;
using PdfSharp.Pdf;
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
using static System.Net.Mime.MediaTypeNames;

namespace NNtelrcom.Pages
{
    /// <summary>
    /// Логика взаимодействия для UPDADDRate.xaml
    /// </summary>
    public partial class UPDADDRate : Page
    {
        Rate rate;
        string CountMinute; 
        public UPDADDRate()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
            VCountM.Visibility = Visibility.Collapsed;
            ComboBox1.ItemsSource = Base.ep.TypeRate.ToList();
            ComboBox1.SelectedValuePath = "IDTypeRate";
            ComboBox1.DisplayMemberPath = "Name";
        }
        public UPDADDRate(Rate rate)
        {
            InitializeComponent();
            btnSave.Visibility = Visibility.Visible;
            this.rate = rate;
            VCountM.Visibility = Visibility.Collapsed;
            NameT.Text = rate.Name;
            CostM.Text = rate.Cost;
            Direct.Text = rate.Direction;


            List<TypeRate> raions = Base.ep.TypeRate.ToList(); // заполнение типов 
            int CurrentIndex = -1;
            foreach (TypeRate raion in raions)
            {
                CurrentIndex += 1;
                ComboBox1.Items.Add(raion.Name);
                if(raion.IDTypeRate == rate.IDTyprRate)
                {
                    ComboBox1.SelectedIndex = CurrentIndex;
                }
            }
            

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox1.SelectedIndex == 3)
            {
                VCountM.Visibility = Visibility.Visible;
                CountMinute = CountM.Text;
            }
            else
            {
                VCountM.Visibility = Visibility.Collapsed;
                CountMinute = "0";
            }
            TypeRate rt = Base.ep.TypeRate.FirstOrDefault(z => z.Name == ComboBox1.Text);
            int a = rt.IDTypeRate;
            rate.Name = NameT.Text;
            rate.IDTyprRate = a;
            rate.Cost = CostM.Text;
            rate.Direction = Direct.Text;
            rate.NumberOfMinutes = CountMinute;
            
            
            

            Base.ep.SaveChanges();
            MessageBox.Show("Тариф " + rate.Name + " изменен");
            FrameClass.frameOrg.Navigate(new RatePage());
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            TypeRate rt = Base.ep.TypeRate.FirstOrDefault(z => z.Name == ComboBox1.Text);
            int a = rt.IDTypeRate;
            if (NameT.Text != "" && CostM.Text != "" && Direct.Text != "")
            {
                if (ComboBox1.SelectedIndex == 3)
                {
                    VCountM.Visibility = Visibility.Visible;
                    CountMinute = CountM.Text;
                }
                else
                {
                    VCountM.Visibility = Visibility.Collapsed;
                    CountMinute = "0";
                }

                Rate emp = new Rate()
                {
                    Name = NameT.Text,
                    IDTyprRate = a,
                    Cost = CostM.Text,
                    Direction = Direct.Text,
                    NumberOfMinutes = CountMinute
                };

                Base.ep.Rate.Add(emp);
                Base.ep.SaveChanges();
                MessageBox.Show("Тариф " + emp.Name + " добавлен");
                FrameClass.frameOrg.Navigate(new RatePage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new RatePage());
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.SelectedIndex == 3)
            {
                VCountM.Visibility = Visibility.Visible;
                CountMinute = CountM.Text;
            }
            else
            {
                VCountM.Visibility = Visibility.Collapsed;
                CountMinute = "0";
            }
        }
    }
}
