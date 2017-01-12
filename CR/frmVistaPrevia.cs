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
    public partial class frmVistaPrevia : Form
    {
        DataSet1 datos;
        public frmVistaPrevia(DataSet1 _datos)
        {
            InitializeComponent();
            datos = _datos;

        }

        private void frmVistaPrevia_Load(object sender, EventArgs e)
        {

            CrystalReport1 rpt = new CrystalReport1();

            rpt.SetDataSource(datos);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
