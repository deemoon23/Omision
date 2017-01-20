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
        Modelo.Omisiones Omi = new Modelo.Omisiones();
        List<Modelo.Omisiones> lstAux = new List<Modelo.Omisiones>();
        BindingList<Modelo.Omisiones> lst;
        List<string> lstEmpleados = new List<string>();
        List<Tuple<string, string, string>> lstTEmpleados = new List<Tuple<string, string, string>>();
        public frmReporteGeneral()
        {
            InitializeComponent();
        }

        private void frmReporteGeneral_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker2.CustomFormat = "MMMM yyyy";
            dgEmpleados.DataSource = Omi.getOmisiones();
            dgEmpleados.Columns[0].HeaderText = "Nombre";
            dgEmpleados.Columns[1].HeaderText = "Apellido Paterno";
            dgEmpleados.Columns[2].HeaderText = "Apellido Materno";
            dgEmpleados.Columns[3].HeaderText = "Fecha";
            dgEmpleados.Columns[3].DisplayIndex = 5;
            dgEmpleados.Columns[4].HeaderText = "Localidad";
            dgEmpleados.Columns[5].HeaderText = "Organismo";

            
        }

        private void dgEmpleados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO ADD LIST TO BINDINGLIST
            int rowIndex = e.RowIndex;

            string nombre = dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString() +" "+ dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString() +" "+ dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString();
            lstTEmpleados.Add(new Tuple<string, string, string>(dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString(), dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString(), dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString()));
            if (!lstEmpleados.Contains(nombre))
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
                lstEmpleados.Add(nombre);
                //lstEmpleadoSel.Add();
            }
            else
            {
                MessageBox.Show("Empleado ya agregado.");
            }

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            int meses = ((dateTimePicker2.Value.Year*12 + dateTimePicker2.Value.Month)- (dateTimePicker1.Value.Year * 12 + dateTimePicker1.Value.Month))+1;
            lblParciales.Text = meses.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int meses = ((dateTimePicker2.Value.Year * 12 + dateTimePicker2.Value.Month) - (dateTimePicker1.Value.Year * 12 + dateTimePicker1.Value.Month))+1;
            lblParciales.Text = meses.ToString();
        }

        //public static Tuple<int, double, double, double, double, double, double, Tuple<double, double, double, double, double, double, double,Tuple<double>>>
        //Create(int t1, double t2, double t3, double t4, double t5, double t6, double t7, double t8, double t9, double t10, double t11, double t12, double t13, double t14,
        //    double t15)
        //{
        //    return new Tuple<int, double, double, double, double, double, double, Tuple<double, double, double, double, double, double, double,Tuple<double>>>
        //        (t1, t2, t3, t4, t5, t6, t7, Tuple.Create(t8, t9,t10,t11,t12,t13,t14,Tuple.Create(t15)));
        //}

        private void button1_Click(object sender, EventArgs e)
        {

            int i = 0;

            List<int> lstAnios = new List<int>();
            int anio = 0;
            double sm = 0;
            if (i == 0)
            {

                anio = Convert.ToDateTime(dgDatos.Rows[0].Cells[2].Value.ToString()).Year;
                lstAnios.Add(anio);

            }

            foreach (DataGridViewRow row in dgDatos.Rows)
            {
                if (i < dgDatos.Rows.Count - 1)

                {
                    if (anio != Convert.ToDateTime(dgDatos.Rows[i].Cells[2].Value.ToString()).Year)
                    {
                        anio = Convert.ToDateTime(dgDatos.Rows[i].Cells[2].Value.ToString()).Year;
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
            DSGeneral ds = new DSGeneral();

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
            foreach (var item in lstEmpleados)
            {
                DSGeneral.dtEmpleadoRow dato = ds.dtEmpleado.NewdtEmpleadoRow();
                dato.nombre = item;
                dato.tMes = Convert.ToDecimal((from a in lst where a.nombre == lstTEmpleados[count].Item3 && a.apellidoM == lstTEmpleados[count].Item2 &&
                                               a.apellidoP == lstTEmpleados[count].Item1 select a.tmes).Sum());
                ds.dtEmpleado.ImportRow(dato);

            }
            DSGeneral.dtPorMesRow data = ds.dtPorMes.NewdtPorMesRow();
            int numMeses = Convert.ToInt32(lblParciales.Text);
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            var months = MonthsBetween(startDate, endDate);
            for (int ii = 0; ii < numMeses; ii++)
            {

               
                data.mes = months.ElementAt(ii).Item1 + " "+ months.ElementAt(ii).Item2.ToString();
                data.sueldo = Convert.ToDecimal((from a in lst select a.sueldo).Sum())/ numMeses;
                data.cfp = Convert.ToDecimal((from a in lst select a.cfp).Sum()) / numMeses;
                data.ccp = Convert.ToDecimal((from a in lst select a.ccp).Sum())/ numMeses;
                data.csm = Convert.ToDecimal((from a in lst select a.csm).Sum())/ numMeses;
                data.apren = Convert.ToDecimal((from a in lst select a.apren).Sum()) / numMeses;
                data.csv = Convert.ToDecimal((from a in lst select a.csv).Sum())/ numMeses;
                data.csr = Convert.ToDecimal((from a in lst select a.csr).Sum())/ numMeses;
                data.cgi = Convert.ToDecimal((from a in lst select a.cgi).Sum()) / numMeses;
                data.tcuotas = Convert.ToDecimal((from a in lst select a.tcuotas).Sum()) / numMeses;
                data.importeC = Convert.ToDecimal((from a in lst select a.importeC).Sum()) / numMeses;
                data.acp = Convert.ToDecimal((from a in lst select a.acp).Sum()) / numMeses;
                data.afp = Convert.ToDecimal((from a in lst select a.afp).Sum()) / numMeses;
                data.asm = Convert.ToDecimal((from a in lst select a.asm).Sum()) / numMeses;
                data.apren = Convert.ToDecimal((from a in lst select a.apren).Sum()) / numMeses;
                data.asv = Convert.ToDecimal((from a in lst select a.asv).Sum())/ numMeses;
                data.asr = Convert.ToDecimal((from a in lst select a.asr).Sum())/ numMeses;
                data.agi = Convert.ToDecimal((from a in lst select a.agi).Sum()) / numMeses;
                data.afovi = Convert.ToDecimal((from a in lst select a.afovi).Sum()) / numMeses;
                data.apm = Convert.ToDecimal((from a in lst select a.apm).Sum())/ numMeses;
                data.aaf = Convert.ToDecimal((from a in lst select a.aaf).Sum())/ numMeses;
                data.aig = Convert.ToDecimal((from a in lst select a.aig).Sum())/ numMeses;
                data.aga = Convert.ToDecimal((from a in lst select a.aga).Sum()) / numMeses;
                data.taporte = Convert.ToDecimal((from a in lst select a.taporta).Sum()) / numMeses;
                data.importeA = Convert.ToDecimal((from a in lst select a.importeA).Sum()) / numMeses;
                data.tasa = Convert.ToDecimal((from a in lst select a.tasa).Sum()) / numMeses;
                data.tmoratorio = Convert.ToDecimal((from a in lst select a.tmoratorio).Sum()) / numMeses;
                data.tmes = Convert.ToDecimal((from a in lst select a.tmes).Sum()) / numMeses;               
                ds.dtPorMes.ImportRow(data);



            }
            frmVistaPrevia frm = new frmVistaPrevia(ds);
            frm.Show();

        }

        private void dgEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


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
    }
}
