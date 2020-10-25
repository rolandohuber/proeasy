
using BLL;
using System.Windows.Forms;

namespace ProEasyUI
{
    public partial class RestoreForm : I18nForm
    {
        DbBackUpService service = DbBackUpService.getInstance();
        private string path;

        public RestoreForm()
        {
            InitializeComponent();
            ReloadLang();
        }

        public override void ReloadLang()
        {
            this.label1.Text = i18n().GetString("restore.path");
            this.button1.Text = i18n().GetString("restore.import");
        }

        private void RestoreForm_Load(object sender, System.EventArgs e)
        {

        }

        private void button2_Click(object sender, System.EventArgs e)
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            service.restaurar(this.path);
        }
    }
}
