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
    public partial class frmBonificaciones : Form
    {

        Modelo.localidades loc = new Modelo.localidades();
        Modelo.organismos org = new Modelo.organismos();
       
        public frmBonificaciones()
        {
            InitializeComponent();
            cbLocalidad.DataSource = loc.getAll();
            cbLocalidad.DisplayMember = "DESCRIPCION";
            cbLocalidad.ValueMember = "codigo";
            cbOrganismos.DataSource = org.getAll();
            cbOrganismos.DisplayMember = "DESCRIPCION";
            cbOrganismos.ValueMember = "codigo";
        }

        private void frmBonificaciones_Load(object sender, EventArgs e)
        {

        }
    }
}
