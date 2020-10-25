using BE;
using BLL;
using System;
using System.Collections.Generic;

namespace ProEasyUI
{
    public partial class AgregarPatenteFamiliaForm : I18nForm
    {
        private readonly Familia familiaSelected;
        readonly PatenteService patenteService = PatenteService.getInstance();
        public AgregarPatenteFamiliaForm(Familia familiaSelected)
        {
            InitializeComponent();
            ReloadLang();
            this.familiaSelected = familiaSelected;
        }

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("asig.pat.fam.disp");
                this.label2.Text = i18n().GetString("asig.pat.fam.asign");
            }
            catch (Exception ex)
            {
                showError("ALV el idioma");
            }
        }

        private void AgregarPatenteFamiliaForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Patente> disponibles = patenteService.obtenerPatentesDisponibles(this.familiaSelected);
                List<Patente> asignadas = patenteService.obtenerPatentesAsignadas(this.familiaSelected);
                this.disponibles.Items.Clear();
                this.asignadas.Items.Clear();

                foreach (Patente patente in disponibles)
                {
                    this.disponibles.Items.Add(patente);
                }

                foreach (Patente patente in asignadas)
                {
                    this.asignadas.Items.Add(patente);
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
                Patente patente = (Patente)this.disponibles.SelectedItem;
                if (patente == null)
                {
                    showWarning("Debe seleccionar una patente para asignar.");
                    return;
                }
                patenteService.asignarPatente(familiaSelected, patente);
                AgregarPatenteFamiliaForm_Load(null, null);
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
                Patente patente = (Patente)this.asignadas.SelectedItem;
                if (patente == null)
                {
                    showWarning("Debe seleccionar una patente para desasignar.");
                    return;
                }
                patenteService.quitarPatente(familiaSelected, patente);
                AgregarPatenteFamiliaForm_Load(null, null);
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
