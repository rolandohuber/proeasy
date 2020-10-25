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
            try
            {
                AgregarPatenteFamiliaForm form = new AgregarPatenteFamiliaForm(familiaSelected);
                form.ShowDialog();
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

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("family.name");
                this.createButton.Text = i18n().GetString("family.create");
                this.deleteButton.Text = i18n().GetString("family.delete");
                this.saveButton.Text = i18n().GetString("family.save");
                this.cancelButton.Text = i18n().GetString("family.cancel");
                this.patentesButton.Text = i18n().GetString("family.patentes");
                this.Nombre.HeaderText = i18n().GetString("family.list.name");
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

        private void FamiliaForm_Load(object sender, EventArgs e)
        {
            try
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
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
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
                if (!validarForm())
                    return;

                familiaService.crear(new BE.Familia(0, this.textBox1.Text, null, false, "", null));

                FamiliaForm_Load(null, null);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                familiaService.eliminar(familiaSelected);
                FamiliaForm_Load(null, null);
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

                familiaSelected.Nombre = this.textBox1.Text;
                familiaService.actualizar(this.familiaSelected);
                FamiliaForm_Load(null, null);
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
                FamiliaForm_Load(null, null);
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
            try
            {
                if (this.textBox1.Text == null || this.textBox1.Text.Length < 1)
                {
                    MessageBox.Show("El nombre es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (ProEasyException pEx)
            {
                showError(i18n().GetString("errors." + pEx.Code));
            }
            catch (Exception ex)
            {
                showError("General");
            }
            return false;
        }
    }
}
