using NNtelrcom.Class;
using NNtelrcom.Windows;
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
    /// Логика взаимодействия для UPDADDOrganizationPage.xaml
    /// </summary>
    public partial class UPDADDOrganizationPage : Page
    {
        Organizations organizations;
        public UPDADDOrganizationPage()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;
        }
        public UPDADDOrganizationPage(Organizations organizations)
        {
            InitializeComponent();
            btnSave.Visibility = Visibility.Visible;
            this.organizations = organizations;

            NameOrgan.Text = organizations.NameOrganization;
            IndexO.Text = organizations.IndexO;
            Surname.Text = organizations.Surname;
            Patromoc.Text = organizations.Patronymic;
            Phone.Text = organizations.Phone;
            Name.Text = organizations.Name;
            Email.Text = organizations.Email;
            KPP.Text = organizations.KPP;
            Adress.Text = organizations.Address;
            INN.Text = organizations.INN;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            organizations.NameOrganization = NameOrgan.Text  ;
            organizations.INN = INN.Text;
            organizations.Surname = Surname.Text;
            organizations.Patronymic = Patromoc.Text;
            organizations.Address = Adress.Text;
            organizations.Name = Name.Text;
            organizations.Email = Email.Text;
            organizations.KPP = KPP.Text;
            organizations.IndexO = IndexO.Text ;
            
            
            organizations.Phone = Phone.Text ;
            
            
            Base.ep.SaveChanges();
            MessageBox.Show("Организация " + organizations.NameOrganization + " изменена");
            FrameClass.frameOrg.Navigate(new OrganizationPage());

        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            if (Surname.Text != "" && Name.Text != "" && Patromoc.Text != "" && NameOrgan.Text != "" && INN.Text != "" && Adress.Text != "" && Email.Text != "" && IndexO.Text != "" && Phone.Text != "")
            {
               
                Organizations emp = new Organizations()
                {
                    NameOrganization = NameOrgan.Text,
                    INN = IndexO.Text,
                    Surname = Surname.Text,
                    Patronymic = Phone.Text,
                    Address = Name.Text,
                    Name = Name.Text,
                    Email = Email.Text,
                    KPP = KPP.Text,
                    IndexO = IndexO.Text,
                    Phone = Phone.Text
                };

                Base.ep.Organizations.Add(emp);
                Base.ep.SaveChanges();
                MessageBox.Show("Организация " + emp.NameOrganization + " добавлена");
                FrameClass.frameOrg.Navigate(new OrganizationPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new OrganizationPage());
        }
    }
}
