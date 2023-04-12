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
    /// Логика взаимодействия для PBXMenu.xaml
    /// </summary>
    public partial class PBXMenu : Page
    {
        public PBXMenu()
        {
            InitializeComponent();
        }

        private void MainPbxBt_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new MainPBXPage());
        }

        private void PbxINBt_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new PBXINPage());
        }

        private void PbxOutBt_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new PBXOUTPage());
        }

        private void Pbx_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new PBXPage());
        }
    }
}
