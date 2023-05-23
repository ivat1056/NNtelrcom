using iTextSharp.text;
using iTextSharp.text.pdf;
using MimeKit;
using NNtelrcom.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace NNtelrcom.Pages
{
    /// <summary>
    /// Логика взаимодействия для CalculetionPage.xaml
    /// </summary>
    public partial class CalculetionPage : Page
    {
        List<PhonesOrganizations> PhonesOrganizations1 = Base.ep.PhonesOrganizations.ToList();
        List<Organizations> organsList = Base.ep.Organizations.ToList();
        List<ATC> atc1 = Base.ep.ATC.ToList();
        double multi;
        double kol;
        string IDRate;
        double summ;
        int IDOrgan;
        DateTime OnData1;
        DateTime TwoData1;
        int calc = 0;  // type calc

        List<string> NumberAndSumma = new List<string>();



        double SumTime = 0;
        public CalculetionPage()
        {
            InitializeComponent();

            List<Organizations> raions = Base.ep.Organizations.ToList(); // Заполнение списка организаций
            CBOrgan.Items.Add("Все организации");
            foreach (Organizations raion in raions)
            {
                CBOrgan.Items.Add(raion.NameOrganization);
            }
            CBOrgan.SelectedIndex = 0;


        }

        private void CBOrgan_TextChanged(object sender, TextChangedEventArgs e)
        {
            string sert = "Все организации";
            CBOrgan.ClearValue(ItemsControl.ItemsSourceProperty);
            CBOrgan.Items.Clear();
            CBOrgan.IsDropDownOpen = true;
            List <Organizations> oti = Base.ep.Organizations.Where(x => x.NameOrganization.ToLower().Contains(CBOrgan.Text.ToLower())).ToList();
            if (sert.ToLower().Contains(CBOrgan.Text.ToLower()))
            {
                CBOrgan.Items.Add("Все организации");
            }
            foreach (Organizations raion in oti)
            {
                CBOrgan.Items.Add(raion.NameOrganization);
            }
           
        }

        private void CBOrgan_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

            FrameClass.frameOrg.Visibility = Visibility.Collapsed;
        }

        public void sendmeseg()
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("NN Telecom", "nntelecom52@gmail.com"));
            //add the receiver email address
            message.To.Add(MailboxAddress.Parse("ivat1056@gmail.com"));
            // add the message subject
            message.Subject = "Счёт от ООО «НН Телекома»";

            // indicates that it's plain text and not HTML for example

            var body = new TextPart()
            {
                Text = @"Уважаемый абонент ! Напоминаем Вам о необходимости оплаты счета по лицевому счету 352011634070 во избежание начисления пени и ограничения доступа."
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


        private void Calc_Click(object sender, RoutedEventArgs e)  // calc and check  
        {
            if (CBOrgan.Text != "")
            {
                if (OneDateTx.Text != "")
                {
                    if (TwoDateTx.Text != "")
                    {
                        try
                        {
                            if (CBOrgan.Text == "Все организации")
                            {
                                NumberAndSumma.Clear();
                                string OneDateStr = OneDateTx.SelectedDate.ToString();
                                string TwoDateStr = TwoDateTx.SelectedDate.ToString();
                                DateTime OnData = DateTime.Parse(OneDateStr);  // даты для формирования счета
                                DateTime TwoDate = DateTime.Parse(TwoDateStr);
                                OnData1 = OnData;
                                TwoData1 = TwoDate;




                                foreach (Organizations organizations12 in organsList)
                                {
                                    int o1 = organizations12.IDOrganization;  // id organization 
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
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
                                                multi = 0;
                                                SumTime = 0;
                                                NumberAdd = "";
                                                Cost = 0;
                                            }
                                            if (IDType2 == 2)
                                            {
                                                multi = (SumTime / 10) * Cost;
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
                                                multi = 0;
                                                SumTime = 0;
                                                NumberAdd = "";
                                                Cost = 0;
                                            }
                                            if (IDType2 == 3)
                                            {
                                                multi = (SumTime - 60) * Cost;
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
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
                                                    NumberAndSumma.Add(NumberAdd); // номер
                                                    NumberAndSumma.Add(IDRate); // тариф

                                                    NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                    NumberAndSumma.Add(Convert.ToString(Cost));
                                                    NumberAndSumma.Add(multi2); // Стоимость
                                                    NumberAdd = "";
                                                    Cost = 0;
                                                }
                                                else
                                                {
                                                    Rate rate = Base.ep.Rate.FirstOrDefault(z => z.IDRate == 1);
                                                    double sK = Convert.ToDouble(rate.Cost);
                                                    multi = ((SumTime / 60) - kol) * sK;
                                                    string multi2 = Convert.ToString(Cost);
                                                    NumberAndSumma.Add(NumberAdd); // номер
                                                    NumberAndSumma.Add(IDRate); // тариф

                                                    NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                    NumberAndSumma.Add(Convert.ToString(Cost));
                                                    NumberAndSumma.Add(multi2); // Стоимость
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

                                    if (countNumber != 0)
                                    {

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

                                        doc.Add(new iTextSharp.text.Paragraph("НН Телеком ", font2));
                                        string Text2 = " "; // пустая строчка 
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));



                                        int year = OnData1.Year;
                                        int month = OnData1.Month;
                                        int day = OnData1.Day;

                                        int year2 = TwoData1.Year;
                                        int month2 = TwoData1.Month;
                                        int day2 = TwoData1.Day;
                                        string monthapay = GetMonth(month);
                                        string monthapay2 = GetMonth(month2);

                                        string now = DateTime.Now.ToString("dd-MMMM-yyyy");

                                        int numbertable = 1;

                                        PdfPCell cell = new PdfPCell();
                                        PdfPTable table2 = new PdfPTable(4);
                                        PdfPTable table = new PdfPTable(7);



                                        OrganInfo organInfo = Base.ep.OrganInfo.FirstOrDefault(z => z.IdInfoorgan == 1);
                                        string KPP = organInfo.KPP;
                                        string ChekB = organInfo.CheckBank;
                                        string ChekA = organInfo.Checkorgan;
                                        string NameB = organInfo.NameBank;
                                        string NameA = organInfo.Name;
                                        string INN = organInfo.INN;
                                        string bik = organInfo.Bik;
                                        string Email = organInfo.Email;
                                        string Index = organInfo.IndexO;
                                        string Adress = organInfo.Adress;
                                        string phonw = organInfo.Phone;

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(NameB, font)));
                                        cell.Colspan = 2;
                                        table2.AddCell(cell); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("БИК" + "\n" + "Сч.№", font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph(bik + "\n" + ChekB, font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("ИНН " + INN, font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("KПП " + KPP, font)); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph("Сч.№", font))); // таблица 2 
                                        cell.Rowspan = 2;
                                        table2.AddCell(cell); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(ChekA, font))); // таблица 2 
                                        cell.Rowspan = 2;
                                        table2.AddCell(cell); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(NameA, font)));
                                        cell.Colspan = 2;
                                        table2.AddCell(cell); // таблица 2 
                                        doc.Add(table2);

                                        string TextData = "Дата формирования счета " + now;
                                        string DataCalc = "Расчет за " + day + " " + monthapay + " По " + day2 + " " + monthapay2;
                                        doc.Add(new iTextSharp.text.Paragraph(TextData, font));
                                        doc.Add(new iTextSharp.text.Paragraph(DataCalc, font));
                                        string Text = "Внимание! Оплата данного счета означает согласие с условиями поставки товара\r\nУведомление об оплате обязательно, в противном случае не гарантируется наличие товара на складе.\r\nТовар отпускается по факту прихода денег на р/с Поставщика, самовывозом, при наличии доверенности и паспорта";
                                        doc.Add(new iTextSharp.text.Paragraph(Text, font));
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));
                                        string Text4 = "Поставщик: " + NameA + " ИНН " + INN + " КПП " + KPP + " " + Index + " " + Adress + " тел: " + phonw;
                                        doc.Add(new iTextSharp.text.Paragraph(Text4, font));
                                        Organizations organizations1 = Base.ep.Organizations.FirstOrDefault(z => z.IDOrganization == IDOrgan);
                                        if (organizations1 != null)
                                        {
                                            string ORGAN = " " + organizations1.NameOrganization + " , ИНН " + organizations1.INN + " , " + organizations1.Surname + " " + organizations1.Name + " " + organizations1.Patronymic + " , " + organizations1.Address;
                                            string Text3 = "Покупатель: " + ORGAN;
                                            doc.Add(new iTextSharp.text.Paragraph(Text3, font));
                                            doc.Add(new iTextSharp.text.Paragraph(Text2, font));


                                            for (int j = 4; j < NumberAndSumma.Count; j++) // 
                                            {
                                                double a = Convert.ToDouble(NumberAndSumma[j]);
                                                summ = summ + a;
                                                j = j + 4;
                                            }
                                            table.AddCell(new iTextSharp.text.Paragraph("№", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Номер телефона", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Тариф", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Количество", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Ед.", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Цена", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Сумма, руб", font));
                                            for (int j = 0; j < NumberAndSumma.Count; j++)
                                            {
                                                table.AddCell(new iTextSharp.text.Paragraph(Convert.ToString(numbertable))); //номер списка
                                                table.AddCell(NumberAndSumma[j]); // номер телефона
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 1], font)); // Тариф
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 2], font)); // кол во минут
                                                table.AddCell(new iTextSharp.text.Paragraph("Секунды", font)); // обозн минуты
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 3], font)); // цена
                                                table.AddCell(NumberAndSumma[j + 4]);  // Сумма
                                                j = j + 4;
                                                numbertable = numbertable + 1;
                                            }
                                            numbertable = 1;
                                            cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph("Итоговая сумма к оплате", font)));
                                            cell.Colspan = 6;
                                            table.AddCell(cell);
                                            string b = Convert.ToString(summ);
                                            table.AddCell(b);

                                            doc.Add(table);

                                            summ = 0;
                                            NumberAndSumma.Clear();

                                            NumberAndSumma.Clear();
                                            doc.Close();

                                        }


                                    }
                                    else
                                    {

                                        MessageBox.Show("Звонков не обнаружено ");
                                    }



                                    // отправка сообщений 
                                    sendmeseg();






                                } // create list for date if vs

                                MessageBox.Show("Сообщения отправлены");

                            }
                            else
                            {
                                NumberAndSumma.Clear();
                                string OneDateStr = OneDateTx.SelectedDate.ToString();
                                string TwoDateStr = TwoDateTx.SelectedDate.ToString();
                                DateTime OnData = DateTime.Parse(OneDateStr);
                                DateTime TwoDate = DateTime.Parse(TwoDateStr);
                                OnData1 = OnData;
                                TwoData1 = TwoDate;

                                Organizations organizations = Base.ep.Organizations.FirstOrDefault(z => z.NameOrganization == CBOrgan.Text);
                                if (organizations == null)
                                {
                                    MessageBox.Show("Проверьте правильность ввода организации");
                                }
                                else
                                {
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
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
                                                multi = 0;
                                                SumTime = 0;
                                                NumberAdd = "";
                                                Cost = 0;
                                            }
                                            if (IDType2 == 2)
                                            {
                                                multi = (SumTime / 10) * Cost;
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
                                                multi = 0;
                                                SumTime = 0;
                                                NumberAdd = "";
                                                Cost = 0;
                                            }
                                            if (IDType2 == 3)
                                            {
                                                multi = (SumTime - 60) * Cost;
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
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
                                                    NumberAndSumma.Add(NumberAdd); // номер
                                                    NumberAndSumma.Add(IDRate); // тариф

                                                    NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                    NumberAndSumma.Add(Convert.ToString(Cost));
                                                    NumberAndSumma.Add(multi2); // Стоимость
                                                    NumberAdd = "";
                                                    Cost = 0;
                                                }
                                                else
                                                {
                                                    Rate rate = Base.ep.Rate.FirstOrDefault(z => z.IDRate == 1);
                                                    double sK = Convert.ToDouble(rate.Cost);
                                                    multi = ((SumTime / 60) - kol) * sK;
                                                    string multi2 = Convert.ToString(Cost);
                                                    NumberAndSumma.Add(NumberAdd); // номер
                                                    NumberAndSumma.Add(IDRate); // тариф

                                                    NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                    NumberAndSumma.Add(Convert.ToString(Cost));
                                                    NumberAndSumma.Add(multi2); // Стоимость
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
                                    } // created list for date




                                    int countNumber = NumberAndSumma.Count;

                                    if (countNumber != 0)
                                    {

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


                                        doc.Add(new iTextSharp.text.Paragraph("НН Телеком ", font2));
                                        string Text2 = " "; // пустая строчка 
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));



                                        int year = OnData1.Year;
                                        int month = OnData1.Month;
                                        int day = OnData1.Day;

                                        int year2 = TwoData1.Year;
                                        int month2 = TwoData1.Month;
                                        int day2 = TwoData1.Day;
                                        string monthapay = GetMonth(month);
                                        string monthapay2 = GetMonth(month2);

                                        string now = DateTime.Now.ToString("dd-MMMM-yyyy");

                                        int numbertable = 1;

                                        PdfPCell cell = new PdfPCell();
                                        PdfPTable table2 = new PdfPTable(4);
                                        PdfPTable table = new PdfPTable(7);



                                        OrganInfo organInfo = Base.ep.OrganInfo.FirstOrDefault(z => z.IdInfoorgan == 1);
                                        string KPP = organInfo.KPP;
                                        string ChekB = organInfo.CheckBank;
                                        string ChekA = organInfo.Checkorgan;
                                        string NameB = organInfo.NameBank;
                                        string NameA = organInfo.Name;
                                        string INN = organInfo.INN;
                                        string bik = organInfo.Bik;
                                        string Email = organInfo.Email;
                                        string Index = organInfo.IndexO;
                                        string Adress = organInfo.Adress;
                                        string phonw = organInfo.Phone;

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(NameB, font)));
                                        cell.Colspan = 2;
                                        table2.AddCell(cell); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("БИК" + "\n" + "Сч.№", font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph(bik + "\n" + ChekB, font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("ИНН " + INN, font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("KПП " + KPP, font)); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph("Сч.№", font))); // таблица 2 
                                        cell.Rowspan = 2;
                                        table2.AddCell(cell); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(ChekA, font))); // таблица 2 
                                        cell.Rowspan = 2;
                                        table2.AddCell(cell); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(NameA, font)));
                                        cell.Colspan = 2;
                                        table2.AddCell(cell); // таблица 2 
                                        doc.Add(table2);

                                        string TextData = "Дата формирования счета " + now;
                                        string DataCalc = "Расчет за " + day + " " + monthapay + " По " + day2 + " " + monthapay2;
                                        doc.Add(new iTextSharp.text.Paragraph(TextData, font));
                                        doc.Add(new iTextSharp.text.Paragraph(DataCalc, font));
                                        string Text = "Внимание! Оплата данного счета означает согласие с условиями поставки товара\r\nУведомление об оплате обязательно, в противном случае не гарантируется наличие товара на складе.\r\nТовар отпускается по факту прихода денег на р/с Поставщика, самовывозом, при наличии доверенности и паспорта";
                                        doc.Add(new iTextSharp.text.Paragraph(Text, font));
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));
                                        string Text4 = "Поставщик: " + NameA + " ИНН " + INN + " КПП " + KPP + " " + Index + " " + Adress + " тел: " + phonw;
                                        doc.Add(new iTextSharp.text.Paragraph(Text4, font));
                                        Organizations organizations1 = Base.ep.Organizations.FirstOrDefault(z => z.IDOrganization == IDOrgan);
                                        if (organizations1 != null)
                                        {
                                            string ORGAN = " " + organizations1.NameOrganization + " , ИНН " + organizations1.INN + " , " + organizations1.Surname + " " + organizations1.Name + " " + organizations1.Patronymic + " , " + organizations1.Address;
                                            string Text3 = "Покупатель: " + ORGAN;
                                            doc.Add(new iTextSharp.text.Paragraph(Text3, font));
                                            doc.Add(new iTextSharp.text.Paragraph(Text2, font));


                                            for (int j = 4; j < NumberAndSumma.Count; j++) // 
                                            {
                                                double a = Convert.ToDouble(NumberAndSumma[j]);
                                                summ = summ + a;
                                                j = j + 4;
                                            }
                                            table.AddCell(new iTextSharp.text.Paragraph("№", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Номер телефона", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Тариф", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Количество", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Ед.", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Цена", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Сумма, руб", font));
                                            for (int j = 0; j < NumberAndSumma.Count; j++)
                                            {
                                                table.AddCell(new iTextSharp.text.Paragraph(Convert.ToString(numbertable))); //номер списка
                                                table.AddCell(NumberAndSumma[j]); // номер телефона
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 1], font)); // Тариф
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 2], font)); // кол во минут
                                                table.AddCell(new iTextSharp.text.Paragraph("Секунды", font)); // обозн минуты
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 3], font)); // цена
                                                table.AddCell(NumberAndSumma[j + 4]);  // Сумма
                                                j = j + 4;
                                                numbertable = numbertable + 1;
                                            }
                                            numbertable = 1;
                                            cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph("Итоговая сумма к оплате", font)));
                                            cell.Colspan = 6;
                                            table.AddCell(cell);
                                            string b = Convert.ToString(summ);
                                            table.AddCell(b);

                                            doc.Add(table);


                                            doc.Close();


                                        }

                                        else
                                        {
                                            MessageBox.Show("Организация не совершила ни одного звонка");
                                        }

                                        multi = 0;
                                        kol = 0;
                                        IDRate = "";
                                        summ = 0;
                                        IDOrgan = 0;
                                        IDType2 = 0;
                                        Cost = 0;
                                        NumberAdd = "";
                                        NumberAndSumma.Clear();
                                        sendmeseg();
                                        MessageBox.Show("Сообщение отправлено");
                                    }

                                    else
                                    {
                                        MessageBox.Show("Организация не совершила ни одного звонка");
                                    }
                                }
                            }



                        }
                        catch (SystemException ex)
                        {
                            MessageBox.Show(ex.ToString(), "Ошибка");
                        }
                    }


                    else
                    {
                        MessageBox.Show("Конечная дата должна быть заполнена");
                    }

                }
                else
                {
                    MessageBox.Show("Начальная дата должна быть заполнена");
                }

            }
            else
            {
                MessageBox.Show("Организация должно быть заполнена");
            }

        }

        public string GetMonth(int a)
        {
            if (a == 1)
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


        private void CalcAndOpen_Click(object sender, RoutedEventArgs e)
        {
            if (CBOrgan.Text != "")
            {
                if (OneDateTx.Text != "")
                {
                    if (TwoDateTx.Text != "")
                    {
                        try
                        {
                            if (CBOrgan.Text == "Все организации")
                            {
                                NumberAndSumma.Clear();
                                string OneDateStr = OneDateTx.SelectedDate.ToString();
                                string TwoDateStr = TwoDateTx.SelectedDate.ToString();
                                DateTime OnData = DateTime.Parse(OneDateStr);  // даты для формирования счета
                                DateTime TwoDate = DateTime.Parse(TwoDateStr);
                                OnData1 = OnData;
                                TwoData1 = TwoDate;

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

                                foreach (Organizations organizations12 in organsList)
                                {
                                    int o1 = organizations12.IDOrganization;  // id organization 
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
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
                                                multi = 0;
                                                SumTime = 0;
                                                NumberAdd = "";
                                                Cost = 0;
                                            }
                                            if (IDType2 == 2)
                                            {
                                                multi = (SumTime / 10) * Cost;
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
                                                multi = 0;
                                                SumTime = 0;
                                                NumberAdd = "";
                                                Cost = 0;
                                            }
                                            if (IDType2 == 3)
                                            {
                                                multi = (SumTime - 60) * Cost;
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
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
                                                    NumberAndSumma.Add(NumberAdd); // номер
                                                    NumberAndSumma.Add(IDRate); // тариф

                                                    NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                    NumberAndSumma.Add(Convert.ToString(Cost));
                                                    NumberAndSumma.Add(multi2); // Стоимость
                                                    NumberAdd = "";
                                                    Cost = 0;
                                                }
                                                else
                                                {
                                                    Rate rate = Base.ep.Rate.FirstOrDefault(z => z.IDRate == 1);
                                                    double sK = Convert.ToDouble(rate.Cost);
                                                    multi = ((SumTime / 60) - kol) * sK;
                                                    string multi2 = Convert.ToString(Cost);
                                                    NumberAndSumma.Add(NumberAdd); // номер
                                                    NumberAndSumma.Add(IDRate); // тариф

                                                    NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                    NumberAndSumma.Add(Convert.ToString(Cost));
                                                    NumberAndSumma.Add(multi2); // Стоимость
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

                                    if (countNumber != 0)
                                    {

                                        doc.Add(new iTextSharp.text.Paragraph("НН Телеком ", font2));
                                        string Text2 = " "; // пустая строчка 
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));



                                        int year = OnData1.Year;
                                        int month = OnData1.Month;
                                        int day = OnData1.Day;

                                        int year2 = TwoData1.Year;
                                        int month2 = TwoData1.Month;
                                        int day2 = TwoData1.Day;
                                        string monthapay = GetMonth(month);
                                        string monthapay2 = GetMonth(month2);

                                        string now = DateTime.Now.ToString("dd-MMMM-yyyy");

                                        int numbertable = 1;

                                        PdfPCell cell = new PdfPCell();
                                        PdfPTable table2 = new PdfPTable(4);
                                        PdfPTable table = new PdfPTable(7);



                                        OrganInfo organInfo = Base.ep.OrganInfo.FirstOrDefault(z => z.IdInfoorgan == 1);
                                        string KPP = organInfo.KPP;
                                        string ChekB = organInfo.CheckBank;
                                        string ChekA = organInfo.Checkorgan;
                                        string NameB = organInfo.NameBank;
                                        string NameA = organInfo.Name;
                                        string INN = organInfo.INN;
                                        string bik = organInfo.Bik;
                                        string Email = organInfo.Email;
                                        string Index = organInfo.IndexO;
                                        string Adress = organInfo.Adress;
                                        string phonw = organInfo.Phone;

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(NameB, font)));
                                        cell.Colspan = 2;
                                        table2.AddCell(cell); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("БИК" + "\n" + "Сч.№", font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph(bik + "\n" + ChekB, font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("ИНН " + INN, font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("KПП " + KPP, font)); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph("Сч.№", font))); // таблица 2 
                                        cell.Rowspan = 2;
                                        table2.AddCell(cell); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(ChekA, font))); // таблица 2 
                                        cell.Rowspan = 2;
                                        table2.AddCell(cell); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(NameA, font)));
                                        cell.Colspan = 2;
                                        table2.AddCell(cell); // таблица 2 
                                        doc.Add(table2);

                                        string TextData = "Дата формирования счета " + now;
                                        string DataCalc = "Расчет за " + day + " " + monthapay + " По " + day2 + " " + monthapay2;
                                        doc.Add(new iTextSharp.text.Paragraph(TextData, font));
                                        doc.Add(new iTextSharp.text.Paragraph(DataCalc, font));
                                        string Text = "Внимание! Оплата данного счета означает согласие с условиями поставки товара\r\nУведомление об оплате обязательно, в противном случае не гарантируется наличие товара на складе.\r\nТовар отпускается по факту прихода денег на р/с Поставщика, самовывозом, при наличии доверенности и паспорта";
                                        doc.Add(new iTextSharp.text.Paragraph(Text, font));
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));
                                        string Text4 = "Поставщик: " + NameA + " ИНН " + INN + " КПП " + KPP + " " + Index + " " + Adress + " тел: " + phonw;
                                        doc.Add(new iTextSharp.text.Paragraph(Text4, font));
                                        Organizations organizations1 = Base.ep.Organizations.FirstOrDefault(z => z.IDOrganization == IDOrgan);
                                        if (organizations1 != null)
                                        {
                                            string ORGAN = " " + organizations1.NameOrganization + " , ИНН " + organizations1.INN + " , " + organizations1.Surname + " " + organizations1.Name + " " + organizations1.Patronymic + " , " + organizations1.Address;
                                            string Text3 = "Покупатель: " + ORGAN;
                                            doc.Add(new iTextSharp.text.Paragraph(Text3, font));
                                            doc.Add(new iTextSharp.text.Paragraph(Text2, font));


                                            for (int j = 4; j < NumberAndSumma.Count; j++) // 
                                            {
                                                double a = Convert.ToDouble(NumberAndSumma[j]);
                                                summ = summ + a;
                                                j = j + 4;
                                            }
                                            table.AddCell(new iTextSharp.text.Paragraph("№", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Номер телефона", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Тариф", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Количество", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Ед.", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Цена", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Сумма, руб", font));
                                            for (int j = 0; j < NumberAndSumma.Count; j++)
                                            {
                                                table.AddCell(new iTextSharp.text.Paragraph(Convert.ToString(numbertable))); //номер списка
                                                table.AddCell(NumberAndSumma[j]); // номер телефона
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 1], font)); // Тариф
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 2], font)); // кол во минут
                                                table.AddCell(new iTextSharp.text.Paragraph("Секунды", font)); // обозн минуты
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 3], font)); // цена
                                                table.AddCell(NumberAndSumma[j + 4]);  // Сумма
                                                j = j + 4;
                                                numbertable = numbertable + 1;
                                            }
                                            numbertable = 1;
                                            cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph("Итоговая сумма к оплате", font)));
                                            cell.Colspan = 6;
                                            table.AddCell(cell);
                                            string b = Convert.ToString(summ);
                                            table.AddCell(b);

                                            doc.Add(table);

                                            summ = 0;
                                            NumberAndSumma.Clear();
                                            doc.NewPage();

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Звонков не обнаружено ");
                                    }


                                    NumberAndSumma.Clear();


                                } // create list for date if vs

                                doc.Close();
                                Process.Start("Test.pdf");  // open file 


                            }

                            else
                            {
                                NumberAndSumma.Clear();
                                string OneDateStr = OneDateTx.SelectedDate.ToString();
                                string TwoDateStr = TwoDateTx.SelectedDate.ToString();
                                DateTime OnData = DateTime.Parse(OneDateStr);
                                DateTime TwoDate = DateTime.Parse(TwoDateStr);
                                OnData1 = OnData;
                                TwoData1 = TwoDate;

                                Organizations organizations = Base.ep.Organizations.FirstOrDefault(z => z.NameOrganization == CBOrgan.Text);
                                if (organizations == null)
                                {
                                    MessageBox.Show("Проверьте правильность ввода организации");
                                }
                                else
                                {
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
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
                                                multi = 0;
                                                SumTime = 0;
                                                NumberAdd = "";
                                                Cost = 0;
                                            }
                                            if (IDType2 == 2)
                                            {
                                                multi = (SumTime / 10) * Cost;
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
                                                multi = 0;
                                                SumTime = 0;
                                                NumberAdd = "";
                                                Cost = 0;
                                            }
                                            if (IDType2 == 3)
                                            {
                                                multi = (SumTime - 60) * Cost;
                                                string multi2 = Convert.ToString(Math.Round(multi, 2));
                                                NumberAndSumma.Add(NumberAdd); // номер
                                                NumberAndSumma.Add(IDRate); // тариф

                                                NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                NumberAndSumma.Add(Convert.ToString(Cost));
                                                NumberAndSumma.Add(multi2); // Стоимость
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
                                                    NumberAndSumma.Add(NumberAdd); // номер
                                                    NumberAndSumma.Add(IDRate); // тариф

                                                    NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                    NumberAndSumma.Add(Convert.ToString(Cost));
                                                    NumberAndSumma.Add(multi2); // Стоимость
                                                    NumberAdd = "";
                                                    Cost = 0;
                                                }
                                                else
                                                {
                                                    Rate rate = Base.ep.Rate.FirstOrDefault(z => z.IDRate == 1);
                                                    double sK = Convert.ToDouble(rate.Cost);
                                                    multi = ((SumTime / 60) - kol) * sK;
                                                    string multi2 = Convert.ToString(Cost);
                                                    NumberAndSumma.Add(NumberAdd); // номер
                                                    NumberAndSumma.Add(IDRate); // тариф

                                                    NumberAndSumma.Add(Convert.ToString(SumTime)); // минуты
                                                    NumberAndSumma.Add(Convert.ToString(Cost));
                                                    NumberAndSumma.Add(multi2); // Стоимость
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
                                    } // created list for date




                                    int countNumber = NumberAndSumma.Count;

                                    if (countNumber != 0)
                                    {

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


                                        doc.Add(new iTextSharp.text.Paragraph("НН Телеком ", font2));
                                        string Text2 = " "; // пустая строчка 
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));



                                        int year = OnData1.Year;
                                        int month = OnData1.Month;
                                        int day = OnData1.Day;

                                        int year2 = TwoData1.Year;
                                        int month2 = TwoData1.Month;
                                        int day2 = TwoData1.Day;
                                        string monthapay = GetMonth(month);
                                        string monthapay2 = GetMonth(month2);

                                        string now = DateTime.Now.ToString("dd-MMMM-yyyy");

                                        int numbertable = 1;

                                        PdfPCell cell = new PdfPCell();
                                        PdfPTable table2 = new PdfPTable(4);
                                        PdfPTable table = new PdfPTable(7);



                                        OrganInfo organInfo = Base.ep.OrganInfo.FirstOrDefault(z => z.IdInfoorgan == 1);
                                        string KPP = organInfo.KPP;
                                        string ChekB = organInfo.CheckBank;
                                        string ChekA = organInfo.Checkorgan;
                                        string NameB = organInfo.NameBank;
                                        string NameA = organInfo.Name;
                                        string INN = organInfo.INN;
                                        string bik = organInfo.Bik;
                                        string Email = organInfo.Email;
                                        string Index = organInfo.IndexO;
                                        string Adress = organInfo.Adress;
                                        string phonw = organInfo.Phone;

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(NameB, font)));
                                        cell.Colspan = 2;
                                        table2.AddCell(cell); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("БИК" + "\n" + "Сч.№", font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph(bik + "\n" + ChekB, font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("ИНН " + INN, font)); // таблица 2 
                                        table2.AddCell(new iTextSharp.text.Paragraph("KПП " + KPP, font)); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph("Сч.№", font))); // таблица 2 
                                        cell.Rowspan = 2;
                                        table2.AddCell(cell); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(ChekA, font))); // таблица 2 
                                        cell.Rowspan = 2;
                                        table2.AddCell(cell); // таблица 2 

                                        cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph(NameA, font)));
                                        cell.Colspan = 2;
                                        table2.AddCell(cell); // таблица 2 
                                        doc.Add(table2);

                                        string TextData = "Дата формирования счета " + now;
                                        string DataCalc = "Расчет за " + day + " " + monthapay + " По " + day2 + " " + monthapay2;
                                        doc.Add(new iTextSharp.text.Paragraph(TextData, font));
                                        doc.Add(new iTextSharp.text.Paragraph(DataCalc, font));
                                        string Text = "Внимание! Оплата данного счета означает согласие с условиями поставки товара\r\nУведомление об оплате обязательно, в противном случае не гарантируется наличие товара на складе.\r\nТовар отпускается по факту прихода денег на р/с Поставщика, самовывозом, при наличии доверенности и паспорта";
                                        doc.Add(new iTextSharp.text.Paragraph(Text, font));
                                        doc.Add(new iTextSharp.text.Paragraph(Text2, font));
                                        string Text4 = "Поставщик: " + NameA + " ИНН " + INN + " КПП " + KPP + " " + Index + " " + Adress + " тел: " + phonw;
                                        doc.Add(new iTextSharp.text.Paragraph(Text4, font));
                                        Organizations organizations1 = Base.ep.Organizations.FirstOrDefault(z => z.IDOrganization == IDOrgan);
                                        if (organizations1 != null)
                                        {
                                            string ORGAN = " " + organizations1.NameOrganization + " , ИНН " + organizations1.INN + " , " + organizations1.Surname + " " + organizations1.Name + " " + organizations1.Patronymic + " , " + organizations1.Address;
                                            string Text3 = "Покупатель: " + ORGAN;
                                            doc.Add(new iTextSharp.text.Paragraph(Text3, font));
                                            doc.Add(new iTextSharp.text.Paragraph(Text2, font));


                                            for (int j = 4; j < NumberAndSumma.Count; j++) // 
                                            {
                                                double a = Convert.ToDouble(NumberAndSumma[j]);
                                                summ = summ + a;
                                                j = j + 4;
                                            }
                                            table.AddCell(new iTextSharp.text.Paragraph("№", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Номер телефона", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Тариф", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Количество", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Ед.", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Цена", font));
                                            table.AddCell(new iTextSharp.text.Paragraph("Сумма, руб", font));
                                            for (int j = 0; j < NumberAndSumma.Count; j++)
                                            {
                                                table.AddCell(new iTextSharp.text.Paragraph(Convert.ToString(numbertable))); //номер списка
                                                table.AddCell(NumberAndSumma[j]); // номер телефона
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 1], font)); // Тариф
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 2], font)); // кол во минут
                                                table.AddCell(new iTextSharp.text.Paragraph("Секунды", font)); // обозн минуты
                                                table.AddCell(new iTextSharp.text.Paragraph(NumberAndSumma[j + 3], font)); // цена
                                                table.AddCell(NumberAndSumma[j + 4]);  // Сумма
                                                j = j + 4;
                                                numbertable = numbertable + 1;
                                            }
                                            numbertable = 1;
                                            cell = new PdfPCell(new Phrase(new iTextSharp.text.Paragraph("Итоговая сумма к оплате", font)));
                                            cell.Colspan = 6;
                                            table.AddCell(cell);
                                            string b = Convert.ToString(summ);
                                            table.AddCell(b);

                                            doc.Add(table);


                                            doc.Close();



                                            Process.Start("Test.pdf");  // open file 
                                        }
                                        else
                                        {
                                            MessageBox.Show("Организация не совершила ни одного звонка");
                                        }

                                        multi = 0;
                                        kol = 0;
                                        IDRate = "";
                                        summ = 0;
                                        IDOrgan = 0;
                                        IDType2 = 0;
                                        Cost = 0;
                                        NumberAdd = "";
                                        NumberAndSumma.Clear();

                                    }

                                    else
                                    {
                                        MessageBox.Show("Организация не совершила ни одного звонка");
                                    }
                                }
                            }
                        }
                        catch (SystemException ex)
                        {
                            MessageBox.Show(ex.ToString(), "Ошибка");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Конечная дата должна быть заполнена");
                    }

                }
                else
                {
                    MessageBox.Show("Начальная дата должна быть заполнена");
                }

            }
            else
            {
                MessageBox.Show("Организация должно быть заполнена");
            }

        }
    }
}
