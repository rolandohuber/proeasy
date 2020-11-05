using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace ProEasyUI
{
    public class I18nForm : Form
    {
        public virtual void ReloadLang() { }

        protected ResourceManager i18n()
        {
            return new I18n("ProEasyUI.i18n." + System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName + "_lang");
        }

        protected int getUnit()
        {
            return this.Width / 12;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // I18nForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "I18nForm";
            this.Load += new EventHandler(this.I18nForm_Load);
            this.ResumeLayout(false);

        }

        private void I18nForm_Load(object sender, EventArgs e)
        {

        }

        protected void showError(string content)
        {
            showMessage(content, MessageBoxIcon.Error);
        }

        protected void showInfo(string content)
        {
            showMessage(content, MessageBoxIcon.Information);
        }

        protected void showWarning(string content)
        {
            showMessage(content, MessageBoxIcon.Warning);
        }

        private void showMessage(string content, MessageBoxIcon icon)
        {
            MessageBox.Show(content, i18n().GetString("project.name"),
                MessageBoxButtons.OK,
                icon,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly,
                false);
        }
    }
}
