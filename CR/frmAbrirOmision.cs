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
    public partial class frmAbrirOmision : Form
    {
        Modelo.Omisiones Omi = new Modelo.Omisiones();
        Modelo.organismos Org = new Modelo.organismos();
        Modelo.localidades Loc = new Modelo.localidades();

        public string nombre { get { return nombree; } }
        public string apellidoP { get { return apellidoPP; } }
        public string apelidoM { get { return apellidoMM; } }
        public string localidad { get { return localidadd; } }
        public string organismo { get { return organismoo; } }
        public string localidadd = "";
        public string organismoo = "";
        public string nombree="";
        public string apellidoPP = "";
        public string apellidoMM = "";
           
        public frmAbrirOmision()
        {
            InitializeComponent();
            cbLocalidad.DataSource = Loc.getAll();
            cbLocalidad.DisplayMember = "DESCRIPCION";
            cbLocalidad.ValueMember = "codigo";
            cbOrganismos.DataSource = Org.getAll();
            cbOrganismos.DisplayMember = "DESCRIPCION";
            cbOrganismos.ValueMember = "codigo";
        }

        private void frmAbrirOmision_Load(object sender, EventArgs e)
        {           
            dgDatos.DataSource = Omi.getOmisiones();
            dgDatos.Columns[0].HeaderText = "Nombre";
            dgDatos.Columns[0].DisplayIndex = 2;
            dgDatos.Columns[1].HeaderText = "Apellido Paterno";
            dgDatos.Columns[1].DisplayIndex = 0;
            dgDatos.Columns[2].HeaderText = "Apellido Materno";
            dgDatos.Columns[2].DisplayIndex = 1;
            dgDatos.Columns[3].HeaderText = "Fecha";
            dgDatos.Columns[3].DisplayIndex = 5;
            dgDatos.Columns[4].HeaderText = "Localidad";
            dgDatos.Columns[5].HeaderText = "Organismo";               
        }
        
        private void dgDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            nombree= dgDatos.Rows[rowIndex].Cells[0].Value.ToString();
            apellidoMM = dgDatos.Rows[rowIndex].Cells[2].Value.ToString();
            apellidoPP= dgDatos.Rows[rowIndex].Cells[1].Value.ToString();
            localidadd = dgDatos.Rows[rowIndex].Cells[4].Value.ToString();
            organismoo = dgDatos.Rows[rowIndex].Cells[5].Value.ToString();
            this.Close();
            if (dgDatos.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgDatos.SelectedRows[0];

            }
        }
       
        private void btnBuscar_Click(object sender, EventArgs e)
        {        
            dgDatos.DataSource = Omi.getOmisiones(txtNombre.Text.Trim(), txtApellidoP.Text, txtApellidoM.Text, cbLocalidad.Text, cbOrganismos.Text);
        }

        private void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
            {
                int rowIndex = e.RowIndex;
                nombree = dgDatos.Rows[rowIndex].Cells[0].Value.ToString();
                apellidoMM = dgDatos.Rows[rowIndex].Cells[2].Value.ToString();
                apellidoPP = dgDatos.Rows[rowIndex].Cells[1].Value.ToString();
                txtNombre.Text =  nombre;
                txtApellidoM.Text = apellidoMM;
                txtApellidoP.Text = apellidoPP;
                int index = cbLocalidad.FindString(dgDatos.Rows[rowIndex].Cells[4].Value.ToString());
                cbLocalidad.SelectedIndex = index;
                int index2 = cbOrganismos.FindString(dgDatos.Rows[rowIndex].Cells[5].Value.ToString());
                cbOrganismos.SelectedIndex = index2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}