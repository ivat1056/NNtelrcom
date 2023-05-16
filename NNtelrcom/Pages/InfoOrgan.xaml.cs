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
using static System.Net.Mime.MediaTypeNames;

namespace NNtelrcom.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfoOrgan.xaml
    /// </summary>
    public partial class InfoOrgan : Page
    {
        OrganInfo organ;
        public InfoOrgan(OrganInfo organ)
        {
            InitializeComponent();
            this.organ = organ;
            NameOrgan.Text = organ.Name;
            KPPOrgan.Text = organ.KPP;
            CeckOrgan.Text = organ.Checkorgan;
            Email.Text = organ.Email;
            Adress.Text = organ.Adress;
            Phone.Text = organ.Phone;
            NameBank.Text = organ.NameBank;
            IndexO.Text = organ.IndexO;
            CheckB.Text = organ.CheckBank;
            bk.Text = organ.Bik;
            INN.Text = organ.INN;
            Password.Text = organ.Password;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (NameOrgan.Text != "" && KPPOrgan.Text != "" && CeckOrgan.Text != "" && Email.Text != "" && Adress.Text != "" && Phone.Text != "" && NameBank.Text != ""   && IndexO.Text != "" && CheckB.Text != ""  && bk.Text != "" && INN.Text != "" && Password.Text != "")
            {

                organ.Name = NameOrgan.Text ;
                organ.INN = INN.Text;
                organ.KPP = KPPOrgan.Text ;
                organ.CheckBank = CheckB.Text;
                organ.Adress = Adress.Text;
                organ.Phone = Phone.Text;
                organ.IndexO = IndexO.Text;
                organ.Checkorgan = CeckOrgan.Text ;
                organ.NameBank = NameBank.Text;
                organ.Bik = bk.Text;
                organ.Email = Email.Text;
                organ.Password = Password.Text ;
                Base.ep.SaveChanges();
                MessageBox.Show("Данные организации сохранины");
                FrameClass.administrationf.Navigate(new AdministrationPage());
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.administrationf.Navigate(new AdministrationPage());
        }
    }
}
