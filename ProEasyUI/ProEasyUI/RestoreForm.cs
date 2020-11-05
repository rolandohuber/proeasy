
using BE;
using BLL;
using System;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class RestoreForm : I18nForm
    {
        private string path;

        public RestoreForm()
        {
            InitializeComponent();
            ReloadLang();
        }

        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("restore.path");
                this.button1.Text = i18n().GetString("restore.import");
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

        private void RestoreForm_Load(object sender, System.EventArgs e)
        {

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            try
            {
                OpenFileDialog choofdlog = new OpenFileDialog();
                choofdlog.Filter = "ZIP files (.zip)|*.zip";
                choofdlog.FilterIndex = 1;
                choofdlog.Multiselect = false;

                if (choofdlog.ShowDialog() == DialogResult.OK)
                {
                    this.path = choofdlog.FileName;
                    this.label1.Text += ": " + choofdlog.FileName;
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                DbBackUpService.getInstance().restaurar(this.path);
                showInfo(i18n().GetString("restore.sucess"));
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
