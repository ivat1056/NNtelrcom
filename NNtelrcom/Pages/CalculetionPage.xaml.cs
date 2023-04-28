using NNtelrcom.Class;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
using static System.Net.Mime.MediaTypeNames;

namespace NNtelrcom.Pages
{
    /// <summary>
    /// Логика взаимодействия для CalculetionPage.xaml
    /// </summary>
    public partial class CalculetionPage : Page
    {
        List<PhonesOrganizations> PhonesOrganizations1 = Base.ep.PhonesOrganizations.ToList();
        List<ATC> atc1 = Base.ep.ATC.ToList() ;
        double multi;

        List<string> NumberAndSumma = new List<string>();
        List<string> NumberAndSumma2 = new List<string>();


        double SumTime = 0;
        public CalculetionPage()
        {
            InitializeComponent();
            CBOrgan.DisplayMemberPath = "NameOrganization";

        }

        private void CBOrgan_TextChanged(object sender, TextChangedEventArgs e)
        {
          
            CBOrgan.IsDropDownOpen = true;
            CBOrgan.ItemsSource = Base.ep.Organizations.Where(x => x.NameOrganization.ToLower().Contains(CBOrgan.Text.ToLower())).ToList();

            

        }

        private void CBOrgan_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            Organizations organizations = Base.ep.Organizations.FirstOrDefault(z => z.NameOrganization == CBOrgan.Text);
            int o1 = organizations.IDOrganization;  // id organization 
            int IDType2 = 0;
            double Cost = 0;
            string NumberAdd = "";


            foreach (PhonesOrganizations phonesOrganizations in PhonesOrganizations1)
            {
                foreach (ATC at in atc1)
                {
                    int org = Convert.ToInt32(phonesOrganizations.IDOrganixation);
                    string ph = phonesOrganizations.Phone;

                    if (org == o1)
                    {
                        

                        int idCd1 = Convert.ToInt32(at.IDCgPhCdPh);

                        CgPCdPh callTermination = Base.ep.CgPCdPh.FirstOrDefault(z => z.IDCgPhCdPh == idCd1);
                        string number = callTermination.CgPN_root_out; // номер из таблицы сdcg

                        

                        if (number == ph)
                        {
                            PhonesOrganizations phones = Base.ep.PhonesOrganizations.FirstOrDefault(z => z.Phone == ph);
                            int IDType = Convert.ToInt32(phones.IDRate);
                            Rate rate = Base.ep.Rate.FirstOrDefault(z => z.IDRate == IDType);
                            IDType2 = Convert.ToInt32(rate.IDTyprRate); // type of rate 
                            Cost = Convert.ToDouble(rate.Cost); // cost of rate 
                            NumberAdd = number;

                            string call = at.CallDuration;
                            string сallR = call.Replace(".", ",");
                            double a = Convert.ToDouble(сallR);
                            SumTime = SumTime + a;
                        }
                    }
                    
                }
                if (IDType2 == 1)
                {
                    multi = (SumTime / 60) * Cost;
                    string multi2 = Convert.ToString(multi);
                    NumberAndSumma.Add(multi2);
                    NumberAndSumma.Add(NumberAdd);
                    multi = 0;
                    SumTime = 0;
                    NumberAdd = "";
                    Cost = 0;
                }
            }


            


            StringBuilder sb = new StringBuilder();
            foreach (string elementin in NumberAndSumma)
            {
                sb.AppendLine(elementin);

            }


            StringBuilder sb2 = new StringBuilder();

            foreach (string elementin2 in NumberAndSumma2)
            {
                sb2.AppendLine(elementin2);

            }
            //MessageBox.Show(sb.ToString());




            PdfDocument document = new PdfDocument();

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);
            XTextFormatter tf = new XTextFormatter(gfx);

            XRect rect = new XRect(40, 100, 250, 220);
            gfx.DrawRectangle(XBrushes.SeaShell, rect);
            tf.DrawString(sb.ToString(), font, XBrushes.Black, rect, XStringFormats.TopLeft);

            string filename = "FirstPDFDocument.pdf";
            //Save PDF File
            document.Save(filename);
            //Load PDF File for viewing
            Process.Start(filename);

            ////Create PDF Document
            //PdfDocument document = new PdfDocument();
            ////You will have to add Page in PDF Document
            //PdfPage page = document.AddPage();
            ////For drawing in PDF Page you will nedd XGraphics Object
            //XGraphics gfx = XGraphics.FromPdfPage(page);
            ////For Test you will have to define font to be used
            //XFont font = new XFont("Times New Roman", 14, XFontStyle.Bold);
            ////Finally use XGraphics & font object to draw text in PDF Page
            //gfx.DrawString(sb.ToString(), font, XBrushes.Black,

            //new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);
            //gfx.DrawString(sb2.ToString(), font, XBrushes.Black,
            //new XRect(0, 0, page.Width, page.Height), XStringFormats.TopLeft);
            ////Specify file name of the PDF file
            //string filename = "FirstPDFDocument.pdf";
            ////Save PDF File
            //document.Save(filename);
            ////Load PDF File for viewing
            //Process.Start(filename);




            //    PdfDocument document = new PdfDocument();

            //    PdfPage page = document.AddPage();
            //    XGraphics gfx = XGraphics.FromPdfPage(page);
            //    XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);
            //    XTextFormatter tf = new XTextFormatter(gfx);

            //    XRect rect = new XRect(40, 100, 250, 220);
            //    gfx.DrawRectangle(XBrushes.SeaShell, rect);
            //    tf.DrawString(sb.ToString(), font, XBrushes.Black, rect, XStringFormats.TopLeft);

            //    string filename = "FirstPDFDocument.pdf";
            //    //Save PDF File
            //    document.Save(filename);
            //    //Load PDF File for viewing
            //    Process.Start(filename);
        }
    }
}
