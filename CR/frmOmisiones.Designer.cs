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
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sueldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoCobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesOmitido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesCalculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organismo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cfp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cgi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcuotas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apren = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.afovi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aaf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aga = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taporta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importeA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tasa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmoratorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TasaCalculada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.interi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbLocalidad = new System.Windows.Forms.ComboBox();
            this.dtUltimaTasa = new System.Windows.Forms.DateTimePicker();
            this.chkInterinato = new System.Windows.Forms.CheckBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellidoMa = new System.Windows.Forms.TextBox();
            this.chkUltimaTasa = new System.Windows.Forms.CheckBox();
            this.lstTipo = new System.Windows.Forms.ListBox();
            this.lstDe = new System.Windows.Forms.ListBox();
            this.lstHasta = new System.Windows.Forms.ListBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
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
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
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
            this.cbOrganismos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.apellidoP,
            this.ApellidoM,
            this.Nombre,
            this.sueldo,
            this.tipoCobro,
            this.mesOmitido,
            this.mesCalculo,
            this.folio,
            this.idLoc,
            this.Localidad,
            this.idOrg,
            this.Organismo,
            this.csm,
            this.cfp,
            this.ccp,
            this.cpren,
            this.csv,
            this.csr,
            this.cgi,
            this.tcuotas,
            this.importeC,
            this.asm,
            this.afp,
            this.acp,
            this.apren,
            this.asv,
            this.asr,
            this.agi,
            this.afovi,
            this.apm,
            this.aaf,
            this.aig,
            this.aga,
            this.taporta,
            this.importeA,
            this.tasa,
            this.tmoratorio,
            this.tmes,
            this.TasaCalculada,
            this.genera,
            this.interi,
            this.activo});
            resources.ApplyResources(this.dgDatos, "dgDatos");
            this.dgDatos.Name = "dgDatos";
            this.dgDatos.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgDatos_CellBeginEdit);
            this.dgDatos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDatos_CellValueChanged);
            // 
            // ColumnID
            // 
            this.ColumnID.DataPropertyName = "ID";
            resources.ApplyResources(this.ColumnID, "ColumnID");
            this.ColumnID.Name = "ColumnID";
            // 
            // apellidoP
            // 
            this.apellidoP.DataPropertyName = "apellidoP";
            resources.ApplyResources(this.apellidoP, "apellidoP");
            this.apellidoP.Name = "apellidoP";
            // 
            // ApellidoM
            // 
            this.ApellidoM.DataPropertyName = "apellidoM";
            resources.ApplyResources(this.ApellidoM, "ApellidoM");
            this.ApellidoM.Name = "ApellidoM";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            resources.ApplyResources(this.Nombre, "Nombre");
            this.Nombre.Name = "Nombre";
            // 
            // sueldo
            // 
            this.sueldo.DataPropertyName = "sueldo";
            resources.ApplyResources(this.sueldo, "sueldo");
            this.sueldo.Name = "sueldo";
            // 
            // tipoCobro
            // 
            this.tipoCobro.DataPropertyName = "tipoCobro";
            resources.ApplyResources(this.tipoCobro, "tipoCobro");
            this.tipoCobro.Name = "tipoCobro";
            // 
            // mesOmitido
            // 
            this.mesOmitido.DataPropertyName = "mesOmitido";
            resources.ApplyResources(this.mesOmitido, "mesOmitido");
            this.mesOmitido.Name = "mesOmitido";
            // 
            // mesCalculo
            // 
            this.mesCalculo.DataPropertyName = "mesCalculo";
            resources.ApplyResources(this.mesCalculo, "mesCalculo");
            this.mesCalculo.Name = "mesCalculo";
            // 
            // folio
            // 
            this.folio.DataPropertyName = "folio";
            resources.ApplyResources(this.folio, "folio");
            this.folio.Name = "folio";
            // 
            // idLoc
            // 
            this.idLoc.DataPropertyName = "idLoc";
            resources.ApplyResources(this.idLoc, "idLoc");
            this.idLoc.Name = "idLoc";
            // 
            // Localidad
            // 
            this.Localidad.DataPropertyName = "localidad";
            resources.ApplyResources(this.Localidad, "Localidad");
            this.Localidad.Name = "Localidad";
            // 
            // idOrg
            // 
            this.idOrg.DataPropertyName = "idOrg";
            resources.ApplyResources(this.idOrg, "idOrg");
            this.idOrg.Name = "idOrg";
            // 
            // Organismo
            // 
            this.Organismo.DataPropertyName = "Organismo";
            resources.ApplyResources(this.Organismo, "Organismo");
            this.Organismo.Name = "Organismo";
            // 
            // csm
            // 
            this.csm.DataPropertyName = "csm";
            resources.ApplyResources(this.csm, "csm");
            this.csm.Name = "csm";
            // 
            // cfp
            // 
            this.cfp.DataPropertyName = "cfp";
            resources.ApplyResources(this.cfp, "cfp");
            this.cfp.Name = "cfp";
            // 
            // ccp
            // 
            this.ccp.DataPropertyName = "ccp";
            resources.ApplyResources(this.ccp, "ccp");
            this.ccp.Name = "ccp";
            // 
            // cpren
            // 
            this.cpren.DataPropertyName = "cpren";
            resources.ApplyResources(this.cpren, "cpren");
            this.cpren.Name = "cpren";
            // 
            // csv
            // 
            this.csv.DataPropertyName = "csv";
            resources.ApplyResources(this.csv, "csv");
            this.csv.Name = "csv";
            // 
            // csr
            // 
            this.csr.DataPropertyName = "csr";
            resources.ApplyResources(this.csr, "csr");
            this.csr.Name = "csr";
            // 
            // cgi
            // 
            this.cgi.DataPropertyName = "cgi";
            resources.ApplyResources(this.cgi, "cgi");
            this.cgi.Name = "cgi";
            // 
            // tcuotas
            // 
            this.tcuotas.DataPropertyName = "tcuotas";
            resources.ApplyResources(this.tcuotas, "tcuotas");
            this.tcuotas.Name = "tcuotas";
            // 
            // importeC
            // 
            this.importeC.DataPropertyName = "importeC";
            resources.ApplyResources(this.importeC, "importeC");
            this.importeC.Name = "importeC";
            // 
            // asm
            // 
            this.asm.DataPropertyName = "asm";
            resources.ApplyResources(this.asm, "asm");
            this.asm.Name = "asm";
            // 
            // afp
            // 
            this.afp.DataPropertyName = "afp";
            resources.ApplyResources(this.afp, "afp");
            this.afp.Name = "afp";
            // 
            // acp
            // 
            this.acp.DataPropertyName = "acp";
            resources.ApplyResources(this.acp, "acp");
            this.acp.Name = "acp";
            // 
            // apren
            // 
            this.apren.DataPropertyName = "apren";
            resources.ApplyResources(this.apren, "apren");
            this.apren.Name = "apren";
            // 
            // asv
            // 
            this.asv.DataPropertyName = "asv";
            resources.ApplyResources(this.asv, "asv");
            this.asv.Name = "asv";
            // 
            // asr
            // 
            this.asr.DataPropertyName = "asr";
            resources.ApplyResources(this.asr, "asr");
            this.asr.Name = "asr";
            // 
            // agi
            // 
            this.agi.DataPropertyName = "agi";
            resources.ApplyResources(this.agi, "agi");
            this.agi.Name = "agi";
            // 
            // afovi
            // 
            this.afovi.DataPropertyName = "afovi";
            resources.ApplyResources(this.afovi, "afovi");
            this.afovi.Name = "afovi";
            // 
            // apm
            // 
            this.apm.DataPropertyName = "apm";
            resources.ApplyResources(this.apm, "apm");
            this.apm.Name = "apm";
            // 
            // aaf
            // 
            this.aaf.DataPropertyName = "aaf";
            resources.ApplyResources(this.aaf, "aaf");
            this.aaf.Name = "aaf";
            // 
            // aig
            // 
            this.aig.DataPropertyName = "aig";
            resources.ApplyResources(this.aig, "aig");
            this.aig.Name = "aig";
            // 
            // aga
            // 
            this.aga.DataPropertyName = "aga";
            resources.ApplyResources(this.aga, "aga");
            this.aga.Name = "aga";
            // 
            // taporta
            // 
            this.taporta.DataPropertyName = "taporta";
            resources.ApplyResources(this.taporta, "taporta");
            this.taporta.Name = "taporta";
            // 
            // importeA
            // 
            this.importeA.DataPropertyName = "importeA";
            resources.ApplyResources(this.importeA, "importeA");
            this.importeA.Name = "importeA";
            // 
            // tasa
            // 
            this.tasa.DataPropertyName = "tasa";
            resources.ApplyResources(this.tasa, "tasa");
            this.tasa.Name = "tasa";
            // 
            // tmoratorio
            // 
            this.tmoratorio.DataPropertyName = "tmoratorio";
            resources.ApplyResources(this.tmoratorio, "tmoratorio");
            this.tmoratorio.Name = "tmoratorio";
            // 
            // tmes
            // 
            this.tmes.DataPropertyName = "tmes";
            resources.ApplyResources(this.tmes, "tmes");
            this.tmes.Name = "tmes";
            // 
            // TasaCalculada
            // 
            this.TasaCalculada.DataPropertyName = "TasaCalculada";
            resources.ApplyResources(this.TasaCalculada, "TasaCalculada");
            this.TasaCalculada.Name = "TasaCalculada";
            // 
            // genera
            // 
            this.genera.DataPropertyName = "generacion";
            resources.ApplyResources(this.genera, "genera");
            this.genera.Name = "genera";
            // 
            // interi
            // 
            this.interi.DataPropertyName = "interinato";
            resources.ApplyResources(this.interi, "interi");
            this.interi.Name = "interi";
            // 
            // activo
            // 
            this.activo.DataPropertyName = "activo";
            resources.ApplyResources(this.activo, "activo");
            this.activo.Name = "activo";
            // 
            // cbLocalidad
            // 
            resources.ApplyResources(this.cbLocalidad, "cbLocalidad");
            this.cbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.chkInterinato.CheckedChanged += new System.EventHandler(this.chkInterinato_CheckedChanged);
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
            // btnBorrar
            // 
            resources.ApplyResources(this.btnBorrar, "btnBorrar");
            this.btnBorrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnBuscar
            // 
            resources.ApplyResources(this.btnBuscar, "btnBuscar");
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmOmisiones
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnBorrar);
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
        private System.Windows.Forms.ComboBox cbLocalidad;
        private System.Windows.Forms.DateTimePicker dtUltimaTasa;
        private System.Windows.Forms.CheckBox chkInterinato;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidoMa;
        private System.Windows.Forms.CheckBox chkUltimaTasa;
        private System.Windows.Forms.ListBox lstTipo;
        private System.Windows.Forms.ListBox lstDe;
        private System.Windows.Forms.ListBox lstHasta;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.DataGridView dgDatos;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn sueldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoCobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesOmitido;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesCalculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn idOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organismo;
        private System.Windows.Forms.DataGridViewTextBoxColumn csm;
        private System.Windows.Forms.DataGridViewTextBoxColumn cfp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccp;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpren;
        private System.Windows.Forms.DataGridViewTextBoxColumn csv;
        private System.Windows.Forms.DataGridViewTextBoxColumn csr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cgi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcuotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeC;
        private System.Windows.Forms.DataGridViewTextBoxColumn asm;
        private System.Windows.Forms.DataGridViewTextBoxColumn afp;
        private System.Windows.Forms.DataGridViewTextBoxColumn acp;
        private System.Windows.Forms.DataGridViewTextBoxColumn apren;
        private System.Windows.Forms.DataGridViewTextBoxColumn asv;
        private System.Windows.Forms.DataGridViewTextBoxColumn asr;
        private System.Windows.Forms.DataGridViewTextBoxColumn agi;
        private System.Windows.Forms.DataGridViewTextBoxColumn afovi;
        private System.Windows.Forms.DataGridViewTextBoxColumn apm;
        private System.Windows.Forms.DataGridViewTextBoxColumn aaf;
        private System.Windows.Forms.DataGridViewTextBoxColumn aig;
        private System.Windows.Forms.DataGridViewTextBoxColumn aga;
        private System.Windows.Forms.DataGridViewTextBoxColumn taporta;
        private System.Windows.Forms.DataGridViewTextBoxColumn importeA;
        private System.Windows.Forms.DataGridViewTextBoxColumn tasa;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmoratorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmes;
        private System.Windows.Forms.DataGridViewTextBoxColumn TasaCalculada;
        private System.Windows.Forms.DataGridViewTextBoxColumn genera;
        private System.Windows.Forms.DataGridViewTextBoxColumn interi;
        private System.Windows.Forms.DataGridViewTextBoxColumn activo;
    }
}

