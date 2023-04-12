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
    /// Логика взаимодействия для TypeCausePage.xaml
    /// </summary>
    public partial class TypeCausePage : Page
    {
        List<TypeCause> typeCauseList = Base2.ep2.TypeCause.ToList();

        public TypeCausePage()
        {
            InitializeComponent();
            CallTer.ItemsSource = Base2.ep2.TypeCause.ToList();

        }
        private void ADD_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.frame.Navigate(new PBXMenu());
        }


        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDell_Click(object sender, RoutedEventArgs e)
        {
            //if (CallTer.SelectedItems.Count != 0)
            //{
            //    foreach (PBXType pBX in CallTer.SelectedItems)
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
