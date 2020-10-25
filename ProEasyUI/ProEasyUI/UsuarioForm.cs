﻿using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class UsuarioForm : I18nForm
    {
        UsuarioService service = UsuarioService.getInstance();
        Usuario userSelected;
        public UsuarioForm()
        {
            InitializeComponent();
            ReloadLang();
        }

        public override void ReloadLang()
        {
            this.name.Text = i18n().GetString("user.name");
            this.lastname.Text = i18n().GetString("user.lastname");
            this.disp.Text = i18n().GetString("user.disp");
            this.val.Text = i18n().GetString("user.valor");
            this.username.Text = i18n().GetString("user.username");
            this.email.Text = i18n().GetString("user.email");
            this.enabled.Text = i18n().GetString("user.enabled");
            this.createButton.Text = i18n().GetString("user.create");
            this.deleteButton.Text = i18n().GetString("user.delete");
            this.saveButton.Text = i18n().GetString("user.save");
            this.button4.Text = i18n().GetString("user.cancel");
            this.unlockButton.Text = i18n().GetString("user.unlock");
            this.familiaButton.Text = i18n().GetString("user.families");
            this.patentesButton.Text = i18n().GetString("user.patentes");
            this.resetButton.Text = i18n().GetString("user.generate.pass");
            this.Nombre.HeaderText = i18n().GetString("user.list.name");
            this.Apellido.HeaderText = i18n().GetString("user.list.lastname");
            this.Usuario.HeaderText = i18n().GetString("user.list.username");
            this.Estado.HeaderText = i18n().GetString("user.list.state");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AsignarFamiliaUsuarioForm form = new AsignarFamiliaUsuarioForm(userSelected);
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AsignarPatenteUsuarioForm form = new AsignarPatenteUsuarioForm(userSelected);
            form.ShowDialog();
        }

        private void UsuarioForm_Resize(object sender, EventArgs e)
        {
            listado.Width = Convert.ToInt32(this.Width * 0.4);
            listado.Height = Convert.ToInt32(this.Height * 0.95);
        }

        private void UsuarioForm_Load(object sender, EventArgs e)
        {
            listado.Width = Convert.ToInt32(this.Width * 0.4);
            listado.Height = Convert.ToInt32(this.Height * 0.95);

            this.listado.Rows.Clear();

            List<Usuario> usuarios = service.listar();
            foreach (Usuario user in usuarios)
            {
                this.listado.Rows.Add(new object[] { user.Id, user.Nombre, user.Apellido, user.Username, user.Habilitado });
            }

            this.deleteButton.Visible = false;
            this.saveButton.Visible = false;
            this.familiaButton.Visible = false;
            this.patentesButton.Visible = false;
            this.resetButton.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarRequeridos())
                return;

            service.crear(BE.Usuario.builder()
                .Nombre(this.nombreField.Text)
                .Apellido(this.apellidoField.Text)
                .Username(this.usernameField.Text)
                .Email(this.emailField.Text)
                .Disponibilidad(Convert.ToInt32(this.disponibilidadField.Text))
                .ValorHora(Convert.ToString(this.valorHoraField.Text))
                .Habilitado(this.enabled.Checked)
                .build());
            button4_Click(null, null);
            UsuarioForm_Load(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            service.eliminar(userSelected);
            button4_Click(null, null);
            UsuarioForm_Load(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!validarRequeridos())
                return;

            this.userSelected.Nombre = this.nombreField.Text;
            this.userSelected.Apellido = this.apellidoField.Text;
            this.userSelected.Username = this.usernameField.Text;
            this.userSelected.Email = this.emailField.Text;
            this.userSelected.Disponibilidad = Convert.ToInt32(this.disponibilidadField.Text);
            this.userSelected.ValorHora = Convert.ToString(this.valorHoraField.Text);
            this.userSelected.Habilitado = this.enabled.Checked;
            service.actualizar(this.userSelected);
            button4_Click(null, null);
            UsuarioForm_Load(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.userSelected = null;
            this.nombreField.Clear();
            this.apellidoField.Clear();
            this.usernameField.Clear();
            this.emailField.Clear();
            this.disponibilidadField.Clear();
            this.valorHoraField.Clear();
            this.enabled.Checked = false;

            this.createButton.Visible = true;
            this.deleteButton.Visible = false;
            this.saveButton.Visible = false;
            this.familiaButton.Visible = false;
            this.patentesButton.Visible = false;
            this.resetButton.Visible = false;
        }

        private void listado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = this.listado.Rows[e.RowIndex];
            this.userSelected = service.leer(Convert.ToInt32(row.Cells[0].Value));

            this.nombreField.Text = this.userSelected.Nombre;
            this.apellidoField.Text = this.userSelected.Apellido;
            this.usernameField.Text = this.userSelected.Username;
            this.emailField.Text = this.userSelected.Email;
            this.disponibilidadField.Text = this.userSelected.Disponibilidad.ToString();
            this.valorHoraField.Text = this.userSelected.ValorHora;
            this.enabled.Checked = this.userSelected.Habilitado;

            this.createButton.Visible = false;
            this.deleteButton.Visible = true;
            this.saveButton.Visible = true;
            this.familiaButton.Visible = true;
            this.patentesButton.Visible = true;
            this.resetButton.Visible = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            service.resetPass(userSelected);
        }

        private bool validarRequeridos()
        {
            if (this.nombreField.Text == null || this.nombreField.Text.Length < 1)
            {
                MessageBox.Show("El nombre es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.apellidoField.Text == null || this.apellidoField.Text.Length < 1)
            {
                MessageBox.Show("El apellido es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.usernameField.Text == null || this.usernameField.Text.Length < 1)
            {
                MessageBox.Show("El nombre de usuario es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.emailField.Text == null || this.emailField.Text.Length < 1)
            {
                MessageBox.Show("El email es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.disponibilidadField.Text == null || this.disponibilidadField.Text.Length < 1)
            {
                MessageBox.Show("La disponibilidad mensual es requerida.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this.valorHoraField.Text == null || this.valorHoraField.Text.Length < 1)
            {
                MessageBox.Show("El valor hora es requerido.", "Complete todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.userSelected.Intentos = 0;
            this.service.actualizar(this.userSelected);
            showInfo("Se desbloqueo el usuario");
        }
    }
}
