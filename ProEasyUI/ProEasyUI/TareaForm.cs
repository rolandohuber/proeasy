using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class TareaForm : I18nForm
    {
        readonly ProyectoService proyectoService = ProyectoService.getInstance();
        readonly TareaService tareaService = TareaService.getInstance();
        private Proyecto proyectoSelected;
        private Tarea tareaSelected;
        public TareaForm()
        {
            InitializeComponent();
            ReloadLang();
        }

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("task.project");
                this.label2.Text = i18n().GetString("task.title");
                this.label3.Text = i18n().GetString("task.description");
                this.createButton.Text = i18n().GetString("task.create");
                this.deleteButton.Text = i18n().GetString("task.delete");
                this.saveButton.Text = i18n().GetString("task.save");
                this.cancelButton.Text = i18n().GetString("task.cancel");
                this.Proyecto.HeaderText = i18n().GetString("task.list.project");
                this.Titulo.HeaderText = i18n().GetString("task.list.title");
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception ex)
            {
                showError("General");
            }
        }

        private void TareaForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.proyectosCombo.Items.Clear();
                foreach (Proyecto p in proyectoService.listar())
                {
                    this.proyectosCombo.Items.Add(p);
                }

                if (proyectoSelected != null)
                    this.proyectosCombo.SelectedItem = proyectoSelected;

                this.createButton.Visible = true;
                this.deleteButton.Visible = false;
                this.saveButton.Visible = false;
                this.createButton.Visible = true;
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception ex)
            {
                showError("General");
            }
        }

        private void proyectosCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.proyectoSelected = (Proyecto)this.proyectosCombo.SelectedItem;
                this.listado.Rows.Clear();
                this.tituloField.Clear();
                this.descripcionField.Clear();
                List<Tarea> tareas = tareaService.listarPorProyecto(proyectoSelected);
                foreach (Tarea tarea in tareas)
                {
                    this.listado.Rows.Add(new object[] { tarea.Id, tarea.Proyecto.Nombre, tarea.Titulo });
                }
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception ex)
            {
                showError("General");
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarForm())
                    return;

                Tarea t = Tarea.builder().build();
                t.Proyecto = proyectoSelected;
                t.Titulo = this.tituloField.Text;
                t.Descripcion = this.descripcionField.Text;
                tareaService.crear(t);

                cancelButton_Click(null, null);
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception ex)
            {
                showError("General");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                tareaService.eliminar(tareaSelected);

                cancelButton_Click(null, null);
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception ex)
            {
                showError("General");
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarForm())
                    return;

                tareaSelected.Titulo = this.tituloField.Text;
                tareaSelected.Descripcion = this.descripcionField.Text;
                tareaService.actualizar(tareaSelected);

                cancelButton_Click(null, null);
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception ex)
            {
                showError("General");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tituloField.Clear();
                this.descripcionField.Clear();

                TareaForm_Load(null, null);
                proyectosCombo_SelectedValueChanged(null, null);
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception ex)
            {
                showError("General");
            }
        }

        private void listado_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                DataGridViewRow row = this.listado.Rows[e.RowIndex];
                this.tareaSelected = tareaService.leer(Convert.ToInt32(row.Cells[0].Value));
                this.tareaSelected.Proyecto = proyectoSelected;

                this.tituloField.Text = tareaSelected.Titulo;
                this.descripcionField.Text = tareaSelected.Descripcion;

                this.createButton.Visible = false;
                this.deleteButton.Visible = true;
                this.saveButton.Visible = true;
                this.createButton.Visible = true;
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception ex)
            {
                showError("General");
            }
        }

        private bool validarForm()
        {
            if (this.proyectosCombo.SelectedItem == null)
            {
                MessageBox.Show("El proyecto es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.tituloField.Text == null || this.tituloField.Text.Length < 1)
            {
                MessageBox.Show("El titulo es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.descripcionField.Text == null || this.descripcionField.Text.Length < 1)
            {
                MessageBox.Show("El campo descripcion es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
