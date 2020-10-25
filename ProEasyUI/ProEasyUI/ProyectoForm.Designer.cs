namespace ProEasyUI
{
    partial class ProyectoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.nombreField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.horasEstimadasField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.horasInsumidasField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.valorHoraField = new System.Windows.Forms.TextBox();
            this.habilitadoField = new System.Windows.Forms.CheckBox();
            this.createButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.resourcesButton = new System.Windows.Forms.Button();
            this.listado = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // nombreField
            // 
            this.nombreField.Location = new System.Drawing.Point(16, 30);
            this.nombreField.Name = "nombreField";
            this.nombreField.Size = new System.Drawing.Size(389, 20);
            this.nombreField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Horas estimadas";
            // 
            // horasEstimadasField
            // 
            this.horasEstimadasField.Location = new System.Drawing.Point(16, 79);
            this.horasEstimadasField.Name = "horasEstimadasField";
            this.horasEstimadasField.Size = new System.Drawing.Size(193, 20);
            this.horasEstimadasField.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Horas insumidas";
            // 
            // horasInsumidasField
            // 
            this.horasInsumidasField.Location = new System.Drawing.Point(215, 79);
            this.horasInsumidasField.Name = "horasInsumidasField";
            this.horasInsumidasField.ReadOnly = true;
            this.horasInsumidasField.Size = new System.Drawing.Size(190, 20);
            this.horasInsumidasField.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Valor hora acordado con el cliente";
            // 
            // valorHoraField
            // 
            this.valorHoraField.Location = new System.Drawing.Point(16, 126);
            this.valorHoraField.Name = "valorHoraField";
            this.valorHoraField.Size = new System.Drawing.Size(389, 20);
            this.valorHoraField.TabIndex = 3;
            // 
            // habilitadoField
            // 
            this.habilitadoField.AutoSize = true;
            this.habilitadoField.Location = new System.Drawing.Point(16, 155);
            this.habilitadoField.Name = "habilitadoField";
            this.habilitadoField.Size = new System.Drawing.Size(73, 17);
            this.habilitadoField.TabIndex = 4;
            this.habilitadoField.Text = "Habilitado";
            this.habilitadoField.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(16, 188);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 5;
            this.createButton.Text = "Crear";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(97, 188);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Eliminar";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(178, 188);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Guardar";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(259, 188);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // resourcesButton
            // 
            this.resourcesButton.Location = new System.Drawing.Point(16, 217);
            this.resourcesButton.Name = "resourcesButton";
            this.resourcesButton.Size = new System.Drawing.Size(156, 23);
            this.resourcesButton.TabIndex = 9;
            this.resourcesButton.Text = "Asignar recursos";
            this.resourcesButton.UseVisualStyleBackColor = true;
            this.resourcesButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // listado
            // 
            this.listado.AllowUserToAddRows = false;
            this.listado.AllowUserToDeleteRows = false;
            this.listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NombreProyecto,
            this.Habilitado});
            this.listado.Location = new System.Drawing.Point(418, 13);
            this.listado.Name = "listado";
            this.listado.ReadOnly = true;
            this.listado.Size = new System.Drawing.Size(370, 416);
            this.listado.TabIndex = 40;
            this.listado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // NombreProyecto
            // 
            this.NombreProyecto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreProyecto.HeaderText = "Nombre del proyecto";
            this.NombreProyecto.Name = "NombreProyecto";
            this.NombreProyecto.ReadOnly = true;
            // 
            // Habilitado
            // 
            this.Habilitado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            // 
            // ProyectoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listado);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.resourcesButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.habilitadoField);
            this.Controls.Add(this.horasInsumidasField);
            this.Controls.Add(this.horasEstimadasField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.valorHoraField);
            this.Controls.Add(this.nombreField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProyectoForm";
            this.Text = "ProyectoForm";
            this.Load += new System.EventHandler(this.ProyectoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nombreField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox horasEstimadasField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox horasInsumidasField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox valorHoraField;
        private System.Windows.Forms.CheckBox habilitadoField;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button resourcesButton;
        private System.Windows.Forms.DataGridView listado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Habilitado;
    }
}