namespace ProEasyUI
{
    partial class UsuarioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuarioForm));
            this.name = new System.Windows.Forms.Label();
            this.nombreField = new System.Windows.Forms.TextBox();
            this.lastname = new System.Windows.Forms.Label();
            this.apellidoField = new System.Windows.Forms.TextBox();
            this.disp = new System.Windows.Forms.Label();
            this.disponibilidadField = new System.Windows.Forms.TextBox();
            this.val = new System.Windows.Forms.Label();
            this.valorHoraField = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.Label();
            this.usernameField = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.Label();
            this.emailField = new System.Windows.Forms.TextBox();
            this.enabled = new System.Windows.Forms.CheckBox();
            this.createButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.familiaButton = new System.Windows.Forms.Button();
            this.patentesButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.listado = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unlockButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            // 
            // nombreField
            // 
            resources.ApplyResources(this.nombreField, "nombreField");
            this.nombreField.Name = "nombreField";
            // 
            // lastname
            // 
            resources.ApplyResources(this.lastname, "lastname");
            this.lastname.Name = "lastname";
            // 
            // apellidoField
            // 
            resources.ApplyResources(this.apellidoField, "apellidoField");
            this.apellidoField.Name = "apellidoField";
            // 
            // disp
            // 
            resources.ApplyResources(this.disp, "disp");
            this.disp.Name = "disp";
            // 
            // disponibilidadField
            // 
            resources.ApplyResources(this.disponibilidadField, "disponibilidadField");
            this.disponibilidadField.Name = "disponibilidadField";
            // 
            // val
            // 
            resources.ApplyResources(this.val, "val");
            this.val.Name = "val";
            // 
            // valorHoraField
            // 
            resources.ApplyResources(this.valorHoraField, "valorHoraField");
            this.valorHoraField.Name = "valorHoraField";
            // 
            // username
            // 
            resources.ApplyResources(this.username, "username");
            this.username.Name = "username";
            // 
            // usernameField
            // 
            resources.ApplyResources(this.usernameField, "usernameField");
            this.usernameField.Name = "usernameField";
            // 
            // email
            // 
            resources.ApplyResources(this.email, "email");
            this.email.Name = "email";
            // 
            // emailField
            // 
            resources.ApplyResources(this.emailField, "emailField");
            this.emailField.Name = "emailField";
            // 
            // enabled
            // 
            resources.ApplyResources(this.enabled, "enabled");
            this.enabled.Name = "enabled";
            this.enabled.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            resources.ApplyResources(this.createButton, "createButton");
            this.createButton.Name = "createButton";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteButton
            // 
            resources.ApplyResources(this.deleteButton, "deleteButton");
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // familiaButton
            // 
            resources.ApplyResources(this.familiaButton, "familiaButton");
            this.familiaButton.Name = "familiaButton";
            this.familiaButton.UseVisualStyleBackColor = true;
            this.familiaButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // patentesButton
            // 
            resources.ApplyResources(this.patentesButton, "patentesButton");
            this.patentesButton.Name = "patentesButton";
            this.patentesButton.UseVisualStyleBackColor = true;
            this.patentesButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // resetButton
            // 
            resources.ApplyResources(this.resetButton, "resetButton");
            this.resetButton.Name = "resetButton";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.button7_Click);
            // 
            // listado
            // 
            resources.ApplyResources(this.listado, "listado");
            this.listado.AllowUserToAddRows = false;
            this.listado.AllowUserToDeleteRows = false;
            this.listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.Apellido,
            this.Usuario,
            this.Estado});
            this.listado.Name = "listado";
            this.listado.ReadOnly = true;
            this.listado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_CellClick);
            // 
            // ID
            // 
            resources.ApplyResources(this.ID, "ID");
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Nombre, "Nombre");
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Apellido, "Apellido");
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Usuario, "Usuario");
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            resources.ApplyResources(this.Estado, "Estado");
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // unlockButton
            // 
            resources.ApplyResources(this.unlockButton, "unlockButton");
            this.unlockButton.Name = "unlockButton";
            this.unlockButton.UseVisualStyleBackColor = true;
            this.unlockButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // UsuarioForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.unlockButton);
            this.Controls.Add(this.listado);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.patentesButton);
            this.Controls.Add(this.familiaButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.enabled);
            this.Controls.Add(this.emailField);
            this.Controls.Add(this.email);
            this.Controls.Add(this.valorHoraField);
            this.Controls.Add(this.val);
            this.Controls.Add(this.usernameField);
            this.Controls.Add(this.apellidoField);
            this.Controls.Add(this.disponibilidadField);
            this.Controls.Add(this.username);
            this.Controls.Add(this.lastname);
            this.Controls.Add(this.disp);
            this.Controls.Add(this.nombreField);
            this.Controls.Add(this.name);
            this.Name = "UsuarioForm";
            this.Load += new System.EventHandler(this.UsuarioForm_Load);
            this.Resize += new System.EventHandler(this.UsuarioForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.listado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.TextBox nombreField;
        private System.Windows.Forms.Label lastname;
        private System.Windows.Forms.TextBox apellidoField;
        private System.Windows.Forms.Label disp;
        private System.Windows.Forms.TextBox disponibilidadField;
        private System.Windows.Forms.Label val;
        private System.Windows.Forms.TextBox valorHoraField;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.TextBox usernameField;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.TextBox emailField;
        private System.Windows.Forms.CheckBox enabled;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button familiaButton;
        private System.Windows.Forms.Button patentesButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.DataGridView listado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button unlockButton;
    }
}