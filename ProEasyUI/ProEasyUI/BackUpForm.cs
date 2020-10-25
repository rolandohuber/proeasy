using BLL;
using System;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class BackUpForm : I18nForm
    {

        DbBackUpService service = DbBackUpService.getInstance();

        public BackUpForm()
        {
            InitializeComponent();
            ReloadLang();
        }

        public override void ReloadLang()
        {
            this.label2.Text = i18n().GetString("backup.cant");
            this.button1.Text = i18n().GetString("backup.export");
        }

        private void BackUpForm_Load(object sender, EventArgs e)
        {
            this.textBox2.Text = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = service.generarBackUp(Convert.ToInt32(this.textBox2.Text != null && this.textBox2.Text.Trim().Length > 0 ? this.textBox2.Text : "1"));
            Clipboard.SetText(path);
            MessageBox.Show("Tu bkp esta aca y lo copiamos al clipboard: " + path);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
