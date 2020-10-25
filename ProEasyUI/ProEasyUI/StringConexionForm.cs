using Nini.Config;
using System;
using System.IO;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class StringConexionForm : I18nForm
    {
        public Login parent { get; set; }

        public StringConexionForm()
        {
            InitializeComponent();
            ReloadLang();
        }
        public override void ReloadLang()
        {
            this.label1.Text = i18n().GetString("connection.server");
            this.label2.Text = i18n().GetString("connection.db");
            this.label3.Text = i18n().GetString("connection.user");
            this.label4.Text = i18n().GetString("connection.pass");
            this.button1.Text = i18n().GetString("connection.save");
        }

        private void StringConexionForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=" + this.serverField.Text + ";Initial Catalog=" + this.baseDeDatosField.Text + ";User ID=" + this.userField.Text + ";Password=" + this.passField.Text;

            string configFileName = AppDomain.CurrentDomain.BaseDirectory + "config.ini";

            if (!File.Exists(configFileName))
                File.Create(configFileName).Close();

            IniConfigSource configSource = new IniConfigSource(configFileName);

            IConfig demoConfigSection = configSource.Configs["Proeasy"];
            if (demoConfigSection == null)
            {
                configSource.AddConfig("Proeasy");
                configSource.Save();
                demoConfigSection = configSource.Configs["Proeasy"];
            }
            demoConfigSection.Set("connectionString", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(connectionString)));
            configSource.Save();
            if (this.parent != null)
            {
                this.parent.loadLang();
                this.parent.Show();
            }
            if (this.parent != null)
            {
                this.Close();
            }
            else
            {
                showInfo("Debera volver a abrir la aplicacion para tomar la nueva configuracion");
                Application.Exit();
            }

        }

    }
}
