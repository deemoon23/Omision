namespace CR.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class trabajadores
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal tafiliacion { get; set; }

        [Column(TypeName = "numeric")]
        public decimal tpension { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal tconsecutivo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal tpensionado { get; set; }

        [StringLength(25)]
        public string tpaterno { get; set; }

        [StringLength(25)]
        public string tmaterno { get; set; }

        [StringLength(25)]
        public string tnombre { get; set; }

        [StringLength(1)]
        public string tsexo { get; set; }

        public DateTime? tfechanacto { get; set; }

        public short? testadocivil { get; set; }

        public short? ttiposangre { get; set; }

        [StringLength(30)]
        public string talergia { get; set; }

        [StringLength(30)]
        public string tenfercronica { get; set; }

        public short? tultimalocalidad { get; set; }

        public short? tultimoorganismo { get; set; }

        public short? tdependencia { get; set; }

        public short? tunidad { get; set; }

        public short? tplaza { get; set; }

        public short? tpuesto { get; set; }

        public short? tcolonia { get; set; }

        [StringLength(50)]
        public string tdomicilio { get; set; }

        [StringLength(10)]
        public string ttelefonop { get; set; }

        [StringLength(10)]
        public string ttelefonoo { get; set; }

        public short? tstatus { get; set; }

        public DateTime? tfechaingreso { get; set; }

        public DateTime? tfechaultcred { get; set; }

        public DateTime? tfechavencred { get; set; }

        [StringLength(50)]
        public string tobservaciones { get; set; }

        [StringLength(10)]
        public string tfotografia { get; set; }

        public DateTime? tfechafoto { get; set; }

        public DateTime? tfechacaptura { get; set; }

        [StringLength(10)]
        public string tusuariored { get; set; }

        [StringLength(10)]
        public string tusuariosql { get; set; }

        public DateTime? tfecmat { get; set; }

        public short? tstmed { get; set; }

        [StringLength(40)]
        public string tmotmed { get; set; }

        [StringLength(40)]
        public string tmotmed1 { get; set; }

        public DateTime? tfecmed { get; set; }

        [StringLength(40)]
        public string tcoloniaalfa { get; set; }

        public DateTime? tfechaorganismo { get; set; }

        public DateTime? tactivacion { get; set; }

        public DateTime? tfechaisssteson { get; set; }

        [StringLength(10)]
        public string tusertoma { get; set; }

        [StringLength(10)]
        public string tuserexpide { get; set; }

        public DateTime? tcredimpresa { get; set; }

        [Column(TypeName = "image")]
        public byte[] timgfoto { get; set; }

        [Column(TypeName = "image")]
        public byte[] timgfirma { get; set; }

        public short? status_ingresos { get; set; }

        [Column(TypeName = "money")]
        public decimal? sueldo_ingresos { get; set; }

        public short? baja_ingresos { get; set; }

        public DateTime? tfechaempleo { get; set; }

        [StringLength(1)]
        public string generacion { get; set; }
        Modelo.organismos org = new Modelo.organismos();
        Modelo.localidades loc = new Modelo.localidades();

        /// <summary>
        /// Busca solo un trabajador por el nombre y apellidos.
        /// </summary>
        /// <param name="_apellidoP">Apellido Paterno del trabajador</param>
        /// <param name="_apellidoM">Apellido Materno del trabajador</param>
        /// <param name="_nombre">Nombre del trabajadr</param>
        /// <returns></returns>
        public trabajadores getTrabajador(string _apellidoP, string _apellidoM, string _nombre)
        {
            using (var ctx = new mSipesdb())
            {
                var query = ctx.trabajadores.Where(r => r.tnombre == _nombre && r.tpaterno == _apellidoP && r.tmaterno == _apellidoM).ToList();
                if (query.Count == 0)
                {
                    trabajadores tra = new trabajadores();
                    tra.tpension = 0000;
                    return tra;
                }
                else
                {
                    return query.First();

                 }
            }
               
        }

        /// <summary>
        /// Obtiene una lista con todos los trabajadores
        /// </summary>
        /// <returns></returns>
        public List<trabajadores> getTrabajador()
        {
            using (var ctx = new mSipesdb())
            {
                var query = ctx.trabajadores.OrderBy(r => r.tpaterno).ToList(); ;             
               
                 
                return query;
            }

        }

        /// <summary>
        /// Obtiene una lista de trabajadores usando filtros, se pueden dejar vacíos los campos para no tomarlo en cuenta.
        /// </summary>
        /// <param name="_nombre">Nombre del trabajador</param>
        /// <param name="_apellidoP">Apellido Paterno del trabajador</param>
        /// <param name="_apellidoM">Apellido Materno del trabajador</param>
        /// <param name="_localidad">Nombre de la localidad</param>
        /// <param name="_organismo">Nombre del organismo</param>
        /// <returns></returns>
        public List<trabajadores> getTrabajadores(string _nombre, string _apellidoP, string _apellidoM, string _localidad, string _organismo)
        {
            using (var ctx = new mSipesdb())
            {
               int idLoc = loc.getByDescripcion(_localidad).codigo;
                int idOrg = org.getByDescripcion(_organismo).codigo;
                List<trabajadores> lst = new List<trabajadores>();
                
                   // lst = ctx.trabajadores.Where(r => r.tultimalocalidad == idLoc && r.tultimoorganismo == idOrg && r.tnombre.Contains(_nombre) && r.tmaterno.Contains(_apellidoM) && r.tpaterno.Contains(_apellidoP)).OrderBy(r => r.tpaterno).ToList();
                 var query = from p in ctx.trabajadores
                           where p.tultimalocalidad == idLoc &&
                           p.tultimoorganismo == idOrg &&
                           p.tpaterno.Contains(_apellidoP) &&
                           p.tmaterno.Contains(_apellidoM) &&
                           p.tnombre.Contains(_nombre)
                           select p;





                    return query.ToList();
            }

        }
    }
}
