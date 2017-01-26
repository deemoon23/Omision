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

namespace CR.Modelo
{
    class DatagGridView
    {
        /// <summary>
        /// Da formato a un DataGridView
        /// </summary>
        /// <param name="Grid">DataGridView que se quiere aplicar el formato</param>
        /// <param name="agregar">Booleano que dice si se borra el contenido anterior del DataGridView o se concatena</param>
        public void generarGrid(DataGridView Grid, bool agregar, bool flag)
        {
            //TODO GUARDAR VERIFICAR DATOS
            //  var lstTasa = tasas.getLstTasas(inicio, final);
            if (agregar == false || flag==true)
            {
                Grid.DataSource = null;
                Grid.Rows.Clear();
            }
            Grid.ColumnCount = 34;
            Grid.Columns[0].Name = "Sueldo Mensual";
            Grid.Columns[1].Name = "Mes Omitido";
            Grid.Columns[2].Name = "Número de Meses";
            Grid.Columns[3].Name = "Total Sueldo Base A Calcular";
            Grid.Columns[4].Name = "Servicio Médico";
            Grid.Columns[5].Name = "Gastos Inf. Hosp.";
            Grid.Columns[6].Name = "Fondo de Pensión";
            Grid.Columns[7].Name = "C.P";
            Grid.Columns[8].Name = "Prendario";
            Grid.Columns[9].Name = "Seguro de Vida";
            Grid.Columns[10].Name = "Seguro de Retiro";
            Grid.Columns[11].Name = "Total Cuotas";
            Grid.Columns[12].Name = "Tasa";
            Grid.Columns[13].Name = "Importe";
            Grid.Columns[14].Name = "Servicio Médico";
            Grid.Columns[15].Name = "Gastos Inf. Hosp.";
            Grid.Columns[16].Name = "Fondo de Pensión";
            Grid.Columns[17].Name = "C.P";
            Grid.Columns[18].Name = "Prendario";
            Grid.Columns[19].Name = "Indemn. Global";
            Grid.Columns[20].Name = "Ayuda de funeral";
            Grid.Columns[21].Name = "Gastos Admón";
            Grid.Columns[22].Name = "Pensión Mínima";
            Grid.Columns[23].Name = "FOVI";
            Grid.Columns[24].Name = "Seguro de Vida";
            Grid.Columns[25].Name = "Seguro de Retiro";
            Grid.Columns[26].Name = "Total Aportaciones";
            Grid.Columns[27].Name = "Tasa";
            Grid.Columns[28].Name = "Importe";
            Grid.Columns[29].Name = "Total cuotas aport.";
            Grid.Columns[30].Name = "Total Moratario";
            Grid.Columns[31].Name = "TOTAL GENERAL";
            Grid.Columns[32].Name = "Ultima Tasa";
            Grid.Columns[33].Name = "Fecha";

        }

