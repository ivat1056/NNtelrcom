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
    /// Логика взаимодействия для TypeReleaseDirectionPage.xaml
    /// </summary>
    public partial class TypeReleaseDirectionPage : Page
    {
        List<TypeReleaseDirection> typeReleaseDirections = Base.ep.TypeReleaseDirection.ToList();
        public TypeReleaseDirectionPage()
        {
            InitializeComponent();
            CallTer.ItemsSource = Base.ep.TypeReleaseDirection.ToList();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass2.frame2.Navigate(new CallMenu());
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {

        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            //if (PBXList.SelectedItems.Count != 0)
            //{
            //    foreach (PBXType pBX in PBXList.SelectedItems)
            //    {
            //        List<PBXType> hot = Base.ep.PBXType.Where(z => z.IDPBXType == pBX.IDPBXType).ToList();
            //        foreach (PBXType h in hot)
            //        {
            //            if (MessageBox.Show("Вы хотите удалить {0}", Name, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //            {
            //                Base.ep.PBXType.Remove(pBX);
            //                Base.ep.SaveChanges();
            //                MessageBox.Show("Успешное удаление!!!");
            //            }


            //        }
            //    }
            //}
        }
    }
}
