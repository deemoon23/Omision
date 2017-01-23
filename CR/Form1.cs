using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CR
{
    public partial class frmHome : Form
    {
        private bool _TypedInto;

        Modelo._Modelo ctx = new Modelo._Modelo();
        Modelo.Omisiones Omi = new Modelo.Omisiones();
        Modelo.organismos org = new Modelo.organismos();
        Modelo.localidades loc = new Modelo.localidades();
        Modelo.tasasOmisiones tasas = new Modelo.tasasOmisiones();
        Modelo.tasasOmisionesInterinato tasasInter = new Modelo.tasasOmisionesInterinato();
        Modelo.cat_organismos2 catOrg = new Modelo.cat_organismos2();
        char generacion='X';
        bool interinato = false;
        int idLocalidad=0;
        string strlocalidad = "";
        int idOrganismo = 0;
        string strOrganismo = "";
        string empleado = "";
        string elaboro = "";

        public frmHome()
        {
            InitializeComponent();
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnVistaP, "Vista Previa");
            ToolTip1.SetToolTip(this.btnGuardar, "Guardar");
            ToolTip1.SetToolTip(this.btnAbrir, "Abrir Omisión");
            ToolTip1.SetToolTip(this.btnRptGeneral, "Reporte General");



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbActual.Checked = true;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker2.CustomFormat = "MMMM yyyy";
            dtUltimaTasa.CustomFormat = "MMMM yyyy";
            dtUltimaTasa.MinDate = dateTimePicker2.Value.AddMonths(1);
            lstTipo.SelectedIndex = 0;
            lstDe.SelectedIndex = 0;
            lstHasta.SelectedIndex = 1;
            txtApellidoPa.Text = "Apellido Paterno";
            txtApellidoPa.ForeColor = Color.Gray;
            txtApellidoMa.Text = "Apellido Materno";
            txtApellidoMa.ForeColor = Color.Gray;
            txtNombre.Text = "Nombre";
            txtNombre.ForeColor = Color.Gray;
            txtSueldo.Text = "Sueldo";
            txtSueldo.ForeColor = Color.Gray;
            txtElaborada.Text = "Elabora";
            txtElaborada.ForeColor = Color.Gray;

            try
            {
                using (var ctx = new Modelo._Modelo())
                {


                    cbLocalidad.DataSource = loc.getAll();
                    cbLocalidad.DisplayMember = "DESCRIPCION";
                    cbLocalidad.ValueMember = "codigo";
                    cbOrganismos.DataSource = org.getAll();
                    cbLocalidad.Text = "LOCALIDAD";
                    cbOrganismos.Text = "ORGANISMOS";
                    cbOrganismos.DisplayMember = "DESCRIPCION";
                    cbOrganismos.ValueMember = "codigo";
                    dgTasas.DataSource = ctx.tasasOmisiones.Select(r => new { r.fecha, r.tasa }).OrderByDescending(r => r.fecha).ToList();


                    //
                    DateTime fechaHoyAux = DateTime.Today;
                    DateTime fechaHoy = new DateTime(fechaHoyAux.Year, fechaHoyAux.Month, 1);
                    Modelo.tasasOmisiones ultimaFechaTemp = tasas.getUltimaTasa();
                    DateTime ultimaFecha = new DateTime(ultimaFechaTemp.fecha.Year, ultimaFechaTemp.fecha.Month, 1);

                    if (ultimaFecha < fechaHoy)
                    {

                        lblFecha.BackColor = Color.Red;


                    }

                    lblFecha.Text = tasas.getUltimaTasa().fecha.AddDays(1).ToString("MMMM yyyy").ToUpper();


                    //
                }
            }
            catch (Exception) { throw; }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            var lstTasa = tasas.getLstTasas(dateTimePicker1.Value, dateTimePicker2.Value);
            if (rbActual.Checked == true)
            {
                generacion = 'A';
            }
            else
            {
                generacion = 'F';
            }
            interinato = chkInterinato.Checked;
            if (lstTipo.SelectedIndex == 1)
            {
                int De = lstDe.SelectedIndex;
                int Hasta = lstHasta.SelectedIndex;
                if (lstDe.SelectedIndex == 1) { De = 2; } else { De = 1; }
                if (lstHasta.SelectedIndex == 1) { Hasta = 2; } else { Hasta = 1; }

                lstTasa = tasas.getLstTasas(dateTimePicker1.Value, dateTimePicker2.Value, De, Hasta);
            }


            //      dgDatos.Rows.Clear();
            string TipoGenera;
            if (rbActual.Checked == true)
            {
                TipoGenera = "A";
            }
            else
            {
                TipoGenera = "F";
            }
            Modelo.localidades localidad = loc.getByDescripcion(cbLocalidad.Text);
            Modelo.organismos organismo = org.getByDescripcion(cbOrganismos.Text);
            //DATOS DEL ORGANISMO
            Dictionary<int, Modelo.cat_organismos2> datos = catOrg.getData(localidad, organismo, TipoGenera, dateTimePicker1.Value, dateTimePicker2.Value);

            //
            Modelo.DatagGridView dgv = new Modelo.DatagGridView();
            dgv.generarGrid(dgDatos,true);
            if (chkUltimaTasa.Checked == true)
            {
                dgv.llenarGrid(lstTasa, Convert.ToDouble(txtSueldo.Text), datos, dgDatos, chkInterinato.Checked, dtUltimaTasa.Value, Convert.ToInt32(lstTipo.SelectedIndex));

            }
            else
            {
                dgv.llenarGrid(lstTasa, Convert.ToDouble(txtSueldo.Text), datos, dgDatos, chkInterinato.Checked, Convert.ToInt32(lstTipo.SelectedIndex));
            }

            empleado= txtApellidoPa.Text.Trim() + " " + txtApellidoMa.Text.Trim() + " " + txtNombre.Text.Trim();
            idLocalidad = localidad.codigo;
            strlocalidad = localidad.descripcion;
            idOrganismo = organismo.codigo;
            strOrganismo = organismo.descripcion;
            elaboro = txtElaborada.Text.Trim();
            //





        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //PRUEBA || TODO CREAR UN NUEVO OBJETO CON LA NUEVA FECHA* || IMPLEMENTARLO
            DateTime prueba = new DateTime(2016, 12, 1);
            DateTime prueba2 = new DateTime();
            if (prueba.Month == 12)
            {
                prueba2 = new DateTime(prueba.Year + 1, 1, 1);
            }

            MessageBox.Show(prueba2.Year.ToString());

            //
            Modelo.tasasOmisiones nuevo = new Modelo.tasasOmisiones();
            DateTime fechaHoyAux = DateTime.Today;
            Modelo.tasasOmisiones ultimaFechaTemp = tasas.getUltimaTasa();
            nuevo.fecha = new DateTime(ultimaFechaTemp.fecha.Year, ultimaFechaTemp.fecha.Month + 1, 1);
            nuevo.tasa = Convert.ToDecimal(txtInteres.Text.Trim());

            var ctx = new Modelo._Modelo();
            ctx.tasasOmisiones.Add(nuevo);
            ctx.SaveChanges();


            //AGREGAR A UNA CLASE
            DateTime fechaHoy = new DateTime(fechaHoyAux.Year, fechaHoyAux.Month, 1);
            DateTime ultimaFecha = new DateTime(ultimaFechaTemp.fecha.Year, ultimaFechaTemp.fecha.Month, 1);

            if (ultimaFecha < fechaHoy)
            {

                lblFecha.BackColor = Color.Red;


            }

            lblFecha.Text = tasas.getUltimaTasa().fecha.AddDays(1).ToString("MMMM yyyy").ToUpper();


            //

        }

        private void chkUltimaTasa_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUltimaTasa.Checked == true)
            {
                dtUltimaTasa.Enabled = true;
            }
            else
            {
                dtUltimaTasa.Enabled = false;
            }
        }

        private void lstTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTipo.SelectedIndex == 1)
            {
                lstDe.Enabled = true;
                lstHasta.Enabled = true;
            }
            else
            {
                lstDe.Enabled = false;
                lstHasta.Enabled = false;
            }

        }

        #region TextBox
        private void txtEmpleado_TextChanged(object sender, EventArgs e)
        {
            _TypedInto = !String.IsNullOrEmpty(txtApellidoPa.Text);

            if (_TypedInto) { txtApellidoPa.ForeColor = Color.Black; }

        }


        private void txtEmpleado_Click(object sender, EventArgs e)
        {
            if (txtApellidoPa.ForeColor == Color.Gray)
            {
                txtApellidoPa.Text = "";
            }

        }

        private void txtEmpleado_Leave(object sender, EventArgs e)
        {
            if (txtApellidoPa.Text.Count() == 0)
            {
                txtApellidoPa.Text = "Apellido Paterno";
                txtApellidoPa.ForeColor = Color.Gray;
            }
        }

        private void txtSueldo_TextChanged(object sender, EventArgs e)
        {
            _TypedInto = !String.IsNullOrEmpty(txtSueldo.Text);

            if (_TypedInto) { txtSueldo.ForeColor = Color.Black; }

        }

        private void txtSueldo_Click(object sender, EventArgs e)
        {
            if (txtSueldo.ForeColor == Color.Gray)
            {
                txtSueldo.Text = "";
            }
        }

        private void txtSueldo_Leave(object sender, EventArgs e)
        {
            if (txtSueldo.Text.Count() == 0)
            {
                txtSueldo.Text = "Sueldo";
                txtSueldo.ForeColor = Color.Gray;
            }
        }

        private void txtElaborada_TextChanged(object sender, EventArgs e)
        {
            _TypedInto = !String.IsNullOrEmpty(txtElaborada.Text);

            if (_TypedInto) { txtElaborada.ForeColor = Color.Black; }
        }

        private void txtElaborada_Click(object sender, EventArgs e)
        {
            if (txtElaborada.ForeColor == Color.Gray)
            {
                txtElaborada.Text = "";
            }
        }

        private void txtElaborada_Leave(object sender, EventArgs e)
        {
            if (txtElaborada.Text.Count() == 0)
            {
                txtElaborada.Text = "Elabora";
                txtElaborada.ForeColor = Color.Gray;
            }
        }
        #endregion



        private void txtNombre_Click(object sender, EventArgs e)
        {
            if (txtNombre.ForeColor == Color.Gray)
            {
                txtNombre.Text = "";
            }

        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text.Count() == 0)
            {
                txtNombre.Text = "Nombre";
                txtNombre.ForeColor = Color.Gray;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            _TypedInto = !String.IsNullOrEmpty(txtNombre.Text);

            if (_TypedInto) { txtNombre.ForeColor = Color.Black; }
        }

        private void txtApellidoMa_TextChanged(object sender, EventArgs e)
        {
            _TypedInto = !String.IsNullOrEmpty(txtApellidoMa.Text);

            if (_TypedInto) { txtApellidoMa.ForeColor = Color.Black; }
        }

        private void txtApellidoMa_Click(object sender, EventArgs e)
        {
            if (txtApellidoMa.ForeColor == Color.Gray)
            { txtApellidoMa.Text = "";

            }
        }

        private void txtApellidoMa_Leave(object sender, EventArgs e)
        {
            if (txtApellidoMa.Text.Count() == 0)
            {
                txtApellidoMa.Text = "Apellido Materno";
                txtApellidoMa.ForeColor = Color.Gray;
            }
        }

        private void btnVistaP_Click(object sender, EventArgs e)
        {

            DataSet1 dt = new DataSet1();
            DataSet1.dtInfoRow dato = dt.dtInfo.NewdtInfoRow();
            dato.Elaboro = elaboro;
            dato.Empleado = empleado;
            dato.idLocalidad = idLocalidad.ToString();
            dato.Localidad = strlocalidad;
            dato.idOrganismo = idOrganismo.ToString();
            dato.Organismo = strOrganismo;
            dt.dtInfo.AdddtInfoRow(dato);
            foreach (DataGridViewRow r in dgDatos.Rows)
            {

                if (r.Cells[0].Value != null && Convert.ToDouble(r.Cells[31].Value) != 0)
                {
                    DataSet1.dtOmisionRow row = dt.dtOmision.NewdtOmisionRow();
                    row.Sueldo = Convert.ToDouble(Convert.ToDouble(r.Cells[0].Value));
                    row.Mes_Omitido = Convert.ToString(r.Cells[1].Value);
                    row._S_M = Convert.ToDouble(Convert.ToDouble(r.Cells[4].Value));
                    row._G_I = Convert.ToDouble(Convert.ToDouble(r.Cells[5].Value));
                    row._F_P = Convert.ToDouble(Convert.ToDouble(r.Cells[6].Value));
                    row._C_P = Convert.ToDouble(Convert.ToDouble(r.Cells[7].Value));                   
                    row._Pren_ = Convert.ToDouble(r.Cells[8].Value);                    
                    var uno = Convert.ToDouble(r.Cells[9].Value);
                    var dos = Convert.ToDouble(r.Cells[9].Value);
                    var tres = Convert.ToDouble(Convert.ToDouble(r.Cells[9].Value));
                    row._S_V = Convert.ToDouble(Convert.ToDouble(r.Cells[9].Value));
                    row._S_R = Convert.ToDouble(Convert.ToDouble(r.Cells[10].Value));
                    row._T__Cuotas = Convert.ToDouble(Convert.ToDouble(r.Cells[11].Value));
                    row._a_S_M = Convert.ToDouble(Convert.ToDouble(r.Cells[14].Value));
                    row._a_G_I = Convert.ToDouble(Convert.ToDouble(r.Cells[15].Value));
                    row._a_F_P = Convert.ToDouble(Convert.ToDouble(r.Cells[16].Value));
                    row._a_C_P = Convert.ToDouble(Convert.ToDouble(r.Cells[17].Value));
                    row._a_Pren_ = Convert.ToDouble(Convert.ToDouble(r.Cells[18].Value));                                   
                    row._a_I_G = Convert.ToDouble(Convert.ToDouble(r.Cells[19].Value));                  
                    row._a_A_F = Convert.ToDouble(Convert.ToDouble(r.Cells[20].Value));                    
                    row._a_G_A = Convert.ToDouble(r.Cells[21].Value);                    
                    row._a_FOVI_ = Convert.ToDouble(Convert.ToDouble(r.Cells[22].Value));                   
                    row._a_P_M = Convert.ToDouble(Convert.ToDouble(r.Cells[23].Value));                    
                    row._a_S_V = Convert.ToDouble(Convert.ToDouble(r.Cells[24].Value));
                    row._a_S_R = Convert.ToDouble(Convert.ToDouble(r.Cells[25].Value));
                    row._T__Aportaciones = Convert.ToDouble(Convert.ToDouble(r.Cells[26].Value));
                    string tasa = r.Cells[13].Value.ToString().Substring(0, r.Cells[13].Value.ToString().Count() - 1);
                    row.Tasa = Convert.ToDouble(Convert.ToDouble(tasa));
                    row._Mora__Cuotas = Convert.ToDouble(Convert.ToDouble(r.Cells[13].Value));
                    row._Mora__Aporta_ = Convert.ToDouble(Convert.ToDouble(r.Cells[28].Value));
                    row.Total_Moratorio = Convert.ToDouble(Convert.ToDouble(r.Cells[30].Value));
                    row.Total_Mes = Convert.ToDouble(Convert.ToDouble(r.Cells[31].Value));
                    dt.dtOmision.AdddtOmisionRow(row);

                }
                if (r.Cells[0].Value != null && Convert.ToDouble(r.Cells[31].Value) == 0)
                {
                    DataSet1.dtOmisionRow row = dt.dtOmision.NewdtOmisionRow();
                    row.Sueldo = Convert.ToDouble(Convert.ToDouble(r.Cells[0].Value));
                    row.Mes_Omitido = Convert.ToString(r.Cells[1].Value);
                    row._S_M = 0;
                    row._G_I = 0;
                    row._F_P = 0;
                    row._C_P = 0;
                    row._Pren_ = 0;
                   // var uno = Convert.ToDouble(r.Cells[9].Value);
                    //var dos = Convert.ToDouble(r.Cells[9].Value);
                    //var tres = Convert.ToDouble(Convert.ToDouble(r.Cells[9].Value));
                    row._S_V = 0;
                    row._S_R = 0;
                    row._T__Cuotas = 0;
                    row._a_S_M = 0;
                    row._a_G_I = 0;
                    row._a_F_P = 0;
                    row._a_C_P = 0;
                    row._a_Pren_ = 0;
                    row._a_I_G = 0;
                    row._a_A_F = 0;
                    row._a_G_A = 0;
                    row._a_FOVI_ = 0;
                    row._a_P_M = 0;
                    row._a_S_V = 0;
                    row._a_S_R = 0;
                    row._T__Aportaciones = 0;
                    
                    row.Tasa = 0;
                    row._Mora__Cuotas = 0;
                    row._Mora__Aporta_ = 0;
                    row.Total_Moratorio = 0;
                    row.Total_Mes = 0;
                    dt.dtOmision.AdddtOmisionRow(row);

                }
            }
            frmVistaPrevia a = new frmVistaPrevia(dt);
            a.ShowDialog();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dtUltimaTasa.MinDate = dateTimePicker2.Value.AddMonths(1);
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                //row._S_M = Convert.ToDouble(Convert.ToDouble(r.Cells[4].Value).ToString("#.##"));
                if (Convert.ToDouble(row.Cells[0].Value) != 0)
                {

                    Omi.nombre = txtNombre.Text.Trim();
                    Omi.apellidoP = txtApellidoPa.Text.Trim();
                    Omi.apellidoM = txtApellidoMa.Text.Trim();
                    Omi.sueldo = Convert.ToDecimal(row.Cells[0].Value);
                    Omi.mesOmitido = Convert.ToDateTime(row.Cells[33].Value);
                    Omi.mesCalculo = DateTime.Today;
                    Omi.folio = txtElaborada.Text.Trim();
                    if (lstTipo.SelectedIndex == 0)
                    {
                        Omi.tipoCobro = "M";
                    }
                    else
                    {

                        Omi.tipoCobro = row.Cells[1].Value.ToString().Substring(0, 2);
                    }
                    Omi.idLoc = Convert.ToInt32(cbLocalidad.SelectedValue);
                    Omi.Localidad = cbLocalidad.Text.ToString();
                    Omi.idOrg = Convert.ToInt32(cbOrganismos.SelectedValue);
                    Omi.Organismo = cbOrganismos.Text.ToString();
                    Omi.csm = Convert.ToDecimal(row.Cells[4].Value.ToString());
                    Omi.ccp = Convert.ToDecimal(row.Cells[7].Value.ToString());
                    Omi.cfp = Convert.ToDecimal(row.Cells[6].Value.ToString());
                    Omi.cpren = Convert.ToDecimal(row.Cells[8].Value.ToString());
                    Omi.csv = Convert.ToDecimal(row.Cells[9].Value.ToString());
                    Omi.csr = Convert.ToDecimal(row.Cells[10].Value.ToString());
                    Omi.cgi = Convert.ToDecimal(row.Cells[5].Value.ToString());
                    Omi.tcuotas = Convert.ToDecimal(row.Cells[11].Value.ToString());
                    Omi.importeC = Convert.ToDecimal(row.Cells[13].Value.ToString());
                    Omi.asm = Convert.ToDecimal(row.Cells[14].Value.ToString());
                    Omi.afp = Convert.ToDecimal(row.Cells[16].Value.ToString());
                    Omi.acp = Convert.ToDecimal(row.Cells[17].Value.ToString());
                    Omi.apren = Convert.ToDecimal(row.Cells[18].Value.ToString());
                    Omi.asv = Convert.ToDecimal(row.Cells[24].Value.ToString());
                    Omi.asr = Convert.ToDecimal(row.Cells[25].Value.ToString());
                    Omi.agi = Convert.ToDecimal(row.Cells[15].Value.ToString());
                    Omi.afovi = Convert.ToDecimal(row.Cells[23].Value.ToString());
                    Omi.apm = Convert.ToDecimal(row.Cells[22].Value.ToString());
                    Omi.aaf = Convert.ToDecimal(row.Cells[20].Value.ToString());
                    Omi.aig = Convert.ToDecimal(row.Cells[19].Value.ToString());
                    Omi.aga = Convert.ToDecimal(row.Cells[21].Value.ToString());
                    Omi.taporta = Convert.ToDecimal(row.Cells[26].Value.ToString());
                    Omi.importeA = Convert.ToDecimal(row.Cells[28].Value.ToString());

                    Omi.tasa = Convert.ToDecimal(row.Cells[27].Value.ToString().Substring(0, row.Cells[27].Value.ToString().Count() - 1));
                    Omi.tmoratorio = Convert.ToDecimal(row.Cells[30].Value.ToString());
                    Omi.tmes = Convert.ToDecimal(row.Cells[31].Value.ToString());
                    Omi.TasaCalculada = Convert.ToDateTime(row.Cells[32].Value.ToString());
                    Omi.generacion = generacion.ToString();
                    Omi.interinato = interinato;
                    ctx.Omisiones.Add(Omi);
                    ctx.SaveChanges();

                    //Omi.mesOmitido;
                }

            }
            //if (ctx.SaveChanges() > 0)
            //{
            //    MessageBox.Show("Omision guardada.");
            //}

        }

        private void txtAbrir_Click(object sender, EventArgs e)
        {

            frmAbrirOmision frmAbrir = new frmAbrirOmision();
            frmAbrir.ShowDialog();
            string nombre = frmAbrir.nombre;
            string apellidoP = frmAbrir.apellidoP;
            string apellidoM = frmAbrir.apelidoM;
            dgDatos.Columns.Clear();
            dgDatos.DataSource = Omi.getOmision(nombre, apellidoP, apellidoM);

            this.dgDatos.Columns[0].Visible = false;
            this.dgDatos.Columns[6].Visible = false;
            this.dgDatos.Columns[8].Visible = false;

            dgDatos.Columns[37].DisplayIndex = 2;
            dgDatos.Columns[38].DisplayIndex = 3;
            dgDatos.Columns[39].DisplayIndex = 4;
            dgDatos.Columns[7].DisplayIndex = 5;
            dgDatos.Columns[9].DisplayIndex = 6;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReporteGeneral frmRpt = new frmReporteGeneral();
            frmRpt.Show();

        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            int i = 0;

            List<double> sueldos = new List<double>();
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                sueldos.Add(Convert.ToDouble(dgDatos.Rows[i].Cells[1].Value));
                i++;
            }
            //1 Sueldo
            DateTime de = Convert.ToDateTime(dgDatos.Rows[0].Cells[2].Value);
            DateTime hasta = Convert.ToDateTime(dgDatos.Rows[dgDatos.Rows.Count - 1].Cells[2].Value);
            double sueldo = Convert.ToDouble(dgDatos.Rows[0].Cells[1].Value);
            
            var lstTasa = tasas.getLstTasas(de, hasta);

            if (lstTipo.SelectedIndex == 1)
            {
                int q1 = Convert.ToInt32(dgDatos.Rows[0].Cells[5].Value);
                int q2 = Convert.ToInt32(dgDatos.Rows[dgDatos.Rows.Count - 1].Cells[5].Value);


                lstTasa = tasas.getLstTasas(de, hasta, q1, q2);

            }
            string generacion = dgDatos.Rows[0].Cells[40].Value.ToString();
            bool interinato = Convert.ToBoolean(dgDatos.Rows[0].Cells[41].Value.ToString());
            Modelo.localidades localidad = loc.getByDescripcion(dgDatos.Rows[0].Cells[7].Value.ToString().Trim());
            Modelo.organismos organismo = org.getByDescripcion(dgDatos.Rows[0].Cells[9].Value.ToString().Trim());
            //DATOS DEL ORGANISMO
            Dictionary<int, Modelo.cat_organismos2> datos = catOrg.getData(localidad, organismo, generacion, de, hasta);

            Modelo.DatagGridView dgv = new Modelo.DatagGridView();
            dgv.generarGrid(dgDatos, false);
                dgv.llenarGrid(lstTasa, sueldos, datos, dgDatos, interinato, Convert.ToInt32(lstTipo.SelectedIndex));
            MessageBox.Show("exito");



        }
    }
}
