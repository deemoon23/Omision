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
    public partial class frmBuscarEmpleado : Form
    {
        private bool _TypedInto;

        Modelo.trabajadores tra = new Modelo.trabajadores();
        Modelo.localidades loc = new Modelo.localidades();
        Modelo.organismos org = new Modelo.organismos();
        public string nombre { get { return nombree; } }
        public string apellidoP { get { return apellidoPP; } }
        public string apellidoM { get { return apellidoMM; } }
        public string generacion { get { return generacionn; } }
        public int idLocalidad { get { return idLocalidadd; } }
        public int idOrganismo { get{ return idOrganismoo; } }
        string nombree;
        string apellidoPP;
        string apellidoMM;
        int idLocalidadd;
        int idOrganismoo;
        string generacionn;
        
        public frmBuscarEmpleado()
        {
            InitializeComponent();
          
            //    BindingList<Modelo.Omisiones> bs = (BindingList<Modelo.Omisiones>)Grid.DataSource; // Se convierte el DataSource 

            List<Modelo.organismos> lstORG = org.getAll();
            List<Modelo.localidades> lstLOC = loc.getAll();
            lstORG.RemoveAt(0);
            lstLOC.RemoveAt(0);
             cbOrganismos.DataSource = lstORG.ToList();
            cbLocalidad.DataSource = lstLOC.ToList();
            cbLocalidad.DisplayMember = "DESCRIPCION";
            cbLocalidad.ValueMember = "codigo";
            cbOrganismos.DisplayMember = "DESCRIPCION";
            cbOrganismos.ValueMember = "codigo";

        }

        private void frmBuscarEmpleado_Load(object sender, EventArgs e)
        {
            txtApellidoP.Text = "Apellido Paterno";
            txtApellidoP.ForeColor = Color.Gray;
            txtApellidoM.Text = "Apellido Materno";
            txtApellidoM.ForeColor = Color.Gray;
            txtNombre.Text = "Nombre";
            txtNombre.ForeColor = Color.Gray;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellidoP = txtApellidoP.Text;
            string apellidoM = txtApellidoM.Text;
            if (txtNombre.ForeColor== Color.Gray)
            { nombre = ""; }
            if (txtApellidoM.ForeColor == Color.Gray)
            { apellidoM= ""; }
            if (txtApellidoP.ForeColor == Color.Gray)
            { apellidoP = ""; }
            dgDatos.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing; //or even better .DisableResizing. Most time consumption enum is DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders

            // set it to false if not needed
            dgDatos.RowHeadersVisible = false;

            dgDatos.DataSource = tra.getTrabajadores(nombre, apellidoP, apellidoM, cbLocalidad.Text, cbOrganismos.Text);

        }

        private void dgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int rowIndex = e.RowIndex;
                nombree = dgDatos.Rows[rowIndex].Cells["tnombre"].Value.ToString();
                apellidoMM = dgDatos.Rows[rowIndex].Cells["tpaterno"].Value.ToString();
                apellidoPP = dgDatos.Rows[rowIndex].Cells["tmaterno"].Value.ToString();
                idLocalidadd = Convert.ToInt32(dgDatos.Rows[rowIndex].Cells["tultimalocalidad"].Value);
                idOrganismoo = Convert.ToInt32(dgDatos.Rows[rowIndex].Cells["tultimoorganismo"].Value);
                generacionn = dgDatos.Rows[rowIndex].Cells["generacion"].Value.ToString();
                txtApellidoM.Text = apellidoMM;
                txtApellidoP.Text = apellidoP;
                txtNombre.Text = nombree;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int rowIndex = e.RowIndex;
                nombree = dgDatos.Rows[rowIndex].Cells["tnombre"].Value.ToString();
                apellidoMM = dgDatos.Rows[rowIndex].Cells["tpaterno"].Value.ToString();
                apellidoPP = dgDatos.Rows[rowIndex].Cells["tmaterno"].Value.ToString();
                idLocalidadd = Convert.ToInt32(dgDatos.Rows[rowIndex].Cells["tultimalocalidad"].Value);
                idOrganismoo = Convert.ToInt32(dgDatos.Rows[rowIndex].Cells["tultimoorganismo"].Value);
                generacionn = dgDatos.Rows[rowIndex].Cells["generacion"].Value.ToString();

                this.Close();
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
