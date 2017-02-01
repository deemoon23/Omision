namespace CR
{
    partial class frmOmisiones
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOmisiones));
            this.btnGenerar = new System.Windows.Forms.Button();
            this.txtElaborada = new System.Windows.Forms.TextBox();
            this.dgTasas = new System.Windows.Forms.DataGridView();
            this.txtInteres = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.btnRecalcular = new System.Windows.Forms.Button();
            this.btnRptGeneral = new System.Windows.Forms.Button();
            this.btnAbrir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVistaP = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbOrganismos = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.rbFutura = new System.Windows.Forms.RadioButton();
            this.rbActual = new System.Windows.Forms.RadioButton();
            this.txtApellidoPa = new System.Windows.Forms.TextBox();
            this.dgDatos = new System.Windows.Forms.DataGridView();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.dtUltimaTasa = new System.Windows.Forms.DateTimePicker();
            this.chkInterinato = new System.Windows.Forms.CheckBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellidoMa = new System.Windows.Forms.TextBox();
            this.chkUltimaTasa = new System.Windows.Forms.CheckBox();
            this.lstTipo = new System.Windows.Forms.ListBox();
            this.lstDe = new System.Windows.Forms.ListBox();
            this.lstHasta = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgTasas)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerar
            // 
            resources.ApplyResources(this.btnGenerar, "btnGenerar");
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // txtElaborada
            // 
            resources.ApplyResources(this.txtElaborada, "txtElaborada");
            this.txtElaborada.Name = "txtElaborada";
            this.txtElaborada.Click += new System.EventHandler(this.txtElaborada_Click);
            this.txtElaborada.TextChanged += new System.EventHandler(this.txtElaborada_TextChanged);
            this.txtElaborada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoPa_KeyPress);
            this.txtElaborada.Leave += new System.EventHandler(this.txtElaborada_Leave);
            // 
            // dgTasas
            // 
            resources.ApplyResources(this.dgTasas, "dgTasas");
            this.dgTasas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTasas.Name = "dgTasas";
            // 
            // txtInteres
            // 
            resources.ApplyResources(this.txtInteres, "txtInteres");
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInteres_KeyPress);
            // 
            // btnAgregar
            // 
            resources.ApplyResources(this.btnAgregar, "btnAgregar");
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblFecha
            // 
            resources.ApplyResources(this.lblFecha, "lblFecha");
            this.lblFecha.Name = "lblFecha";
            // 
            // btnRecalcular
            // 
            resources.ApplyResources(this.btnRecalcular, "btnRecalcular");
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.UseVisualStyleBackColor = true;
            this.btnRecalcular.Click += new System.EventHandler(this.btnRecalcular_Click);
            // 
            // btnRptGeneral
            // 
            resources.ApplyResources(this.btnRptGeneral, "btnRptGeneral");
            this.btnRptGeneral.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRptGeneral.Name = "btnRptGeneral";
            this.btnRptGeneral.UseVisualStyleBackColor = true;
            this.btnRptGeneral.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAbrir
            // 
            resources.ApplyResources(this.btnAbrir, "btnAbrir");
            this.btnAbrir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.UseVisualStyleBackColor = true;
            this.btnAbrir.Click += new System.EventHandler(this.txtAbrir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnGuardar, "btnGuardar");
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.txtGuardar_Click);
            // 
            // btnVistaP
            // 
            this.btnVistaP.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.btnVistaP, "btnVistaP");
            this.btnVistaP.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVistaP.Name = "btnVistaP";
            this.btnVistaP.UseVisualStyleBackColor = false;
            this.btnVistaP.Click += new System.EventHandler(this.btnVistaP_Click);
            // 
            // btnLimpiar
            // 
            resources.ApplyResources(this.btnLimpiar, "btnLimpiar");
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Info;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // timer1
            // 
            this.timer1.Interval = 6000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtSueldo
            // 
            resources.ApplyResources(this.txtSueldo, "txtSueldo");
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.Click += new System.EventHandler(this.txtSueldo_Click);
            this.txtSueldo.TextChanged += new System.EventHandler(this.txtSueldo_TextChanged);
            this.txtSueldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSueldo_KeyPress);
            this.txtSueldo.Leave += new System.EventHandler(this.txtSueldo_Leave);
            // 
            // dateTimePicker1
            // 
            resources.ApplyResources(this.dateTimePicker1, "dateTimePicker1");
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Name = "dateTimePicker1";
            // 
            // cbOrganismos
            // 
            resources.ApplyResources(this.cbOrganismos, "cbOrganismos");
            this.cbOrganismos.FormattingEnabled = true;
            this.cbOrganismos.Name = "cbOrganismos";
            // 
            // dateTimePicker2
            // 
            resources.ApplyResources(this.dateTimePicker2, "dateTimePicker2");
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Value = new System.DateTime(2017, 1, 6, 12, 36, 41, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // rbFutura
            // 
            resources.ApplyResources(this.rbFutura, "rbFutura");
            this.rbFutura.Name = "rbFutura";
            this.rbFutura.TabStop = true;
            this.rbFutura.UseVisualStyleBackColor = true;
            // 
            // rbActual
            // 
            resources.ApplyResources(this.rbActual, "rbActual");
            this.rbActual.Name = "rbActual";
            this.rbActual.TabStop = true;
            this.rbActual.UseVisualStyleBackColor = true;
            // 
            // txtApellidoPa
            // 
            resources.ApplyResources(this.txtApellidoPa, "txtApellidoPa");
            this.txtApellidoPa.Name = "txtApellidoPa";
            this.txtApellidoPa.Click += new System.EventHandler(this.txtEmpleado_Click);
            this.txtApellidoPa.TextChanged += new System.EventHandler(this.txtEmpleado_TextChanged);
            this.txtApellidoPa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoPa_KeyPress);
            this.txtApellidoPa.Leave += new System.EventHandler(this.txtEmpleado_Leave);
            // 
            // dgDatos
            // 
            resources.ApplyResources(this.dgDatos, "dgDatos");
            this.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatos.Name = "dgDatos";
            // 
            // cbLocalidad
            // 
            resources.ApplyResources(this.cbLocalidad, "cbLocalidad");
            this.cbLocalidad.FormattingEnabled = true;
            this.cbLocalidad.Name = "cbLocalidad";
            // 
            // dtUltimaTasa
            // 
            resources.ApplyResources(this.dtUltimaTasa, "dtUltimaTasa");
            this.dtUltimaTasa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtUltimaTasa.Name = "dtUltimaTasa";
            // 
            // chkInterinato
            // 
            resources.ApplyResources(this.chkInterinato, "chkInterinato");
            this.chkInterinato.Name = "chkInterinato";
            this.chkInterinato.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            resources.ApplyResources(this.txtNombre, "txtNombre");
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Click += new System.EventHandler(this.txtNombre_Click);
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtApellidoMa
            // 
            resources.ApplyResources(this.txtApellidoMa, "txtApellidoMa");
            this.txtApellidoMa.Name = "txtApellidoMa";
            this.txtApellidoMa.Click += new System.EventHandler(this.txtApellidoMa_Click);
            this.txtApellidoMa.TextChanged += new System.EventHandler(this.txtApellidoMa_TextChanged);
            this.txtApellidoMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoPa_KeyPress);
            this.txtApellidoMa.Leave += new System.EventHandler(this.txtApellidoMa_Leave);
            // 
            // chkUltimaTasa
            // 
            resources.ApplyResources(this.chkUltimaTasa, "chkUltimaTasa");
            this.chkUltimaTasa.Name = "chkUltimaTasa";
            this.chkUltimaTasa.UseVisualStyleBackColor = true;
            this.chkUltimaTasa.CheckedChanged += new System.EventHandler(this.chkUltimaTasa_CheckedChanged);
            // 
            // lstTipo
            // 
            resources.ApplyResources(this.lstTipo, "lstTipo");
            this.lstTipo.FormattingEnabled = true;
            this.lstTipo.Items.AddRange(new object[] {
            resources.GetString("lstTipo.Items"),
            resources.GetString("lstTipo.Items1")});
            this.lstTipo.Name = "lstTipo";
            this.lstTipo.SelectedIndexChanged += new System.EventHandler(this.lstTipo_SelectedIndexChanged);
            // 
            // lstDe
            // 
            resources.ApplyResources(this.lstDe, "lstDe");
            this.lstDe.FormattingEnabled = true;
            this.lstDe.Items.AddRange(new object[] {
            resources.GetString("lstDe.Items"),
            resources.GetString("lstDe.Items1")});
            this.lstDe.Name = "lstDe";
            // 
            // lstHasta
            // 
            resources.ApplyResources(this.lstHasta, "lstHasta");
            this.lstHasta.FormattingEnabled = true;
            this.lstHasta.Items.AddRange(new object[] {
            resources.GetString("lstHasta.Items"),
            resources.GetString("lstHasta.Items1")});
            this.lstHasta.Name = "lstHasta";
            // 
            // frmOmisiones
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRecalcular);
            this.Controls.Add(this.btnRptGeneral);
            this.Controls.Add(this.btnAbrir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtApellidoMa);
            this.Controls.Add(this.lstHasta);
            this.Controls.Add(this.lstDe);
            this.Controls.Add(this.lstTipo);
            this.Controls.Add(this.chkUltimaTasa);
            this.Controls.Add(this.dtUltimaTasa);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtInteres);
            this.Controls.Add(this.dgTasas);
            this.Controls.Add(this.txtElaborada);
            this.Controls.Add(this.txtSueldo);
            this.Controls.Add(this.txtApellidoPa);
            this.Controls.Add(this.dgDatos);
            this.Controls.Add(this.chkInterinato);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.rbFutura);
            this.Controls.Add(this.rbActual);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cbOrganismos);
            this.Controls.Add(this.cbLocalidad);
            this.Controls.Add(this.btnVistaP);
            this.Name = "frmOmisiones";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTasas)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TextBox txtElaborada;
        private System.Windows.Forms.DataGridView dgTasas;
        private System.Windows.Forms.TextBox txtInteres;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnVistaP;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnRptGeneral;
        private System.Windows.Forms.Button btnRecalcular;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cbOrganismos;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.RadioButton rbFutura;
        private System.Windows.Forms.RadioButton rbActual;
        private System.Windows.Forms.TextBox txtApellidoPa;
        private System.Windows.Forms.DataGridView dgDatos;
        private System.Windows.Forms.ComboBox cbLocalidad;
        private System.Windows.Forms.DateTimePicker dtUltimaTasa;
        private System.Windows.Forms.CheckBox chkInterinato;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidoMa;
        private System.Windows.Forms.CheckBox chkUltimaTasa;
        private System.Windows.Forms.ListBox lstTipo;
        private System.Windows.Forms.ListBox lstDe;
        private System.Windows.Forms.ListBox lstHasta;
    }
}

