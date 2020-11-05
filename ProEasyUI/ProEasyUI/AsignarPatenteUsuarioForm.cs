using BE;
using BLL;
using System;
using System.Collections.Generic;

namespace ProEasyUI
{
    public partial class AsignarPatenteUsuarioForm : I18nForm
    {
        Usuario userSelected;
        PatenteService patenteService = PatenteService.getInstance();

        public AsignarPatenteUsuarioForm(Usuario userSelected)
        {
            InitializeComponent();
            ReloadLang();
            this.userSelected = userSelected;
        }

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("asig.patente.disp");
                this.label2.Text = i18n().GetString("asig.patente.asign");
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

        private void AsignarPatenteUsuarioForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Patente> disponibles = patenteService.obtenerPatentesDisponibles(this.userSelected);
                List<Patente> asignadas = patenteService.obtenerPatentesAsignadas(this.userSelected);
                this.toAssign.Items.Clear();
                this.toRemove.Items.Clear();

                foreach (Patente patente in disponibles)
                {
                    this.toAssign.Items.Add(patente);
                }

                foreach (Patente patente in asignadas)
                {
                    this.toRemove.Items.Add(patente);
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
            try
            {
                Patente patente = (Patente)this.toAssign.SelectedItem;

                if (patente == null)
                {
                    showError(i18n().GetString("asignacion.patente.uduario.asign.required"));
                    return;
                }

                patenteService.asignarPatente(userSelected, patente);
                AsignarPatenteUsuarioForm_Load(null, null);
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
                Patente patente = (Patente)this.toRemove.SelectedItem;

                if (patente == null)
                {
                    showError(i18n().GetString("asignacion.patente.uduario.remove.required"));
                    return;
                }

                patenteService.quitarPatente(userSelected, patente);
                AsignarPatenteUsuarioForm_Load(null, null);
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
    }
}
