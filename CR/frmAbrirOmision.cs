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
        public string nombre { get { return nombree; } }
        public string apellidoP { get { return apellidoPP; } }
        public string apelidoM { get { return apellidoMM; } }
        public string nombree="";
        public string apellidoPP = "";
        public string apellidoMM = "";

        public frmAbrirOmision()
        {
            InitializeComponent();
            

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
            this.Close();
            if (dgDatos.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dgDatos.SelectedRows[0];

            }
        }

       
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgDatos.DataSource = Omi.getOmisiones(txtNombre.Text.Trim());

        }

        private void dgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            nombree = dgDatos.Rows[rowIndex].Cells[0].Value.ToString();
            apellidoMM = dgDatos.Rows[rowIndex].Cells[2].Value.ToString();
            apellidoPP = dgDatos.Rows[rowIndex].Cells[1].Value.ToString();
            txtNombre.Text = apellidoPP+" " + apellidoMM +" "+ nombre;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}