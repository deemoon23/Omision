using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public frmReporteGeneral()
        {
            InitializeComponent();
        }

        private void frmReporteGeneral_Load(object sender, EventArgs e)
        {
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

            }
            else
            {
                MessageBox.Show("Empleado ya agregado.");
            }

        }
    }
}
