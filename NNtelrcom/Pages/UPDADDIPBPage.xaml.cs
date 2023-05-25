using NNtelrcom.Class;
using System.Windows;
using System.Windows.Controls;

namespace NNtelrcom.Pages
{
    /// <summary>
    /// Логика взаимодействия для UPDADDIPBPage.xaml
    /// </summary>
    public partial class UPDADDIPBPage : Page
    {
        HostB hostB;
        public UPDADDIPBPage()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
        }
        public UPDADDIPBPage(HostB hostB)
        {
            InitializeComponent();
            this.hostB = hostB;
            btnSave.Visibility = Visibility.Visible;
            Name.Text = hostB.Name;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new HostPortBPage());
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                HostB cat = new HostB()
                {
                    Name = Name.Text
                };
                Base.ep.HostB.Add(cat);
                Base.ep.SaveChanges();
                MessageBox.Show(cat.Name + " добавлен");
                FrameClass4.frame4.Navigate(new HostPortBPage());
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
                hostB.Name = Name.Text;
                Base.ep.SaveChanges();
                MessageBox.Show(hostB.Name + " изменен");
                FrameClass4.frame4.Navigate(new HostPortBPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
    }
}
