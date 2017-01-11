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
                    cbOrganismos.DataSource = org.getAll();
                    cbLocalidad.Text = "LOCALIDAD";
                    cbOrganismos.Text = "ORGANISMOS";
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
           
            
            dgDatos.Rows.Clear();
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
                dgv.llenarGrid(lstTasa, 10000, datos, dgDatos, chkInterinato.Checked,dtUltimaTasa.Value, Convert.ToInt32(lstTipo.SelectedIndex));

            }
            else
            {
                dgv.llenarGrid(lstTasa, 10000, datos, dgDatos, chkInterinato.Checked, Convert.ToInt32(lstTipo.SelectedIndex));
            }

            //





            frmTabla frm = new frmTabla(localidad, organismo, datos, 13599.22, dateTimePicker1.Value, dateTimePicker2.Value, chkInterinato.Checked);
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
    }
}
