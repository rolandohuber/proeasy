using BE;
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
            try
            {
                this.label2.Text = i18n().GetString("backup.cant");
                this.button1.Text = i18n().GetString("backup.export");
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

        private void BackUpForm_Load(object sender, EventArgs e)
        {
            this.textBox2.Text = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValidForm())
                    return;
                string path = service.generarBackUp(Convert.ToInt32(this.textBox2.Text != null && this.textBox2.Text.Trim().Length > 0 ? this.textBox2.Text : "1"));
                Clipboard.SetText(path);
                showInfo(i18n().GetString("backup.created") + path);
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

        private bool isValidForm()
        {
            if (this.textBox2.Text == null || this.textBox2.Text.Trim().Length <= 0 || Convert.ToInt32(this.textBox2.Text) <= 0)
            {
                showError(i18n().GetString("backup.required.size"));
                return false;
            }
            return true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
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
    }
}
