using NNtelrcom.Class;
using System.Windows;
using System.Windows.Controls;

namespace NNtelrcom.Pages
{
    /// <summary>
    /// Логика взаимодействия для UPDADDFaxPage.xaml
    /// </summary>
    public partial class UPDADDFaxPage : Page
    {
        Fax Fax;
        public UPDADDFaxPage()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
        }
        public UPDADDFaxPage(Fax fax)
        {
            InitializeComponent();
            this.Fax = fax;
            btnSave.Visibility = Visibility.Visible;
            Name.Text = fax.Name;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                Fax.Name = Name.Text;
                Base.ep.SaveChanges();
                MessageBox.Show(Fax.Name + " изменен");
                FrameClass4.frame4.Navigate(new FaxPage());
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
                Fax cat = new Fax()
                {
                    Name = Name.Text
                };
                Base.ep.Fax.Add(cat);
                Base.ep.SaveChanges();
                MessageBox.Show(cat.Name + " добавлен");
                FrameClass4.frame4.Navigate(new FaxPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new FaxPage());
        }
    }
}
