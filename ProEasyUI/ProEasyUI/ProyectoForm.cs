using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class ProyectoForm : I18nForm
    {
        readonly ProyectoService proyectoService = ProyectoService.getInstance();
        Proyecto proyectoSelected;

        public ProyectoForm()
        {
            InitializeComponent();
            ReloadLang();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarRecursosProyectoForm form = new AgregarRecursosProyectoForm(this.proyectoSelected);
                form.ShowDialog();
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

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("project.list.title");
                this.label2.Text = i18n().GetString("project.estimated");
                this.label3.Text = i18n().GetString("project.insumidas");
                this.label4.Text = i18n().GetString("project.valor");
                this.habilitadoField.Text = i18n().GetString("project.enabled");
                this.createButton.Text = i18n().GetString("project.create");
                this.deleteButton.Text = i18n().GetString("project.delete");
                this.saveButton.Text = i18n().GetString("project.save");
                this.cancelButton.Text = i18n().GetString("project.cancel");
                this.resourcesButton.Text = i18n().GetString("project.resources");
                this.NombreProyecto.HeaderText = i18n().GetString("project.list.title");
                this.Habilitado.HeaderText = i18n().GetString("project.list.enabled");
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

        private void ProyectoForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.listado.Rows.Clear();
                List<Proyecto> proyectos = proyectoService.listar();
                foreach (Proyecto proyecto in proyectos)
                {
                    this.listado.Rows.Add(new object[] { proyecto.Id, proyecto.Nombre, proyecto.Habilitado });
                }
                this.createButton.Visible = true;
                this.deleteButton.Visible = false;
                this.saveButton.Visible = false;
                this.cancelButton.Visible = true;
                this.resourcesButton.Visible = false;
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
                if (!validarForm())
                    return;

                Proyecto proyecto = Proyecto.builder().build();
                proyecto.Nombre = this.nombreField.Text;
                proyecto.HorasEstimadas = this.horasEstimadasField.Text;
                proyecto.ValorHora = this.valorHoraField.Text;
                proyecto.Habilitado = this.habilitadoField.Checked;
                proyecto.Fecha = DateTime.Now;
                this.proyectoService.crear(proyecto);

                cancelButton_Click(null, null);
                ProyectoForm_Load(null, null);
                showInfo(i18n().GetString("project.created"));
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.proyectoService.eliminar(this.proyectoSelected);
                cancelButton_Click(null, null);
                ProyectoForm_Load(null, null);
                showInfo(i18n().GetString("project.deleted"));
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarForm())
                    return;

                this.proyectoSelected.Nombre = this.nombreField.Text;
                this.proyectoSelected.HorasEstimadas = this.horasEstimadasField.Text;
                this.proyectoSelected.ValorHora = this.valorHoraField.Text;
                this.proyectoSelected.Habilitado = this.habilitadoField.Checked;
                this.proyectoService.actualizar(proyectoSelected);
                cancelButton_Click(null, null);
                ProyectoForm_Load(null, null);
                showInfo(i18n().GetString("project.updated"));
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.nombreField.Clear();
            this.horasEstimadasField.Clear();
            this.valorHoraField.Clear();
            this.habilitadoField.Checked = false;
            this.horasInsumidasField.Clear();

            this.createButton.Visible = true;
            this.deleteButton.Visible = false;
            this.saveButton.Visible = false;
            this.cancelButton.Visible = true;
            this.resourcesButton.Visible = false;
        }

        private void listado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                DataGridViewRow row = this.listado.Rows[e.RowIndex];
                this.proyectoSelected = this.proyectoService.leer(Convert.ToInt32(row.Cells[0].Value));

                this.nombreField.Text = this.proyectoSelected.Nombre;
                this.horasEstimadasField.Text = this.proyectoSelected.HorasEstimadas;
                this.valorHoraField.Text = this.proyectoSelected.ValorHora;
                this.habilitadoField.Checked = this.proyectoSelected.Habilitado;
                this.horasInsumidasField.Text = this.proyectoSelected.Horas != null ? this.proyectoSelected.Horas.Sum(hora => hora.Cantidad).ToString() : "0";


                this.createButton.Visible = false;
                this.deleteButton.Visible = true;
                this.saveButton.Visible = true;
                this.cancelButton.Visible = true;
                this.resourcesButton.Visible = true;
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

        private bool validarForm()
        {
            if (this.nombreField.Text == null || this.nombreField.Text.Length < 1)
            {
                showWarning(i18n().GetString("project.required.name"));
                return false;
            }
            if (this.horasEstimadasField.Text == null || this.horasEstimadasField.Text.Length < 1)
            {
                showWarning(i18n().GetString("project.required.horas"));
                return false;
            }
            if (this.valorHoraField.Text == null || this.valorHoraField.Text.Length < 1)
            {
                showWarning(i18n().GetString("project.required.salary"));
                return false;
            }
            return true;
        }
    }
}
