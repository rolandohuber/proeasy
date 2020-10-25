namespace ProEasyUI
{
    partial class StringConexionForm
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
            this.serverField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.baseDeDatosField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passField = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // serverField
            // 
            this.serverField.Location = new System.Drawing.Point(16, 30);
            this.serverField.Name = "serverField";
            this.serverField.Size = new System.Drawing.Size(260, 20);
            this.serverField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Base de datos";
            // 
            // baseDeDatosField
            // 
            this.baseDeDatosField.Location = new System.Drawing.Point(16, 74);
            this.baseDeDatosField.Name = "baseDeDatosField";
            this.baseDeDatosField.Size = new System.Drawing.Size(260, 20);
            this.baseDeDatosField.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Usuario";
            // 
            // userField
            // 
            this.userField.Location = new System.Drawing.Point(16, 117);
            this.userField.Name = "userField";
            this.userField.Size = new System.Drawing.Size(260, 20);
            this.userField.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Contraseña";
            // 
            // passField
            // 
            this.passField.Location = new System.Drawing.Point(16, 160);
            this.passField.Name = "passField";
            this.passField.PasswordChar = '*';
            this.passField.Size = new System.Drawing.Size(260, 20);
            this.passField.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StringConexionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 237);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baseDeDatosField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverField);
            this.Controls.Add(this.label1);
            this.Name = "StringConexionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProEasy - String de conexion";
            this.Load += new System.EventHandler(this.StringConexionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox baseDeDatosField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passField;
        private System.Windows.Forms.Button button1;
    }
}