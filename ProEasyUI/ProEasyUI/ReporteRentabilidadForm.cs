using BE;
using BLL;
using System;
using System.Collections.Generic;

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
            }
            catch (ProEasyException pEx)
            {
                showError(pEx.Code.ToString());
            }
            catch (Exception ex)
            {
                showError("General");
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
                showError(pEx.Code.ToString());
            }
            catch (Exception ex)
            {
                showError("General");
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
                showError(pEx.Code.ToString());
            }
            catch (Exception ex)
            {
                showError("General");
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
                showError(pEx.Code.ToString());
            }
            catch (Exception ex)
            {
                showError("General");
            }
        }
    }
}
