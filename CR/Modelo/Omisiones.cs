namespace CR.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows.Forms;
    using System.Web.UI.WebControls;

    public partial class Omisiones
    {
        public long id { get; set; }

        public string empleado { get; set; }

        public decimal? sueldo { get; set; }

        public DateTime? mesOmitido { get; set; }

        public DateTime? mesCalculo { get; set; }

        [StringLength(50)]
        public string folio { get; set; }

        [StringLength(2)]
        public string tipoCobro { get; set; }

        public int? idLoc { get; set; }

        [StringLength(50)]
        public string Localidad { get; set; }

        public int? idOrg { get; set; }

        public string Organismo { get; set; }

        public decimal? csm { get; set; }

        public decimal? cfp { get; set; }

        public decimal? ccp { get; set; }

        public decimal? cpren { get; set; }

        public decimal? csv { get; set; }

        public decimal? csr { get; set; }

        public decimal? cgi { get; set; }

        public decimal? tcuotas { get; set; }

        public decimal? importeC { get; set; }

        public decimal? asm { get; set; }

        public decimal? afp { get; set; }

        public decimal? acp { get; set; }

        public decimal? apren { get; set; }

        public decimal? asv { get; set; }

        public decimal? asr { get; set; }

        public decimal? agi { get; set; }

        public decimal? afovi { get; set; }

        public decimal? apm { get; set; }

        public decimal? aaf { get; set; }

        public decimal? aig { get; set; }

        public decimal? aga { get; set; }

        public decimal? taporta { get; set; }

        public decimal? importeA { get; set; }

        public decimal? tasa { get; set; }

        public decimal? tmoratorio { get; set; }

        public decimal? tmes { get; set; }

        public DateTime? TasaCalculada { get; set; }

        [StringLength(30)]
        public string nombre { get; set; }

        [StringLength(30)]
        public string apellidoP { get; set; }

        [StringLength(30)]
        public string apellidoM { get; set; }

        [StringLength(1)]
        public string generacion { get; set; }

        public bool? interinato { get; set; }

        public bool? activo { get; set; }

        // Guarda una omisión.
        /// <summary>
        /// <param name="_omision">Objeto con la informacíon que se guardará</param>
        /// </summary>
        public void nuevaOmision(Omisiones _omision)
        {
            try
            {
                using (var ctx = new mIngresos())
                {
                    ctx.Omisiones.Add(_omision);

                    ctx.SaveChanges();
                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Regresa una Lista con una tupla con los datos de las omisiones guardadas.
        /// </summary>
        /// <returns></returns>
        public List<Tuple<string, string, string, string, string, string>> getOmisiones()
        {
            try
            {
                using (var ctx = new mIngresos())
                {
                    List<Tuple<string, string, string, string, string, string>> lst = new List<Tuple<string, string, string, string, string, string>>();
                    var x = (ctx.Omisiones.Where(r=>r.activo==true).Select(r => new { r.apellidoP, r.apellidoM, r.nombre, r.mesCalculo, r.Localidad, r.Organismo }).OrderByDescending(r => r.mesCalculo).GroupBy(r => new { r.apellidoP, r.apellidoM, r.nombre, r.Localidad, r.Organismo, r.mesCalculo })).ToList();
                    var xx = x.OrderByDescending(r => r.Key.mesCalculo);
                    foreach (var item in xx)
                    {
                        lst.Add(new Tuple<string, string, string, string, string, string>(item.Key.nombre, item.Key.apellidoP, item.Key.apellidoM, item.Key.mesCalculo.ToString(), item.Key.Localidad, item.Key.Organismo));
                    }
                    return lst;
                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Regresa una lista con una tupla con los datos de las omisiones según el texto mandado por la variable
        /// </summary>
        /// <param name="_nombre">Busca las omisiones que contengan el texto de la variable.</param>
        /// <returns></returns>
        public List<Tuple<string, string, string, string, string, string>> getOmisiones(string _nombre, string _apellidoP, string _apellidoM, string _localidad, string _organismo)
        {
            // TODO BUSCAR POR TODO
            try
            {
                using (var ctx = new mIngresos())
                {
                    List<Tuple<string, string, string, string, string, string>> lst = new List<Tuple<string, string, string, string, string, string>>();

                    var x = ctx.Omisiones.OrderBy(r => apellidoP).Select(r => new { r.apellidoP, r.apellidoM, r.nombre, r.mesCalculo, r.Localidad, r.Organismo, r.activo }).Where(r => r.nombre.Contains(_nombre) && r.apellidoM.Contains(_apellidoM) && r.apellidoP.Contains(_apellidoP) && r.activo == true).GroupBy(r => new { r.apellidoP, r.apellidoM, r.nombre, r.Localidad, r.Organismo, r.mesCalculo }).ToList();
                        if (_localidad != "---TODOS---")
                        {
                            x = x.Where(r => r.Key.Localidad == _localidad).ToList();

                        }
                        if (_organismo != "---TODOS---")
                        {
                            x = x.Where(r => r.Key.Organismo == _organismo).ToList();

                        }

                        foreach (var item in x)
                        {
                            lst.Add(new Tuple<string, string, string, string, string, string>(item.Key.nombre, item.Key.apellidoP, item.Key.apellidoM, item.Key.mesCalculo.ToString(), item.Key.Localidad, item.Key.Organismo));
                        }
                 
                    return lst;
                }
            }
            catch (Exception) { throw; }
        }
        

        /// <summary>
        /// Obtiene una lista con todas las omisiones de un empleado en específico.
        /// </summary>
        /// <param name="_nombre">Nombre(s) del empleado</param>
        /// <param name="_apellidoP">Apellido paterno del empleado</param>
        /// <param name="_apellidoM">Apellido materno del emleado </param>
        /// <returns></returns>
        public List<Omisiones> getOmision(string _nombre, string _apellidoP, string _apellidoM)
        {
            try
            {
                using (var ctx = new mIngresos())
                {
                    return ctx.Omisiones.OrderBy(r => r.mesOmitido).Where(r => r.nombre == _nombre && r.apellidoP == _apellidoP && r.apellidoM == _apellidoM &&r.activo==true).ToList();
                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Obtiene una con todos los empleados.
        /// </summary>
        /// <returns></returns>
        public List<string> getEmpleados()
        {
            try
            {
                using (var ctx = new mIngresos())
                {
                    return ctx.Omisiones.Where(r=>r.activo==true).Select(r => r.empleado).ToList();
                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Borrado lógico de un solo registro, pone en 0 el status de activo.
        /// </summary>
        /// <param name="_id">id del registro</param>
        public void borrarRegistro(int _id)
        {
            try
            {
                using (var ctx = new mIngresos())
                {
                    Omisiones omi = ctx.Omisiones.Where(r => r.id == _id).SingleOrDefault();
                    omi.activo = false;
                    ctx.SaveChanges();
                }
            }
            catch (Exception) { throw; }
            
        }

        /// <summary>
        /// Obtiene un registro de la tabla omisiones.
        /// </summary>
        /// <param name="_id">id de la omisión</param>
        /// <returns></returns>
        public Omisiones getOmision(int _id)
        {
            try
            {
                using (var ctx = new mIngresos())
                {
                    return ctx.Omisiones.Where(r => r.id == _id).SingleOrDefault();
                }
            }
            catch (Exception) { throw; }
        }







    }

}