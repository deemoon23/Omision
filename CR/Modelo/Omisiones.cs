namespace CR.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Omisiones
    {
        public long id { get; set; }

        //    public string empleado { get; set; }

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

        [Column(TypeName = "char")]
        public string generacion { get; set; }

        public bool interinato { get; set; }


        // Guarda una omisión.
        /// <summary>
        /// <param name="_omision">Objeto con la informacíon que se guardará</param>
        /// </summary>
        public void nuevaOmision(Omisiones _omision)
        {
            try
            {
                using (var ctx = new _Modelo())
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
                using (var ctx = new _Modelo())
                {
                    List<Tuple<string, string, string,string, string, string>> lst = new List<Tuple<string, string, string,string, string, string>>();
                   
                    var x = ctx.Omisiones.OrderBy(r => apellidoP).Select(r => new { r.apellidoP, r.apellidoM, r.nombre, r.mesCalculo, r.Localidad, r.Organismo }).GroupBy(r => new { r.apellidoP, r.apellidoM, r.nombre, r.Localidad, r.Organismo, r.mesCalculo }).ToList();
                    foreach (var item in x)
                    {
                        lst.Add(new Tuple<string, string, string, string,string, string>(item.Key.nombre,item.Key.apellidoP, item.Key.apellidoM, item.Key.mesCalculo.ToString(),  item.Key.Localidad, item.Key.Organismo));
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
        public List<Tuple<string, string, string, string, string, string>> getOmisiones(string _nombre)
        {
            try
            {
                using (var ctx = new _Modelo())
                {
                    List<Tuple<string, string, string, string, string, string>> lst = new List<Tuple<string, string, string, string, string, string>>();
                    var x= ctx.Omisiones.OrderBy(r => apellidoP).Select(r => new { r.apellidoP, r.apellidoM, r.nombre, r.mesCalculo, r.Localidad, r.Organismo }).Where(r => r.nombre.Contains(_nombre) || r.apellidoM.Contains(_nombre) || r.apellidoP.Contains(_nombre)).GroupBy(r => new { r.apellidoP, r.apellidoM, r.nombre, r.Localidad, r.Organismo, r.mesCalculo }).ToList();
                    string[] nombre = _nombre.Split(null);
                    if (nombre.Count() == 1)
                    {
                        string array = nombre[0];
                         x = ctx.Omisiones.OrderBy(r => apellidoP).Select(r => new { r.apellidoP, r.apellidoM, r.nombre, r.mesCalculo, r.Localidad, r.Organismo }).Where(r => r.nombre.Contains(array) || r.apellidoM.Contains(array) || r.apellidoP.Contains(array)).GroupBy(r => new { r.apellidoP, r.apellidoM, r.nombre, r.Localidad, r.Organismo, r.mesCalculo }).ToList();
                    }
                    if (nombre.Count() == 2)
                    {
                        string array = nombre[0];
                        string array2 = nombre[1];
                         x = ctx.Omisiones.OrderBy(r => apellidoP).Select(r => new { r.apellidoP, r.apellidoM, r.nombre, r.mesCalculo, r.Localidad, r.Organismo }).Where(r => r.nombre.Contains(array) || r.apellidoM.Contains(array) || r.apellidoP.Contains(array) || r.nombre.Contains(array2) || r.apellidoM.Contains(array2) || r.apellidoP.Contains(array2)).GroupBy(r => new { r.apellidoP, r.apellidoM, r.nombre, r.Localidad, r.Organismo, r.mesCalculo }).ToList();
                    }

                    if (nombre.Count() == 3)
                    {
                        string array = nombre[0];
                        string array2 = nombre[1];
                        string array3 = nombre[2];

                        x = ctx.Omisiones.OrderBy(r => apellidoP).Select(r => new { r.apellidoP, r.apellidoM, r.nombre, r.mesCalculo, r.Localidad, r.Organismo }).Where(r => r.nombre.Contains(array3) && r.apellidoM.Contains(array2) && r.apellidoP.Contains(array) ).GroupBy(r => new { r.apellidoP, r.apellidoM, r.nombre, r.Localidad, r.Organismo, r.mesCalculo }).ToList();
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
                using (var ctx = new _Modelo())
                {
                    return ctx.Omisiones.Where(r => r.nombre == _nombre && r.apellidoP == _apellidoP && r.apellidoM == _apellidoM).ToList();
                }
            }
            catch (Exception) { throw; }
        }
    }
   
}