namespace CR
{
    partial class frmBonificaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBonificaciones));
            this.dgDatos = new System.Windows.Forms.DataGridView();
            this.cbOrganismos = new System.Windows.Forms.ComboBox();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRptGeneral = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVistaP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDatos
            // 
            this.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatos.Location = new System.Drawing.Point(12, 173);
            this.dgDatos.Name = "dgDatos";
            this.dgDatos.Size = new System.Drawing.Size(844, 306);
            this.dgDatos.TabIndex = 0;
            // 
            // cbOrganismos
            // 
            this.cbOrganismos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOrganismos.FormattingEnabled = true;
            this.cbOrganismos.Location = new System.Drawing.Point(12, 28);
            this.cbOrganismos.Name = "cbOrganismos";
            this.cbOrganismos.Size = new System.Drawing.Size(185, 21);
            this.cbOrganismos.TabIndex = 6;
            // 
            // cbLocalidad
            // 
            this.cbLocalidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLocalidad.FormattingEnabled = true;
            this.cbLocalidad.Location = new System.Drawing.Point(203, 28);
            this.cbLocalidad.Name = "cbLocalidad";
            this.cbLocalidad.Size = new System.Drawing.Size(184, 21);
            this.cbLocalidad.TabIndex = 7;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLimpiar.Location = new System.Drawing.Point(806, 110);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(50, 59);
            this.btnLimpiar.TabIndex = 35;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnRptGeneral
            // 
            this.btnRptGeneral.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRptGeneral.BackgroundImage")));
            this.btnRptGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRptGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRptGeneral.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRptGeneral.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRptGeneral.Location = new System.Drawing.Point(682, 108);
            this.btnRptGeneral.Name = "btnRptGeneral";
            this.btnRptGeneral.Size = new System.Drawing.Size(56, 61);
            this.btnRptGeneral.TabIndex = 34;
            this.btnRptGeneral.UseVisualStyleBackColor = true;
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbrir.BackgroundImage")));
            this.btnAbrir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAbrir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAbrir.Location = new System.Drawing.Point(566, 115);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(52, 54);
            this.btnAbrir.TabIndex = 33;
            this.btnAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAbrir.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.BackgroundImage")));
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGuardar.Location = new System.Drawing.Point(624, 115);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(52, 54);
            this.btnGuardar.TabIndex = 32;
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnVistaP
            // 
            this.btnVistaP.BackColor = System.Drawing.SystemColors.Control;
            this.btnVistaP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVistaP.BackgroundImage")));
            this.btnVistaP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVistaP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVistaP.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVistaP.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVistaP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnVistaP.Location = new System.Drawing.Point(744, 115);
            this.btnVistaP.Name = "btnVistaP";
            this.btnVistaP.Size = new System.Drawing.Size(56, 54);
            this.btnVistaP.TabIndex = 31;
            this.btnVistaP.UseVisualStyleBackColor = false;
            // 
            // frmBonificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 491);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRptGeneral);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnVistaP);
            this.Controls.Add(this.cbOrganismos);
            this.Controls.Add(this.cbLocalidad);
            this.Controls.Add(this.dgDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBonificaciones";
            this.Text = "Bonificaciones";
            this.Load += new System.EventHandler(this.frmBonificaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDatos;
        private System.Windows.Forms.ComboBox cbOrganismos;
        private System.Windows.Forms.ComboBox cbLocalidad;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRptGeneral;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVistaP;
    }
}