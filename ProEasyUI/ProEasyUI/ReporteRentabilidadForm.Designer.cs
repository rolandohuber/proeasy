namespace ProEasyUI
{
    partial class ReporteRentabilidadForm
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
            this.desdeField = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.hastaField = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Proyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estimadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Insumidas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesvioDinero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Desde";
            // 
            // desdeField
            // 
            this.desdeField.Location = new System.Drawing.Point(12, 27);
            this.desdeField.Name = "desdeField";
            this.desdeField.Size = new System.Drawing.Size(200, 20);
            this.desdeField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Hasta";
            // 
            // hastaField
            // 
            this.hastaField.Location = new System.Drawing.Point(218, 27);
            this.hastaField.Name = "hastaField";
            this.hastaField.Size = new System.Drawing.Size(200, 20);
            this.hastaField.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(438, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(519, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 373);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
             this.Proyecto,
            this.Estado,
            this.Estimadas,
            this.Insumidas,
            this.Desvio,
            this.DesvioDinero,
            this.Fecha
        });
            // 
            // Proyecto
            // 
            this.Proyecto.HeaderText = "Proyecto";
            this.Proyecto.Name = "Proyecto";
            this.Proyecto.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Estimadas
            // 
            this.Estimadas.HeaderText = "Estimadas";
            this.Estimadas.Name = "Estimadas";
            this.Estimadas.ReadOnly = true;
            // 
            // Insumidas
            // 
            this.Insumidas.HeaderText = "Insumidas";
            this.Insumidas.Name = "Insumidas";
            this.Insumidas.ReadOnly = true;
            // 
            // DesvioDinero
            // 
            this.DesvioDinero.HeaderText = "Desvio dinero";
            this.DesvioDinero.Name = "DesvioDinero";
            this.DesvioDinero.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;

            // 
            // ReporteRentabilidadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hastaField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.desdeField);
            this.Controls.Add(this.label1);
            this.Name = "ReporteRentabilidadForm";
            this.Text = "ReporteRentabilidadForm";
            this.Load += new System.EventHandler(this.ReporteRentabilidadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker desdeField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker hastaField;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estimadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Insumidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desvio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesvioDinero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
    }
}