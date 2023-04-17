using Microsoft.Win32;
using NNtelrcom.Class;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace NNtelrcom.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                int size = -1;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = true;
                openFileDialog.Filter = "Text files (*.log)|*.log|All files (*.*)|*.*";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (string filename in openFileDialog.FileNames) lbFiles.Items.Add(System.IO.Path.GetFileName(filename));
                    string file = openFileDialog.FileName;

                    using (StreamReader reader = new StreamReader(file))
                    {
                        string line;

                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] massiv = new string[37];
                            massiv = line.Split(';');
                        string MKD_ID1 = massiv[0];
                        string CallID1 = massiv[1];
                        string CallLegIDD1 = massiv[2];
                        string Event1 = massiv[3];

                        string CdPN_root_out1 = massiv[4];
                        string CgPN_root_out1 = massiv[5];

                        string PN_List1 = massiv[6];
                        string OgPN_root1 = massiv[7];
                        string RdPN_root1 = massiv[8];
                        string EstablishFlag1 = massiv[9];
                        string ReleaseDirection1 = massiv[10];
                        string Cause1  = massiv[11];
                        string Q931Cause1 = massiv[12];
                        string SetupDateTime1 = massiv[13];
                        string ReleaseDateTime1 = massiv[14];
                        string CallDuration1 = massiv[15];
                        string AnswerDateTime1 = massiv[16];
                        string SpeechDuration1 = massiv[17];
                        string FaxDuration1 = massiv[18];
                        string HostPort_A1 = massiv[19];
                        string HostPort_B1 = massiv[20];
                        string type1 = massiv[21];
                        string Cat1 = massiv[22];

                        string CdPN_root_in1 = massiv[23];
                        string CgPN_root_in1 = massiv[24];
                        string CdPN_ext_out1 = massiv[25];
                        string CgPN_ext_out1 = massiv[26];
                        string CdPN_ext_in1 = massiv[27];
                        string CgPN_ext_in1 = massiv[28];

                        string OgPN_ext = massiv[29];
                        string RdPN_ext = massiv[30];
                        string pbx_in = massiv[31];
                        string pbx_out = massiv[32];
                        string pbx = massiv[33];
                        string record_number = massiv[34];
                        string GateIN = massiv[35];
                        string GateOUT = massiv[36];
                        string Session_ID = massiv[37];


                        
                        CgPCdPh Cd = new CgPCdPh()
                        {
                            CdPN_root_out = CdPN_root_out1,
                            CgPN_root_out = CgPN_root_out1,
                            CdPN_root_in = CdPN_root_in1,
                            CdPN_ext_out = CdPN_ext_out1,
                            CgPN_ext_out = CgPN_ext_out1,
                            CgPN_root_in = CgPN_root_in1,
                            CdPN_ext_in = CdPN_ext_in1,
                            CgPN_ext_in = CgPN_ext_in1

                        };
                        int IDCh = Base.ep.CgPCdPh.FirstOrDefault(z => z.IDCgPhCdPh == z.IDCgPhCdPh );

                        Base.ep.CgPCdPh.Add(Cd);
                        Base.ep.SaveChanges();
                        //CgPCdPh cd2 = Base.ep.CgPCdPh.FirstOrDefault(z => z.IDCgPhCdPh);
                        //if (user2.UserRole == 1)
                        //{
                        //    Role = 1;
                        //}


                    }
                    }

                }


           
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            this.Close();
            mainMenu.Show();
        }
    }
}
