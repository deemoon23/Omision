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
            List<Modelo.Omisiones> newlst = new List<Modelo.Omisiones>();
            newlst = Omi.getOmision(dgEmpleados.Rows[rowIndex].Cells[0].Value.ToString(), dgEmpleados.Rows[rowIndex].Cells[1].Value.ToString(), dgEmpleados.Rows[rowIndex].Cells[2].Value.ToString());
            lstAux.AddRange(newlst);
            List<Modelo.Omisiones> test = lstAux;
            dgDatos.Rows.Clear();
            lst = new BindingList<Modelo.Omisiones>(lstAux);
            var source = new BindingSource(lst, null);

            dgDatos.DataSource = lst;
            
                       
        }
    }
}
