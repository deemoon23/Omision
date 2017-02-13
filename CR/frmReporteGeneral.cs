using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CR
{
    public partial class frmReporteGeneral : Form
    {
        private bool _TypedInto;

        Modelo.Omisiones Omi = new Modelo.Omisiones();
        Modelo.organismos Org = new Modelo.organismos();
        Modelo.localidades Loc = new Modelo.localidades();
        Modelo.trabajadores Tra = new Modelo.trabajadores();
        List<Modelo.Omisiones> lstAux = new List<Modelo.Omisiones>();
        BindingList<Modelo.Omisiones> lst;
        List<string> lstEmpleados = new List<string>();
        List<string> lstChkEmpleados = new List<string>();
        List<Tuple<string, string, string, string>> lstTEmpleados = new List<Tuple<string, string, string, string>>();
        string nombreX, chkNombreX, T1, T2, T3, T4;
        public frmReporteGeneral()
        {
            InitializeComponent();
            statusStrip1.Items[0].Text = "";
            cbLocalidad.DataSource = Loc.getAll();
            cbLocalidad.DisplayMember = "DESCRIPCION";
            cbLocalidad.ValueMember = "codigo";
            cbOrganismos.DataSource = Org.getAll();
            cbOrganismos.DisplayMember = "DESCRIPCION";
            cbOrganismos.ValueMember = "codigo";

        }

        private void frmReporteGeneral_Load(object sender, EventArgs e)
        {
            

            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker2.CustomFormat = "MMMM yyyy";
            dgEmpleados.DataSource = Omi.getOmisiones();
            txtApellidoP.Text = "Apellido Paterno";
            txtApellidoP.ForeColor = Color.Gray;
            txtApellidoM.Text = "Apellido Materno";
            txtApellidoM.ForeColor = Color.Gray;
            txtNombre.Text = "Nombre";
            txtNombre.ForeColor = Color.Gray;
            dgEmpleados.Columns[0].HeaderText = "Nombre";
            dgEmpleados.Columns[0].DisplayIndex = 2;
            dgEmpleados.Columns[1].HeaderText = "Apellido Paterno";
            dgEmpleados.Columns[1].DisplayIndex = 0;
            dgEmpleados.Columns[2].HeaderText = "Apellido Materno";
            dgEmpleados.Columns[2].DisplayIndex = 1;
            dgEmpleados.Columns[3].HeaderText = "Fecha";
            dgEmpleados.Columns[3].DisplayIndex = 5;
            dgEmpleados.Columns[4].HeaderText = "Localidad";
            dgEmpleados.Columns[5].HeaderText = "Organismo";

        }

        private void dgEmpleados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO ADD LIST TO BINDINGLIST
            int rowIndex = e.RowIndex;
            string nombre = dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString();
            string chknombre = dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[3].Value.ToString();
            bool tupleHadProduct = lstTEmpleados.Any(m => m.Item1 == dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString() && m.Item2 == dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString() && m.Item3 == dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString() && m.Item4 == dgEmpleados.Rows[rowIndex].Cells[3].Value.ToString());

            if (tupleHadProduct == false)
            {

                lstTEmpleados.Add(new Tuple<string, string, string, string>(dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString(), dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString(), dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString(), dgEmpleados.Rows[rowIndex].Cells[3].Value.ToString()));
                if (!lstChkEmpleados.Contains(chknombre))
                {
                    List<Modelo.Omisiones> newlst = new List<Modelo.Omisiones>();
                    newlst = Omi.getOmision(dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString(), dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString(), dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString());
                    lstAux.AddRange(newlst);
                    lst = new BindingList<Modelo.Omisiones>(lstAux);
                    var source = new BindingSource(lst, null);

                    dgDatos.DataSource = lst;
                    dgDatos.Columns[0].Visible = false;
                    dgDatos.Columns[6].Visible = false;
                    dgDatos.Columns[8].Visible = false;

                    dgDatos.Columns[37].DisplayIndex = 2;
                    dgDatos.Columns[38].DisplayIndex = 3;
                    dgDatos.Columns[39].DisplayIndex = 4;
                    dgDatos.Columns[7].DisplayIndex = 5;
                    dgDatos.Columns[9].DisplayIndex = 6;
                    statusStrip1.Items[0].Text = dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString() + " \t| AGREGADO.";

                    if (lstEmpleados.Contains(nombre) == false)
                    {
                        lstEmpleados.Add(nombre);
                    }
                    lstChkEmpleados.Add(chknombre);
                    //lstEmpleadoSel.Add();
                }
                else
                {
                    MessageBox.Show("Registros ya agregados.");
                }

            }
            else
            {
                MessageBox.Show("Registros ya agregados.");
            }

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            int meses = ((dateTimePicker2.Value.Year * 12 + dateTimePicker2.Value.Month) - (dateTimePicker1.Value.Year * 12 + dateTimePicker1.Value.Month)) + 1;
            lblParciales.Text = meses.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int meses = ((dateTimePicker2.Value.Year * 12 + dateTimePicker2.Value.Month) - (dateTimePicker1.Value.Year * 12 + dateTimePicker1.Value.Month)) + 1;
            lblParciales.Text = meses.ToString();
        }

        private void cbOrganismos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgDatos.Rows.Clear();
            lstEmpleados.Clear();
            lstChkEmpleados.Clear();
            lstTEmpleados.Clear();
            nombreX = "";
            chkNombreX = "";
            T2 = "";
            T3 = "";
            T4 = "";
            T1 = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgDatos.Rows.Count != 0)
            {


                DSGeneral ds = new DSGeneral();

                int i = 0;
                string localidad = (from a in lst select a.Localidad).FirstOrDefault();
                string organismo = (from a in lst select a.Organismo).FirstOrDefault();
                DSGeneral.dtInfoRow dtInfoRow = ds.dtInfo.NewdtInfoRow();
                dtInfoRow.Localidad = localidad;
                dtInfoRow.Organismo = organismo;
                dtInfoRow.idLocalidad = Loc.getByDescripcion(localidad).codigo;
                dtInfoRow.idOrganismo = Org.getByDescripcion(organismo).codigo;
                ds.dtInfo.AdddtInfoRow(dtInfoRow);
                List<int> lstAnios = new List<int>();
                int anio = 0;

                if (i == 0)
                {

                    anio = Convert.ToDateTime(dgDatos.Rows[0].Cells[3].Value.ToString()).Year;
                    lstAnios.Add(anio);

                }

                foreach (DataGridViewRow row in dgDatos.Rows)
                {
                    if (i < dgDatos.Rows.Count - 1)

                    {
                        if (anio != Convert.ToDateTime(dgDatos.Rows[i].Cells[3].Value.ToString()).Year)
                        {
                            anio = Convert.ToDateTime(dgDatos.Rows[i].Cells[3].Value.ToString()).Year;
                            if (!lstAnios.Contains(anio))
                            {
                                lstAnios.Add(anio);
                            }
                        }
                    }

                    i++;


                }
                lstAnios.Sort();

                int count = 0;

                foreach (var item in lstAnios)
                {
                    DSGeneral.dtDatosAñoRow dato = ds.dtDatosAño.NewdtDatosAñoRow();
                    dato.año = lstAnios[count];
                    dato.sueldo = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.sueldo).Sum());
                    dato.csm = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.csm).Sum());
                    dato.cfp = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.cfp).Sum());
                    dato.ccp = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.ccp).Sum());
                    dato.cpren = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.cpren).Sum());
                    dato.csv = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.csv).Sum());
                    dato.csr = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.csr).Sum());
                    dato.cgi = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.cgi).Sum());
                    dato.tcuotas = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.tcuotas).Sum());
                    dato.importeC = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.importeC).Sum());
                    dato.afp = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.afp).Sum());
                    dato.asm = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.asm).Sum());
                    dato.cfp = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.cfp).Sum());
                    dato.acp = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.acp).Sum());
                    dato.apren = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.apren).Sum());
                    dato.asr = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.asr).Sum());
                    dato.agi = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.agi).Sum());
                    dato.asv = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.asv).Sum());
                    dato.afovi = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.afovi).Sum());
                    dato.apm = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.apm).Sum());
                    dato.aaf = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.aaf).Sum());
                    dato.aig = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.aig).Sum());
                    dato.aga = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.aga).Sum());
                    dato.taporte = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.taporta).Sum());
                    dato.importeA = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.importeA).Sum());
                    dato.tasa = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.tasa).Sum());
                    dato.tmoratorio = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.tmoratorio).Sum());
                    dato.tmes = Convert.ToDecimal((from a in lst where a.mesOmitido.Value.Year == lstAnios[count] select a.tmes).Sum());
                    ds.dtDatosAño.AdddtDatosAñoRow(dato);

                    count++;
                }

                count = 0;
                List<string> lstNewEmpleados = lstEmpleados.OrderByDescending(r => r).ToList();
                foreach (var item in lstNewEmpleados)
                {
                    int pension = Convert.ToInt32(Tra.getTrabajador(lstTEmpleados[count].Item1, lstTEmpleados[count].Item2, lstTEmpleados[count].Item3).tpension);
                     DSGeneral.dtEmpleadoRow dato = ds.dtEmpleado.NewdtEmpleadoRow();
                    dato.nombre = lstTEmpleados[count].Item1 + " " + lstTEmpleados[count].Item2 +" " +lstTEmpleados[count].Item3;
                    dato.tMes = Convert.ToDecimal((from a in lst
                                                   where a.nombre == lstTEmpleados[count].Item3 && a.apellidoM == lstTEmpleados[count].Item2 &&
                                     a.apellidoP == lstTEmpleados[count].Item1
                                                   select a.tmes).Sum());
                    dato.pension = pension;
                    ds.dtEmpleado.AdddtEmpleadoRow(dato);
                    count++;
                }
                DataTable dt = new DataTable();
                DSGeneral dsGeneral = new DSGeneral();
                dt = dsGeneral.dtPorMes.Clone();
                DSGeneral.dtPorMesRow data = ds.dtPorMes.NewdtPorMesRow();
                int numMeses = Convert.ToInt32(lblParciales.Text);
                DateTime startDate = dateTimePicker1.Value;
                DateTime endDate = dateTimePicker2.Value;
                var months = MonthsBetween(startDate, endDate);
                for (int ii = 0; ii < numMeses; ii++)
                {

                    // DataRow rowDsOmision2 = dsOmisiones.DtOmisionesReport.NewRow();
                    DataRow row = dsGeneral.dtPorMes.NewRow();
                    row["mes"] = months.ElementAt(ii).Item1 + " " + months.ElementAt(ii).Item2.ToString();
                    row["sueldo"] = Convert.ToDecimal((from a in lst select a.sueldo).Sum()) / numMeses;
                    row["cfp"] = Convert.ToDecimal((from a in lst select a.cfp).Sum()) / numMeses;
                    row["ccp"] = Convert.ToDecimal((from a in lst select a.ccp).Sum()) / numMeses;
                    row["csm"] = Convert.ToDecimal((from a in lst select a.csm).Sum()) / numMeses;
                    row["apren"] = Convert.ToDecimal((from a in lst select a.apren).Sum()) / numMeses;
                    row["csv"] = Convert.ToDecimal((from a in lst select a.csv).Sum()) / numMeses;
                    row["csr"] = Convert.ToDecimal((from a in lst select a.csr).Sum()) / numMeses;
                    row["cgi"] = Convert.ToDecimal((from a in lst select a.cgi).Sum()) / numMeses;
                    row["tcuotas"] = Convert.ToDecimal((from a in lst select a.tcuotas).Sum()) / numMeses;
                    row["importeC"] = Convert.ToDecimal((from a in lst select a.importeC).Sum()) / numMeses;
                    row["acp"] = Convert.ToDecimal((from a in lst select a.acp).Sum()) / numMeses;
                    row["afp"] = Convert.ToDecimal((from a in lst select a.afp).Sum()) / numMeses;
                    row["asm"] = Convert.ToDecimal((from a in lst select a.asm).Sum()) / numMeses;
                    row["cpren"] = Convert.ToDecimal((from a in lst select a.cpren).Sum()) / numMeses;
                    row["asv"] = Convert.ToDecimal((from a in lst select a.asv).Sum()) / numMeses;
                    row["asr"] = Convert.ToDecimal((from a in lst select a.asr).Sum()) / numMeses;
                    row["agi"] = Convert.ToDecimal((from a in lst select a.agi).Sum()) / numMeses;
                    row["afovi"] = Convert.ToDecimal((from a in lst select a.afovi).Sum()) / numMeses;
                    row["apm"] = Convert.ToDecimal((from a in lst select a.apm).Sum()) / numMeses;
                    row["aaf"] = Convert.ToDecimal((from a in lst select a.aaf).Sum()) / numMeses;
                    row["aig"] = Convert.ToDecimal((from a in lst select a.aig).Sum()) / numMeses;
                    row["aga"] = Convert.ToDecimal((from a in lst select a.aga).Sum()) / numMeses;
                    row["taporte"] = Convert.ToDecimal((from a in lst select a.taporta).Sum()) / numMeses;
                    row["importeA"] = Convert.ToDecimal((from a in lst select a.importeA).Sum()) / numMeses;
                    row["tasa"] = Convert.ToDecimal((from a in lst select a.tasa).Sum()) / numMeses;
                    row["tmoratorio"] = Convert.ToDecimal((from a in lst select a.tmoratorio).Sum()) / numMeses;
                    row["tmes"] = Convert.ToDecimal((from a in lst select a.tmes).Sum()) / numMeses;
                    row["AUX"] = ii;
                    dsGeneral.dtPorMes.Rows.Add(row);
                }
                foreach (DataRow dr in dsGeneral.dtPorMes.Rows)
                {

                    ds.dtPorMes.Rows.Add(dr.ItemArray);
                }
                frmVistaPrevia frm = new frmVistaPrevia(ds);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Grid vacío, Seleccione empleados.");
            }
        }

       

        private void dgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            nombreX = dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString();
            chkNombreX = dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString() + " " + dgEmpleados.Rows[rowIndex].Cells[3].Value.ToString();
            T1 = dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString();
            T2 = dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString();
            T3 = dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString();
            T4 = dgEmpleados.Rows[rowIndex].Cells[3].Value.ToString();



        }

    

        public static IEnumerable<Tuple<string, int>> MonthsBetween(
          DateTime startDate,
          DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;

            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, 1);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, 1);
                limit = startDate;
            }

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            while (iterator <= limit)
            {
                yield return Tuple.Create(
                    dateTimeFormat.GetMonthName(iterator.Month),
                    iterator.Year);
                iterator = iterator.AddMonths(1);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellidoP = txtApellidoP.Text;
            string apellidoM = txtApellidoM.Text;
            if (txtNombre.ForeColor == Color.Gray)
            { nombre = ""; }
            if (txtApellidoM.ForeColor == Color.Gray)
            { apellidoM = ""; }
            if (txtApellidoP.ForeColor == Color.Gray)
            { apellidoP = ""; }

            dgEmpleados.DataSource = Omi.getOmisiones(nombre,apellidoP, apellidoM,cbLocalidad.Text,cbOrganismos.Text);

        }       

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //TODO ADD LIST TO BINDINGLIST
                lstTEmpleados.Add(new Tuple<string, string, string, string>(T1, T2, T3, T4));
            if (!lstChkEmpleados.Contains(chkNombreX))
            {
                List<Modelo.Omisiones> newlst = new List<Modelo.Omisiones>();
                newlst = Omi.getOmision(T3,T1, T2);
                lstAux.AddRange(newlst);
                lst = new BindingList<Modelo.Omisiones>(lstAux);
                var source = new BindingSource(lst, null);

                dgDatos.DataSource = lst;
                dgDatos.Columns[0].Visible = false;
                dgDatos.Columns[6].Visible = false;
                dgDatos.Columns[8].Visible = false;

                dgDatos.Columns[37].DisplayIndex = 2;
                dgDatos.Columns[38].DisplayIndex = 3;
                dgDatos.Columns[39].DisplayIndex = 4;
                dgDatos.Columns[7].DisplayIndex = 5;
                dgDatos.Columns[9].DisplayIndex = 6;
                statusStrip1.Items[0].Text = T1 +" "+ T2 +" " + T3 +" \t| AGREGADO.";

                if (lstEmpleados.Contains(nombreX) == false)
                {
                    lstEmpleados.Add(nombreX);
                }
                lstChkEmpleados.Add(chkNombreX);
                //lstEmpleadoSel.Add();
            }
            else
            {
                MessageBox.Show("Registros ya agregados.");
            }
        }


        private void txtApellidoP_Click(object sender, EventArgs e)
        {
            if (txtApellidoP.ForeColor == Color.Gray)
            {
                txtApellidoP.Text = "";
            }

        }
        private void txtApellidoP_TextChanged(object sender, EventArgs e)
        {
            _TypedInto = !String.IsNullOrEmpty(txtApellidoP.Text);

            if (_TypedInto)
            {
                txtApellidoP.ForeColor = Color.Black;
            }

        }
        private void txtApellidoP_Leave(object sender, EventArgs e)
        {
            if (txtApellidoP.Text.Count() == 0)
            {
                txtApellidoP.Text = "Apellido Paterno";
                txtApellidoP.ForeColor = Color.Gray;
            }
        }




        private void txtApellidoM_Click(object sender, EventArgs e)
        {
            if (txtApellidoM.ForeColor == Color.Gray)
            {
                txtApellidoM.Text = "";
            }

        }
        private void txtApellidoM_TextChanged(object sender, EventArgs e)
        {
            _TypedInto = !String.IsNullOrEmpty(txtApellidoM.Text);

            if (_TypedInto)
            {
                txtApellidoM.ForeColor = Color.Black;
            }

        }
        private void txtApellidoM_Leave(object sender, EventArgs e)
        {
            if (txtApellidoM.Text.Count() == 0)
            {
                txtApellidoM.Text = "Apellido Materno";
                txtApellidoM.ForeColor = Color.Gray;
            }
        }

        private void txtNombre_Click(object sender, EventArgs e)
        {
            if (txtNombre.ForeColor == Color.Gray)
            {
                txtNombre.Text = "";
            }

        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            _TypedInto = !String.IsNullOrEmpty(txtNombre.Text);

            if (_TypedInto)
            {
                txtNombre.ForeColor = Color.Black;
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




    }
}
