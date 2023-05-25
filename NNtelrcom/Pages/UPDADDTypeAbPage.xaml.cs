using NNtelrcom.Class;
using System.Windows;
using System.Windows.Controls;

namespace NNtelrcom.Pages
{
    /// <summary>
    /// Логика взаимодействия для UPDADDTypeAbPage.xaml
    /// </summary>
    public partial class UPDADDTypeAbPage : Page
    {
        Cat cat;
        public UPDADDTypeAbPage()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
        }
        public UPDADDTypeAbPage(Cat cat)
        {
            InitializeComponent();
            this.cat = cat;
            btnSave.Visibility = Visibility.Visible;
            Name.Text = cat.Name;

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass4.frame4.Navigate(new CatPage());
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "")
            {
                Cat cat = new Cat()
                {
                    Name = Name.Text
                };
                Base.ep.Cat.Add(cat);
                Base.ep.SaveChanges();
                MessageBox.Show(cat.Name + " добавлен");
                FrameClass4.frame4.Navigate(new CatPage());
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
                cat.Name = Name.Text;
                Base.ep.SaveChanges();
                MessageBox.Show(cat.Name + " изменен");
                FrameClass4.frame4.Navigate(new CatPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
    }
}
