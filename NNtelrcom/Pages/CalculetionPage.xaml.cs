using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using NNtelrcom.Class;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
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
using MimeKit;
using MailKit;
using MailKit.Net.Smtp;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Utilities.Net;
using Org.BouncyCastle.Utilities;
using iTextSharp.text.pdf.parser;


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
        double summ;
        int IDOrgan;
        DateTime OnData1;
        DateTime TwoData1;

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
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("NN Telecom", "nntelecom52@gmail.com"));
            //add the receiver email address
            message.To.Add(MailboxAddress.Parse("ivat1056@gmail.com"));
            // add the message subject
            message.Subject = "Счёт от ООО «НН Телекома»";
            // add the message body as plain text the "plain" string passed to the TextPart
            // indicates that it's plain text and not HTML for example

            var body = new TextPart("Уважаемый клиент!\r\n\r\nВаш счет в приложении.")
            {
                Text = @" Подробная информацию по оплате можно узнать по телефону организации  

                    Благодарим вас за пользование нашими услугами и выбор электронной формы получения счета.
                "
            };


            // create an image attachment for the file located at path
            var attachment = new MimePart("Test", "pdf")
            {
                Content = new MimeContent(File.OpenRead("Test.pdf")),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = System.IO.Path.GetFileName("Test.pdf")
            };

            // now create the multipart/mixed container to hold the message text and the
            // image attachment
            var multipart = new Multipart("mixed");
            multipart.Add(body);
            multipart.Add(attachment);

            //now set the multipart/ mixed as the message body
            message.Body = multipart;


            // ask the user to enter the email

            string emailAddress = "nntelecom52@gmail.com";
            // ask the user to enter the password

            string password = "rcwzkwcqaxjxbhyl"; // ключ верификации 

            MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
                client.Authenticate(emailAddress, password);

                client.Send(message);

                MessageBox.Show("Сообщение отправлено");
            }
            catch (Exception ex)
            {

                //in case of an error display the message.
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // at any case always disconnect from the client
                client.Disconnect(true);
                // and dispose of the client object
                client.Dispose();
            }


        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            string OneDateStr = OneDateTx.SelectedDate.ToString();
            string TwoDateStr = TwoDateTx.SelectedDate.ToString();
            DateTime OnData = DateTime.Parse(OneDateStr);
            DateTime TwoDate = DateTime.Parse(TwoDateStr);
            OnData1 = OnData;
            TwoData1 = TwoDate;

            Organizations organizations = Base.ep.Organizations.FirstOrDefault(z => z.NameOrganization == CBOrgan.Text);
            int o1 = organizations.IDOrganization;  // id organization 
            int IDType2 = 0;
            double Cost = 0;
            string NumberAdd = "";
            

            foreach (PhonesOrganizations phonesOrganizations in PhonesOrganizations1)
            {
                foreach (ATC at in atc1)
                {
                     
                    DateTime dataforatc = DateTime.Parse(at.SetupDateTime);

                    if ((dataforatc >= OnData) && (dataforatc <= TwoDate))
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
                                IDOrgan = o1;

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
                }
                if (NumberAdd != "")
                {
                    if (IDType2 == 1)
                    {
                        multi = (SumTime / 60) * Cost;
                        string multi2 = Convert.ToString(multi);
                        NumberAndSumma.Add(NumberAdd);
                        NumberAndSumma.Add(IDRate);
                        NumberAndSumma.Add(multi2);
                        multi = 0;
                        SumTime = 0;
                        NumberAdd = "";
                        Cost = 0;
                    }
                    if (IDType2 == 2)
                    {
                        multi = (SumTime / 10) * Cost;
                        string multi2 = Convert.ToString(multi);
                        NumberAndSumma.Add(NumberAdd);
                        NumberAndSumma.Add(IDRate);
                        NumberAndSumma.Add(multi2);
                        multi = 0;
                        SumTime = 0;
                        NumberAdd = "";
                        Cost = 0;
                    }
                    if (IDType2 == 3)
                    {
                        multi = (SumTime - 60) * Cost;
                        string multi2 = Convert.ToString(multi);
                        NumberAndSumma.Add(NumberAdd);
                        NumberAndSumma.Add(IDRate);
                        NumberAndSumma.Add(multi2);
                        multi = 0;
                        SumTime = 0;
                        NumberAdd = "";
                        Cost = 0;
                    }
                    if (IDType2 == 4)
                    {
                        double Kol =
                        multi = ((SumTime / 60) - kol);
                        if (multi < 0)
                        {
                            string multi2 = Convert.ToString(Cost);
                            NumberAndSumma.Add(NumberAdd);
                            NumberAndSumma.Add(IDRate);
                            NumberAndSumma.Add(multi2);
                            NumberAdd = "";
                            Cost = 0;
                        }
                        else
                        {
                            Rate rate = Base.ep.Rate.FirstOrDefault(z => z.IDRate == 1);
                            double sK = Convert.ToDouble(rate.Cost);
                            multi = ((SumTime / 60) - kol) * sK;
                            string multi2 = Convert.ToString(Cost);
                            NumberAndSumma.Add(NumberAdd);
                            NumberAndSumma.Add(IDRate);
                            NumberAndSumma.Add(multi2);
                            NumberAdd = "";
                            Cost = 0;
                        }
                        kol = 0;
                        multi = 0;
                        SumTime = 0;
                        NumberAdd = "";
                        IDRate = "";
                        Cost = 0;
                    }
                }
            }

            int countNumber = NumberAndSumma.Count;



            //string filename = "FirstPDFDocument.pdf";
            //document.Save(filename);
            //Process.Start(filename);
            //Set the default encoding to support Unicode characters

           

            Document doc = new Document();

            FileStream fs = new FileStream("Test.pdf", FileMode.Create, FileAccess.Write, FileShare.None); // создание пдф файла 
            string ttf = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF"); // шрифт 
            var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            string ttf2 = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            BaseFont bf = BaseFont.CreateFont(ttf2, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font2 = new iTextSharp.text.Font(bf, 20, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph(new Chunk("Sample text", font2));

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();



            //PdfContentByte cb = writer.DirectContent;

            //// select the font properties
            //BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            //cb.SetColorFill(BaseColor.DARK_GRAY);
            //cb.SetFontAndSize(bf, 8);

            //// write the text in the pdf content
            //cb.BeginText();
            //string text = (new iTextSharp.text.Paragraph("Организация proba ", font));
            //// put the alignment and coordinates here
            //cb.ShowTextAligned(1, text, 100, 800, 0);
            //cb.EndText();
            //cb.BeginText();
            //text = "Other random blabla...";
            //// put the alignment and coordinates here
            //cb.ShowTextAligned(2, text, 5, 5, 0);
            //cb.EndText();

            doc.Add(new iTextSharp.text.Paragraph("НН Телеком ", font2));

           
            int year = OnData1.Year;
            int month = OnData1.Month;
            int day = OnData1.Day;

            int year2 = TwoData1.Year;
            int month2 = TwoData1.Month;
            int day2 = TwoData1.Day;
            string monthapay = GetMonth(month);
            string monthapay2 = GetMonth(month2);

            string now = DateTime.Now.ToString("dd-MMMM-yyyy");
            
            

            string TextData = "Дата формирования счета " + now ;
            string DataCalc = "Расчет за " + day + " " + monthapay + " По " + day2 + " " + monthapay2; 
            doc.Add(new iTextSharp.text.Paragraph(TextData, font));
            doc.Add(new iTextSharp.text.Paragraph(DataCalc, font));
            string Text = "Внимание! Оплата данного счета означает согласие с условиями предоставления услуг. Уведомление об оплате обязательно.";
            doc.Add(new iTextSharp.text.Paragraph(Text,font));
            string Text2 = " "; // пустая строчка 
            doc.Add(new iTextSharp.text.Paragraph(Text2, font));
            string Text4 = "Поставщик: ";
            doc.Add(new iTextSharp.text.Paragraph(Text4, font));
            Organizations organizations1 = Base.ep.Organizations.FirstOrDefault(z => z.IDOrganization == IDOrgan);
            string ORGAN =  " " + organizations1.NameOrganization + " , ИНН " + organizations1.INN + " , " + organizations1.Surname + " " + organizations1.Name + " " + organizations1.Patronymic + " , " + organizations1.Address;
            string Text3 = "Покупатель: " + ORGAN ;
            doc.Add(new iTextSharp.text.Paragraph( Text3, font));
            doc.Add(new iTextSharp.text.Paragraph(Text2, font));
            


            PdfPCell cell = new PdfPCell();
            PdfPTable table = new PdfPTable(3);
            for (int j = 2; j < NumberAndSumma.Count; j++)
            {
                double a = Convert.ToDouble(NumberAndSumma[j]);
                summ = summ + a;
                j = j + 2;
            }

            table.AddCell(new iTextSharp.text.Paragraph("Номер телефона", font));
            table.AddCell(new iTextSharp.text.Paragraph("Тариф", font));
            table.AddCell(new iTextSharp.text.Paragraph("Стоимость, руб", font));
            for (int j = 0; j < NumberAndSumma.Count; j++)
            {
                table.AddCell(NumberAndSumma[j]);
                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 1], font));
                table.AddCell(NumberAndSumma[j + 2]);
                j = j + 2;
            }
            cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph("Итоговая сумма к оплате", font)));
            cell.Colspan = 2;
            table.AddCell(cell);
            string b = Convert.ToString(summ);
            table.AddCell(b);

            doc.Add(table);
            doc.Close();
            Process.Start("Test.pdf");



            




        }

        public string GetMonth(int a)
        {
            if(a ==1)
            {
                return "Январь";
            }
            if (a == 2)
            {
                return "Февраль";
            }
            if (a == 3)
            {
                return "Март";
            }
            if (a == 4)
            {
                return "Апрель";
            }
            if (a == 5)
            {
                return "Май";
            }
            if (a == 6)
            {
                return "Июнь";
            }
            if (a == 7)
            {
                return "Июль";
            }
            if (a == 8)
            {
                return "Август";
            }
            if (a == 9)
            {
                return "Сентябрь";
            }
            if (a == 10)
            {
                return "Октябрь";
            }
            if (a == 11)
            {
                return "Ноябрь";
            }
            else
            {
                return "Декабрь";
            }

        }
    }
}
