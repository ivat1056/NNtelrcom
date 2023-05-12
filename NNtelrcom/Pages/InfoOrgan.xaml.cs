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
           
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.administrationf.Navigate(new AdministrationPage());
        }
    }
}
