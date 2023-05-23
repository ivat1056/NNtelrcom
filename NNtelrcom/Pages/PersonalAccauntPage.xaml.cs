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
    /// Логика взаимодействия для PersonalAccauntPage.xaml
    /// </summary>
    public partial class PersonalAccauntPage : Page
    {
        Employ Employ;
        public PersonalAccauntPage(Employ employ)
        {
            InitializeComponent();
            this.Employ = employ;

            Surname.Text = employ.Surname;
            Name.Text = employ.Name;
            Otch.Text = employ.Patronymic;
            login.Text = employ.Login;
            pass.Text = employ.Password;

            
            ComboBox1.SelectedIndex = 0;
            Birthday.DataContext = Employ.DataBirsday;


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Floor fl = Base.ep.Floor.FirstOrDefault(z => z.Name == ComboBox1.Text);
            int b = fl.Floor_ID;
            DateTime dateTime = Convert.ToDateTime(Birthday.Text);

            Employ.Surname = Surname.Text;
            Employ.Name = Name.Text;
            Employ.Patronymic = Otch.Text;
            Employ.Login = login.Text;
            Employ.Password = pass.Text;
            Employ.IDRole = Employ.IDRole;
            Employ.IDfloor = b;
            Employ.DataBirsday = dateTime;
            Base.ep.SaveChanges();
            MessageBox.Show("Данные личного кабинента обновлены ");

        }

       
    }
}
