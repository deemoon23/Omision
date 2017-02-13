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
using System.Diagnostics;
using System.Configuration;

namespace CR
{
    public partial class frmOmisiones : Form
    {
        private bool _TypedInto;

        Modelo.mIngresos ctx = new Modelo.mIngresos();
        Modelo.Omisiones Omi = new Modelo.Omisiones();
        Modelo.organismos org = new Modelo.organismos();
        Modelo.localidades loc = new Modelo.localidades();
        Modelo.tasasOmisiones tasas = new Modelo.tasasOmisiones();
        Modelo.tasasOmisionesInterinato tasasInter = new Modelo.tasasOmisionesInterinato();
        Modelo.cat_organismos2 catOrg = new Modelo.cat_organismos2();
        char generacion = 'X';
        double oldvalue = 0;
        private bool _inCellValueChanged = false;

        bool interinato = false, flag = false, guardado = false, recalculado = false, abierto = false;
        int idLocalidad = 0, idOrganismo = 0;
        string strlocalidad = "", strOrganismo = "", empleado = "", elaboro = "";
        List<int> id = new List<int>();
        public frmOmisiones()
        {
            InitializeComponent();
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnVistaP, "Vista Previa");
            ToolTip1.SetToolTip(this.btnGuardar, "Guardar");
            ToolTip1.SetToolTip(this.btnAbrir, "Abrir Omisión");
            ToolTip1.SetToolTip(this.btnRptGeneral, "Reporte General");
            dateTimePicker2.Value = dateTimePicker1.Value;
            Modelo.DatagGridView dg = new Modelo.DatagGridView();

            dgDatos.AutoGenerateColumns = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dgDatos.Sort(this.dgDatos.Columns["mesOmitido"], ListSortDirection.Ascending);
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
                using (var ctx = new Modelo.mIngresos())
                {
                    List<Modelo.organismos> lstORG = org.getAll();
                    List<Modelo.localidades> lstLOC = loc.getAll();
                    lstORG.RemoveAt(0);
                    lstLOC.RemoveAt(0);

                    cbLocalidad.DataSource = lstLOC;
                    cbLocalidad.DisplayMember = "DESCRIPCION";
                    cbLocalidad.ValueMember = "codigo";
                    cbOrganismos.DataSource = lstORG;
                    cbOrganismos.DisplayMember = "descripcion";
                    cbOrganismos.ValueMember = "codigo";
                

                    dgTasas.DataSource = ctx.tasasOmisiones.Select(r => new { r.fecha, r.tasa }).OrderByDescending(r => r.fecha).ToList();


                    //
                    Modelo.tasasOmisiones ultimaFechaTemp = tasas.getUltimaTasa();
                    DateTime ultimaFecha = new DateTime(ultimaFechaTemp.fecha.Year, ultimaFechaTemp.fecha.Month, 1);
                    var XXX = ultimaFecha.Month + ultimaFecha.Year * 12;
                    var zzz = DateTime.Now.Year * 12 + DateTime.Now.Month;
                    if ((ultimaFecha.Month + ultimaFecha.Year * 12) < (DateTime.Now.Year * 12 + DateTime.Now.Month))
                    {

                        lblFecha.BackColor = Color.Red;


                    }
                    else
                    {
                        lblFecha.BackColor = Color.LightGreen;
                    }

                    lblFecha.Text = tasas.getUltimaTasa().fecha.AddMonths(1).ToString("MMMM yyyy").ToUpper();


                    //
                }
            }
            catch (Exception) { throw; }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            decimal sueldo;
            if (decimal.TryParse(txtSueldo.Text.Trim(), out sueldo) && txtNombre.Text.Trim() != "Nombre" && txtNombre.Text.Trim().Count() >2 && txtApellidoMa.Text!="Apellido Materno" && txtApellidoMa.Text.Trim().Count() >2 && txtApellidoPa.Text != "Apellido Paterno" && txtApellidoPa.Text.Trim().Count() > 2 && cbLocalidad.SelectedValue.ToString()!="0" && cbOrganismos.SelectedValue.ToString()!="0")
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
                dgv.generarGrid(dgDatos, true, flag);
                if (chkUltimaTasa.Checked == true)
                {
                    dgv.llenarGrid(lstTasa, Convert.ToDecimal(txtSueldo.Text), datos, dgDatos, chkInterinato.Checked, dtUltimaTasa.Value, Convert.ToInt32(lstTipo.SelectedIndex), txtApellidoPa.Text, txtApellidoMa.Text, txtNombre.Text, Convert.ToInt32(cbOrganismos.SelectedValue), Convert.ToInt32(cbLocalidad.SelectedValue), txtElaborada.Text.Trim(), TipoGenera);

                }
                else
                {
                    dgv.llenarGrid(lstTasa, Convert.ToDecimal(txtSueldo.Text), datos, dgDatos, chkInterinato.Checked, Convert.ToInt32(lstTipo.SelectedIndex), abierto, txtApellidoPa.Text, txtApellidoMa.Text, txtNombre.Text, Convert.ToInt32(cbOrganismos.SelectedValue), Convert.ToInt32(cbLocalidad.SelectedValue), txtElaborada.Text.Trim(), TipoGenera);
                }

