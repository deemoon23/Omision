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
        DSGeneral data;
        public frmVistaPrevia(DataSet1 _datos)
        {
            InitializeComponent();
            datos = _datos;
            crystalReportViewer2.Visible = false;
            crystalReportViewer1.Visible = true;
            CrystalReport1 rpt = new CrystalReport1();
            rpt.SetDataSource(datos);
            crystalReportViewer1.ReportSource = rpt;

        }

        public frmVistaPrevia(DSGeneral _datos)
        {
            InitializeComponent();
            data = _datos;
            crystalReportViewer1.Visible = false;
            crystalReportViewer2.Visible = true;
            CRGeneral rpt = new CRGeneral();

            rpt.SetDataSource(data);
            crystalReportViewer2.ReportSource = rpt;

        }

        private void frmVistaPrevia_Load(object sender, EventArgs e)
        {

           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
