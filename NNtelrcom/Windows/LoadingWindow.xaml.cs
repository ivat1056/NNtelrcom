using Microsoft.Win32;
using NNtelrcom.Class;
using NNtelrcom.Pages;
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
        Employ employ;
        public LoadingWindow(Employ employ)
        {
            InitializeComponent();
            this.employ = employ;
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

                        string MKD_ID1 = massiv[0]; // 
                        string CallID1 = massiv[1];
                        string CallLegIDD1 = massiv[2];
                        string Event1 = massiv[3]; // 

                        string CdPN_root_out1 = massiv[4]; //
                        string CgPN_root_out1 = massiv[5]; // 

                        string PN_List1 = massiv[6]; // 
                        string OgPN_root1 = massiv[7]; // 
                        string RdPN_root1 = massiv[8]; // 
                        string EstablishFlag1 = massiv[9];
                        string ReleaseDirection1 = massiv[10];
                        string Cause1 = massiv[11];
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

                        string OgPN_ext1 = massiv[29];
                        string RdPN_ext1 = massiv[30];
                        string pbx_in1 = massiv[31];
                        string pbx_out1 = massiv[32];
                        string pbx1 = massiv[33];
                        string record_number1 = massiv[34];
                        string GateIN1 = massiv[35];
                        string GateOUT1 = massiv[36];
                        string Session_ID1 = massiv[37];



                        CgPCdPh Cd = new CgPCdPh()
                        {
                            CdPN_root_out = CdPN_root_out1,
                            CgPN_root_out = CgPN_root_out1,
                            CdPN_root_in = CdPN_root_in1,
                            CdPN_ext_out = CdPN_ext_out1,
                            CgPN_ext_out = CgPN_ext_out1,
                            CgPN_root_in = CgPN_root_in1,
                            CdPN_ext_in = CdPN_ext_in1,
                            CgPN_ext_in = CgPN_ext_in1,
                            SessionID = Session_ID1

                        };

                        Base.ep.CgPCdPh.Add(Cd);
                        Base.ep.SaveChanges();


                        CgPCdPh cd = Base.ep.CgPCdPh.FirstOrDefault(z => z.SessionID == Session_ID1);
                        int CD = cd.IDCgPhCdPh;  // id cd

                        PBX_In pBX_In = Base.ep.PBX_In.FirstOrDefault(z => z.Name == pbx_in1);
                        PBX_Out pBX_Out = Base.ep.PBX_Out.FirstOrDefault(z => z.Name == pbx_out1);
                        PBXType pBXType = Base.ep.PBXType.FirstOrDefault(z => z.Name == pbx1);

                        int PbxIn, PbxOut, PbxType;
                        PbxIn = pBX_In.IDpbx_in;
                        PbxOut = pBX_Out.IDpbx_out;
                        PbxType = pBXType.IDPBXType;


                        MainPBX PBX = new MainPBX()
                        {
                            IDpbx_in = PbxIn,
                            IDpbx_out = PbxOut,
                            IDPBXType = PbxType,

                            SessionID = Session_ID1

                        };

                        Base.ep.MainPBX.Add(PBX);
                        Base.ep.SaveChanges();

                        MainPBX pbx = Base.ep.MainPBX.FirstOrDefault(z => z.SessionID == Session_ID1);
                        int pbx2 = pbx.IDPBX;  // id pbx

                        UnusedParameters unused = new UnusedParameters()
                        {
                            PN_List = PN_List1,
                            OgPN_root = OgPN_root1,
                            RdPN_root = RdPN_root1,
                            OgPN_ext = OgPN_ext1,
                            RdPN_ext = RdPN_ext1,
                            SessionID = Session_ID1

                        };
                        Base.ep.UnusedParameters.Add(unused);
                        Base.ep.SaveChanges();

                        UnusedParameters UD = Base.ep.UnusedParameters.FirstOrDefault(z => z.SessionID == Session_ID1);
                        int UD2 = UD.IDEmptyDate;  // id emty



                        TypeEstablishFlag EF = Base.ep.TypeEstablishFlag.FirstOrDefault(z => z.Name == EstablishFlag1);
                        int ef = EF.IDTypeEstablishFlag; // flag

                        TypeReleaseDirection typeRelease = Base.ep.TypeReleaseDirection.FirstOrDefault(z => z.Name == ReleaseDirection1);
                        int TR = typeRelease.IDTypeReleaseDirection;  // id  releas

                        TypeCause TC = Base.ep.TypeCause.FirstOrDefault(z => z.Name == Cause1);
                        int tc = TC.IDCause;  // id  cause


                        Q931Cause q = Base.ep.Q931Cause.FirstOrDefault(z => z.Name == Q931Cause1);
                        int Q = q.IDQ931Cause;  // id  q93


                        CallTermination call = new CallTermination()
                        {
                            IDTypeEstablishFlag = ef,
                            IDTypeReleaseDirection = TR,
                            IDQ931Cause = Q,
                            IDCause =tc,
                            SessionID = Session_ID1
                        };
                        Base.ep.CallTermination.Add(call);
                        Base.ep.SaveChanges();

                        CallTermination CT = Base.ep.CallTermination.FirstOrDefault(z => z.SessionID == Session_ID1);
                        int ct = CT.IDCallTermination;  // id emty


                        MKD_ID mKD_ID = Base.ep.MKD_ID.FirstOrDefault(z => z.Name == MKD_ID1);
                        int mkd = mKD_ID.MKD_ID1; // mkd

                        Event ev = Base.ep.Event.FirstOrDefault(z => z.Name == Event1);
                        int eventN = ev.IDEvent; // event 

                        //Base.ep.Event.Where(x => x.Name.ToLower().Contains(Event1.ToLower())).ToList();

                        Fax fax = Base.ep.Fax.FirstOrDefault(z => z.Name == FaxDuration1);
                        int fax1 = fax.IDFax; // fax

                        Cat cat = Base.ep.Cat.FirstOrDefault(z => z.Name == Cat1);
                        int cat1 = cat.IDTypeCatID;

                        Type tp = Base.ep.Type.FirstOrDefault(z => z.Name == type1);
                        int type =tp.IDType ; // type

                        HostA ha = Base.ep.HostA.FirstOrDefault(z => z.Name == HostPort_A1);
                        int hoa = ha.IDHostA; // host a

                        HostB hb = Base.ep.HostB.FirstOrDefault(z => z.Name == HostPort_B1);
                        int hob = hb.IDHostB; // host b

                        GateIN GIN = Base.ep.GateIN.FirstOrDefault(z => z.Name == GateIN1);
                        int gin = GIN.IDGateIN; // gate in 

                        GateOut GOUT = Base.ep.GateOut.FirstOrDefault(z => z.Name == GateOUT1);
                        int gout = GOUT.IDGateOut; // gate out

                        RecordNumber record = Base.ep.RecordNumber.FirstOrDefault(z => z.Name == record_number1);
                        int rec = record.IDRecordNumber; // record


                        ATC aTC = new ATC()
                        {
                            IDMKD = mkd,
                            CallID = CallID1,
                            CallLegID = CallLegIDD1,
                            IDEvent = eventN, 
                            IDCallTermination = ct,
                            SetupDateTime = SetupDateTime1,
                            ReleaseDateTime = ReleaseDateTime1, 
                            CallDuration = CallDuration1,
                            AnswerDateTime = AnswerDateTime1, 
                            SpeechDuration = SpeechDuration1, 
                            FaxDuration = fax1,
                            HostPort_A = hoa,
                            HostPort_B = hob,
                            IDtype = type,
                            IDTypeCat = cat1,
                            IDEmptyDate = UD2, 
                            IDPBX = pbx2,
                            IDrecord_number = rec,
                            IDGateIN = gin,
                            IDGateOUT = gout,
                            SessionID = Session_ID1,
                            IDCgPhCdPh =CD
                        };
                        Base.ep.ATC.Add(aTC);
                        Base.ep.SaveChanges();
                    } 
                
                    }

                }


           
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            
            MainMenu mainMenu = new MainMenu(employ);
            this.Close();
            mainMenu.Show();
        }
    }
}
