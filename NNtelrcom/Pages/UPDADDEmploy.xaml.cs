using NNtelrcom.Class;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NNtelrcom.Pages
{
    /// <summary>
    /// Логика взаимодействия для UPDADDEmploy.xaml
    /// </summary>
    public partial class UPDADDEmploy : Page
    {
        Employ employ;
        public UPDADDEmploy()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
            ComboBox1.ItemsSource = Base.ep.Floor.ToList();
            ComboBox1.SelectedValuePath = "Floor_ID";
            ComboBox1.DisplayMemberPath = "Name";
            ComboBox1.SelectedIndex = 0;

            Role.ItemsSource = Base.ep.Role.ToList();
            Role.SelectedValuePath = "Role_ID";
            Role.DisplayMemberPath = "Name";
            Role.SelectedIndex = 0;
        }
        public UPDADDEmploy(Employ employ)
        {
            InitializeComponent();
            this.employ = employ;


            Surname.Text = employ.Surname;
            Name.Text = employ.Name;
            Otch.Text = employ.Patronymic;
            login.Text = employ.Login;
            pass.Text = employ.Password;

            btnSave.Visibility = Visibility.Visible;
            ComboBox1.ItemsSource = Base.ep.Floor.ToList();
            ComboBox1.SelectedValuePath = "Floor";
            ComboBox1.DisplayMemberPath = "Name";
            ComboBox1.SelectedIndex = 0;

            Role.ItemsSource = Base.ep.Role.ToList();
            Role.SelectedValuePath = "Role_ID";
            Role.DisplayMemberPath = "Name";
            Role.SelectedIndex = 0;

            Birthday.Text = Convert.ToString(employ.DataBirsday);

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Surname.Text != "" && Name.Text != "" && Otch.Text != "" && ComboBox1.SelectedIndex != -1 && Birthday.Text != "" && login.Text != "" && Role.Text != "" && pass.Text != "")
            {
                Role rol = Base.ep.Role.FirstOrDefault(z => z.Name == Role.Text);
                int a = rol.Role_ID;
                Floor fl = Base.ep.Floor.FirstOrDefault(z => z.Name == ComboBox1.Text);
                int b = fl.Floor_ID;
                DateTime dateTime = Convert.ToDateTime(Birthday.Text);

                employ.Surname = Surname.Text;
                employ.Name = Name.Text;
                employ.Patronymic = Otch.Text;
                employ.Login = login.Text;
                employ.Password = pass.Text;
                employ.IDRole = a;
                employ.IDfloor = b;
                employ.DataBirsday = dateTime;
                Base.ep.SaveChanges();
                MessageBox.Show("Сотрудник " + employ.Surname + " изменен");
                FrameClass.administrationf.Navigate(new EmployPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            if (Surname.Text != "" && Name.Text != "" && Otch.Text != "" && ComboBox1.SelectedIndex != -1 && Birthday.Text != "" && login.Text != "" && Role.Text != "" && pass.Text != "")
            {
                Role employ = Base.ep.Role.FirstOrDefault(z => z.Name == Role.Text);
                int a = employ.Role_ID;
                Floor fl = Base.ep.Floor.FirstOrDefault(z => z.Name == ComboBox1.Text);
                int b = fl.Floor_ID;
                DateTime dateTime = Convert.ToDateTime(Birthday.Text);

                Employ emp = new Employ()
                {
                    Surname = Surname.Text,
                    Name = Name.Text,
                    Patronymic = Otch.Text,
                    Login = login.Text,
                    Password = Name.Text,
                    IDRole = a,
                    IDfloor = b,
                    DataBirsday = dateTime
                };

                Base.ep.Employ.Add(emp);
                Base.ep.SaveChanges();
                MessageBox.Show("Сотрудник " + emp.Surname + " добавлен");
                FrameClass.administrationf.Navigate(new EmployPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.administrationf.Navigate(new EmployPage());
        }
    }
}