        /// <summary>
        /// Alimenta de información el DataGridView con el cálculo de omisión.
        /// </summary>
        /// <param name="lstTasa">Lista de tasas de cada mes entre el rango de fechas de la omisión.</param>
        /// <param name="sueldo">Sueldo del empleado</param>
        /// <param name="datos">Datos del catálogo de organismos</param>
        /// <param name="Grid">DataGridView que se desea utilizar</param>
        /// <param name="_Interinato">Booleano que determina si el cálculo se realizara con las tasas de interinato</param>
        /// <param name="_Tipo">Tipo de cobro.</param>
        public void llenarGrid(Dictionary<DateTime, double> lstTasa, double sueldo, Dictionary<int, Modelo.cat_organismos2> datos, DataGridView Grid, bool _Interinato, int _Tipo)
        {
           
            
           
            Modelo.tasasOmisiones tasas = new Modelo.tasasOmisiones();
            DateTime ultimaTasa = tasas.getUltimaTasa().fecha;
            Modelo.tasasOmisionesInterinato tasasInter = new tasasOmisionesInterinato();
            var y = 0.0;

            
            foreach (var item in lstTasa)
            {
                string mes = "";
                double tasa;
                if (_Interinato == false)
                {
                    tasa = tasas.getTasa(item.Key);
                }
                else
                {
                    tasa = tasasInter.getTasa(item.Key);
                }

                DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
                int año = item.Key.Year;
                if (_Tipo == 1)
                {
                    if (item.Key.Minute == 1)
                    {
                        mes = item.Key.ToString("Q2 yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                    }
                    else
                    {
                        mes = item.Key.ToString("Q1 yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                    }
                }
                else
                {
                    mes = item.Key.ToString("yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                }
                if (datos.ContainsKey(año))
                {
                    double servMed = Convert.ToDouble(datos[año].C_ServMedico / 100) * sueldo;
                    double gInfHosp = Convert.ToDouble(datos[año].C_GastosInfra / 100) * sueldo;
                    double fondoP = Convert.ToDouble(datos[año].C_FondoPens / 100) * sueldo;
                    double CP = Convert.ToDouble(datos[año].C_CortoPlazo / 100) * sueldo;
                    double prendario = Convert.ToDouble(datos[año].C_Prendario / 100) * sueldo;
                    double segurovida = Convert.ToDouble(datos[año].C_SeguroVida);
                    double seguroretiro = Convert.ToDouble(datos[año].C_SeguroRetiro);
                    double totalCuotas = servMed + gInfHosp + fondoP + CP + prendario + segurovida + seguroretiro;
                    double importe = totalCuotas * (tasa / 100);
                    double a_servMed = Convert.ToDouble(datos[año].A_ServMedico / 100) * sueldo;
                    double a_gInfHosp = Convert.ToDouble(datos[año].A_GastosInfra / 100) * sueldo;
                    double a_fondoP = Convert.ToDouble(datos[año].A_FondoPens / 100) * sueldo;
                    double a_CP = Convert.ToDouble(datos[año].A_CortoPlazo / 100) * sueldo;
                    double a_prendario = Convert.ToDouble(datos[año].A_Prendario / 100) * sueldo;
                    double a_indGlobal = Convert.ToDouble(datos[año].A_Indemniza / 100) * sueldo;
                    double a_ayudaFune = Convert.ToDouble(datos[año].A_AyudaFune / 100) * sueldo;
                    double a_GastosAdmin = Convert.ToDouble(datos[año].A_GastosAdmin / 100) * sueldo;
                    double a_pensionMin = Convert.ToDouble(datos[año].A_PensionMin / 100) * sueldo;
                    double a_Fovi = Convert.ToDouble(datos[año].A_Fovisssteson / 100) * sueldo;
                    double a_segurovida = Convert.ToDouble(datos[año].A_SeguroVida);
                    double a_seguroretiro = Convert.ToDouble(datos[año].A_SeguroRetiro);
                    double a_TotalAportaciones = a_servMed + a_gInfHosp + a_fondoP + a_CP + a_prendario + a_indGlobal + a_ayudaFune + a_GastosAdmin + a_pensionMin + a_Fovi + a_segurovida + a_seguroretiro;
                    double a_importe = (tasa / 100) * a_TotalAportaciones;
                    double totalCuoApo = a_TotalAportaciones + totalCuotas;
                    double totalMor = importe + a_importe;
                    double totalGen = totalMor + totalCuoApo;

                    string[] row = new string[] { sueldo + "",
                    mes, "1",
                    sueldo.ToString(),
                    servMed.ToString("#.00"),
                    gInfHosp.ToString("#.00"),
                    fondoP.ToString("#.00"),
                    CP.ToString("#.00"),
                    prendario.ToString("#.00"),
                    segurovida.ToString("#.00"),
                    seguroretiro.ToString(),
                    totalCuotas.ToString("#.00"),
                    tasa.ToString("#.00")+"%",
                    importe.ToString(),
                    a_servMed.ToString("#.00"),
                    a_gInfHosp.ToString("#.00"),
                    a_fondoP.ToString("#.00"),
                    a_CP.ToString("#.00"),
                    a_prendario.ToString("#.00"),
                    a_indGlobal.ToString("#.00"),
                    a_ayudaFune.ToString("#.00"),
                    a_GastosAdmin.ToString("#.00"),
                    a_pensionMin.ToString("#.00"),
                    a_Fovi.ToString("#.00"),
                    a_segurovida.ToString("#.00"),
                    a_seguroretiro.ToString("#.00"),
                    a_TotalAportaciones.ToString("#.00"),
                    tasa.ToString()+"%",
                    a_importe.ToString(),
                    totalCuoApo.ToString("#.00"),
                    totalMor.ToString("#.00"),
                    totalGen.ToString("#.00"),
                    ultimaTasa.ToShortDateString(),
                    item.Key.ToShortDateString()

                    };
                    Grid.Rows.Add(row);
                }
                else
                {
                    string[] row = new string[] { sueldo + "",
                    mes, "1",
                    sueldo.ToString(),
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    "0.0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ultimaTasa.ToShortDateString(),
                    item.Key.ToShortDateString()

                    };
                    Grid.Rows.Add(row);
                    MessageBox.Show("No se encontraron datos del organismo para el año "+año+".");

                }
            }
        }
        /// <summary>
        /// Alimenta de información el DataGridView con el cálculo de omisión.
        /// </summary>
        /// <param name="lstTasa">Lista de tasas de cada mes entre el rango de fechas de la omisión.</param>
        /// <param name="sueldo">Sueldo del empleado</param>
        /// <param name="datos">Datos del catálogo de organismos</param>
        /// <param name="Grid">DataGridView que se desea utilizar</param>
        /// <param name="_Interinato">Booleano que determina si el cálculo se realizara con las tasas de interinato</param>
        /// <param name="_UltimaTasa">Fecha de la ultima tasa que se desea utilizar para el cálculo.</param>
        /// <param name="_Tipo">Tipo de cobro.</param>
        public void llenarGrid(Dictionary<DateTime, double> lstTasa, double sueldo, Dictionary<int, Modelo.cat_organismos2> datos, DataGridView Grid, bool _Interinato, DateTime _UltimaTasa, int _Tipo)
        {
            string mes = "";
            Modelo.tasasOmisiones tasas = new Modelo.tasasOmisiones();
            Modelo.tasasOmisionesInterinato tasasInter = new tasasOmisionesInterinato();
            var first = lstTasa.First();          
            foreach (var item in lstTasa)
            {
                double tasa;
                if (_Interinato == false)
                {
                    tasa = tasas.getTasa(item.Key,_UltimaTasa);
                }
                else
                {
                    tasa = tasasInter.getTasa(item.Key, _UltimaTasa);
                }

                DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
                int año = item.Key.Year;
                if (_Tipo == 1)
                {
                    if (item.Key.Minute == 1)
                    {
                        mes = item.Key.ToString("Q2 yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                    }
                    else
                    {
                        mes = item.Key.ToString("Q1 yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                    }
                }
                else
                {
                    mes = item.Key.ToString("yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                }
                DateTime ultimaTasa = new DateTime(_UltimaTasa.Year, _UltimaTasa.Month, 1, 0, 0, 0);

                if (datos.ContainsKey(año))
                {


                    double servMed = Convert.ToDouble(datos[año].C_ServMedico / 100) * sueldo;
                    double gInfHosp = Convert.ToDouble(datos[año].C_GastosInfra / 100) * sueldo;
                    double fondoP = Convert.ToDouble(datos[año].C_FondoPens / 100) * sueldo;
                    double CP = Convert.ToDouble(datos[año].C_CortoPlazo / 100) * sueldo;
                    double prendario = Convert.ToDouble(datos[año].C_Prendario / 100) * sueldo;
                    double segurovida = Convert.ToDouble(datos[año].C_SeguroVida);
                    double seguroretiro = Convert.ToDouble(datos[año].C_SeguroRetiro);
                    double totalCuotas = servMed + gInfHosp + fondoP + CP + prendario + segurovida + seguroretiro;
                    double importe = totalCuotas * (tasa / 100);
                    double a_servMed = Convert.ToDouble(datos[año].A_ServMedico / 100) * sueldo;
                    double a_gInfHosp = Convert.ToDouble(datos[año].A_GastosInfra / 100) * sueldo;
                    double a_fondoP = Convert.ToDouble(datos[año].A_FondoPens / 100) * sueldo;
                    double a_CP = Convert.ToDouble(datos[año].A_CortoPlazo / 100) * sueldo;
                    double a_prendario = Convert.ToDouble(datos[año].A_Prendario / 100) * sueldo;
                    double a_indGlobal = Convert.ToDouble(datos[año].A_Indemniza / 100) * sueldo;
                    double a_ayudaFune = Convert.ToDouble(datos[año].A_AyudaFune / 100) * sueldo;
                    double a_GastosAdmin = Convert.ToDouble(datos[año].A_GastosAdmin / 100) * sueldo;
                    double a_pensionMin = Convert.ToDouble(datos[año].A_PensionMin / 100) * sueldo;
                    double a_Fovi = Convert.ToDouble(datos[año].A_Fovisssteson / 100) * sueldo;
                    double a_segurovida = Convert.ToDouble(datos[año].A_SeguroVida);
                    double a_seguroretiro = Convert.ToDouble(datos[año].A_SeguroRetiro);
                    double a_TotalAportaciones = a_servMed + a_gInfHosp + a_fondoP + a_CP + a_prendario + a_indGlobal + a_ayudaFune + a_GastosAdmin + a_pensionMin + a_Fovi + a_segurovida + a_seguroretiro;
                    double a_importe = (tasa / 100) * a_TotalAportaciones;
                    double totalCuoApo = a_TotalAportaciones + totalCuotas;
                    double totalMor = importe + a_importe;
                    double totalGen = totalMor + totalCuoApo;

                

                    string[] row = new string[] { sueldo + "",
                    mes, "1",
                    sueldo.ToString(),
                    servMed.ToString("#.0"),
                    gInfHosp.ToString("#.0"),
                    fondoP.ToString("#.0"),
                    CP.ToString("#.0"),
                    prendario.ToString("#.0"),
                    segurovida.ToString("#.0"),
                    seguroretiro.ToString("#.0"),
                    totalCuotas.ToString("#.0"),
                    tasa.ToString("#.0")+"%",
                    importe.ToString(),
                    a_servMed.ToString("#.0"),
                    a_gInfHosp.ToString("#.0"),
                    a_fondoP.ToString("#.0"),
                    a_CP.ToString("#.0"),
                    a_prendario.ToString("#.0"),
                    a_indGlobal.ToString("#.0"),
                    a_ayudaFune.ToString("#.0"),
                    a_GastosAdmin.ToString("#.0"),
                    a_pensionMin.ToString("#.0"),
                    a_Fovi.ToString("#.0"),
                    a_segurovida.ToString("#.0"),
                    a_seguroretiro.ToString("#.0"),
                    a_TotalAportaciones.ToString("#.0"),
                    tasa.ToString("#.0")+"%",
                    a_importe.ToString(),
                    totalCuoApo.ToString("#.0"),
                    totalMor.ToString("#.0"),
                    totalGen.ToString("#.0"),
                    ultimaTasa.ToShortDateString(),
                    item.Key.ToShortDateString()
                    };
                    Grid.Rows.Add(row);
                }
                else
                {
                    string[] row = new string[] { sueldo + "",
                    mes, "1",
                    sueldo.ToString(),
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    "0.0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ultimaTasa.ToShortDateString(),
                    item.Key.ToShortDateString()

                    };
                    Grid.Rows.Add(row);
                    MessageBox.Show("No se encontraron datos del organismo para el año "+año+"");
                }
            }
        }
        public void llenarGrid(Dictionary<DateTime, double> lstTasa, List<double> _sueldo, Dictionary<int, Modelo.cat_organismos2> datos, DataGridView Grid, bool _Interinato, int _Tipo)
        {
            
            Modelo.tasasOmisiones tasas = new Modelo.tasasOmisiones();
            DateTime ultimaTasa = tasas.getUltimaTasa().fecha;

            Modelo.tasasOmisionesInterinato tasasInter = new tasasOmisionesInterinato();
            var y = 0.0;
            int i = 0;
         


            foreach (var item in lstTasa)
            {
                double sueldo = _sueldo[i];
                i++;
                string mes = "";
                double tasa;
                if (_Interinato == false)
                {
                    tasa = tasas.getTasa(item.Key);
                }
                else
                {
                    tasa = tasasInter.getTasa(item.Key);
                }

                DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
                int año = item.Key.Year;
                if (_Tipo == 1)
                {
                    if (item.Key.Minute == 1)
                    {
                        mes = item.Key.ToString("Q2 yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                    }
                    else
                    {
                        mes = item.Key.ToString("Q1 yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                    }
                }
                else
                {
                    mes = item.Key.ToString("yy-MMM", CultureInfo.CurrentCulture).ToUpper();
                }
                if (datos.ContainsKey(año))
                {
                    double servMed = Convert.ToDouble(datos[año].C_ServMedico / 100) * sueldo;
                    double gInfHosp = Convert.ToDouble(datos[año].C_GastosInfra / 100) * sueldo;
                    double fondoP = Convert.ToDouble(datos[año].C_FondoPens / 100) * sueldo;
                    double CP = Convert.ToDouble(datos[año].C_CortoPlazo / 100) * sueldo;
                    double prendario = Convert.ToDouble(datos[año].C_Prendario / 100) * sueldo;
                    double segurovida = Convert.ToDouble(datos[año].C_SeguroVida);
                    double seguroretiro = Convert.ToDouble(datos[año].C_SeguroRetiro);
                    double totalCuotas = servMed + gInfHosp + fondoP + CP + prendario + segurovida + seguroretiro;
                    double importe = totalCuotas * (tasa / 100);
                    double a_servMed = Convert.ToDouble(datos[año].A_ServMedico / 100) * sueldo;
                    double a_gInfHosp = Convert.ToDouble(datos[año].A_GastosInfra / 100) * sueldo;
                    double a_fondoP = Convert.ToDouble(datos[año].A_FondoPens / 100) * sueldo;
                    double a_CP = Convert.ToDouble(datos[año].A_CortoPlazo / 100) * sueldo;
                    double a_prendario = Convert.ToDouble(datos[año].A_Prendario / 100) * sueldo;
                    double a_indGlobal = Convert.ToDouble(datos[año].A_Indemniza / 100) * sueldo;
                    double a_ayudaFune = Convert.ToDouble(datos[año].A_AyudaFune / 100) * sueldo;
                    double a_GastosAdmin = Convert.ToDouble(datos[año].A_GastosAdmin / 100) * sueldo;
                    double a_pensionMin = Convert.ToDouble(datos[año].A_PensionMin / 100) * sueldo;
                    double a_Fovi = Convert.ToDouble(datos[año].A_Fovisssteson / 100) * sueldo;
                    double a_segurovida = Convert.ToDouble(datos[año].A_SeguroVida);
                    double a_seguroretiro = Convert.ToDouble(datos[año].A_SeguroRetiro);
                    double a_TotalAportaciones = a_servMed + a_gInfHosp + a_fondoP + a_CP + a_prendario + a_indGlobal + a_ayudaFune + a_GastosAdmin + a_pensionMin + a_Fovi + a_segurovida + a_seguroretiro;
                    double a_importe = (tasa / 100) * a_TotalAportaciones;
                    double totalCuoApo = a_TotalAportaciones + totalCuotas;
                    double totalMor = importe + a_importe;
                    double totalGen = totalMor + totalCuoApo;

                    string[] row = new string[] { sueldo + "",
                    mes, "1",
                    sueldo.ToString(),
                    servMed.ToString("#.0"),
                    gInfHosp.ToString("#.0"),
                    fondoP.ToString("#.0"),
                    CP.ToString("#.0"),
                    prendario.ToString("#.0"),
                    segurovida.ToString("#.0"),
                    seguroretiro.ToString("#.0"),
                    totalCuotas.ToString("#.0"),
                    tasa.ToString("#.0")+"%",
                    importe.ToString(),
                    a_servMed.ToString("#.0"),
                    a_gInfHosp.ToString("#.0"),
                    a_fondoP.ToString("#.0"),
                    a_CP.ToString("#.0"),
                    a_prendario.ToString("#.0"),
                    a_indGlobal.ToString("#.0"),
                    a_ayudaFune.ToString("#.0"),
                    a_GastosAdmin.ToString("#.0"),
                    a_pensionMin.ToString("#.0"),
                    a_Fovi.ToString("#.0"),
                    a_segurovida.ToString("#.0"),
                    a_seguroretiro.ToString("#.0"),
                    a_TotalAportaciones.ToString("#.0"),
                    tasa.ToString("#.0")+"%",
                    a_importe.ToString(),
                    totalCuoApo.ToString("#.0"),
                    totalMor.ToString("#.0"),
                    totalGen.ToString("#.0"),
                    ultimaTasa.ToShortDateString(),
                    item.Key.ToShortDateString()

                    };
                    Grid.Rows.Add(row);
                }
                else
                {
                    string[] row = new string[] { sueldo + "",
                    mes, "1",
                    sueldo.ToString(),
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    "0.0",
                    ".0",
                    ".0",
                    ".0",
                    ".0",
                    ultimaTasa.ToShortDateString(),
                    item.Key.ToShortDateString()

                    };
                    Grid.Rows.Add(row);
                    MessageBox.Show("No se encontraron datos del organismo para el año " + año + ".");

                }
            }
        }

    }
}