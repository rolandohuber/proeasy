using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class FamiliaForm : I18nForm
    {
        FamiliaService familiaService = FamiliaService.getInstance();
        Familia familiaSelected;
        public FamiliaForm()
        {
            InitializeComponent();
            ReloadLang();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AgregarPatenteFamiliaForm form = new AgregarPatenteFamiliaForm(familiaSelected);
            form.ShowDialog();
        }

        public override void ReloadLang()
        {
            this.label1.Text = i18n().GetString("family.name");
            this.createButton.Text = i18n().GetString("family.create");
            this.deleteButton.Text = i18n().GetString("family.delete");
            this.saveButton.Text = i18n().GetString("family.save");
            this.cancelButton.Text = i18n().GetString("family.cancel");
            this.patentesButton.Text = i18n().GetString("family.patentes");
            this.Nombre.HeaderText = i18n().GetString("family.list.name");
        }

        private void FamiliaForm_Load(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.listado.Rows.Clear();
            List<BE.Familia> list = familiaService.listar();
            foreach (BE.Familia r in list)
            {
                this.listado.Rows.Add(new object[] { r.Id, r.Nombre });
            }

            this.createButton.Visible = true;
            this.deleteButton.Visible = false;
            this.saveButton.Visible = false;
            this.patentesButton.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarForm())
                return;

            familiaService.crear(new BE.Familia(0, this.textBox1.Text, null, false, "", null));

            FamiliaForm_Load(null, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = this.listado.Rows[e.RowIndex];
            this.familiaSelected = familiaService.leer(Convert.ToInt32(row.Cells[0].Value));

            this.textBox1.Text = familiaSelected.Nombre;

            this.createButton.Visible = false;
            this.deleteButton.Visible = true;
            this.saveButton.Visible = true;
            this.patentesButton.Visible = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            familiaService.eliminar(familiaSelected);
            FamiliaForm_Load(null, null);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!validarForm())
                return;

            familiaSelected.Nombre = this.textBox1.Text;
            familiaService.actualizar(this.familiaSelected);
            FamiliaForm_Load(null, null);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            FamiliaForm_Load(null, null);
        }

        private bool validarForm()
        {
            if (this.textBox1.Text == null || this.textBox1.Text.Length < 1)
            {
                MessageBox.Show("El nombre es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
