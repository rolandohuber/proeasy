using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class AsignarFamiliaUsuarioForm : I18nForm
    {
        BE.Usuario userSelected;
        FamiliaService familiaService = FamiliaService.getInstance();
        public AsignarFamiliaUsuarioForm(BE.Usuario userSelected)
        {
            InitializeComponent();
            ReloadLang();
            this.userSelected = userSelected;
        }

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("asig.family.disp");
                this.label2.Text = i18n().GetString("asig.family.asign");
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

        private void AsignarFamiliaUsuarioForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Familia> disponibles = familiaService.obtenerFamiliasDisponibles(this.userSelected);
                List<Familia> asignadas = familiaService.obtenerFamiliasAsignadas(this.userSelected);
                this.disponibles.Items.Clear();
                this.asignadas.Items.Clear();

                foreach (Familia familia in disponibles)
                {
                    this.disponibles.Items.Add(familia);
                }

                foreach (Familia familia in asignadas)
                {
                    this.asignadas.Items.Add(familia);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Familia familia = (Familia)this.disponibles.SelectedItem;

                if (familia == null)
                {
                    MessageBox.Show("Debe seleccionar una familia para asignar.", "Seleccione una familia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                familiaService.asignarFamilia(userSelected, familia);
                AsignarFamiliaUsuarioForm_Load(null, null);
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
                Familia familia = (Familia)this.asignadas.SelectedItem;

                if (familia == null)
                {
                    MessageBox.Show("Debe seleccionar una familia para desasignar.", "Seleccione una familia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                familiaService.quitarFamilia(userSelected, familia);
                AsignarFamiliaUsuarioForm_Load(null, null);
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
