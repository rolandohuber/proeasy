﻿using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class AgregarRecursosProyectoForm : I18nForm
    {
        Proyecto proyectoSelected;
        UsuarioService usuarioService = UsuarioService.getInstance();

        public AgregarRecursosProyectoForm(Proyecto proyectoSelected)
        {
            InitializeComponent();
            ReloadLang();
            this.proyectoSelected = proyectoSelected;
        }

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("asig.rec.proj.disp");
                this.label2.Text = i18n().GetString("asig.rec.proj.asign");
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

        private void AgregarRecursosProyectoForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> asignados = usuarioService.obtenerUsuariosAsignados(this.proyectoSelected);
                List<Usuario> disponibles = usuarioService.obtenerUsuariosDisponibles(this.proyectoSelected);

                this.disponiblesList.Items.Clear();
                this.asignadosList.Items.Clear();

                foreach (Usuario user in disponibles)
                {
                    this.disponiblesList.Items.Add(user);
                }

                foreach (Usuario user in asignados)
                {
                    this.asignadosList.Items.Add(user);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)this.disponiblesList.SelectedItem;
                if (usuario == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario para asignar.", "Seleccione un usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                usuarioService.asignarRecurso(this.proyectoSelected, usuario);
                AgregarRecursosProyectoForm_Load(null, null);
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
                Usuario usuario = (Usuario)this.asignadosList.SelectedItem;
                if (usuario == null)
                {
                    MessageBox.Show("Debe seleccionar un usuario para desasignar.", "Seleccione un usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                usuarioService.desasignarRecurso(this.proyectoSelected, usuario);
                AgregarRecursosProyectoForm_Load(null, null);
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
    }
}
