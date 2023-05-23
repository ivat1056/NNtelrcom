using NNtelrcom.Class;
using NNtelrcom.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NNtelrcom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Base.ep = new EP3();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != "" || PasswordBox2.Password != "")
            {

                Employ employ = Base.ep.Employ.FirstOrDefault(z => z.Login == NameTextBox.Text);
                if (employ != null)
                {
                    if (employ.Password == PasswordBox2.Password)
                    {

                        MainMenu mainMenu = new MainMenu(employ);
                        this.Close();
                        mainMenu.Show();

                    }
                    else
                    {
                        MessageBox.Show("Пароль введен не верно");
                    }
                }
                else
                {
                    MessageBox.Show("Сотрудник с таким логином не сществует ");
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль ");
            }
            
        }
    }
}
