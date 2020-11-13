using BE;
using BLL;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class ReporteRentabilidadForm : I18nForm
    {
        ProyectoService proyectoService = ProyectoService.getInstance();

        public ReporteRentabilidadForm()
        {
            InitializeComponent();
            ReloadLang();
        }

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("report.since");
                this.label2.Text = i18n().GetString("report.until");
                this.button1.Text = i18n().GetString("report.clean");
                this.button2.Text = i18n().GetString("report.search");
                this.Proyecto.HeaderText = i18n().GetString("report.list.project");
                this.Estado.HeaderText = i18n().GetString("report.list.state");
                this.Estimadas.HeaderText = i18n().GetString("report.list.estimated.hs");
                this.Insumidas.HeaderText = i18n().GetString("report.list.insumidas.hs");
                this.Desvio.HeaderText = i18n().GetString("report.list.desvio.hs");
                this.DesvioDinero.HeaderText = i18n().GetString("report.list.desvio.dinero");
                this.Fecha.HeaderText = i18n().GetString("report.list.date");
                this.button3.Text = i18n().GetString("export");
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception)
            {
                showError(i18n().GetString("errors.1"));
            }
        }

        private void ReporteRentabilidadForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.Width = Convert.ToInt32(this.Width * 0.98);
                this.dataGridView1.Height = Convert.ToInt32(this.Height * 0.80);
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception)
            {
                showError(i18n().GetString("errors.1"));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.desdeField.Value = DateTime.Now;
                this.hastaField.Value = DateTime.Now;
                this.dataGridView1.Rows.Clear();
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception)
            {
                showError(i18n().GetString("errors.1"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.Rows.Clear();
                List<BE.ProyectoReporte> list = proyectoService.generarReporte(this.desdeField.Value, this.hastaField.Value);
                foreach (BE.ProyectoReporte r in list)
                {
                    this.dataGridView1.Rows.Add(new object[] { r.Nombre, true, r.HorasEstimadas, r.HorasInsumidas, r.DesvioHoras, r.DesvioDinero, r.Fecha });
                }
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception)
            {
                showError(i18n().GetString("errors.1"));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "reporteRentabilidad_" + DateTime.Now.ToString("dd - MM - yyyy") + ".pdf";
            savefile.Filter = "PDF files (*.pdf)|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                PdfWriter writer = new PdfWriter(savefile.FileName);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf, PageSize.LETTER);
                document.SetMargins(60, 20, 55, 20);


                iText.Kernel.Font.PdfFont fontCol = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
                iText.Kernel.Font.PdfFont fontText = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);


                string[] columns = { i18n().GetString("report.list.project"), i18n().GetString("report.list.estimated.hs"), i18n().GetString("report.list.insumidas.hs")
                        , i18n().GetString("report.list.desvio.hs"), i18n().GetString("report.list.desvio.dinero") };

                float[] sizes = { 20, 20, 20, 20, 20 };
                Table table = new Table(UnitValue.CreatePercentArray(sizes));
                table.SetWidth(UnitValue.CreatePercentValue(100));

                foreach (string col in columns)
                    table.AddHeaderCell(new Cell().Add(new Paragraph(col)));

                List<BE.ProyectoReporte> list = proyectoService.generarReporte(this.desdeField.Value, this.hastaField.Value);
                foreach (BE.ProyectoReporte r in list)
                {
                    table.AddCell(new Cell().Add(new Paragraph(r.Nombre).SetFont(fontText)));
                    table.AddCell(new Cell().Add(new Paragraph(r.HorasEstimadas.ToString()).SetFont(fontText)));
                    table.AddCell(new Cell().Add(new Paragraph(r.HorasInsumidas.ToString()).SetFont(fontText)));
                    table.AddCell(new Cell().Add(new Paragraph(r.DesvioHoras.ToString()).SetFont(fontText)));
                    table.AddCell(new Cell().Add(new Paragraph(r.DesvioDinero.ToString()).SetFont(fontText)));
                }
                document.Add(table);
                document.Close();

                showInfo(i18n().GetString("exportado"));
            }
        }
    }
}
