namespace CR
{
    partial class frmHome
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
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.cbOrganismos = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.rbActual = new System.Windows.Forms.RadioButton();
            this.rbFutura = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.chkInterinato = new System.Windows.Forms.CheckBox();
            this.dgDatos = new System.Windows.Forms.DataGridView();
            this.txtApellidoPa = new System.Windows.Forms.TextBox();
            this.txtSueldo = new System.Windows.Forms.TextBox();
            this.txtElaborada = new System.Windows.Forms.TextBox();
            this.dgTasas = new System.Windows.Forms.DataGridView();
            this.txtInteres = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtUltimaTasa = new System.Windows.Forms.DateTimePicker();
            this.chkUltimaTasa = new System.Windows.Forms.CheckBox();
            this.lstTipo = new System.Windows.Forms.ListBox();
            this.lstDe = new System.Windows.Forms.ListBox();
            this.lstHasta = new System.Windows.Forms.ListBox();
            this.txtApellidoMa = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnVistaP = new System.Windows.Forms.Button();
            this.txtGuardar = new System.Windows.Forms.Button();
            this.txtAbrir = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRecalcular = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTasas)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLocalidad
            // 
            this.cbLocalidad.FormattingEnabled = true;
            this.cbLocalidad.Location = new System.Drawing.Point(745, 7);
            this.cbLocalidad.Name = "cbLocalidad";
            this.cbLocalidad.Size = new System.Drawing.Size(184, 21);
            this.cbLocalidad.TabIndex = 0;
            // 
            // cbOrganismos
            // 
            this.cbOrganismos.FormattingEnabled = true;
            this.cbOrganismos.Location = new System.Drawing.Point(554, 7);
            this.cbOrganismos.Name = "cbOrganismos";
            this.cbOrganismos.Size = new System.Drawing.Size(185, 21);
            this.cbOrganismos.TabIndex = 1;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(936, 6);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(78, 41);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // rbActual
            // 
            this.rbActual.AutoSize = true;
            this.rbActual.Location = new System.Drawing.Point(365, 64);
            this.rbActual.Name = "rbActual";
            this.rbActual.Size = new System.Drawing.Size(55, 17);
            this.rbActual.TabIndex = 4;
            this.rbActual.TabStop = true;
            this.rbActual.Text = "Actual";
            this.rbActual.UseVisualStyleBackColor = true;
            // 
            // rbFutura
            // 
            this.rbFutura.AutoSize = true;
            this.rbFutura.Location = new System.Drawing.Point(425, 64);
            this.rbFutura.Name = "rbFutura";
            this.rbFutura.Size = new System.Drawing.Size(55, 17);
            this.rbFutura.TabIndex = 5;
            this.rbFutura.TabStop = true;
            this.rbFutura.Text = "Futura";
            this.rbFutura.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(471, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(611, 34);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(134, 20);
            this.dateTimePicker2.TabIndex = 7;
            this.dateTimePicker2.Value = new System.DateTime(2017, 1, 6, 12, 36, 41, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // chkInterinato
            // 
            this.chkInterinato.AutoSize = true;
            this.chkInterinato.Location = new System.Drawing.Point(486, 66);
            this.chkInterinato.Name = "chkInterinato";
            this.chkInterinato.Size = new System.Drawing.Size(70, 17);
            this.chkInterinato.TabIndex = 8;
            this.chkInterinato.Text = "Interinato";
            this.chkInterinato.UseVisualStyleBackColor = true;
            // 
            // dgDatos
            // 
            this.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatos.Location = new System.Drawing.Point(365, 96);
            this.dgDatos.Name = "dgDatos";
            this.dgDatos.Size = new System.Drawing.Size(766, 385);
            this.dgDatos.TabIndex = 9;
            // 
            // txtApellidoPa
            // 
            this.txtApellidoPa.Location = new System.Drawing.Point(217, 7);
            this.txtApellidoPa.Name = "txtApellidoPa";
            this.txtApellidoPa.Size = new System.Drawing.Size(115, 20);
            this.txtApellidoPa.TabIndex = 10;
            this.txtApellidoPa.Click += new System.EventHandler(this.txtEmpleado_Click);
            this.txtApellidoPa.TextChanged += new System.EventHandler(this.txtEmpleado_TextChanged);
            this.txtApellidoPa.Leave += new System.EventHandler(this.txtEmpleado_Leave);
            // 
            // txtSueldo
            // 
            this.txtSueldo.Location = new System.Drawing.Point(365, 34);
            this.txtSueldo.Name = "txtSueldo";
            this.txtSueldo.Size = new System.Drawing.Size(100, 20);
            this.txtSueldo.TabIndex = 11;
            this.txtSueldo.Click += new System.EventHandler(this.txtSueldo_Click);
            this.txtSueldo.TextChanged += new System.EventHandler(this.txtSueldo_TextChanged);
            this.txtSueldo.Leave += new System.EventHandler(this.txtSueldo_Leave);
            // 
            // txtElaborada
            // 
            this.txtElaborada.Location = new System.Drawing.Point(751, 60);
            this.txtElaborada.Name = "txtElaborada";
            this.txtElaborada.Size = new System.Drawing.Size(178, 20);
            this.txtElaborada.TabIndex = 12;
            this.txtElaborada.Click += new System.EventHandler(this.txtElaborada_Click);
            this.txtElaborada.TextChanged += new System.EventHandler(this.txtElaborada_TextChanged);
            this.txtElaborada.Leave += new System.EventHandler(this.txtElaborada_Leave);
            // 
            // dgTasas
            // 
            this.dgTasas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTasas.Location = new System.Drawing.Point(12, 127);
            this.dgTasas.Name = "dgTasas";
            this.dgTasas.Size = new System.Drawing.Size(240, 413);
            this.dgTasas.TabIndex = 13;
            // 
            // txtInteres
            // 
            this.txtInteres.Location = new System.Drawing.Point(12, 60);
            this.txtInteres.Name = "txtInteres";
            this.txtInteres.Size = new System.Drawing.Size(100, 20);
            this.txtInteres.TabIndex = 14;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 86);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 16;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(12, 34);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 17;
            // 
            // dtUltimaTasa
            // 
            this.dtUltimaTasa.Enabled = false;
            this.dtUltimaTasa.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtUltimaTasa.Location = new System.Drawing.Point(751, 34);
            this.dtUltimaTasa.Name = "dtUltimaTasa";
            this.dtUltimaTasa.Size = new System.Drawing.Size(178, 20);
            this.dtUltimaTasa.TabIndex = 18;
            // 
            // chkUltimaTasa
            // 
            this.chkUltimaTasa.AutoSize = true;
            this.chkUltimaTasa.Location = new System.Drawing.Point(562, 64);
            this.chkUltimaTasa.Name = "chkUltimaTasa";
            this.chkUltimaTasa.Size = new System.Drawing.Size(100, 17);
            this.chkUltimaTasa.TabIndex = 19;
            this.chkUltimaTasa.Text = "Rango de Tasa";
            this.chkUltimaTasa.UseVisualStyleBackColor = true;
            this.chkUltimaTasa.CheckedChanged += new System.EventHandler(this.chkUltimaTasa_CheckedChanged);
            // 
            // lstTipo
            // 
            this.lstTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTipo.FormattingEnabled = true;
            this.lstTipo.Items.AddRange(new object[] {
            "M",
            "Q"});
            this.lstTipo.Location = new System.Drawing.Point(663, 60);
            this.lstTipo.Name = "lstTipo";
            this.lstTipo.Size = new System.Drawing.Size(22, 30);
            this.lstTipo.TabIndex = 20;
            this.lstTipo.SelectedIndexChanged += new System.EventHandler(this.lstTipo_SelectedIndexChanged);
            // 
            // lstDe
            // 
            this.lstDe.Enabled = false;
            this.lstDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDe.FormattingEnabled = true;
            this.lstDe.Items.AddRange(new object[] {
            "Q1",
            "Q2"});
            this.lstDe.Location = new System.Drawing.Point(691, 60);
            this.lstDe.Name = "lstDe";
            this.lstDe.Size = new System.Drawing.Size(24, 30);
            this.lstDe.TabIndex = 21;
            // 
            // lstHasta
            // 
            this.lstHasta.Enabled = false;
            this.lstHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHasta.FormattingEnabled = true;
            this.lstHasta.Items.AddRange(new object[] {
            "Q1",
            "Q2"});
            this.lstHasta.Location = new System.Drawing.Point(721, 60);
            this.lstHasta.Name = "lstHasta";
            this.lstHasta.Size = new System.Drawing.Size(24, 30);
            this.lstHasta.TabIndex = 22;
            // 
            // txtApellidoMa
            // 
            this.txtApellidoMa.Location = new System.Drawing.Point(338, 6);
            this.txtApellidoMa.Name = "txtApellidoMa";
            this.txtApellidoMa.Size = new System.Drawing.Size(100, 20);
            this.txtApellidoMa.TabIndex = 23;
            this.txtApellidoMa.Click += new System.EventHandler(this.txtApellidoMa_Click);
            this.txtApellidoMa.TextChanged += new System.EventHandler(this.txtApellidoMa_TextChanged);
            this.txtApellidoMa.Leave += new System.EventHandler(this.txtApellidoMa_Leave);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(448, 6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 24;
            this.txtNombre.Click += new System.EventHandler(this.txtNombre_Click);
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // btnVistaP
            // 
            this.btnVistaP.Location = new System.Drawing.Point(274, 112);
            this.btnVistaP.Name = "btnVistaP";
            this.btnVistaP.Size = new System.Drawing.Size(75, 23);
            this.btnVistaP.TabIndex = 25;
            this.btnVistaP.Text = "Vista Prevía";
            this.btnVistaP.UseVisualStyleBackColor = true;
            this.btnVistaP.Click += new System.EventHandler(this.btnVistaP_Click);
            // 
            // txtGuardar
            // 
            this.txtGuardar.Location = new System.Drawing.Point(274, 141);
            this.txtGuardar.Name = "txtGuardar";
            this.txtGuardar.Size = new System.Drawing.Size(75, 23);
            this.txtGuardar.TabIndex = 26;
            this.txtGuardar.Text = "Guardar";
            this.txtGuardar.UseVisualStyleBackColor = true;
            this.txtGuardar.Click += new System.EventHandler(this.txtGuardar_Click);
            // 
            // txtAbrir
            // 
            this.txtAbrir.Location = new System.Drawing.Point(274, 170);
            this.txtAbrir.Name = "txtAbrir";
            this.txtAbrir.Size = new System.Drawing.Size(75, 23);
            this.txtAbrir.TabIndex = 27;
            this.txtAbrir.Text = "Abrir";
            this.txtAbrir.UseVisualStyleBackColor = true;
            this.txtAbrir.Click += new System.EventHandler(this.txtAbrir_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 28;
            this.button1.Text = "Reporte General";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRecalcular
            // 
            this.btnRecalcular.Location = new System.Drawing.Point(936, 53);
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.Size = new System.Drawing.Size(75, 37);
            this.btnRecalcular.TabIndex = 29;
            this.btnRecalcular.Text = "Recalcular";
            this.btnRecalcular.UseVisualStyleBackColor = true;
            this.btnRecalcular.Click += new System.EventHandler(this.btnRecalcular_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 552);
            this.Controls.Add(this.btnRecalcular);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAbrir);
            this.Controls.Add(this.txtGuardar);
            this.Controls.Add(this.btnVistaP);
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
            this.Name = "frmHome";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTasas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLocalidad;
        private System.Windows.Forms.ComboBox cbOrganismos;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.RadioButton rbActual;
        private System.Windows.Forms.RadioButton rbFutura;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.CheckBox chkInterinato;
        private System.Windows.Forms.DataGridView dgDatos;
        private System.Windows.Forms.TextBox txtApellidoPa;
        private System.Windows.Forms.TextBox txtSueldo;
        private System.Windows.Forms.TextBox txtElaborada;
        private System.Windows.Forms.DataGridView dgTasas;
        private System.Windows.Forms.TextBox txtInteres;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtUltimaTasa;
        private System.Windows.Forms.CheckBox chkUltimaTasa;
        private System.Windows.Forms.ListBox lstTipo;
        private System.Windows.Forms.ListBox lstDe;
        private System.Windows.Forms.ListBox lstHasta;
        private System.Windows.Forms.TextBox txtApellidoMa;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnVistaP;
        private System.Windows.Forms.Button txtGuardar;
        private System.Windows.Forms.Button txtAbrir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRecalcular;
    }
}

