using BE;
using BLL;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class Login : I18nForm
    {

        public Login()
        {
            InitializeComponent();
            ReloadLang();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StringConexionForm conexionForm = new StringConexionForm();
                conexionForm.parent = this;

                conexionForm.Show();
                this.Hide();
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
                Session.getInstance().Usuario = UsuarioService.getInstance().login(this.textBox1.Text, this.textBox2.Text);
                if (Session.getInstance().Usuario != null)
                {
                    MenuForm menuForm = new MenuForm();
                    menuForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login incorrecto, chequee los datos.");
                }
            }
            catch (ProEasyException pEx)
            {
                showError(pEx.Code.ToString());
            }
            catch (Exception ex)
            {
                showError("Login incorrecto, chequee los datos.");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            loadLang();
        }

        public void loadLang()
        {
            try
            {
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "config.ini"))
                {
                    try
                    {
                        this.idiomaToolStripMenuItem.DropDownItems.Clear();
                        foreach (Idioma idioma in IdiomaService.getInstance().listar())
                        {
                            var item = new System.Windows.Forms.ToolStripMenuItem();
                            item.Name = idioma.Code;
                            item.Size = new System.Drawing.Size(210, 30);
                            item.Text = idioma.Nombre;
                            item.Click += new System.EventHandler(this.changeLanguage);
                            item.Checked = idioma.Code == "es";
                            this.idiomaToolStripMenuItem.DropDownItems.Add(item);
                        }
                    }
                    catch (ProEasyException ex)
                    {
                        showError("No tiene configurada una base de datos");
                    }
                }
                else
                {
                    showError("No tiene configurada una base de datos");
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

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("login.user");
                this.label2.Text = i18n().GetString("login.pass");
                this.button1.Text = i18n().GetString("login.login");
                this.button2.Text = i18n().GetString("login.connection.string");
                this.idiomaToolStripMenuItem.Text = i18n().GetString("login.language");
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

        private void changeLanguage(object sender, EventArgs e)
        {
            try
            {
                var item = (sender as ToolStripMenuItem);
                item.Checked = true;
                var languagePrefix = item.Name;
                Thread.CurrentThread.CurrentCulture = new CultureInfo(languagePrefix);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languagePrefix);
                this.ReloadLang();
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

        private void Login_Resize(object sender, EventArgs e)
        {
            try
            {
                this.label1.Location = new Point((int)(getUnit() / 1.5), this.label1.Location.Y);
                this.label2.Location = new Point((int)(getUnit() / 1.5), this.label2.Location.Y);

                this.textBox1.Width = Convert.ToInt32(10.4 * getUnit());
                this.textBox1.Location = new Point((int)(getUnit() / 1.5), this.textBox1.Location.Y);

                this.textBox2.Width = Convert.ToInt32(10.4 * getUnit());
                this.textBox2.Location = new Point((int)(getUnit() / 1.5), this.textBox2.Location.Y);

                this.button1.Location = new Point((int)((this.Width - this.button1.Width) / 2), this.button1.Location.Y);
                this.button2.Location = new Point((int)((this.Width - this.button2.Width) / 2), this.button2.Location.Y);
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
