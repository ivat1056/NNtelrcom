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


            Base.ep = new EP2();
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

            //FrameClass6.frame = frame6;
            //FrameClass6.frame.Navigate(new GeneralMenuPage());

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


        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // rнопка убрать меню
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
            MainMenu menu = new MainMenu();
            this.Close();
            menu.Show();
        }

        private void AccountBoxOutline_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Пункт личного кабинета
        {

        }

        private void AdministrationBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Пункт админ
        {

        }

        private void ATCBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // Пункт атс
        {
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
    }
}
