using BE;
using BLL;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class BitacoraForm : I18nForm
    {
        UsuarioService usuarioService = UsuarioService.getInstance();
        BitacoraService service = BitacoraService.getInstance();

        public BitacoraForm()
        {
            InitializeComponent();
            ReloadLang();
        }

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("log.since");
                this.label2.Text = i18n().GetString("log.until");
                this.label3.Text = i18n().GetString("log.level");
                this.label4.Text = i18n().GetString("log.user");
                this.button1.Text = i18n().GetString("log.search");
                this.button2.Text = i18n().GetString("log.clean");
                this.Usuario.HeaderText = i18n().GetString("log.list.user");
                this.Criticidad.HeaderText = i18n().GetString("log.list.level");
                this.Funcionalidad.HeaderText = i18n().GetString("log.list.functionality");
                this.Descripcion.HeaderText = i18n().GetString("log.list.desc");
                this.Fecha.HeaderText = i18n().GetString("log.list.date");
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

        private void BitacoraForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> usuarios = usuarioService.listar();
                this.userCombo.Items.Clear();
                foreach (Usuario user in usuarios)
                {
                    this.userCombo.Items.Add(user);
                }

                this.comboBox1.Items.Add("ALTA");
                this.comboBox1.Items.Add("MEDIA");
                this.comboBox1.Items.Add("BAJA");
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
                List<Bitacora> list = service.buscar(Bitacora.builder()
                    .Criticidad(this.comboBox1.SelectedItem != null ? this.comboBox1.SelectedItem.ToString() : null)
                    .Usuario((Usuario)this.userCombo.SelectedItem)
                    .Desde(this.dateTimePicker1.Value)
                    .Hasta(this.dateTimePicker2.Value).build());
                this.dataGridView1.Rows.Clear();
                foreach (Bitacora b in list)
                {
                    this.dataGridView1.Rows.Add(new object[] { b.Usuario.Username, b.Criticidad, b.Funcionalidad, b.Descripcion, b.Fecha });
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = DateTime.Now;
            this.dateTimePicker2.Value = DateTime.Now;
            this.comboBox1.SelectedItem = null;
            this.userCombo.SelectedItem = null;
            this.dataGridView1.Rows.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "bitacora_" + DateTime.Now.ToString("dd - MM - yyyy") + ".pdf";
            savefile.Filter = "PDF files (*.pdf)|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                PdfWriter writer = new PdfWriter(savefile.FileName);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf, PageSize.LETTER);
                document.SetMargins(60, 20, 55, 20);


                iText.Kernel.Font.PdfFont fontCol = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
                iText.Kernel.Font.PdfFont fontText = iText.Kernel.Font.PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);

                string[] columns = { i18n().GetString("log.list.user"), i18n().GetString("log.list.level"), i18n().GetString("log.list.functionality"), i18n().GetString("log.list.desc"), i18n().GetString("log.list.date") };

                float[] sizes = { 20, 20, 20, 20, 20 };
                Table table = new Table(UnitValue.CreatePercentArray(sizes));
                table.SetWidth(UnitValue.CreatePercentValue(100));

                foreach (string col in columns)
                    table.AddHeaderCell(new Cell().Add(new Paragraph(col)));

                List<Bitacora> list = service.buscar(Bitacora.builder()
                       .Criticidad(this.comboBox1.SelectedItem != null ? this.comboBox1.SelectedItem.ToString() : null)
                       .Usuario((Usuario)this.userCombo.SelectedItem)
                       .Desde(this.dateTimePicker1.Value)
                       .Hasta(this.dateTimePicker2.Value).build());
                foreach (Bitacora b in list)
                {
                    table.AddCell(new Cell().Add(new Paragraph(b.Usuario.Username).SetFont(fontText)));
                    table.AddCell(new Cell().Add(new Paragraph(b.Criticidad).SetFont(fontText)));
                    table.AddCell(new Cell().Add(new Paragraph(b.Funcionalidad).SetFont(fontText)));
                    table.AddCell(new Cell().Add(new Paragraph(b.Descripcion).SetFont(fontText)));
                    table.AddCell(new Cell().Add(new Paragraph(b.Fecha.ToString("dd-MM-yyyy HH:mm:ss")).SetFont(fontText)));
                }
                document.Add(table);
                document.Close();

                showInfo(i18n().GetString("exportado"));
            }
        }
    }
}
