using BE;
using BLL;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class MenuForm : I18nForm
    {
        private IdiomaService idiomaService = IdiomaService.getInstance();
        private I18nForm form;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Idioma idioma in idiomaService.listar())
                {
                    var item = new System.Windows.Forms.ToolStripMenuItem();
                    item.Name = idioma.Code;
                    item.Size = new System.Drawing.Size(210, 30);
                    item.Text = idioma.Nombre;
                    item.Click += new System.EventHandler(this.changeLanguage);
                    //item.Checked = idioma.Id == gestorSistema.ObtenerUsuarioEnSesion().idioma.identificador;
                    idiomasItem.DropDownItems.Add(item);
                }

                string languagePrefix = Session.getInstance().Usuario.Idioma.Code;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(languagePrefix);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languagePrefix);
                ReloadLang();
                ApplyPermissions();
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

        private void changeToMDI(Form form)
        {
            form.MdiParent = this;
            form.ControlBox = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ShowIcon = false;
            form.Text = "";
            form.Dock = DockStyle.Fill;
        }

        private void reporteDeRentabilidadDeProyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form = new ReporteRentabilidadForm();
                changeToMDI(form);
                form.Show();
                this.Text = i18n().GetString("project.name") + " - " + (sender as ToolStripMenuItem).Text;
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

        private void administraciónDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form = new UsuarioForm();
                changeToMDI(form);
                form.Show();
                this.Text = i18n().GetString("project.name") + " - " + (sender as ToolStripMenuItem).Text;
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

        private void administraciónDeProyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form = new ProyectoForm();
                changeToMDI(form);
                form.Show();
                this.Text = i18n().GetString("project.name") + " - " + (sender as ToolStripMenuItem).Text;
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

        private void administraciónDeTareasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form = new TareaForm();
                changeToMDI(form);
                form.Show();
                this.Text = i18n().GetString("project.name") + " - " + (sender as ToolStripMenuItem).Text;
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

        private void administraciónDeFamiliasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form = new FamiliaForm();
                changeToMDI(form);
                form.Show();
                this.Text = i18n().GetString("project.name") + " - " + (sender as ToolStripMenuItem).Text;
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

        private void cargaDeHorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form = new HoraForm();
                changeToMDI(form);
                form.Show();
                this.Text = i18n().GetString("project.name") + " - " + (sender as ToolStripMenuItem).Text;
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

        private void consultarBitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form = new BitacoraForm();
                changeToMDI(form);
                form.Show();
                this.Text = i18n().GetString("project.name") + " - " + (sender as ToolStripMenuItem).Text;
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

        private void realizarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form = new BackUpForm();
                changeToMDI(form);
                form.Show();
                this.Text = i18n().GetString("project.name") + " - " + (sender as ToolStripMenuItem).Text;
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

        private void realizarRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form = new RestoreForm();
                changeToMDI(form);
                form.Show();
                this.Text = i18n().GetString("project.name") + " - " + (sender as ToolStripMenuItem).Text;
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

        private void modificarStringDeConexiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form = new StringConexionForm();
                changeToMDI(form);
                form.Show();
                this.Text = i18n().GetString("project.name") + " - " + (sender as ToolStripMenuItem).Text;
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

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            try
            {
                var languagePrefix = (sender as ToolStripMenuItem).Name;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(languagePrefix);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languagePrefix);
                this.ReloadLang();
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
                this.Text = i18n().GetString("project.name");
                this.reporteItem.Text = i18n().GetString("menu.report");
                this.usuariosItem.Text = i18n().GetString("menu.users");
                this.proyectosItem.Text = i18n().GetString("menu.projects");
                this.tareasItem.Text = i18n().GetString("menu.tasks");
                this.familiaItem.Text = i18n().GetString("menu.families");
                this.horasItem.Text = i18n().GetString("menu.hours");
                this.bitacoraItem.Text = i18n().GetString("menu.logs");
                this.backupItem.Text = i18n().GetString("menu.backup");
                this.restoreItem.Text = i18n().GetString("menu.restore");
                this.idiomasItem.Text = i18n().GetString("menu.language");
                this.stringConexionItem.Text = i18n().GetString("menu.connection.string");
                this.logOutItem.Text = i18n().GetString("menu.logout");

                if (this.form != null)
                    this.form.ReloadLang();
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


        public void ApplyPermissions()
        {
            try
            {
                this.reporteItem.Visible = Session.getInstance().Usuario.Patentes.Find((item) => item.Nombre.Equals("RENTABILIDAD")) != null;
                this.usuariosItem.Visible = Session.getInstance().Usuario.Patentes.Find((item) => item.Nombre.Equals("USUARIOS")) != null;
                this.proyectosItem.Visible = Session.getInstance().Usuario.Patentes.Find((item) => item.Nombre.Equals("PROYECTOS")) != null;
                this.tareasItem.Visible = Session.getInstance().Usuario.Patentes.Find((item) => item.Nombre.Equals("TAREAS")) != null;
                this.familiaItem.Visible = Session.getInstance().Usuario.Patentes.Find((item) => item.Nombre.Equals("FAMILIAS")) != null;
                this.horasItem.Visible = Session.getInstance().Usuario.Patentes.Find((item) => item.Nombre.Equals("HORAS")) != null;
                this.bitacoraItem.Visible = Session.getInstance().Usuario.Patentes.Find((item) => item.Nombre.Equals("BITACORA")) != null;
                this.backupItem.Visible = Session.getInstance().Usuario.Patentes.Find((item) => item.Nombre.Equals("BACKUP")) != null;
                this.restoreItem.Visible = Session.getInstance().Usuario.Patentes.Find((item) => item.Nombre.Equals("RESTORE")) != null;
                this.stringConexionItem.Visible = Session.getInstance().Usuario.Patentes.Find((item) => item.Nombre.Equals("CONNECTION_STRING")) != null;
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