                empleado = txtApellidoPa.Text.Trim() + " " + txtApellidoMa.Text.Trim() + " " + txtNombre.Text.Trim();
                idLocalidad = localidad.codigo;
                strlocalidad = localidad.descripcion;
                idOrganismo = organismo.codigo;
                strOrganismo = organismo.descripcion;
                elaboro = txtElaborada.Text.Trim();
                this.dgDatos.Sort(this.dgDatos.Columns["mesOmitido"], ListSortDirection.Ascending);

                //




            }
            else
            {
                MessageBox.Show("Rellene los datos, todos los campos son requeridos");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Modelo.tasasOmisiones nuevo = new Modelo.tasasOmisiones();
            Modelo.tasasOmisiones ultimaFechaTemp = tasas.getUltimaTasa();

            if (txtInteres.Text.Trim() != "")
            {
                DateTime fechaHoyAux = DateTime.Today;
                if (ultimaFechaTemp.fecha.Month == 12)
                {
                    int año = ultimaFechaTemp.fecha.Year + 1;
                    fechaHoyAux = new DateTime(año, 1, 1, 0, 0, 0);
                }
                else
                {
                    fechaHoyAux = new DateTime(ultimaFechaTemp.fecha.Year, ultimaFechaTemp.fecha.Month + 1, 1, 0, 0, 0);
                }
                nuevo.fecha = fechaHoyAux;
                nuevo.tasa = Convert.ToDecimal(txtInteres.Text.Trim());
                var ctx = new Modelo.mIngresos();
                ctx.tasasOmisiones.Add(nuevo);
                ctx.SaveChanges();
                dgTasas.DataSource = ctx.tasasOmisiones.Select(r => new { r.fecha, r.tasa }).OrderByDescending(r => r.fecha).ToList();
                if (fechaHoyAux.Month + fechaHoyAux.Year * 12 < DateTime.Now.Year * 12 + DateTime.Now.Month)
                {
                    lblFecha.BackColor = Color.Red;
                }
                else
                {
                    lblFecha.BackColor = Color.LightGreen;
                }
                lblFecha.Text = tasas.getUltimaTasa().fecha.AddMonths(1).ToString("MMMM yyyy").ToUpper();
                statusStrip1.Items[0].Text = "Tasa agregada exitosamente.";
                statusStrip1.Items[0].ForeColor = Color.ForestGreen;
                timer1.Start();


            }
            else
            {
                MessageBox.Show("Ingrese una tasa.");
            }

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

            if (_TypedInto)
            {
                txtApellidoPa.ForeColor = Color.Black;
            }

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
            {
                txtApellidoMa.Text = "";

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
        #endregion

        private void btnVistaP_Click(object sender, EventArgs e)
        {
            if (dgDatos.Rows.Count != 0)
            {
                DSOmisiones dt = new DSOmisiones();
                DSOmisiones.dtInfoRow dato = dt.dtInfo.NewdtInfoRow();
                if (flag == false)
                {
                    dato.Elaboro = elaboro;
                    dato.Empleado = empleado;
                    dato.idLocalidad = idLocalidad.ToString();
                    dato.Localidad = strlocalidad;
                    dato.idOrganismo = idOrganismo.ToString();
                    dato.Organismo = strOrganismo;
                    dt.dtInfo.AdddtInfoRow(dato);
                }
                else
                {
                    dato.Elaboro = dgDatos.Rows[0].Cells["folio"].Value.ToString();
                    dato.Empleado = dgDatos.Rows[0].Cells["apellidoP"].Value.ToString() + " " + dgDatos.Rows[0].Cells["apellidoM"].Value.ToString() + " " + dgDatos.Rows[0].Cells["nombre"].Value.ToString();
                    dato.idLocalidad = dgDatos.Rows[0].Cells["idLoc"].Value.ToString();
                    dato.Localidad = dgDatos.Rows[0].Cells["localidad"].Value.ToString();
                    dato.idOrganismo = dgDatos.Rows[0].Cells["idOrg"].Value.ToString();
                    dato.Organismo = dgDatos.Rows[0].Cells["organismo"].Value.ToString();
                    dt.dtInfo.AdddtInfoRow(dato);
                }
                foreach (DataGridViewRow r in dgDatos.Rows)
                {
                    if (r.Cells["ColumnID"].Value != null && Convert.ToDouble(r.Cells["tmes"].Value) != 0)
                    {
                        if (flag == false)
                        {
                            DSOmisiones.dtOmisionRow row = dt.dtOmision.NewdtOmisionRow();
                            row.Sueldo = Convert.ToDecimal(Convert.ToDouble(r.Cells["sueldo"].Value));
                            DateTime var = Convert.ToDateTime(r.Cells["mesOmitido"].Value);
                            string tipo = Convert.ToString(Convert.ToString(r.Cells["tipoCobro"].Value));
                            if (tipo == "M")
                            {
                                row.Mes_Omitido = var.ToString("yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                            }
                            else
                            {
                                if (r.Cells["tipoCobro"].Value.ToString()=="Q2")
                               // if (var.Minute == 1)
                                {
                                    row.Mes_Omitido = var.ToString("Q2 yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                                }
                                else
                                {
                                    row.Mes_Omitido = var.ToString("Q1 yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                                }
                            }
                            //                            row.Mes_Omitido = Convert.ToString(r.Cells["mesOmitido"].Value);
                            row._S_M = Convert.ToDecimal(Convert.ToDouble(r.Cells["csm"].Value));
                            row._G_I = Convert.ToDecimal(Convert.ToDouble(r.Cells["cgi"].Value));
                            row._F_P = Convert.ToDecimal(Convert.ToDouble(r.Cells["cfp"].Value));
                            row._C_P = Convert.ToDecimal(Convert.ToDouble(r.Cells["ccp"].Value));
                            row._Pren_ = Convert.ToDecimal(r.Cells["cpren"].Value);
                            row._S_V = Convert.ToDecimal(Convert.ToDouble(r.Cells["csv"].Value));
                            row._S_R = Convert.ToDecimal(Convert.ToDouble(r.Cells["csr"].Value));
                            row._T__Cuotas = Convert.ToDecimal(Convert.ToDouble(r.Cells["tcuotas"].Value));
                            row._a_S_M = Convert.ToDecimal(Convert.ToDouble(r.Cells["asm"].Value));
                            row._a_G_I = Convert.ToDecimal(Convert.ToDouble(r.Cells["agi"].Value));
                            row._a_F_P = Convert.ToDecimal(Convert.ToDouble(r.Cells["afp"].Value));
                            row._a_C_P = Convert.ToDecimal(Convert.ToDouble(r.Cells["acp"].Value));
                            row._a_Pren_ = Convert.ToDecimal(Convert.ToDouble(r.Cells["apren"].Value));
                            row._a_I_G = Convert.ToDecimal(Convert.ToDouble(r.Cells["aig"].Value));
                            row._a_A_F = Convert.ToDecimal(Convert.ToDouble(r.Cells["aaf"].Value));
                            row._a_G_A = Convert.ToDecimal(r.Cells["aga"].Value);
                            row._a_FOVI_ = Convert.ToDecimal(Convert.ToDouble(r.Cells["afovi"].Value));
                            row._a_P_M = Convert.ToDecimal(Convert.ToDouble(r.Cells["apm"].Value));
                            row._a_S_V = Convert.ToDecimal(Convert.ToDouble(r.Cells["asv"].Value));
                            row._a_S_R = Convert.ToDecimal(Convert.ToDouble(r.Cells["asr"].Value));
                            row._T__Aportaciones = Convert.ToDecimal(Convert.ToDouble(r.Cells["taporta"].Value));
                            string tasa = r.Cells["tasa"].Value.ToString();
                            //string tasa = r.Cells["tasa"].Value.ToString().Substring(0, r.Cells["tasa"].Value.ToString().Count() - 1);
                            string tasa2 = r.Cells["tasa"].Value.ToString();

                            row.Tasa = Convert.ToDouble(Convert.ToDouble(tasa));
                            row._Mora__Cuotas = Convert.ToDecimal(Convert.ToDouble(r.Cells["importeC"].Value));
                            row._Mora__Aporta_ = Convert.ToDecimal(Convert.ToDouble(r.Cells["importeA"].Value));
                            row.Total_Moratorio = Convert.ToDecimal(Convert.ToDouble(r.Cells["tmoratorio"].Value));
                            row.Total_Mes = Convert.ToDecimal(Convert.ToDecimal(r.Cells["tmes"].Value));
                            dt.dtOmision.AdddtOmisionRow(row);
                        }
                        else
                        {
                            DSOmisiones.dtOmisionRow row = dt.dtOmision.NewdtOmisionRow();
                            row.Sueldo = Convert.ToDecimal(Convert.ToDecimal(r.Cells["sueldo"].Value));
                            DateTime var = Convert.ToDateTime(r.Cells["mesOmitido"].Value);
                            string tipo = Convert.ToString(Convert.ToString(r.Cells["tipoCobro"].Value));
                            if (tipo == "M")
                            {
                                row.Mes_Omitido = var.ToString("yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                            }
                            else
                            {
                                if (r.Cells["tipoCobro"].Value.ToString() == "Q2")
                                // if (var.Minute == 1)
                                {
                                    row.Mes_Omitido = var.ToString("Q2 yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                                }
                                else
                                {
                                    row.Mes_Omitido = var.ToString("Q1 yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                                }
                            }
                            row._S_M = Convert.ToDecimal(Convert.ToDouble(r.Cells["csm"].Value));
                            row._G_I = Convert.ToDecimal(Convert.ToDouble(r.Cells["cgi"].Value));
                            row._F_P = Convert.ToDecimal(Convert.ToDouble(r.Cells["cfp"].Value));
                            row._C_P = Convert.ToDecimal(Convert.ToDouble(r.Cells["ccp"].Value));
                            row._Pren_ = Convert.ToDecimal(r.Cells["cpren"].Value);
                            row._S_V = Convert.ToDecimal(Convert.ToDouble(r.Cells["csv"].Value));
                            row._S_R = Convert.ToDecimal(Convert.ToDouble(r.Cells["csr"].Value));
                            row._T__Cuotas = Convert.ToDecimal(Convert.ToDouble(r.Cells["tcuotas"].Value));
                            row._a_S_M = Convert.ToDecimal(Convert.ToDouble(r.Cells["asm"].Value));
                            row._a_G_I = Convert.ToDecimal(Convert.ToDouble(r.Cells["agi"].Value));
                            row._a_F_P = Convert.ToDecimal(Convert.ToDouble(r.Cells["afp"].Value));
                            row._a_C_P = Convert.ToDecimal(Convert.ToDouble(r.Cells["acp"].Value));
                            row._a_Pren_ = Convert.ToDecimal(Convert.ToDouble(r.Cells["apren"].Value));
                            row._a_I_G = Convert.ToDecimal(Convert.ToDouble(r.Cells["aig"].Value));
                            row._a_A_F = Convert.ToDecimal(Convert.ToDouble(r.Cells["aaf"].Value));
                            row._a_G_A = Convert.ToDecimal(r.Cells["aga"].Value);
                            row._a_FOVI_ = Convert.ToDecimal(Convert.ToDouble(r.Cells["afovi"].Value));
                            row._a_P_M = Convert.ToDecimal(Convert.ToDouble(r.Cells["apm"].Value));
                            row._a_S_V = Convert.ToDecimal(Convert.ToDouble(r.Cells["asv"].Value));
                            row._a_S_R = Convert.ToDecimal(Convert.ToDouble(r.Cells["asr"].Value));
                            row._T__Aportaciones = Convert.ToDecimal(Convert.ToDouble(r.Cells["taporta"].Value));
                            string tasa = r.Cells["tasa"].Value.ToString().Substring(0, r.Cells["tasa"].Value.ToString().Count() - 1);
                            row.Tasa = Convert.ToDouble(Convert.ToDouble(tasa));
                            row._Mora__Cuotas = Convert.ToDecimal(Convert.ToDouble(r.Cells["importeC"].Value));
                            row._Mora__Aporta_ = Convert.ToDecimal(Convert.ToDouble(r.Cells["importeA"].Value));
                            row.Total_Moratorio = Convert.ToDecimal(Convert.ToDouble(r.Cells["tmoratorio"].Value));
                            row.Total_Mes = Convert.ToDecimal(Convert.ToDecimal(r.Cells["tmes"].Value));
                            dt.dtOmision.AdddtOmisionRow(row);
                        }
                    }
                    if (r.Cells["Columnid"].Value != null && Convert.ToDouble(r.Cells["tmes"].Value) == 0)
                    {
                        DSOmisiones.dtOmisionRow row = dt.dtOmision.NewdtOmisionRow();
                        row.Sueldo = Convert.ToDecimal(Convert.ToDecimal(r.Cells["sueldo"].Value));
                        row.Mes_Omitido = Convert.ToString(r.Cells["mesOmitido"].Value);
                        row._S_M = 0;
                        row._G_I = 0;
                        row._F_P = 0;
                        row._C_P = 0;
                        row._Pren_ = 0;
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

            else
            {
                statusStrip1.Items[0].Text = "No hay datos en el grid.";
                statusStrip1.Items[0].ForeColor = Color.OrangeRed;
                timer1.Start();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dtUltimaTasa.MinDate = dateTimePicker2.Value.AddMonths(1);
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            if (dgDatos.Rows.Count != 0)
            {
                int i = 0;
                foreach (DataGridViewRow row in dgDatos.Rows)
                {
                    //row._S_M = Convert.ToDouble(Convert.ToDouble(r.Cells[4].Value).ToString("#.##"));

                    if (row.Cells["nombre"].Value != null)
                    {
                        Omi.nombre = txtNombre.Text.Trim();
                        Omi.apellidoP = txtApellidoPa.Text.Trim();
                        Omi.apellidoM = txtApellidoMa.Text.Trim();
                        Omi.sueldo = Convert.ToDecimal(row.Cells["sueldo"].Value);
                        Omi.mesOmitido = Convert.ToDateTime(row.Cells["mesOmitido"].Value);
                        Omi.mesCalculo = DateTime.Today;
                        Omi.folio = txtElaborada.Text.Trim();
                        if (lstTipo.SelectedIndex == 0)
                        {
                            Omi.tipoCobro = "M";
                        }
                        else
                        {
                            ///WARGNING
                            Omi.tipoCobro = row.Cells["tipoCobro"].Value.ToString().Substring(0, 2);
                        }
                        Omi.idLoc = Convert.ToInt32(cbLocalidad.SelectedValue);
                        Omi.Localidad = cbLocalidad.Text.ToString();
                        Omi.idOrg = Convert.ToInt32(cbOrganismos.SelectedValue);
                        Omi.Organismo = cbOrganismos.Text.ToString();
                        Omi.csm = Convert.ToDecimal(row.Cells["csm"].Value.ToString());
                        Omi.ccp = Convert.ToDecimal(row.Cells["ccp"].Value.ToString());
                        Omi.cfp = Convert.ToDecimal(row.Cells["cfp"].Value.ToString());
                        Omi.cpren = Convert.ToDecimal(row.Cells["cpren"].Value.ToString());
                        Omi.csv = Convert.ToDecimal(row.Cells["csv"].Value.ToString());
                        Omi.csr = Convert.ToDecimal(row.Cells["csr"].Value.ToString());
                        Omi.cgi = Convert.ToDecimal(row.Cells["cgi"].Value.ToString());
                        Omi.tcuotas = Convert.ToDecimal(row.Cells["tcuotas"].Value.ToString());
                        Omi.importeC = Convert.ToDecimal(row.Cells["importeC"].Value.ToString());
                        Omi.asm = Convert.ToDecimal(row.Cells["asm"].Value.ToString());
                        Omi.afp = Convert.ToDecimal(row.Cells["afp"].Value.ToString());
                        Omi.acp = Convert.ToDecimal(row.Cells["acp"].Value.ToString());
                        Omi.apren = Convert.ToDecimal(row.Cells["apren"].Value.ToString());
                        Omi.asv = Convert.ToDecimal(row.Cells["asv"].Value.ToString());
                        Omi.asr = Convert.ToDecimal(row.Cells["asr"].Value.ToString());
                        Omi.agi = Convert.ToDecimal(row.Cells["agi"].Value.ToString());
                        Omi.afovi = Convert.ToDecimal(row.Cells["afovi"].Value.ToString());
                        Omi.apm = Convert.ToDecimal(row.Cells["apm"].Value.ToString());
                        Omi.aaf = Convert.ToDecimal(row.Cells["aaf"].Value.ToString());
                        Omi.aig = Convert.ToDecimal(row.Cells["aig"].Value.ToString());
                        Omi.aga = Convert.ToDecimal(row.Cells["aga"].Value.ToString());
                        Omi.taporta = Convert.ToDecimal(row.Cells["taporta"].Value.ToString());
                        Omi.importeA = Convert.ToDecimal(row.Cells["importeA"].Value.ToString());

                        Omi.tasa = Convert.ToDecimal(row.Cells["tasa"].Value.ToString().Substring(0, row.Cells["tasa"].Value.ToString().Count() - 1));
                        Omi.tmoratorio = Convert.ToDecimal(row.Cells["tmoratorio"].Value.ToString());
                        Omi.tmes = Convert.ToDecimal(row.Cells["tmes"].Value.ToString());
                        Omi.TasaCalculada = Convert.ToDateTime(row.Cells["TasaCalculada"].Value.ToString());
                        Omi.generacion = generacion.ToString();
                        Omi.interinato = interinato;
                        Omi.activo = true;
                        ctx.Omisiones.Add(Omi);

                        if (ctx.SaveChanges() > 0)
                        {
                            guardado = true;
                            if (i <= id.Count() && recalculado == true)
                            {
                                Omi.borrarRegistro(id[i]);
                            }
                            i++;

                        }

                        if (guardado == true)
                        {
                            statusStrip1.Items[0].ForeColor = Color.ForestGreen;
                            timer1.Start();

                        }

                    }

                }
                if (guardado == true)
                {
                    MessageBox.Show("Omision guardada");
                    guardado = false;
                    recalculado = false;
                }

            }
            else
            {
                MessageBox.Show("No hay datos en el grid.");
            }

        }
      
        private void txtAbrir_Click(object sender, EventArgs e)
        {
            frmAbrirOmision frmAbrir = new frmAbrirOmision();
            frmAbrir.ShowDialog();

            if (frmAbrir.nombre != "")
            {


                txtNombre.Text = frmAbrir.nombre;
                txtApellidoMa.Text = frmAbrir.apelidoM;
                txtApellidoPa.Text = frmAbrir.apellidoP;
                int index = cbOrganismos.FindString(frmAbrir.organismo);
                cbOrganismos.SelectedIndex = index;
                int indexL = cbLocalidad.FindString(frmAbrir.localidad);

                cbLocalidad.SelectedIndex = indexL;
                //dgDatos.Columns.Clear();


                List<Modelo.Omisiones> source = Omi.getOmision(frmAbrir.nombre, frmAbrir.apellidoP, frmAbrir.apelidoM);
              //  source = source.OrderBy(r => r.tipoCobro).ThenBy(r=>r.mesOmitido).ToList();
                  

                var lst = new BindingList<Modelo.Omisiones>(source);
                dgDatos.DataSource = lst;
            
                if (source[0].generacion == "A")
                {
                    generacion = 'A';
                    rbActual.Checked = true;
                }
                else
                {
                    generacion = 'F';
                    rbFutura.Checked = true;
                }


                if (dgDatos.Rows.Count > 0)
                {
                    btnRecalcular.Enabled = true;
                }
                flag = true;
                abierto = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReporteGeneral frmRpt = new frmReporteGeneral();
            frmRpt.Show();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Desea restablecer el grid?", "Restablecer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                dgDatos.DataSource = null;
                dgDatos.Rows.Clear();
                statusStrip1.Items[0].Text = "Grid restablecido.";
                statusStrip1.Items[0].ForeColor = Color.ForestGreen;
                guardado = false;
                recalculado = false;
                flag = false;
                abierto = false;
                timer1.Start();

            }
        }

        private void txtApellidoPa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);

        }

        private void chkInterinato_CheckedChanged(object sender, EventArgs e)
        {
            frmOmisiones frm = new frmOmisiones();
            if (chkInterinato.Checked == true)
            {
                dgTasas.DataSource = tasasInter.getAll().OrderByDescending(r => r.fecha).ToList();
                this.Text = "Home | Modo Interinato";

                //   dgTasas.DataSource = ctx.tasasOmisiones.Select(r => new { r.fecha, r.tasa }).OrderByDescending(r => r.fecha).ToList();

            }
            else
            {
                this.Text = "Home | Modo Omisión";


                dgTasas.DataSource = tasas.getAll().OrderByDescending(r => r.fecha).ToList();

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleado frm = new frmBuscarEmpleado();
            frm.ShowDialog();
            if (frm.nombre != "")
            {
                txtNombre.Text = frm.nombre;
                txtApellidoMa.Text = frm.apellidoM;
                txtApellidoPa.Text = frm.apellidoP;
                cbLocalidad.SelectedValue = frm.idLocalidad;
                List<Modelo.organismos> xx = (List<Modelo.organismos>)cbOrganismos.DataSource;
                int index = xx.FindIndex(r => r.codigo == frm.idOrganismo);
                cbOrganismos.SelectedIndex = index;

                if (frm.generacion == "A")
                {
                    rbActual.Checked = true;
                }
                else
                {
                    rbFutura.Checked = true;
                }
            }
        }

       
       
        private void dgDatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_inCellValueChanged == true)
            {
                if (e.ColumnIndex == 4)
                {
                    DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea actualizar el registro?, si ya esta guardado en la base de datos se actualizara automaticamente.", "Actualizar", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _inCellValueChanged = true;

                        int index = e.RowIndex;
                        decimal dml;
                        if (e.RowIndex != -1)
                        {
                            if (Decimal.TryParse(dgDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out dml) && Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) > 0)
                            {
                                decimal sueldo = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                                int año = Convert.ToDateTime(dgDatos.Rows[e.RowIndex].Cells["mesOmitido"].Value).Year;
                                int idLoc = Convert.ToInt32(dgDatos.Rows[e.RowIndex].Cells["idLoc"].Value);
                                int idOrg = Convert.ToInt32(dgDatos.Rows[e.RowIndex].Cells["idOrg"].Value);
                                string generacion = dgDatos.Rows[e.RowIndex].Cells["genera"].Value.ToString();
                                var organismo = catOrg.getOrganismo(idLoc, idOrg, año, generacion);
                                decimal tasa = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["tasa"].Value);
                                dgDatos.Rows[e.RowIndex].Cells["csm"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.C_ServMedico) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["cfp"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.C_FondoPens) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["ccp"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.C_CortoPlazo) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["cpren"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.C_Prendario) / 100);
                                  dgDatos.Rows[e.RowIndex].Cells["cgi"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.C_GastosInfra) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["tcuotas"].Value = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["csm"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["cfp"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["ccp"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["cpren"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["csv"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["csr"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["cgi"].Value);
                                dgDatos.Rows[e.RowIndex].Cells["importeC"].Value = (tasa / 100) * Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["tcuotas"].Value);
                                dgDatos.Rows[e.RowIndex].Cells["asm"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.A_ServMedico) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["afp"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.A_FondoPens) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["acp"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.A_CortoPlazo) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["apren"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.A_Prendario) / 100);
                                if (dgDatos.Rows[e.RowIndex].Cells["tipoCobro"].Value.ToString() != "M")
                                {
                                    dgDatos.Rows[e.RowIndex].Cells["asv"].Value = (Convert.ToDecimal(organismo.A_SeguroVida))/2;
                                    dgDatos.Rows[e.RowIndex].Cells["asr"].Value = (Convert.ToDecimal(organismo.A_SeguroRetiro))/2;
                                    dgDatos.Rows[e.RowIndex].Cells["csv"].Value = (Convert.ToDecimal(organismo.C_SeguroVida))/2;
                                    dgDatos.Rows[e.RowIndex].Cells["csr"].Value = (Convert.ToDecimal(organismo.C_SeguroRetiro))/2;
                                }
                                else
                                {
                                    dgDatos.Rows[e.RowIndex].Cells["asv"].Value = (Convert.ToDecimal(organismo.A_SeguroVida));
                                    dgDatos.Rows[e.RowIndex].Cells["asr"].Value = (Convert.ToDecimal(organismo.A_SeguroRetiro));
                                    dgDatos.Rows[e.RowIndex].Cells["csv"].Value = (Convert.ToDecimal(organismo.C_SeguroVida));
                                    dgDatos.Rows[e.RowIndex].Cells["csr"].Value = (Convert.ToDecimal(organismo.C_SeguroRetiro));
                                }
                            
                                dgDatos.Rows[e.RowIndex].Cells["agi"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.A_GastosInfra) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["afovi"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.A_Fovisssteson) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["apm"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.A_PensionMin) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["aaf"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.A_AyudaFune) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["aig"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.A_Indemniza) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["aga"].Value = Convert.ToDecimal(sueldo) * (Convert.ToDecimal(organismo.A_GastosAdmin) / 100);
                                dgDatos.Rows[e.RowIndex].Cells["taporta"].Value = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["asm"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["afp"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["acp"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["apren"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["asv"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["asr"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["agi"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["afovi"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["apm"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["aaf"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["aig"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["aga"].Value);
                                dgDatos.Rows[e.RowIndex].Cells["importeA"].Value = (tasa / 100) * Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["taporta"].Value);
                                dgDatos.Rows[e.RowIndex].Cells["tmoratorio"].Value = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["importeA"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["importeC"].Value);
                                dgDatos.Rows[e.RowIndex].Cells["tmes"].Value = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["tcuotas"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["taporta"].Value) + Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["tmoratorio"].Value);

                                if (Convert.ToInt32(dgDatos.Rows[e.RowIndex].Cells["ColumnID"].Value) != 0)
                                {
                                    using (var ctx = new Modelo.mIngresos())
                                    {
                                        int id = Convert.ToInt32(dgDatos.Rows[e.RowIndex].Cells["ColumnID"].Value);
                                        Modelo.Omisiones actOmi = ctx.Omisiones.Where(r => r.id == id).SingleOrDefault();
                                        //                                        actOmi.getOmision(Convert.ToInt32(dgDatos.Rows[e.RowIndex].Cells["ColumnID"].Value));
                                        actOmi.importeA = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["importeA"].Value);
                                        actOmi.importeC = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["importeC"].Value);
                                        actOmi.sueldo = sueldo;
                                        actOmi.taporta = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["taporta"].Value);
                                        actOmi.tcuotas = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["tcuotas"].Value);
                                        actOmi.tmes = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["tmes"].Value);
                                        actOmi.tmoratorio = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["tmoratorio"].Value);
                                        actOmi.aaf = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["aaf"].Value);
                                        actOmi.acp = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["acp"].Value);
                                        actOmi.afovi = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["afovi"].Value);
                                        actOmi.afp = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["afp"].Value);
                                        actOmi.aga = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["aga"].Value);
                                        actOmi.agi = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["agi"].Value);
                                        actOmi.aig = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["aig"].Value);
                                        actOmi.apm = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["apm"].Value);
                                        actOmi.apren = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["apren"].Value);
                                        actOmi.asm = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["asm"].Value);
                                        actOmi.ccp = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["ccp"].Value);
                                        actOmi.cfp = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["cfp"].Value);
                                        actOmi.cgi = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["cgi"].Value);
                                        actOmi.cpren = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["cpren"].Value);
                                        actOmi.csm = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["csm"].Value);
                                        if (dgDatos.Rows[e.RowIndex].Cells["tipoCobro"].Value.ToString() != "M")
                                        {
                                            actOmi.csr = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["csr"].Value)/2;
                                            actOmi.csv = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["csv"].Value)/2;
                                            actOmi.asr = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["asr"].Value)/2;
                                            actOmi.asv = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["asv"].Value)/2;
                                        }
                                        else

                                        {
                                            actOmi.csr = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["csr"].Value);
                                            actOmi.csv = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["csv"].Value);
                                            actOmi.asr = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["asr"].Value);
                                            actOmi.asv = Convert.ToDecimal(dgDatos.Rows[e.RowIndex].Cells["asv"].Value);
                                        }

                                        ctx.SaveChanges();
                                    }

                                }
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (e.RowIndex != -1)
                            {
                                dgDatos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Convert.ToDecimal(oldvalue);
                            }
                        }
                    }
                }
            }
            _inCellValueChanged = false;

        }
        
        private void dgDatos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            oldvalue = Convert.ToDouble(dgDatos[e.ColumnIndex, e.RowIndex].Value);
            _inCellValueChanged = true;


        }

        private void dgDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea eliminar los registros seleccionados?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (dgDatos.Rows.Count == this.dgDatos.SelectedRows.Count)
                {
                    btnLimpiar_Click(sender, e);
                }
                else
                {
                    foreach (DataGridViewRow item in this.dgDatos.SelectedRows)
                    {
                        int id = Convert.ToInt32(item.Cells[0].Value);
                        if (id != 0)
                        {
                            Omi.borrarRegistro(id);
                        }                       
                       
                        dgDatos.Rows.RemoveAt(item.Index);
                      
                      



                    }
                }
            }
        }

        private void cbOrganismos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            string[,] arrayString = new string[5488, 3];
            List<string> lstEmpleados = Omi.getEmpleados();
            foreach (var item in lstEmpleados)
            {
                string[] ddd = item.Split(null);
                int dddd = ddd.Count();
                if (dddd == 3)
                {
                    //Debug.WriteLine(ddd[2]);
                    arrayString[i, 0] = ddd[0];
                    arrayString[i, 1] = ddd[1];
                    arrayString[i, 2] = ddd[2];
                }
                if (dddd == 4)
                {
                    //Debug.WriteLine(ddd[2] + " " + ddd[3]);
                    arrayString[i, 0] = ddd[0];
                    arrayString[i, 1] = ddd[1];
                    arrayString[i, 2] = ddd[2] + " " + ddd[3];
                }
                if (dddd != 4 && dddd != 3)
                {
                    //  Debug.WriteLine(ddd[0]);
                    arrayString[i, 0] = ddd[0];
                }
                if (dddd > 4)
                {
                    Debug.WriteLine(item);
                }
                i++;
            }


        }

        private void txtInteres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtSueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }    

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            if (dgDatos.Rows.Count != 0)
            {
                if (dgDatos.Columns[0].Name == "ColumnID")
                {

                    int i = 0;

                    List<decimal> sueldos = new List<decimal>();
                    foreach (DataGridViewRow row in dgDatos.Rows)
                    {
                        id.Add(Convert.ToInt32(dgDatos.Rows[i].Cells["ColumnID"].Value));
                        sueldos.Add(Convert.ToDecimal(dgDatos.Rows[i].Cells["sueldo"].Value));
                        i++;
                    }
                    //1 Sueldo
                    DateTime de = Convert.ToDateTime(dgDatos.Rows[0].Cells["mesOmitido"].Value);
                    DateTime hasta = Convert.ToDateTime(dgDatos.Rows[dgDatos.Rows.Count - 1].Cells["mesOmitido"].Value);
                    double sueldo = Convert.ToDouble(dgDatos.Rows[0].Cells["sueldo"].Value);

                    var lstTasa = tasas.getLstTasas(de, hasta);

                    if (lstTipo.SelectedIndex == 1)
                    {
                        int q1 = Convert.ToInt32(dgDatos.Rows[0].Cells["tipoCobro"].Value);
                        int q2 = Convert.ToInt32(dgDatos.Rows[dgDatos.Rows.Count - 1].Cells["tipoCobro"].Value);


                        lstTasa = tasas.getLstTasas(de, hasta, q1, q2);

                    }
                    string generacion = dgDatos.Rows[0].Cells["genera"].Value.ToString();
                    bool interinato = Convert.ToBoolean(dgDatos.Rows[0].Cells["interi"].Value.ToString());
                    Modelo.localidades localidad = loc.getByDescripcion(dgDatos.Rows[0].Cells["localidad"].Value.ToString().Trim());
                    Modelo.organismos organismo = org.getByDescripcion(dgDatos.Rows[0].Cells["organismo"].Value.ToString().Trim());
                    //DATOS DEL ORGANISMO
                    Dictionary<int, Modelo.cat_organismos2> datos = catOrg.getData(localidad, organismo, generacion, de, hasta);

                    Modelo.DatagGridView dgv = new Modelo.DatagGridView();
                    dgv.generarGrid(dgDatos, false, flag);
                    flag = false;
                   
                    dgDatos.DataSource = null;
                    dgv.llenarGrid(lstTasa, sueldos, datos, dgDatos, interinato, Convert.ToInt32(lstTipo.SelectedIndex), txtApellidoPa.Text, txtApellidoMa.Text, txtNombre.Text, Convert.ToInt32(cbOrganismos.SelectedValue), Convert.ToInt32(cbLocalidad.SelectedValue), txtElaborada.Text.Trim(),generacion);
                    recalculado = true;
                    statusStrip1.Items[0].Text = "Omisión recalculada.";
                    btnRecalcular.Enabled = false;
                    statusStrip1.ForeColor = Color.ForestGreen;
                    {
                        statusStrip1.Items[0].Text = "Registros ya recalculados.";
                        statusStrip1.ForeColor = Color.OrangeRed;

                    }
                }
             
                timer1.Start();

            }
            else
            {
                statusStrip1.Items[0].Text = "No hay regitros que recalcular.";
                statusStrip1.ForeColor = Color.OrangeRed;
                timer1.Start();

            }
        }

        // Protect the connectionStrings section.
        private static void ProtectConfiguration()
        {
            // Obtener el archivo de configuracion
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Crear el proveedor de encriptacion
            String provider = "DataProtectionConfigurationProvider";
            // Obtener la seccion de configuracion
            ConfigurationSection connstrings = config.ConnectionStrings;
            // Encriptar
            connstrings.SectionInformation.ProtectSection(provider);
            connstrings.SectionInformation.ForceSave = true;
            // Guardar
            config.Save(ConfigurationSaveMode.Full);

        }


        // Unprotect the connectionStrings section.
        private static void UnProtectConfiguration()
        {
            // Obtener el archivo de configuracion
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            // Obtener la seccion de configuracion
            ConfigurationSection connstrings = config.ConnectionStrings;
            // Desescriptar
            connstrings.SectionInformation.UnprotectSection();
            connstrings.SectionInformation.ForceSave = true;
            // Guardar
            config.Save(ConfigurationSaveMode.Full);

        }
    }
}