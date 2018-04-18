using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using BE;
using System.Windows.Forms;
using BL;

namespace PLWPF
{
    class pdfCreator
    {
        
        public static void createPDFofEmployee(Employee employee)
        {
            BL.IBL bl = BL.FactoryBL.GetBLInstance();
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
            rec.BackgroundColor = new BaseColor(System.Drawing.Color.Azure);
            Document document = new Document(rec, 88f, 88f, 10f, 10f);
            iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            string path = "";

            Document doc = new Document(rec, 10, 10, 42, 35);
            doc.AddTitle("Employee");
            doc.AddAuthor("HTC");
            doc.AddCreationDate();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FileName = "New Employee";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                Phrase phrase = null;
                PdfPCell cell = null;
                PdfPTable table = null;
                iTextSharp.text.BaseColor color = null;

                document.Open();

                //Header Table
                table = new PdfPTable(2);
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 0.3f, 0.7f });

                //Company Logo
                cell = ImageCell(@"\images\icon.png", 60f, PdfPCell.ALIGN_CENTER);
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Company Name and Address
                phrase = new Phrase();
                phrase.Add(new Chunk("High Tech Contracts\n\n", FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED)));
                phrase.Add(new Chunk("21, Havaad Haleumi,\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("Givat Mordechi,\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("Jerusalem, ISRAEL", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Separater Line
                color = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
                DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
                document.Add(table);

                table = new PdfPTable(2);
                table.HorizontalAlignment = Element.ALIGN_LEFT;
                table.SetWidths(new float[] { 0.3f, 1f });
                //table.SpacingBefore = 20f;
                table.SpacingBefore = 30f;

                //Employee Details
                cell = PhraseCell(new Phrase("Employee Record", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Photo
                cell = ImageCell(string.Format(employee.ImageSource, "EmployeeId"), 49f, PdfPCell.ALIGN_CENTER);
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Name
                phrase = new Phrase();
                phrase.Add(new Chunk(employee + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
               // phrase.Add(new Chunk("(" + "".ToString() + ")", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);
                document.Add(table);

                DrawLine(writer, 160f, 40f, 160f, 690f, iTextSharp.text.BaseColor.BLACK);
                DrawLine(writer, 115f, document.Top - 195f, document.PageSize.Width - 100f, document.Top - 195f, iTextSharp.text.BaseColor.BLACK);

                table = new PdfPTable(2);
                table.SetWidths(new float[] { 0.5f, 2f });
                table.TotalWidth = 340f;
                table.LockedWidth = true;
                table.SpacingBefore = 5f;
                table.HorizontalAlignment = Element.ALIGN_RIGHT;

                //Employee Id
                table.AddCell(PhraseCell(new Phrase("Employee code:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employee.ID.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 1f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);


                //Address
                table.AddCell(PhraseCell(new Phrase("Address:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                phrase = new Phrase(new Chunk(employee.address + "\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk(employee.City + "\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("Middle East" + " " + "Israel", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);

                //Date of Birth
                table.AddCell(PhraseCell(new Phrase("Date of Birth:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employee.birth.ToString("dd MMMM, yyyy"), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Phone
                table.AddCell(PhraseCell(new Phrase("House Phone:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employee.phoneNum.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Cell Phone
                table.AddCell(PhraseCell(new Phrase("Cell Phone:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase("0" + employee.CellPhoneNum.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Email address
                table.AddCell(PhraseCell(new Phrase("Email Address:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employee.EmailAddress, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Degree
                table.AddCell(PhraseCell(new Phrase("degree:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employee.degree.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //after army
                table.AddCell(PhraseCell(new Phrase("after army:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employee.afterArmy.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                ////bank info
                //table.AddCell(PhraseCell(new Phrase("bank:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                //table.AddCell(PhraseCell(new Phrase(employee.bankAccount.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                //cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                //cell.Colspan = 2;
                //cell.PaddingBottom = 10f;
                //cell.Border = PdfPCell.NO_BORDER;
                //table.AddCell(cell);

                //account number
                table.AddCell(PhraseCell(new Phrase("account number:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employee._AcountNumber.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //specialization
                table.AddCell(PhraseCell(new Phrase("specialization:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(bl.getSpecialization(employee.numOfSpecialization).SpecializationName, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //status
                table.AddCell(PhraseCell(new Phrase("status:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employee.status.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //number of jobs
                table.AddCell(PhraseCell(new Phrase("number of jobs:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employee.numOfJobs.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                ////Addtional Information
                //table.AddCell(PhraseCell(new Phrase("Addtional Information:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                //table.AddCell(PhraseCell(new Phrase(employee.Summary, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));
                //document.Add(table);
                //document.Close();
                //System.Diagnostics.Process.Start(path);
            }
        }

        public static void createPDFofEmployer(Employer employer)
        {
            BL.IBL bl = BL.FactoryBL.GetBLInstance();
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
            rec.BackgroundColor = new BaseColor(System.Drawing.Color.Azure);
            Document document = new Document(rec, 88f, 88f, 10f, 10f);
            iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            string path = "";

            Document doc = new Document(rec, 10, 10, 42, 35);
            doc.AddTitle("Employer");
            doc.AddAuthor("HTC");
            doc.AddCreationDate();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FileName = "New Employer";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                Phrase phrase = null;
                PdfPCell cell = null;
                PdfPTable table = null;
                iTextSharp.text.BaseColor color = null;

                document.Open();

                //Header Table
                table = new PdfPTable(2);
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 0.3f, 0.7f });

                //Company Logo
                cell = ImageCell(@"\images\icon.png", 60f, PdfPCell.ALIGN_CENTER);
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Company Name and Address
                phrase = new Phrase();
                phrase.Add(new Chunk("High Tech Contracts\n\n", FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED)));
                phrase.Add(new Chunk("21, Havaad Haleumi,\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("Givat Mordechi,\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("Jerusalem, ISRAEL", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Separater Line
                color = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
                DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
                document.Add(table);

                table = new PdfPTable(2);
                table.HorizontalAlignment = Element.ALIGN_LEFT;
                table.SetWidths(new float[] { 0.3f, 1f });
                //table.SpacingBefore = 20f;
                table.SpacingBefore = 30f;

                //Employee Details
                cell = PhraseCell(new Phrase("Employer Record", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Photo
                cell = ImageCell(string.Format(employer.ImageSource, "EmployeeId"), 49f, PdfPCell.ALIGN_CENTER);
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Name
                phrase = new Phrase();
                phrase.Add(new Chunk(employer + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                // phrase.Add(new Chunk("(" + "".ToString() + ")", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);
                document.Add(table);

                DrawLine(writer, 160f, 40f, 160f, 690f, iTextSharp.text.BaseColor.BLACK);
                DrawLine(writer, 115f, document.Top - 195f, document.PageSize.Width - 100f, document.Top - 195f, iTextSharp.text.BaseColor.BLACK);

                table = new PdfPTable(2);
                table.SetWidths(new float[] { 0.5f, 2f });
                table.TotalWidth = 340f;
                table.LockedWidth = true;
                table.SpacingBefore = 5f;
                table.HorizontalAlignment = Element.ALIGN_RIGHT;

                //Employee Id
                table.AddCell(PhraseCell(new Phrase("Employer code:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employer.ID.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 1f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);


                //Address
                table.AddCell(PhraseCell(new Phrase("Address:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                phrase = new Phrase(new Chunk(employer.address + "\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk(employer.area.ToString() + "\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("Middle East" + " " + "Israel", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                table.AddCell(cell);

                //Date of Birth
                table.AddCell(PhraseCell(new Phrase("establishment date:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employer.birth.ToString("dd MMMM, yyyy"), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Phone
                table.AddCell(PhraseCell(new Phrase("Phone:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employer.phoneNum.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);                

                //Email address
                table.AddCell(PhraseCell(new Phrase("Email Address:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employer.EmailAddress, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //field
                table.AddCell(PhraseCell(new Phrase("field:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employer.field1.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);
              
                //number of employees
                table.AddCell(PhraseCell(new Phrase("number of employees:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(employer.NumOfEmployees.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                ////Addtional Information
                //table.AddCell(PhraseCell(new Phrase("Addtional Information:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                //table.AddCell(PhraseCell(new Phrase(employer.CompanySummary, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));
                //document.Add(table);
                //document.Close();
                //System.Diagnostics.Process.Start(path);
            }
        }

        public static void createPDFofContract(Contract contract)
        {
            BL.IBL bl = BL.FactoryBL.GetBLInstance();
            iTextSharp.text.Rectangle rec = new iTextSharp.text.Rectangle(PageSize.A4);
            rec.BackgroundColor = new BaseColor(System.Drawing.Color.Azure);
            Document document = new Document(rec, 88f, 88f, 10f, 10f);
            iTextSharp.text.Font NormalFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            string path = "";

            Document doc = new Document(rec, 10, 10, 42, 35);
            doc.AddTitle("Contract");
            doc.AddAuthor("HTC");
            doc.AddCreationDate();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog1.FileName = "New Contract";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                Phrase phrase = null;
                PdfPCell cell = null;
                PdfPTable table = null;
                iTextSharp.text.BaseColor color = null;

                document.Open();

                //Header Table
                table = new PdfPTable(2);
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                table.SetWidths(new float[] { 0.3f, 0.7f });

                //Company Logo
                cell = ImageCell(@"\images\icon.png", 60f, PdfPCell.ALIGN_CENTER);
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Company Name and Address
                phrase = new Phrase();
                phrase.Add(new Chunk("High Tech Contracts\n\n", FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED)));
                phrase.Add(new Chunk("21, Havaad Haleumi,\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("Givat Mordechi,\n", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                phrase.Add(new Chunk("Jerusalem, ISRAEL", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Separater Line
                color = new iTextSharp.text.BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
                DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
                document.Add(table);

                table = new PdfPTable(2);
                table.HorizontalAlignment = Element.ALIGN_LEFT;
                table.SetWidths(new float[] { 0.3f, 1f });
                //table.SpacingBefore = 20f;
                table.SpacingBefore = 30f;

                //Employee Details
                cell = PhraseCell(new Phrase("Contract Record", FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.UNDERLINE, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Photo
                cell = ImageCell(string.Format(@"\images\contract_pen.png", "EmployeeId"), 49f, PdfPCell.ALIGN_CENTER);
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Name
                phrase = new Phrase();
                phrase.Add(new Chunk(contract + "\n", FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                // phrase.Add(new Chunk("(" + "".ToString() + ")", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)));
                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);
                document.Add(table);

                DrawLine(writer, 160f, 40f, 160f, 690f, iTextSharp.text.BaseColor.BLACK);
                //DrawLine(writer, 115f, document.Top - 195f, document.PageSize.Width - 100f, document.Top - 195f, iTextSharp.text.BaseColor.BLACK);

                table = new PdfPTable(2);
                table.SetWidths(new float[] { 0.5f, 2f });
                table.TotalWidth = 340f;
                table.LockedWidth = true;
                table.SpacingBefore = 5f;
                table.HorizontalAlignment = Element.ALIGN_RIGHT;

                //contract Id
                table.AddCell(PhraseCell(new Phrase("Contract code:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(contract.contractNum.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 1f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);               

                //employer
                table.AddCell(PhraseCell(new Phrase("Employer:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(bl.getEmployer(contract.employerID).ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //employee
                table.AddCell(PhraseCell(new Phrase("Employee:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(bl.getEmployee(contract.employeeID).ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //interview
                table.AddCell(PhraseCell(new Phrase("interview:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(contract.interview.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //gross
                table.AddCell(PhraseCell(new Phrase("gross:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(contract.gross.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //net
                table.AddCell(PhraseCell(new Phrase("net:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(contract.net.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //employement begin
                table.AddCell(PhraseCell(new Phrase("employement begin:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(contract.employementBegin.ToString("dd MMMM, yyyy"), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //employement begin
                table.AddCell(PhraseCell(new Phrase("employement end:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(contract.employementEnd.ToString("dd MMMM, yyyy"), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //net
                table.AddCell(PhraseCell(new Phrase("hours a month:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(contract.monthHours.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //days off a year
                table.AddCell(PhraseCell(new Phrase("days off:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(contract.DaysOffAYear.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //pension
                table.AddCell(PhraseCell(new Phrase("pension:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(contract.Pension.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //signed
                table.AddCell(PhraseCell(new Phrase("signed:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                table.AddCell(PhraseCell(new Phrase(contract.contractSignd.ToString(), FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
                cell.Colspan = 2;
                cell.PaddingBottom = 10f;
                cell.Border = PdfPCell.NO_BORDER;
                table.AddCell(cell);

                //Addtional Information
                //table.AddCell(PhraseCell(new Phrase("Addtional Information:", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
                //table.AddCell(PhraseCell(new Phrase(contract.ExtraInfo, FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));
                //document.Add(table);
                //document.Close();
                //System.Diagnostics.Process.Start(path);
            }
        }

        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, iTextSharp.text.BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = iTextSharp.text.BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            cell.Border = PdfPCell.NO_BORDER;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            string newPath;
            iTextSharp.text.Image image;
            string p = Path.Combine(Environment.CurrentDirectory);
            p=p.Remove(p.Length - 10);
            if(path.Length<30)
            newPath = p + path;
            else
            {
                newPath = path;
            }
            image = iTextSharp.text.Image.GetInstance(newPath);

            //image.ScalePercent(scale);
            image.ScaleAbsolute(scale, scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = iTextSharp.text.BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;
            cell.Border = PdfPCell.NO_BORDER;
            return cell;
        }
    }
}
