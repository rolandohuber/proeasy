using BE;
using BLL;
using System;
using System.Collections.Generic;

namespace ProEasyUI
{
    public partial class BitacoraForm : I18nForm
    {
        UsuarioService usuarioService = UsuarioService.getInstance();
        BitacoraService service = BitacoraService.getInstance();

        public BitacoraForm()
        {
            InitializeComponent();
            ReloadLang();
        }
        public override void ReloadLang()
        {
            try
            {
                this.label1.Text = i18n().GetString("log.since");
                this.label2.Text = i18n().GetString("log.until");
                this.label3.Text = i18n().GetString("log.level");
                this.label4.Text = i18n().GetString("log.user");
                this.button1.Text = i18n().GetString("log.search");
                this.button2.Text = i18n().GetString("log.clean");
                this.Usuario.HeaderText = i18n().GetString("log.list.user");
                this.Criticidad.HeaderText = i18n().GetString("log.list.level");
                this.Funcionalidad.HeaderText = i18n().GetString("log.list.functionality");
                this.Descripcion.HeaderText = i18n().GetString("log.list.desc");
                this.Fecha.HeaderText = i18n().GetString("log.list.date");
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

        private void BitacoraForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Usuario> usuarios = usuarioService.listar();
                this.userCombo.Items.Clear();
                foreach (Usuario user in usuarios)
                {
                    this.userCombo.Items.Add(user);
                }

                this.comboBox1.Items.Add("ALTA");
                this.comboBox1.Items.Add("MEDIA");
                this.comboBox1.Items.Add("BAJA");
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
                List<Bitacora> list = service.buscar(Bitacora.builder()
                    .Criticidad(this.comboBox1.SelectedItem != null ? this.comboBox1.SelectedItem.ToString() : null)
                    .Usuario((Usuario)this.userCombo.SelectedItem)
                    .Desde(this.dateTimePicker1.Value)
                    .Hasta(this.dateTimePicker2.Value).build());
                this.dataGridView1.Rows.Clear();
                foreach (Bitacora b in list)
                {
                    this.dataGridView1.Rows.Add(new object[] { b.Usuario.Username, b.Criticidad, b.Funcionalidad, b.Descripcion, b.Fecha });
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = DateTime.Now;
            this.dateTimePicker2.Value = DateTime.Now;
            this.comboBox1.SelectedItem = null;
            this.userCombo.SelectedItem = null;
            this.dataGridView1.Rows.Clear();
        }
    }
}
