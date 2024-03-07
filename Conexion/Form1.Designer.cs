namespace Conexion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbTipoConn = new ComboBox();
            lbServidor = new Label();
            tbServidor = new TextBox();
            btnConn = new Button();
            tbBd = new TextBox();
            tbUsuario = new TextBox();
            tbPass = new TextBox();
            lbUsuario = new Label();
            lbBd = new Label();
            lbPass = new Label();
            SuspendLayout();
            // 
            // cbTipoConn
            // 
            cbTipoConn.FormattingEnabled = true;
            cbTipoConn.Location = new Point(12, 12);
            cbTipoConn.Name = "cbTipoConn";
            cbTipoConn.Size = new Size(178, 23);
            cbTipoConn.TabIndex = 0;
            // 
            // lbServidor
            // 
            lbServidor.AutoSize = true;
            lbServidor.Location = new Point(12, 50);
            lbServidor.Name = "lbServidor";
            lbServidor.Size = new Size(50, 15);
            lbServidor.TabIndex = 1;
            lbServidor.Text = "Servidor";
            // 
            // tbServidor
            // 
            tbServidor.Location = new Point(12, 68);
            tbServidor.Name = "tbServidor";
            tbServidor.Size = new Size(178, 23);
            tbServidor.TabIndex = 2;
            // 
            // btnConn
            // 
            btnConn.Location = new Point(64, 265);
            btnConn.Name = "btnConn";
            btnConn.Size = new Size(75, 23);
            btnConn.TabIndex = 3;
            btnConn.Text = "Conectar";
            btnConn.UseVisualStyleBackColor = true;
            btnConn.Click += btnConn_Click;
            // 
            // tbBd
            // 
            tbBd.Location = new Point(12, 112);
            tbBd.Name = "tbBd";
            tbBd.Size = new Size(178, 23);
            tbBd.TabIndex = 4;
            // 
            // tbUsuario
            // 
            tbUsuario.Location = new Point(12, 156);
            tbUsuario.Name = "tbUsuario";
            tbUsuario.Size = new Size(178, 23);
            tbUsuario.TabIndex = 5;
            // 
            // tbPass
            // 
            tbPass.Location = new Point(12, 200);
            tbPass.Name = "tbPass";
            tbPass.Size = new Size(178, 23);
            tbPass.TabIndex = 6;
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Location = new Point(12, 138);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(47, 15);
            lbUsuario.TabIndex = 7;
            lbUsuario.Text = "Usuario";
            // 
            // lbBd
            // 
            lbBd.AutoSize = true;
            lbBd.Location = new Point(12, 94);
            lbBd.Name = "lbBd";
            lbBd.Size = new Size(80, 15);
            lbBd.TabIndex = 8;
            lbBd.Text = "Base de Datos";
            // 
            // lbPass
            // 
            lbPass.AutoSize = true;
            lbPass.Location = new Point(12, 182);
            lbPass.Name = "lbPass";
            lbPass.Size = new Size(67, 15);
            lbPass.TabIndex = 9;
            lbPass.Text = "Contraseña";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(202, 351);
            Controls.Add(lbPass);
            Controls.Add(lbBd);
            Controls.Add(lbUsuario);
            Controls.Add(tbPass);
            Controls.Add(tbUsuario);
            Controls.Add(tbBd);
            Controls.Add(btnConn);
            Controls.Add(tbServidor);
            Controls.Add(lbServidor);
            Controls.Add(cbTipoConn);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Conexion";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbTipoConn;
        private Label lbServidor;
        private TextBox tbServidor;
        private Button btnConn;
        private TextBox tbBd;
        private TextBox tbUsuario;
        private TextBox tbPass;
        private Label lbUsuario;
        private Label lbBd;
        private Label lbPass;
    }
}
