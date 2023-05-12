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
    /// Логика взаимодействия для RateTypePage.xaml
    /// </summary>
    public partial class RateTypePage : Page
    {
        
        public RateTypePage()
        {
            InitializeComponent();
            dbList.ItemsSource = Base.ep.TypeRate.ToList();
        }


    private void Back_Click(object sender, RoutedEventArgs e)
    {
        FrameClass.frameOrg.Visibility = Visibility.Hidden;

    }

    
    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("\n Используя поминутную тарификацию, клиент платит за каждую минуту исходящего звонка. При этом не важно, какой была продолжительность звонка: 1 минуту 5 секунд или 1 минуту 59 секунд, абонент все равно будет платить за 2 минуты.\n По 10-ти секундная тарификация. Клиент платит за каждые 10 секунд\n Посекундная, клиент платит за каждую секунду после 1-ой минуты разговора. \n Пакетный тариф – предложение, которое включает в себя пакет услуг:  минуты, (количество минут прописываются в тарифах) после окончания пакета клиент платит поминутно", "О тарифах");
    }

}
}
