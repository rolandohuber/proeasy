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
                showError(pEx.Code.ToString());
            }
            catch (Exception ex)
            {
                showError("General");
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
                string path = service.generarBackUp(Convert.ToInt32(this.textBox2.Text != null && this.textBox2.Text.Trim().Length > 0 ? this.textBox2.Text : "1"));
                Clipboard.SetText(path);
                showInfo("Tu bkp esta aca y lo copiamos al clipboard: " + path);
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
                showError(pEx.Code.ToString());
            }
            catch (Exception ex)
            {
                showError("General");
            }
        }
    }
}
