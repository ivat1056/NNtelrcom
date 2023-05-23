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
    /// Логика взаимодействия для UPDADDPhonesPage.xaml
    /// </summary>
    public partial class UPDADDPhonesPage : Page
    {
        PhonesOrganizations phonesOrganizations;
        public UPDADDPhonesPage()
        {
            InitializeComponent();
            btnADD.Visibility = Visibility.Visible;

            Organ.DisplayMemberPath = "NameOrganization";
            Rate.DisplayMemberPath = "Name";


        }
        public UPDADDPhonesPage(PhonesOrganizations phonesOrganizations)
        {
            InitializeComponent();
            btnSave.Visibility = Visibility.Visible;
            this.phonesOrganizations = phonesOrganizations;
            


            Phone.Text = phonesOrganizations.Phone;

            
            List<Organizations> raions = Base.ep.Organizations.ToList(); // Заполнение списка организаций
            foreach (Organizations raion in raions)
            {

                Organ.Items.Add(raion.NameOrganization);
            }

            Organizations organizations = Base.ep.Organizations.FirstOrDefault(x => x.IDOrganization == phonesOrganizations.IDOrganixation);
            Organ.SelectedIndex = Convert.ToInt32(organizations.IDOrganization);
            Organ.Text = organizations.NameOrganization;
            Organ.DisplayMemberPath = "NameOrganization";

            

            List<Rate> rt = Base.ep.Rate.ToList(); // Заполнение списка тарифов
            foreach (Rate r in rt)
            {

                Rate.Items.Add(r.Name);
            }

            Rate rt1 = Base.ep.Rate.FirstOrDefault(x => x.IDRate == phonesOrganizations.IDRate);
            Rate.SelectedIndex = Convert.ToInt32(rt1.IDRate);
            Rate.Text = rt1.Name;
            Rate.DisplayMemberPath = "Name";

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Rate rol = Base.ep.Rate.FirstOrDefault(z => z.Name == Rate.Text);
            int a = rol.IDRate;
            Organizations fl = Base.ep.Organizations.FirstOrDefault(z => z.NameOrganization == Organ.Text);
            int b = fl.IDOrganization;

            phonesOrganizations.Phone = Phone.Text;
            phonesOrganizations.IDOrganixation = b ;
            phonesOrganizations.IDRate = a;

            Base.ep.SaveChanges();
            MessageBox.Show("Телефон " + phonesOrganizations.Phone + " изменен");
            FrameClass.frameOrg.Navigate(new PhonePage());
        }

        private void btnADD_Click(object sender, RoutedEventArgs e)
        {
            Rate rol = Base.ep.Rate.FirstOrDefault(z => z.Name == Rate.Text);
            int a = rol.IDRate;
            Organizations fl = Base.ep.Organizations.FirstOrDefault(z => z.NameOrganization == Organ.Text);
            int b = fl.IDOrganization;

            if (Phone.Text != "" && Rate.Text != "" && Organ.Text != "")
            {
                PhonesOrganizations emp = new PhonesOrganizations()
                {
                    Phone = Phone.Text,
                    IDRate = a,
                    IDOrganixation = b
                   
                };

                Base.ep.PhonesOrganizations.Add(emp);
                Base.ep.SaveChanges();
                MessageBox.Show("Телефон " + emp.Phone + " добавлен");
                FrameClass.frameOrg.Navigate(new PhonePage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new PhonePage());
        }

        private void Rate_TextChanged(object sender, TextChangedEventArgs e)
        {
            Rate.ClearValue(ItemsControl.ItemsSourceProperty);
            Rate.Items.Clear();
            Rate.IsDropDownOpen = true;
            Rate.ItemsSource = Base.ep.Rate.Where(x => x.Name.ToLower().Contains(Rate.Text.ToLower())).ToList();

        }

        private void Organ_TextChanged(object sender, TextChangedEventArgs e)
        {
            Organ.ClearValue(ItemsControl.ItemsSourceProperty);
            Organ.Items.Clear();
            Organ.IsDropDownOpen = true;
            Organ.ItemsSource = Base.ep.Organizations.Where(x => x.NameOrganization.ToLower().Contains(Organ.Text.ToLower())).ToList();

        }
    }
}
