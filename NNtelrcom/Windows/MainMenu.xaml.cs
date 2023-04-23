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

            Rate.MouseLeftButtonUp += Ratebt_MouseLeftButtonDown;
            Organization.MouseLeftButtonUp += OrganizationBtn_MouseLeftButtonDown;
            TypeRate.MouseLeftButtonUp += TypeRatebtn_MouseLeftButtonDown;
            Phone.MouseLeftButtonUp += Phonebtn_MouseLeftButtonDown;
            Calc.MouseLeftButtonDown += Calc_MouseLeftButtonDown;





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

            

        }

        private void Home_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Visible;
            MenuATC.Visibility = Visibility.Collapsed;
        }

        private void Atc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Hidden;
            MenuATC.Visibility = Visibility.Visible;
        }

        private void Atc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Hidden;
            MenuATC.Visibility = Visibility.Visible;
        }

        private void Home_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Visible;
            MenuATC.Visibility = Visibility.Collapsed;
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
        

        public void CloseIcone()
        {

        }
        public void MainPage()
        {

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

        }

        private void AccountBoxOutline_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Пункт личного кабинета
        {

        }

        private void AdministrationBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Пункт админ
        {

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
           GeneralMenu.Visibility = Visibility.Hidden;
            FrameClass.frameOrg.Navigate(new RatePage());
        }

        private void Calcbtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Hidden;
            FrameClass.frameOrg.Navigate(new CalculetionPage());
        }

        private void Phonebtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Hidden;
            FrameClass.frameOrg.Navigate(new PhonePage());
        }

        private void OrganizationBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Hidden;
            FrameClass.frameOrg.Navigate(new OrganizationPage());
        }

        private void TypeRatebtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GeneralMenu.Visibility = Visibility.Hidden;
            FrameClass.frameOrg.Navigate(new RateTypePage());
        }

        private void frameOrg_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
