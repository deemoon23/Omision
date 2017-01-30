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
        public void llenarGrid(Dictionary<DateTime, double> lstTasa, decimal sueldo, Dictionary<int, Modelo.cat_organismos2> datos, DataGridView Grid, bool _Interinato, int _Tipo)
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

                    decimal segurovida = 0, seguroretiro = 0, a_segurovida = 0, a_seguroretiro = 0;

                   decimal servMed = (Convert.ToDecimal(datos[año].C_ServMedico) / 100) * sueldo;
                   decimal gInfHosp = (Convert.ToDecimal(datos[año].C_GastosInfra) / 100) * sueldo;
                   decimal fondoP = Convert.ToDecimal(datos[año].C_FondoPens / 100) * sueldo;
                   decimal CP = Convert.ToDecimal(datos[año].C_CortoPlazo / 100) * sueldo;
                   decimal prendario = Convert.ToDecimal(datos[año].C_Prendario / 100) * sueldo;

                    if (_Tipo == 1)
                    {
                        segurovida = Convert.ToDecimal(datos[año].C_SeguroVida)/2;
                        seguroretiro = Convert.ToDecimal(datos[año].C_SeguroRetiro)/2;

                        a_segurovida = Convert.ToDecimal(datos[año].A_SeguroVida)/2;
                        a_seguroretiro = Convert.ToDecimal(datos[año].A_SeguroRetiro)/2;

                    }
                    else
                    {
                        seguroretiro = Convert.ToDecimal(datos[año].C_SeguroRetiro);
                        segurovida = Convert.ToDecimal(datos[año].C_SeguroVida);

                        a_seguroretiro = Convert.ToDecimal(datos[año].A_SeguroRetiro);
                        a_segurovida = Convert.ToDecimal(datos[año].A_SeguroVida);

                    }
                    decimal totalCuotas = servMed + gInfHosp + fondoP + CP + prendario + segurovida + seguroretiro;
                   decimal importe = totalCuotas * (Convert.ToDecimal(tasa) / 100);
                   decimal a_servMed = Convert.ToDecimal(datos[año].A_ServMedico / 100) * sueldo;
                   decimal a_gInfHosp = Convert.ToDecimal(datos[año].A_GastosInfra / 100) * sueldo;
                   decimal a_fondoP = Convert.ToDecimal(datos[año].A_FondoPens / 100) * sueldo;
                   decimal a_CP = Convert.ToDecimal(datos[año].A_CortoPlazo / 100) * sueldo;
                   decimal a_prendario = Convert.ToDecimal(datos[año].A_Prendario / 100) * sueldo;
                   decimal a_indGlobal = Convert.ToDecimal(datos[año].A_Indemniza / 100) * sueldo;
                   decimal a_ayudaFune = Convert.ToDecimal(datos[año].A_AyudaFune / 100) * sueldo;
                   decimal a_GastosAdmin = Convert.ToDecimal(datos[año].A_GastosAdmin / 100) * sueldo;
                   decimal a_pensionMin = Convert.ToDecimal(datos[año].A_PensionMin / 100) * sueldo;
                   decimal a_Fovi = Convert.ToDecimal(datos[año].A_Fovisssteson / 100) * sueldo;
                     decimal a_TotalAportaciones = a_servMed + a_gInfHosp + a_fondoP + a_CP + a_prendario + a_indGlobal + a_ayudaFune + a_GastosAdmin + a_pensionMin + a_Fovi + a_segurovida + a_seguroretiro;
                   decimal a_importe = (Convert.ToDecimal(tasa) / 100) * a_TotalAportaciones;
                   decimal totalCuoApo = a_TotalAportaciones + totalCuotas;
                   decimal totalMor = importe + a_importe;
                   decimal totalGen = totalMor + totalCuoApo;

                    string[] row = new string[] { sueldo + "",
                    mes, "1",
                    sueldo.ToString(),
                    servMed.ToString(),
                    gInfHosp.ToString(),
                    fondoP.ToString(),
                    CP.ToString(),
                    prendario.ToString(),
                    segurovida.ToString(),
                    seguroretiro.ToString(),
                    totalCuotas.ToString(),
                    tasa.ToString()+"%",
                    importe.ToString(),
                    a_servMed.ToString(),
                    a_gInfHosp.ToString(),
                    a_fondoP.ToString(),
                    a_CP.ToString(),
                    a_prendario.ToString(),
                    a_indGlobal.ToString(),
                    a_ayudaFune.ToString(),
                    a_GastosAdmin.ToString(),
                    a_pensionMin.ToString(),
                    a_Fovi.ToString(),
                    a_segurovida.ToString(),
                    a_seguroretiro.ToString(),
                    a_TotalAportaciones.ToString(),
                    tasa.ToString()+"%",
                    a_importe.ToString(),
                    totalCuoApo.ToString(),
                    totalMor.ToString(),
                    totalGen.ToString(),
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
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
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
        public void llenarGrid(Dictionary<DateTime, double> lstTasa, decimal sueldo, Dictionary<int, Modelo.cat_organismos2> datos, DataGridView Grid, bool _Interinato, DateTime _UltimaTasa, int _Tipo)
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
                    decimal segurovida = 0, seguroretiro = 0, a_segurovida = 0, a_seguroretiro = 0;

                    if (_Tipo == 1)
                    {
                        segurovida = Convert.ToDecimal(datos[año].C_SeguroVida) / 2;
                        seguroretiro = Convert.ToDecimal(datos[año].C_SeguroRetiro) / 2;

                        a_segurovida = Convert.ToDecimal(datos[año].A_SeguroVida) / 2;
                        a_seguroretiro = Convert.ToDecimal(datos[año].A_SeguroRetiro) / 2;

                    }
                    else
                    {
                        seguroretiro = Convert.ToDecimal(datos[año].C_SeguroRetiro);
                        segurovida = Convert.ToDecimal(datos[año].C_SeguroVida);

                        a_seguroretiro = Convert.ToDecimal(datos[año].A_SeguroRetiro);
                        a_segurovida = Convert.ToDecimal(datos[año].A_SeguroVida);

                    }


                    decimal servMed = Convert.ToDecimal(datos[año].C_ServMedico / 100) * sueldo;
                    decimal gInfHosp = Convert.ToDecimal(datos[año].C_GastosInfra / 100) * sueldo;
                    decimal fondoP = Convert.ToDecimal(datos[año].C_FondoPens / 100) * sueldo;
                    decimal CP = Convert.ToDecimal(datos[año].C_CortoPlazo / 100) * sueldo;
                    decimal prendario = Convert.ToDecimal(datos[año].C_Prendario / 100) * sueldo;
                   
                    decimal totalCuotas = servMed + gInfHosp + fondoP + CP + prendario + segurovida + seguroretiro;
                    decimal importe = totalCuotas * (Convert.ToDecimal(tasa) / 100);
                    decimal a_servMed = Convert.ToDecimal(datos[año].A_ServMedico / 100) * sueldo;
                    decimal a_gInfHosp = Convert.ToDecimal(datos[año].A_GastosInfra / 100) * sueldo;
                    decimal a_fondoP = Convert.ToDecimal(datos[año].A_FondoPens / 100) * sueldo;
                    decimal a_CP = Convert.ToDecimal(datos[año].A_CortoPlazo / 100) * sueldo;
                    decimal a_prendario = Convert.ToDecimal(datos[año].A_Prendario / 100) * sueldo;
                    decimal a_indGlobal = Convert.ToDecimal(datos[año].A_Indemniza / 100) * sueldo;
                    decimal a_ayudaFune = Convert.ToDecimal(datos[año].A_AyudaFune / 100) * sueldo;
                    decimal a_GastosAdmin = Convert.ToDecimal(datos[año].A_GastosAdmin / 100) * sueldo;
                    decimal a_pensionMin = Convert.ToDecimal(datos[año].A_PensionMin / 100) * sueldo;
                    decimal a_Fovi = Convert.ToDecimal(datos[año].A_Fovisssteson / 100) * sueldo;
                   
                    decimal a_TotalAportaciones = a_servMed + a_gInfHosp + a_fondoP + a_CP + a_prendario + a_indGlobal + a_ayudaFune + a_GastosAdmin + a_pensionMin + a_Fovi + a_segurovida + a_seguroretiro;
                    decimal a_importe = (Convert.ToDecimal(tasa) / 100) * a_TotalAportaciones;
                    decimal totalCuoApo = a_TotalAportaciones + totalCuotas;
                    decimal totalMor = importe + a_importe;
                    decimal totalGen = totalMor + totalCuoApo;



                    string[] row = new string[] { sueldo + "",
                    mes, "1",
                    sueldo.ToString(),
                    servMed.ToString(),
                    gInfHosp.ToString(),
                    fondoP.ToString(),
                    CP.ToString(),
                    prendario.ToString(),
                    segurovida.ToString(),
                    seguroretiro.ToString(),
                    totalCuotas.ToString(),
                    tasa.ToString()+"%",
                    importe.ToString(),
                    a_servMed.ToString(),
                    a_gInfHosp.ToString(),
                    a_fondoP.ToString(),
                    a_CP.ToString(),
                    a_prendario.ToString(),
                    a_indGlobal.ToString(),
                    a_ayudaFune.ToString(),
                    a_GastosAdmin.ToString(),
                    a_pensionMin.ToString(),
                    a_Fovi.ToString(),
                    a_segurovida.ToString(),
                    a_seguroretiro.ToString(),
                    a_TotalAportaciones.ToString(),
                    tasa.ToString()+"%",
                    a_importe.ToString(),
                    totalCuoApo.ToString(),
                    totalMor.ToString(),
                    totalGen.ToString(),
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
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    ultimaTasa.ToShortDateString(),
                    item.Key.ToShortDateString()

                    };
                    Grid.Rows.Add(row);
                    MessageBox.Show("No se encontraron datos del organismo para el año "+año+"");
                }
            }
        }
        //Recalcular
        public void llenarGrid(Dictionary<DateTime, double> lstTasa, List<decimal> _sueldo, Dictionary<int, Modelo.cat_organismos2> datos, DataGridView Grid, bool _Interinato, int _Tipo)
        {
            
            Modelo.tasasOmisiones tasas = new Modelo.tasasOmisiones();
            DateTime ultimaTasa = tasas.getUltimaTasa().fecha;

            Modelo.tasasOmisionesInterinato tasasInter = new tasasOmisionesInterinato();
            var y = 0.0;
            int i = 0;
         


            foreach (var item in lstTasa)
            {
                decimal sueldo = _sueldo[i];
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
                    decimal segurovida = 0, seguroretiro = 0, a_segurovida = 0, a_seguroretiro = 0;


                    if (_Tipo == 1)
                    {
                        segurovida = Convert.ToDecimal(datos[año].C_SeguroVida) / 2;
                        seguroretiro = Convert.ToDecimal(datos[año].C_SeguroRetiro) / 2;

                        a_segurovida = Convert.ToDecimal(datos[año].A_SeguroVida) / 2;
                        a_seguroretiro = Convert.ToDecimal(datos[año].A_SeguroRetiro) / 2;

                    }
                    else
                    {
                        seguroretiro = Convert.ToDecimal(datos[año].C_SeguroRetiro);
                        segurovida = Convert.ToDecimal(datos[año].C_SeguroVida);

                        a_seguroretiro = Convert.ToDecimal(datos[año].A_SeguroRetiro);
                        a_segurovida = Convert.ToDecimal(datos[año].A_SeguroVida);

                    }
                    decimal servMed = Convert.ToDecimal(datos[año].C_ServMedico / 100) * sueldo;
                    decimal gInfHosp = Convert.ToDecimal(datos[año].C_GastosInfra / 100) * sueldo;
                    decimal fondoP = Convert.ToDecimal(datos[año].C_FondoPens / 100) * sueldo;
                    decimal CP = Convert.ToDecimal(datos[año].C_CortoPlazo / 100) * sueldo;
                    decimal prendario = Convert.ToDecimal(datos[año].C_Prendario / 100) * sueldo;
             
              
                    decimal totalCuotas = servMed + gInfHosp + fondoP + CP + prendario + segurovida + seguroretiro;
                    decimal importe = totalCuotas * (Convert.ToDecimal(tasa) / 100);
                    decimal a_servMed = Convert.ToDecimal(datos[año].A_ServMedico / 100) * sueldo;
                    decimal a_gInfHosp = Convert.ToDecimal(datos[año].A_GastosInfra / 100) * sueldo;
                    decimal a_fondoP = Convert.ToDecimal(datos[año].A_FondoPens / 100) * sueldo;
                    decimal a_CP = Convert.ToDecimal(datos[año].A_CortoPlazo / 100) * sueldo;
                    decimal a_prendario = Convert.ToDecimal(datos[año].A_Prendario / 100) * sueldo;
                    decimal a_indGlobal = Convert.ToDecimal(datos[año].A_Indemniza / 100) * sueldo;
                    decimal a_ayudaFune = Convert.ToDecimal(datos[año].A_AyudaFune / 100) * sueldo;
                    decimal a_GastosAdmin = Convert.ToDecimal(datos[año].A_GastosAdmin / 100) * sueldo;
                    decimal a_pensionMin = Convert.ToDecimal(datos[año].A_PensionMin / 100) * sueldo;
                    decimal a_Fovi = Convert.ToDecimal(datos[año].A_Fovisssteson / 100) * sueldo;
              
              
                    decimal a_TotalAportaciones = a_servMed + a_gInfHosp + a_fondoP + a_CP + a_prendario + a_indGlobal + a_ayudaFune + a_GastosAdmin + a_pensionMin + a_Fovi + a_segurovida + a_seguroretiro;
                    decimal a_importe = (Convert.ToDecimal(tasa) / 100) * a_TotalAportaciones;
                    decimal totalCuoApo = a_TotalAportaciones + totalCuotas;
                    decimal totalMor = importe + a_importe;
                    decimal totalGen = totalMor + totalCuoApo;

                    string[] row = new string[] { sueldo + "",
                    mes, "1",
                    sueldo.ToString(),
                    servMed.ToString(),
                    gInfHosp.ToString(),
                    fondoP.ToString(),
                    CP.ToString(),
                    prendario.ToString(),
                    segurovida.ToString(),
                    seguroretiro.ToString(),
                    totalCuotas.ToString(),
                    tasa.ToString()+"%",
                    importe.ToString(),
                    a_servMed.ToString(),
                    a_gInfHosp.ToString(),
                    a_fondoP.ToString(),
                    a_CP.ToString(),
                    a_prendario.ToString(),
                    a_indGlobal.ToString(),
                    a_ayudaFune.ToString(),
                    a_GastosAdmin.ToString(),
                    a_pensionMin.ToString(),
                    a_Fovi.ToString(),
                    a_segurovida.ToString(),
                    a_seguroretiro.ToString(),
                    a_TotalAportaciones.ToString(),
                    tasa.ToString()+"%",
                    a_importe.ToString(),
                    totalCuoApo.ToString(),
                    totalMor.ToString(),
                    totalGen.ToString(),
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
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
                    "0.00",
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