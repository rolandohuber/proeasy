using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class HoraForm : I18nForm
    {
        ProyectoService proyectoService = ProyectoService.getInstance();
        TareaService tareaService = TareaService.getInstance();
        HoraService horaService = HoraService.getInstance();
        private Proyecto proyectoSelected;
        private Tarea tareaSelected;
        private Hora horaSelected;

        public HoraForm()
        {
            InitializeComponent();
            ReloadLang();
        }

        public override void ReloadLang()
        {
            this.label1.Text = i18n().GetString("hour.project");
            this.label2.Text = i18n().GetString("hour.task");
            this.Fecha.Text = i18n().GetString("hour.date");
            this.label3.Text = i18n().GetString("hour.amount");
            this.createButton.Text = i18n().GetString("hour.create");
            this.deleteButton.Text = i18n().GetString("hour.delete");
            this.saveButton.Text = i18n().GetString("hour.save");
            this.cancelButton.Text = i18n().GetString("hour.cancel");
            this.Proyecto.HeaderText = i18n().GetString("hour.list.project");
            this.Tarea.HeaderText = i18n().GetString("hour.list.task");
            this.Fech.HeaderText = i18n().GetString("hour.list.date");
            this.Horas.HeaderText = i18n().GetString("hour.list.amount");
        }

        private void HoraForm_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            foreach (Proyecto p in proyectoService.listar())
            {
                this.comboBox1.Items.Add(p);
            }
            if (proyectoSelected != null)
                this.comboBox1.SelectedItem = proyectoSelected;

            this.createButton.Visible = true;
            this.deleteButton.Visible = false;
            this.saveButton.Visible = false;
            this.cancelButton.Visible = true;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            this.proyectoSelected = (Proyecto)this.comboBox1.SelectedItem;
            foreach (Tarea t in tareaService.listarPorProyecto(proyectoSelected))
            {
                this.comboBox2.Items.Add(t);
            }

            if (this.tareaSelected != null)
                this.comboBox2.SelectedItem = this.tareaSelected;

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (!validarForm())
                return;

            Hora h = new Hora();
            h.Proyecto = this.proyectoSelected;
            h.Tarea = (Tarea)this.comboBox2.SelectedItem;
            h.Usuario = Session.getInstance().Usuario;
            h.Fecha = this.dateTimePicker1.Value;
            h.Cantidad = Convert.ToInt32(this.textBox1.Text);

            horaService.crear(h);
            cancelButton_Click(null, null);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!validarForm())
                return;

            this.horaSelected.Proyecto = this.proyectoSelected;
            this.horaSelected.Tarea = (Tarea)this.comboBox2.SelectedItem;
            this.horaSelected.Usuario = Session.getInstance().Usuario;
            this.horaSelected.Fecha = this.dateTimePicker1.Value;
            this.horaSelected.Cantidad = Convert.ToInt32(this.textBox1.Text);

            this.horaService.actualizar(horaSelected);
            cancelButton_Click(null, null);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            horaService.eliminar(this.horaSelected);
            cancelButton_Click(null, null);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = DateTime.Now;
            this.textBox1.Clear();

            HoraForm_Load(null, null);
            comboBox1_SelectedValueChanged(null, null);
            comboBox2_SelectedValueChanged(null, null);
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            this.tareaSelected = (Tarea)this.comboBox2.SelectedItem;
            this.listado.Rows.Clear();
            foreach (Hora h in horaService.listarPorTarea(this.tareaSelected))
            {
                this.listado.Rows.Add(new object[] { h.Id, h.Proyecto.Nombre, h.Tarea.Descripcion, h.Fecha, h.Cantidad });
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = this.listado.Rows[e.RowIndex];
            this.horaSelected = horaService.leer(Convert.ToInt32(row.Cells[0].Value));

            this.dateTimePicker1.Value = this.horaSelected.Fecha;
            this.textBox1.Text = this.horaSelected.Cantidad.ToString();

            this.createButton.Visible = false;
            this.deleteButton.Visible = true;
            this.saveButton.Visible = true;
            this.cancelButton.Visible = true;
        }

        private bool validarForm()
        {
            if (this.comboBox1.SelectedItem == null)
            {
                MessageBox.Show("El proyecto es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.comboBox2.SelectedItem == null)
            {
                MessageBox.Show("La tarea es requerida.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.dateTimePicker1.Value == null)
            {
                MessageBox.Show("La fecha es requerida.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.textBox1.Text == null || this.textBox1.Text.Length < 1)
            {
                MessageBox.Show("La cantidad de horas es requerida.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
