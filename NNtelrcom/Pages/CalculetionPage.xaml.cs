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
        double kol;
        string IDRate;

        List<string> NumberAndSumma = new List<string>();
       


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
                            IDRate = rate.Name; 

                            kol = Convert.ToDouble(rate.NumberOfMinutes);
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
                    NumberAndSumma.Add(IDRate);
                    multi = 0;
                    SumTime = 0;
                    NumberAdd = "";
                    Cost = 0;
                }
                if(IDType2 == 2)
                {
                    multi = (SumTime / 10) * Cost;
                    string multi2 = Convert.ToString(multi);
                    NumberAndSumma.Add(multi2);
                    NumberAndSumma.Add(NumberAdd);
                    NumberAndSumma.Add(IDRate);
                    multi = 0;
                    SumTime = 0;
                    NumberAdd = "";
                    Cost = 0;
                }
                if (IDType2 == 3)
                {
                    multi = (SumTime - 60 ) * Cost;
                    string multi2 = Convert.ToString(multi);
                    NumberAndSumma.Add(multi2);
                    NumberAndSumma.Add(NumberAdd);
                    NumberAndSumma.Add(IDRate);
                    multi = 0;
                    SumTime = 0;
                    NumberAdd = "";
                    Cost = 0;
                }
                if (IDType2 == 4)
                {
                    double Kol = 
                    multi = ((SumTime / 60 ) - kol);
                    if(multi < 0)
                    {
                    string multi2 = Convert.ToString(Cost);
                    NumberAndSumma.Add(multi2);
                    NumberAndSumma.Add(NumberAdd);
                    NumberAndSumma.Add(IDRate);
                    }
                    else
                    {
                        Rate rate = Base.ep.Rate.FirstOrDefault(z => z.IDRate == 1);
                        double sK = Convert.ToDouble(rate.Cost);
                        multi = ((SumTime / 60) - kol) * sK ;
                        string multi2 = Convert.ToString(Cost);
                        NumberAndSumma.Add(multi2);
                        NumberAndSumma.Add(NumberAdd);
                        NumberAndSumma.Add(IDRate);
                    }
                    kol = 0;
                    multi = 0;
                    SumTime = 0;
                    NumberAdd = "";
                    IDRate = "";
                    Cost = 0;
                }
            }

            int countNumber = NumberAndSumma.Count;



            //StringBuilder sb = new StringBuilder();
            //foreach (string elementin in NumberAndSumma)
            //{
            //    sb.AppendLine(elementin);

            //}



            //MessageBox.Show(sb.ToString());




            //PdfDocument document = new PdfDocument();

            //PdfPage page = document.AddPage();
            //XGraphics gfx = XGraphics.FromPdfPage(page);
            //XFont font = new XFont("Times New Roman", 10, XFontStyle.Bold);
            //XTextFormatter tf = new XTextFormatter(gfx);

            //XRect rect = new XRect(40, 100, 250, 220);
            //gfx.DrawRectangle(XBrushes.SeaShell, rect);
            //tf.DrawString(sb.ToString(), font, XBrushes.Black, rect, XStringFormats.TopLeft);

            //string filename = "FirstPDFDocument.pdf";
            ////Save PDF File
            //document.Save(filename);
            ////Load PDF File for viewing
            //Process.Start(filename);




            PdfDocument document = new PdfDocument();
            document.Info.Title = "Table Example";

            for (int p = 0; p < 1; p++)
            {
                // Page Options
                PdfPage pdfPage = document.AddPage();
                pdfPage.Height = 842;//842
                pdfPage.Width = 590;

                // Get an XGraphics object for drawing
                XGraphics graph = XGraphics.FromPdfPage(pdfPage);

                // Text format
                XStringFormat format = new XStringFormat();
                format.LineAlignment = XLineAlignment.Near;
                format.Alignment = XStringAlignment.Near;
                var tf = new XTextFormatter(graph);

                XFont fontParagraph = new XFont("Verdana", 8, XFontStyle.Regular);

                // Row elements
                int el1_width = 80;
                int el2_width = 380;

                // page structure options
                double lineHeight = 20;
                int marginLeft = 20;
                int marginTop = 20;

                int el_height = 30;
                int rect_height = 17;

                int interLine_X_1 = 2;
                int interLine_X_2 = 2 * interLine_X_1;

                int offSetX_1 = el1_width;
                int offSetX_2 = el1_width + el2_width;

                XSolidBrush rect_style1 = new XSolidBrush(XColors.LightGray);
                XSolidBrush rect_style2 = new XSolidBrush(XColors.DarkGreen);
                XSolidBrush rect_style3 = new XSolidBrush(XColors.Red);

                for (int i = 0; i < countNumber+1; i++)
                {
                    double dist_Y = lineHeight * (i + 1);
                    double dist_Y2 = dist_Y - 2;

                    // header della G
                    if (i == 0)
                    {
                        graph.DrawRectangle(rect_style2, marginLeft, marginTop, pdfPage.Width - 2 * marginLeft, rect_height);

                        tf.DrawString("Номер телефона", fontParagraph, XBrushes.White,
                                      new XRect(marginLeft, marginTop, el1_width, el_height), format);

                        tf.DrawString("Тариф", fontParagraph, XBrushes.White,
                                      new XRect(marginLeft + offSetX_1 + interLine_X_1, marginTop, el2_width, el_height), format);

                        tf.DrawString("Оплата", fontParagraph, XBrushes.White,
                                      new XRect(marginLeft + offSetX_2 + 2 * interLine_X_2, marginTop, el1_width, el_height), format);

                        foreach (string j in NumberAndSumma)
                        {


                            // stampo il primo elemento insieme all'header
                            graph.DrawRectangle(rect_style1, marginLeft, dist_Y2 + marginTop, el1_width, rect_height);
                            tf.DrawString(j, fontParagraph, XBrushes.Black,
                                          new XRect(marginLeft, dist_Y + marginTop, el1_width, el_height), format);

                            //ELEMENT 2 - BIG 380
                            graph.DrawRectangle(rect_style1, marginLeft + offSetX_1 + interLine_X_1, dist_Y2 + marginTop, el2_width, rect_height);
                            tf.DrawString(
                                j+1,
                                fontParagraph,
                                XBrushes.Black,
                                new XRect(marginLeft + offSetX_1 + interLine_X_1, dist_Y + marginTop, el2_width, el_height),
                                format);


                            //ELEMENT 3 - SMALL 80

                            graph.DrawRectangle(rect_style1, marginLeft + offSetX_2 + interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                            tf.DrawString(
                                j+2,
                                fontParagraph,
                                XBrushes.Black,
                                new XRect(marginLeft + offSetX_2 + 2 * interLine_X_2, dist_Y + marginTop, el1_width, el_height),
                                format);
                        }

                    }
                    else
                    {

                        //if (i % 2 == 1)
                        //{
                        //  graph.DrawRectangle(TextBackgroundBrush, marginLeft, lineY - 2 + marginTop, pdfPage.Width - marginLeft - marginRight, lineHeight - 2);
                        //}

                        //ELEMENT 1 - SMALL 80
                        graph.DrawRectangle(rect_style1, marginLeft, marginTop + dist_Y2, el1_width, rect_height);
                        tf.DrawString(

                            "text1",
                            fontParagraph,
                            XBrushes.Black,
                            new XRect(marginLeft, marginTop + dist_Y, el1_width, el_height),
                            format);

                        //ELEMENT 2 - BIG 380
                        graph.DrawRectangle(rect_style1, marginLeft + offSetX_1 + interLine_X_1, dist_Y2 + marginTop, el2_width, rect_height);
                        tf.DrawString(
                            "text2",
                            fontParagraph,
                            XBrushes.Black,
                            new XRect(marginLeft + offSetX_1 + interLine_X_1, marginTop + dist_Y, el2_width, el_height),
                            format);


                        //ELEMENT 3 - SMALL 80

                        graph.DrawRectangle(rect_style1, marginLeft + offSetX_2 + interLine_X_2, dist_Y2 + marginTop, el1_width, rect_height);
                        tf.DrawString(
                            "text3",
                            fontParagraph,
                            XBrushes.Black,
                            new XRect(marginLeft + offSetX_2 + 2 * interLine_X_2, marginTop + dist_Y, el1_width, el_height),
                            format);

                    }

                }


            }


            const string filename = "FirstPDFDocument.pdf";
            document.Save(filename);

            //Load PDF File for viewing
            Process.Start(filename);

            //byte[] bytes = null;
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    document.Save(stream, true);
            //    bytes = stream.ToArray();
            //}

            //SendFileToResponse(bytes, "HelloWorld_test.pdf");
        }
    }
}
