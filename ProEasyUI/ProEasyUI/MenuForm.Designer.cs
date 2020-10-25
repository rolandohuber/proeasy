using System.Reflection;
using System.Resources;

namespace ProEasyUI
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.reporteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proyectosItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tareasItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familiaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horasItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomasItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringConexionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteItem,
            this.usuariosItem,
            this.proyectosItem,
            this.tareasItem,
            this.familiaItem,
            this.horasItem,
            this.bitacoraItem,
            this.backupItem,
            this.restoreItem,
            this.idiomasItem,
            this.stringConexionItem,
            this.logOutItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // reporteItem
            // 
            this.reporteItem.Name = "reporteItem";
            this.reporteItem.Click += new System.EventHandler(this.reporteDeRentabilidadDeProyectosToolStripMenuItem_Click);
            // 
            // usuariosItem
            // 
            this.usuariosItem.Name = "usuariosItem";
            this.usuariosItem.Click += new System.EventHandler(this.administraciónDeUsuariosToolStripMenuItem_Click);
            // 
            // proyectosItem
            // 
            this.proyectosItem.Name = "proyectosItem";
            this.proyectosItem.Click += new System.EventHandler(this.administraciónDeProyectosToolStripMenuItem_Click);
            // 
            // tareasItem
            // 
            this.tareasItem.Name = "tareasItem";
            this.tareasItem.Click += new System.EventHandler(this.administraciónDeTareasToolStripMenuItem_Click);
            // 
            // familiaItem
            // 
            this.familiaItem.Name = "familiaItem";
            this.familiaItem.Click += new System.EventHandler(this.administraciónDeFamiliasToolStripMenuItem_Click);
            // 
            // horasItem
            // 
            this.horasItem.Name = "horasItem";
            this.horasItem.Click += new System.EventHandler(this.cargaDeHorasToolStripMenuItem_Click);
            // 
            // bitacoraItem
            // 
            this.bitacoraItem.Name = "bitacoraItem";
            this.bitacoraItem.Click += new System.EventHandler(this.consultarBitácoraToolStripMenuItem_Click);
            // 
            // backupItem
            // 
            this.backupItem.Name = "backupItem";
            this.backupItem.Click += new System.EventHandler(this.realizarBackupToolStripMenuItem_Click);
            // 
            // restoreItem
            // 
            this.restoreItem.Name = "restoreItem";
            this.restoreItem.Click += new System.EventHandler(this.realizarRestoreToolStripMenuItem_Click);
            // 
            // idiomasItem
            // 
            this.idiomasItem.Name = "idiomasItem";
            // 
            // stringConexionItem
            // 
            this.stringConexionItem.Name = "stringConexionItem";
            this.stringConexionItem.Click += new System.EventHandler(this.modificarStringDeConexiónToolStripMenuItem_Click);
            // 
            // logOutItem
            // 
            this.logOutItem.Name = "logOutItem";
            this.logOutItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.Load += new System.EventHandler(this.MenuForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosItem;
        private System.Windows.Forms.ToolStripMenuItem proyectosItem;
        private System.Windows.Forms.ToolStripMenuItem tareasItem;
        private System.Windows.Forms.ToolStripMenuItem familiaItem;
        private System.Windows.Forms.ToolStripMenuItem horasItem;
        private System.Windows.Forms.ToolStripMenuItem reporteItem;
        private System.Windows.Forms.ToolStripMenuItem stringConexionItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraItem;
        private System.Windows.Forms.ToolStripMenuItem backupItem;
        private System.Windows.Forms.ToolStripMenuItem restoreItem;
        private System.Windows.Forms.ToolStripMenuItem idiomasItem;
        private System.Windows.Forms.ToolStripMenuItem logOutItem;
    }
}