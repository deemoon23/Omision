using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CR
{
    public partial class frmTabla : Form
    {
        Modelo.localidades localidad;
        Modelo.organismos organismo;
        Dictionary<int, Modelo.cat_organismos2> datos;
        Modelo.tasasOmisiones tasas = new Modelo.tasasOmisiones();
        double sueldo;
        DateTime inicio;
        DateTime final;
        bool interinato;

        public frmTabla(Modelo.localidades _localidad, Modelo.organismos _organismo, Dictionary<int, Modelo.cat_organismos2> _datos, double _sueldo, DateTime _inicio, DateTime _final, bool _Interinato)
        {
            InitializeComponent();
            localidad = _localidad;
            organismo = _organismo;
            datos = _datos;
            sueldo = _sueldo;
            inicio = _inicio;
            final = _final;
            interinato = _Interinato;
        }

        private void frmTabla_Load(object sender, EventArgs e)
        {
            var lstTasa = tasas.getLstTasas(inicio, final);
            Modelo.DatagGridView dgv = new Modelo.DatagGridView();
            dgv.generarGrid(dgDatos);
           // dgv.llenarGrid(lstTasa, sueldo, datos, dgDatos, interinato);

            //    //foreach (DataGridViewRow oItem in dgDatos.Rows)
            //{
            //    if (oItem.Cells[23].Value.ToString() == "" || oItem.Cells[23].Value == null)
            //    {

            //        oItem.Cells[23].Value = "0";
            //    }
            //}
        }


        private void dgDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        //    if (dgDatos.Columns[e.ColumnIndex].ValueType == Type.GetType("System.UInt32"))
        //    {
        //        uint value = (uint)e.Value;
        //        if (value == 0)
        //        {
        //            e.Value = string.Empty;
        //            e.FormattingApplied = true;
        //        }
        //    }
        //    if (dgDatos.Columns[e.ColumnIndex].Name == "FOVI")
        //    {
        //        uint value = (uint)e.Value;
        //        if (value == 0)
        //        {
        //            e.Value = string.Empty;
        //            e.FormattingApplied = true;
        //        }
        //    }
        //    if (dgDatos.Columns[e.ColumnIndex].Name == "Pensión Mínima")
        //    {
        //        uint value = (uint)e.Value;
        //        if (value == 0)
        //        {
        //            e.Value = string.Empty;
        //            e.FormattingApplied = true;
        //        }
        //    }
        }
    }
}
