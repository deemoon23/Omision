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
        
        Modelo.organismos org = new Modelo.organismos();
        Modelo.localidades loc = new Modelo.localidades();
        Modelo.tasasOmisiones tasas = new Modelo.tasasOmisiones();
        Modelo.tasasOmisionesInterinato tasasInter = new Modelo.tasasOmisionesInterinato();
        Modelo.cat_organismos2 catOrg = new Modelo.cat_organismos2();
        public frmHome()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rbActual.Checked = true;
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker2.CustomFormat = "MMMM yyyy";
            dtUltimaTasa.CustomFormat = "MMMM yyyy";
            dtUltimaTasa.MinDate = dateTimePicker2.Value.AddMonths(1);

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
                    DateTime fechaHoy = new DateTime(fechaHoyAux.Year,fechaHoyAux.Month,1);
                    Modelo.tasasOmisiones ultimaFechaTemp = tasas.getUltimaTasa();
                    DateTime ultimaFecha = new DateTime(ultimaFechaTemp.fecha.Year, ultimaFechaTemp.fecha.Month,1);

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
            
            if (lstTipo.SelectedIndex == 1)
            {
                int De = lstDe.SelectedIndex;
                int Hasta = lstHasta.SelectedIndex;
                if (lstDe.SelectedIndex == 1){ De = 2;} else{ De = 1;}
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
                TipoGenera= "F";
            }
            Modelo.localidades localidad = loc.getByDescripcion(cbLocalidad.Text);
            Modelo.organismos organismo = org.getByDescripcion(cbOrganismos.Text);
            //DATOS DEL ORGANISMO
            Dictionary<int,Modelo.cat_organismos2> datos = catOrg.getData(localidad, organismo,TipoGenera, dateTimePicker1.Value,dateTimePicker2.Value);

            //
            Modelo.DatagGridView dgv = new Modelo.DatagGridView();
            dgv.generarGrid(dgDatos);
            if (chkUltimaTasa.Checked == true)
            {
                dgv.llenarGrid(lstTasa,Convert.ToDouble(txtSueldo.Text), datos, dgDatos, chkInterinato.Checked,dtUltimaTasa.Value, Convert.ToInt32(lstTipo.SelectedIndex));

            }
            else
            {
                dgv.llenarGrid(lstTasa, Convert.ToDouble(txtSueldo.Text), datos, dgDatos, chkInterinato.Checked, Convert.ToInt32(lstTipo.SelectedIndex));
            }

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
            nuevo.fecha = new DateTime(ultimaFechaTemp.fecha.Year, ultimaFechaTemp.fecha.Month+1, 1);
            nuevo.tasa = Convert.ToDecimal(txtInteres.Text.Trim());
            
            var ctx = new Modelo._Modelo();
            ctx.tasasOmisiones.Add(nuevo);
            ctx.SaveChanges();


            //AGREGAR A UNA CLASE
                    DateTime fechaHoy = new DateTime(fechaHoyAux.Year,fechaHoyAux.Month,1);
                    DateTime ultimaFecha = new DateTime(ultimaFechaTemp.fecha.Year, ultimaFechaTemp.fecha.Month,1);

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
            if (txtApellidoPa.Text.Count()==0)
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
            if (txtApellidoMa.ForeColor==Color.Gray)
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
            
            foreach (DataGridViewRow r in dgDatos.Rows)
            {

                if (r.Cells[0].Value != null)
                {
                    DataSet1.dtOmisionRow row = dt.dtOmision.NewdtOmisionRow();
                    row.Sueldo = Convert.ToDouble(Convert.ToDouble(r.Cells[0].Value).ToString("#.##"));
                    row.Mes_Omitido = Convert.ToString(r.Cells[1].Value);
                    row._S_M = Convert.ToDouble(Convert.ToDouble(r.Cells[4].Value).ToString("#.##"));

                    row._G_I = Convert.ToDouble(Convert.ToDouble(r.Cells[5].Value).ToString("#.##"));
                    row._F_P = Convert.ToDouble(Convert.ToDouble(r.Cells[6].Value).ToString("#.##"));
                    row._C_P = Convert.ToDouble(Convert.ToDouble(r.Cells[7].Value).ToString("#.##"));
                    if (r.Cells[8].Value == "")
                    {
                        row._Pren_ = 0;
                    }
                    else
                    {
                        row._Pren_ = Convert.ToDouble(r.Cells[8].Value);
                    }
                    var uno = Convert.ToDouble(r.Cells[9].Value);
                    var dos = Convert.ToDouble(r.Cells[9].Value).ToString("#.##");
                    var tres = Convert.ToDouble(Convert.ToDouble(r.Cells[9].Value).ToString("#.##"));
                    row._S_V = Convert.ToDouble(Convert.ToDouble(r.Cells[9].Value).ToString("#.##"));
                    row._S_R = Convert.ToDouble(Convert.ToDouble(r.Cells[10].Value).ToString("#.##"));
                    row._T__Cuotas = Convert.ToDouble(Convert.ToDouble(r.Cells[11].Value).ToString("#.##"));
                    row._a_S_M = Convert.ToDouble(Convert.ToDouble(r.Cells[14].Value).ToString("#.##"));
                    row._a_G_I = Convert.ToDouble(Convert.ToDouble(r.Cells[15].Value).ToString("#.##"));
                    row._a_F_P = Convert.ToDouble(Convert.ToDouble(r.Cells[16].Value).ToString("#.##"));
                    row._a_C_P = Convert.ToDouble(Convert.ToDouble(r.Cells[17].Value).ToString("#.##"));
                    if (r.Cells[18].Value == "")
                    {
                        row._a_Pren_ = 0;
                    }
                    else
                    {
                        row._a_Pren_ = Convert.ToDouble(Convert.ToDouble(r.Cells[18].Value).ToString("#.##"));
                    }
                    if (r.Cells[19].Value == "")
                    {
                        row._a_I_G = 0;
                    }
                    else
                    {
                        row._a_I_G = Convert.ToDouble(Convert.ToDouble(r.Cells[19].Value).ToString("#.##"));
                    }
                    if (r.Cells[20].Value == "")
                    {
                        row._a_A_F = 0;
                    }
                    else
                    {
                        row._a_A_F = Convert.ToDouble(Convert.ToDouble(r.Cells[20].Value).ToString("#.##"));
                    }
                    row._a_G_A = Convert.ToDouble(r.Cells[21].Value);
                    if (r.Cells[22].Value == "")
                    {
                        row._a_FOVI_ = 0;
                    }
                    else
                    {
                        row._a_FOVI_ = Convert.ToDouble(Convert.ToDouble(r.Cells[22].Value).ToString("#.##"));
                    }
                    if (r.Cells[23].Value == "")
                    {
                        row._a_P_M = 0;
                    }
                    else
                    {
                        row._a_P_M = Convert.ToDouble(Convert.ToDouble(r.Cells[23].Value).ToString("#.##"));
                    }
                    row._a_S_V = Convert.ToDouble(Convert.ToDouble(r.Cells[24].Value).ToString("#.##"));
                    row._a_S_R = Convert.ToDouble(Convert.ToDouble(r.Cells[25].Value).ToString("#.##"));
                    row._T__Aportaciones = Convert.ToDouble(Convert.ToDouble(r.Cells[26].Value).ToString("#.##"));
                    string tasa= r.Cells[13].Value.ToString().Substring(0, r.Cells[13].Value.ToString().Count()-1);                    
                    row.Tasa = Convert.ToDouble(Convert.ToDouble(tasa).ToString("#.##"));
                    row._Mora__Cuotas = Convert.ToDouble(Convert.ToDouble(r.Cells[13].Value).ToString("#.##"));
                    row._Mora__Aporta_ = Convert.ToDouble(Convert.ToDouble(r.Cells[28].Value).ToString("#.##"));
                    row.Total_Moratorio = Convert.ToDouble(Convert.ToDouble(r.Cells[30].Value).ToString("#.##"));
                    row.Total_Mes = Convert.ToDouble(Convert.ToDouble(r.Cells[31].Value).ToString("#.##"));
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
            Modelo.Omisiones Omi = new Modelo.Omisiones();
            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                //row._S_M = Convert.ToDouble(Convert.ToDouble(r.Cells[4].Value).ToString("#.##"));
                Omi.sueldo=Convert.ToDouble(row.Cells[0].Value);
                var año = row.Cells[1].Value.ToString().Substring(0, 2);
                var mes = row.Cells[1].Value.ToString().Substring(3, 3);
                int añoo = DateTime.ParseExact(año, "yy", CultureInfo.InvariantCulture).Year;
                int mess = DateTime.ParseExact(mes, "MMM", CultureInfo.InvariantCulture).Month;
                Omi.mesOmitido = new DateTime(añoo, mess, 1);
                var año2 = row.Cells[32].Value.ToString().Substring(0, 2);
                var mes2 = row.Cells[32].Value.ToString().Substring(3, 3);
                int añoo2 = DateTime.ParseExact(año, "yy", CultureInfo.InvariantCulture).Year;
                int mess2 = DateTime.ParseExact(mes, "MMM", CultureInfo.InvariantCulture).Month;
                Omi.mesCalculo = new DateTime(añoo2, mess2, 1);
                Omi.folio = txtElaborada.Text.Trim();
                if (lstTipo.SelectedIndex == 0)
                {
                    Omi.tipoCobro = "M";
                }
                else
                {
                    Omi.tipoCobro = "Q";
                }
                Omi.idLoc = Convert.ToInt32(cbLocalidad.SelectedValue);
                Omi.Localidad = cbLocalidad.SelectedText.ToString();
                Omi.idOrg = Convert.ToInt32(cbOrganismos.SelectedValue);
                Omi.Organismo = cbOrganismos.SelectedText.ToString();
                Omi.csm = Convert.ToDouble(row.Cells[4].Value.ToString());
                //
                Omi.ccp = Convert.ToDouble(row.Cells[7].Value.ToString());
                Omi.cfp = Convert.ToDouble(row.Cells[16].Value.ToString());


                //Omi.mesOmitido;

            }
        }
    }
}
