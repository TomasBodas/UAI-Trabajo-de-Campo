using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.Abstractions;
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using System.Drawing.Imaging;
using UAICampo.Abstractions.Observer;
using UAICampo.Services.Observer;

namespace UAICampo.UI
{
    public partial class frmSprint : Form, IObserver
    {
        IEquipo equipo;
        BLL_EquipoManager bllEquipo;
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;
        public frmSprint()
        {
            InitializeComponent();
            bllEquipo = new BLL_EquipoManager();
            bllLanguage = new BLL_LanguageManager();

            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }
        }

        private void frmSprint_Load(object sender, EventArgs e)
        {
            equipo = BLL_EquipoManager.getUserTeam(UserInstance.getInstance().user);
            List<User> trabajadores = bllEquipo.getMembers(equipo);
            foreach (var trabajador in trabajadores)
            {
                UserPropuesto up = BLL_PropuestaManager.GetSpecific(trabajador.Username, true);
                dataGridViewProposal.Rows.Add(up.Username, BLL_UserManager.getUserProfile(up).ProfileName, up.ValorTotal,
                        up.PromedioReconocimientoDeSuperiores,
                        up.PorcentajeObjetivosCumplidos,
                        up.PromedioReconocimiento,
                        up.CantidadObjetivosNoCumplidos,
                        up.CantidadReconocimientos
                        );
            }
            List<Tarea> tareasCompletas = BLL_TareasManager.getFinishedByTeam(equipo);
            List<Tarea> tareasIncompletas = BLL_TareasManager.getUnfinishedByTeam(equipo);

            foreach (var tarea in tareasCompletas)
            {
                listBox1.Items.Add(tarea.Title);
            }
            foreach (var tarea in tareasIncompletas)
            {
                listBox2.Items.Add(tarea.Title);
            }
        }

        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add(column.Name);
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Rectangle bounds = this.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                }
                bitmap.Save("D://Sprint.jpg", ImageFormat.Jpeg);
            }

            var doc = new PdfDocument();

            var oPage = new PdfPage();

            doc.Pages.Add(oPage);
            var xgr = XGraphics.FromPdfPage(oPage);
            var img = XImage.FromFile("D://Sprint.jpg");

            xgr.DrawImage(img, 0, 0);

            doc.Save("D://Sprint.pdf");
            doc.Close();
            MessageBox.Show("PDF file created.");

            ////Creating iTextSharp Table from the DataTable data
            //PdfPTable pdfTable = new PdfPTable(dataGridViewProposal.ColumnCount);
            //pdfTable.DefaultCell.Padding = 3;
            //pdfTable.WidthPercentage = 60;
            //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            //pdfTable.DefaultCell.BorderWidth = 1;

            ////Adding Header row
            //foreach (DataGridViewColumn column in dataGridViewProposal.Columns)
            //{
            //    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
            //    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
            //    pdfTable.AddCell(cell);
            //}

            ////Adding DataRow
            //foreach (DataGridViewRow row in dataGridViewProposal.Rows)
            //{
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        try
            //        {
            //            pdfTable.AddCell(cell.Value.ToString());
            //        }
            //        catch { }
            //    }
            //}

            ////Exporting to PDF
            //string folderPath = "C:\\PDFs\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            //using (FileStream stream = new FileStream(folderPath + "SprintStats.pdf", FileMode.Create))
            //{
            //    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
            //    PdfWriter.GetInstance(pdfDoc, stream);
            //    pdfDoc.Open();
            //    pdfDoc.Add(new Paragraph("Sprint stats"));
            //    pdfDoc.Add(pdfTable);
            //    pdfDoc.Close();
            //    stream.Close();
            //}
        }

        public void Update()
        {
            Language selectedLanguage = UserInstance.getInstance().user.language;

            bllLanguage.loadLanguageWords(selectedLanguage);

            foreach (var controller in controllers)
            {
                try
                {
                    if (controller.Key.Word != null)
                    {
                        KeyValuePair<string, string> textValue = selectedLanguage.words.SingleOrDefault(kvp => kvp.Key == controller.Key.Word);
                        if (textValue.Value != null)
                        {
                            controller.Value.Text = textValue.Value;
                        }
                        else
                        {
                            controller.Value.Text = "Not found";
                        }
                    }
                }
                catch (Exception)
                { }
            }
        }


        private void SetControllerTags()
        {
            //In here, we set each controller tag list.
            //This list wil be made out of keyvaluepairs, with a controller, and a tag
            //Each Tag will be made out of two values
            //First value: license required for it to show up to the user
            //Second value: Word Tag, used for language runtime changes

            //General controllers------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Scores"), groupBoxScores));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Tasks"), groupBox1));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "SprintStats"), labelStats));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Completed"), label1));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Unfinished"), label2));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ExportToPDF"), buttonExport));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ExportToXML"), buttonXML));
        }

        private void buttonXML_Click(object sender, EventArgs e)
        {
            DataTable dT = GetDataTableFromDGV(dataGridViewProposal);
            DataSet dS = new DataSet();
            dS.Tables.Add(dT);
            dS.WriteXml(File.OpenWrite("teamscores.xml"));
            MessageBox.Show("Exported to XML.");
        }
    }
}
