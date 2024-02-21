namespace Lambda
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbhasta = new System.Windows.Forms.Label();
            this.lbdesde = new System.Windows.Forms.Label();
            this.dphasta = new System.Windows.Forms.DateTimePicker();
            this.dpdesde = new System.Windows.Forms.DateTimePicker();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lvMain = new System.Windows.Forms.ListView();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.pcBuscar = new System.Windows.Forms.PictureBox();
            this.pcAgregar = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCargo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBuscar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.lbhasta);
            this.panel1.Controls.Add(this.lbdesde);
            this.panel1.Controls.Add(this.dphasta);
            this.panel1.Controls.Add(this.dpdesde);
            this.panel1.Controls.Add(this.cbTipo);
            this.panel1.Name = "panel1";
            // 
            // lbhasta
            // 
            resources.ApplyResources(this.lbhasta, "lbhasta");
            this.lbhasta.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbhasta.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbhasta.Name = "lbhasta";
            // 
            // lbdesde
            // 
            resources.ApplyResources(this.lbdesde, "lbdesde");
            this.lbdesde.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbdesde.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbdesde.Name = "lbdesde";
            // 
            // dphasta
            // 
            this.dphasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dphasta, "dphasta");
            this.dphasta.Name = "dphasta";
            // 
            // dpdesde
            // 
            this.dpdesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dpdesde, "dpdesde");
            this.dpdesde.Name = "dpdesde";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            resources.ApplyResources(this.cbTipo, "cbTipo");
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.SelectedIndexChanged += new System.EventHandler(this.cbTipo_SelectedIndexChanged);
            // 
            // lvMain
            // 
            this.lvMain.Activation = System.Windows.Forms.ItemActivation.OneClick;
            resources.ApplyResources(this.lvMain, "lvMain");
            this.lvMain.HideSelection = false;
            this.lvMain.Name = "lvMain";
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.SelectedIndexChanged += new System.EventHandler(this.lvMain_SelectedIndexChanged);
            // 
            // btnGenerar
            // 
            resources.ApplyResources(this.btnGenerar, "btnGenerar");
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.button1_Click);
            // 
            // pcBuscar
            // 
            resources.ApplyResources(this.pcBuscar, "pcBuscar");
            this.pcBuscar.Image = global::Lambda.Properties.Resources.busqueda_removebg_preview__1_;
            this.pcBuscar.Name = "pcBuscar";
            this.pcBuscar.TabStop = false;
            this.pcBuscar.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pcAgregar
            // 
            resources.ApplyResources(this.pcAgregar, "pcAgregar");
            this.pcAgregar.Image = global::Lambda.Properties.Resources.mas__1_;
            this.pcAgregar.Name = "pcAgregar";
            this.pcAgregar.TabStop = false;
            this.pcAgregar.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Lambda.Properties.Resources.salir_app;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnCargo
            // 
            resources.ApplyResources(this.btnCargo, "btnCargo");
            this.btnCargo.Name = "btnCargo";
            this.btnCargo.UseVisualStyleBackColor = true;
            this.btnCargo.Click += new System.EventHandler(this.btnCargo_Click);
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pcBuscar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.pcAgregar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lvMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCargo);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBuscar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvMain;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.DateTimePicker dpdesde;
        private System.Windows.Forms.DateTimePicker dphasta;
        private System.Windows.Forms.Label lbhasta;
        private System.Windows.Forms.Label lbdesde;
        private System.Windows.Forms.PictureBox pcAgregar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.PictureBox pcBuscar;
        private System.Windows.Forms.Button btnCargo;
        private System.Windows.Forms.Button btnCancelar;
    }
}

