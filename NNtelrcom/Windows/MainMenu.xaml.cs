using MaterialDesignThemes.Wpf;
using NNtelrcom.Class;
using NNtelrcom.Pages;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace NNtelrcom.Windows
{

    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    /// 

    public partial class MainMenu : Window
    {

        public MainMenu()
        {
            InitializeComponent();
            MenuNave.Click += MenuNave_Click;
            btnclose.MouseLeftButtonUp += PackIcon_MouseLeftButtonDown;
            MenuATC.MouseLeftButtonUp += ATCBtn_MouseLeftButtonDown;
            Home.MouseLeftButtonDown += Home_MouseLeftButtonDown;
            Home.MouseLeftButtonUp += Home_MouseLeftButtonUp;
            Atc.MouseLeftButtonDown += Atc_MouseLeftButtonDown;
            Atc.MouseLeftButtonUp += Atc_MouseLeftButtonUp;
            PersonalAccount.MouseLeftButtonUp += AccountBoxOutline_MouseLeftButtonDown;
            PersonalAccount.MouseLeftButtonUp += PersonalAccount_MouseLeftButtonUp;
            Ext.MouseLeftButtonUp += Ext_MouseLeftButtonUp;
            Ext.MouseLeftButtonUp += MenuNave_Click;
            Administration.MouseLeftButtonUp += Administration_MouseLeftButtonUp;
            Administration.MouseLeftButtonUp += AdministrationBtn_MouseLeftButtonDown;

            Rate.MouseLeftButtonUp += Ratebt_MouseLeftButtonDown;
            Organization.MouseLeftButtonUp += OrganizationBtn_MouseLeftButtonDown;
            TypeRate.MouseLeftButtonUp += TypeRatebtn_MouseLeftButtonDown;
            Phone.MouseLeftButtonUp += Phonebtn_MouseLeftButtonDown;
            Calc.MouseLeftButtonDown += Calc_MouseLeftButtonDown;

            frameOrg.Visibility = Visibility.Hidden;
            PersonalAccauntframe.Visibility = Visibility.Hidden;
            administrationFrame.Visibility = Visibility.Hidden;

            GeneralMenu.Visibility = Visibility.Visible;

            Base.ep = new EP3();
            FrameClass.frame = frame;
            FrameClass.frame.Navigate(new PBXMenu());

            FrameClass2.frame2 = frame2;
            FrameClass2.frame2.Navigate(new CallMenu());

            FrameClass3.frame3 = frame3;
            FrameClass3.frame3.Navigate(new CdCGPage());

            FrameClass5.frame5 = frame5;
            FrameClass5.frame5.Navigate(new EmtyTablePage());

            FrameClass4.frame4 = frame4;
            FrameClass4.frame4.Navigate(new AddMenu());

            FrameClass.frameOrg = frameOrg;
            FrameClass.frameOrg.Navigate(new OrganizationPage());

            //FrameClass.administrationf = administrationFrame;
            //FrameClass.frameOrg.Navigate(new AdministrationPage());
        }

        private void Administration_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            GeneralMenu.Visibility = Visibility.Collapsed;
            MenuATC.Visibility = Visibility.Collapsed;
            frameOrg.Visibility = Visibility.Hidden;
            PersonalAccauntframe.Visibility = Visibility.Collapsed;
            administrationFrame.Visibility = Visibility.Visible;
        }

        private void Ext_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow loading = new MainWindow();
            this.Close();
            loading.Show();
        }

        private void PersonalAccount_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameClass.frameAccaunt = PersonalAccauntframe;
            FrameClass.frameAccaunt.Navigate(new PersonalAccauntPage());
            GeneralMenu.Visibility = Visibility.Collapsed;
            MenuATC.Visibility = Visibility.Collapsed;
            frameOrg.Visibility = Visibility.Hidden;
            PersonalAccauntframe.Visibility = Visibility.Visible;
            administrationFrame.Visibility = Visibility.Collapsed;
        }

        private void Home_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Visible;
            MenuATC.Visibility = Visibility.Collapsed;
            frameOrg.Visibility = Visibility.Hidden;
            PersonalAccauntframe.Visibility = Visibility.Collapsed;
            administrationFrame.Visibility = Visibility.Collapsed;
        }

        private void Atc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Hidden;
            MenuATC.Visibility = Visibility.Visible;
            frameOrg.Visibility = Visibility.Hidden;
            PersonalAccauntframe.Visibility = Visibility.Collapsed;
            administrationFrame.Visibility = Visibility.Collapsed;
        }

        private void Atc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Hidden;
            MenuATC.Visibility = Visibility.Visible;
            frameOrg.Visibility = Visibility.Hidden;
            PersonalAccauntframe.Visibility = Visibility.Collapsed;
            administrationFrame.Visibility = Visibility.Collapsed;
        }

        private void Home_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Visible;
            MenuATC.Visibility = Visibility.Collapsed;
            frameOrg.Visibility = Visibility.Hidden;
            PersonalAccauntframe.Visibility = Visibility.Collapsed;
            administrationFrame.Visibility = Visibility.Collapsed;
        }

        private void Calc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Hidden;
            FrameClass.frameOrg.Navigate(new CalculetionPage());
        }

        private void OrganizationBtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            GeneralMenu.Visibility = Visibility.Hidden;
            FrameClass.frameOrg.Navigate(new OrganizationPage());
        }

        private void BtnUploy_Click(object sender, RoutedEventArgs e)
        {
           LoadingWindow loading = new LoadingWindow();
            this.Close();
            loading.Show();
        }

        private void MenuNave_Click(object sender, RoutedEventArgs e)
        {
            Nav.Opacity = 0.3;
            Storyboard sb = Resources["OpenMenu"] as Storyboard;
            sb.Begin(LeftMenu);
            
        }
        


        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // кнопка убрать меню
        { 
            Storyboard sb = Resources["CloseMenu"] as Storyboard;
            sb.Begin(LeftMenu);
            Nav.Opacity = 1;
        }

       

        private void MenuNave_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MenuNave_Click(sender, e);
        }

        private void Homebt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Visible;
            MenuATC.Visibility = Visibility.Collapsed;
            administrationFrame.Visibility = Visibility.Collapsed;
            PersonalAccauntframe.Visibility = Visibility.Collapsed;

        }

        private void AccountBoxOutline_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Пункт личного кабинета
        {
            FrameClass.frameAccaunt = PersonalAccauntframe;
            FrameClass.frameAccaunt.Navigate(new PersonalAccauntPage());
            GeneralMenu.Visibility = Visibility.Collapsed;
            MenuATC.Visibility = Visibility.Collapsed;
            frameOrg.Visibility = Visibility.Hidden;
            administrationFrame.Visibility = Visibility.Collapsed;
            PersonalAccauntframe.Visibility = Visibility.Visible;
        }

        private void AdministrationBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Пункт админ
        {
           
            GeneralMenu.Visibility = Visibility.Collapsed;
            MenuATC.Visibility = Visibility.Collapsed;
            frameOrg.Visibility = Visibility.Hidden;
            PersonalAccauntframe.Visibility = Visibility.Collapsed;
            administrationFrame.Visibility = Visibility.Visible;
        }

        private void ATCBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Пункт атс
        {
            GeneralMenu.Visibility = Visibility.Hidden;
            MenuATC.Visibility = Visibility.Visible;

        }

        private void extBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // выход
        {
            MainWindow ext = new MainWindow();
            this.Close();
            ext.Show();
        }

        private void General1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void General2_Click(object sender, RoutedEventArgs e)
        {

            GeneralWindow generalPage = new GeneralWindow();
            generalPage.Show();
        }

        private void Ratebt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new RatePage());
            frameOrg.Visibility = Visibility.Visible;
        }

        private void Calcbtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new CalculetionPage());
            frameOrg.Visibility = Visibility.Visible;
        }

        private void Phonebtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new PhonePage());
            frameOrg.Visibility = Visibility.Visible;
        }

        private void OrganizationBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            FrameClass.frameOrg.Navigate(new OrganizationPage());
            frameOrg.Visibility = Visibility.Visible;

        }

        private void TypeRatebtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new RateTypePage());
            frameOrg.Visibility = Visibility.Visible;
        }

        

        private void Calcbtn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            FrameClass.frameOrg.Navigate(new CalculetionPage());
            frameOrg.Visibility = Visibility.Visible;
        }

        private void StackPanel_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //General1.Visibility = Visibility.Visible;
        }

        
    }
}
