namespace CR.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Windows.Forms;

    public partial class cat_organismos2
    {
        #region atributos
        public int id { get; set; }

        public int idLocalidad { get; set; }

        public int idOrganismo { get; set; }

        public int? idIsssteson { get; set; }

        [StringLength(1)]
        public string idTipoGenera { get; set; }

        public int? nomina { get; set; }

        public decimal? C_ServMedico { get; set; }

        public decimal? C_FondoPens { get; set; }

        public decimal? C_GastosInfra { get; set; }

        public decimal? C_SeguroVida { get; set; }

        public decimal? C_SeguroRetiro { get; set; }

        public decimal? C_CortoPlazo { get; set; }

        public decimal? C_Prendario { get; set; }

        public decimal? A_ServMedico { get; set; }

        public decimal? A_FondoPens { get; set; }

        public decimal? A_CortoPlazo { get; set; }

        public decimal? A_Prendario { get; set; }

        public decimal? A_Indemniza { get; set; }

        public decimal? A_AyudaFune { get; set; }

        public decimal? A_GastosAdmin { get; set; }

        public decimal? A_GastosInfra { get; set; }

        public decimal? A_PensionMin { get; set; }

        public decimal? A_Fovisssteson { get; set; }

        public decimal? A_SeguroVida { get; set; }

        public decimal? A_SeguroRetiro { get; set; }

        public decimal? S_minimo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? F_IN { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? F_OUT { get; set; }

        public int? status { get; set; }

        public int? vigencia { get; set; }

        public int? modif { get; set; }

        public DateTime? FinModif { get; set; }

        [Column(TypeName = "image")]
        public byte[] logo { get; set; }
        #endregion

        public virtual localidades localidades { get; set; }

        /// <summary>
        /// Obtiene un Dictionary con los datos del organismo seleccionado.
        /// </summary>
        /// <param name="_localidad">Localidad del organismo</param>
        /// <param name="_organismo">Organismo</param>
        /// <param name="_tipoGenera">Tipo de generación</param>
        /// <param name="_inicio">Vigencia inicial</param>
        /// <param name="_final">Vigencia final</param>
        /// <returns></returns>
        public Dictionary<int, cat_organismos2> getData(localidades _localidad, organismos _organismo, string _tipoGenera, DateTime _inicio, DateTime _final)
        {
            Dictionary<int, cat_organismos2> data = new Dictionary<int, cat_organismos2>();
            int inicio = _inicio.Year;
            int final = _final.Year;
            Dictionary<int, cat_organismos2> empty = null;
            try
            {
                using (var ctx = new mIngresos())
                {
                    int vigencia = 0;
                    var query = ctx.cat_organismos2.OrderBy(r => r.vigencia).Where(r => r.idLocalidad == _localidad.codigo && r.idOrganismo == _organismo.codigo && r.idTipoGenera == _tipoGenera && r.vigencia >= inicio && r.vigencia <= final).ToList();
                    List<cat_organismos2> lista = new List<cat_organismos2>();
                    foreach (var item in query)
                    {
                        if (vigencia != item.vigencia)
                        {
                            lista.Add(item);
                        }
                        vigencia = Convert.ToInt32(item.vigencia);
                    }
                    foreach (var item in lista)
                    {

                        data.Add(item.vigencia.Value, item);
                    }

                    return data;

                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No hay datos");
                return empty;
            }


        }

        /// <summary>
        /// Obtiene solo un registro de la tabla cat_organismos2
        /// </summary>
        /// <param name="_idLoc">id de la localidad</param>
        /// <param name="_idOrg">id del organismo</param>
        /// <param name="_año">Año de vigencia</param>
        /// <param name="_generacion">Tipo de generación</param>
        /// <returns></returns>
        public cat_organismos2 getOrganismo(int _idLoc, int _idOrg, int _año, string _generacion)
        {
            try
            {
                using (var ctx = new mIngresos())
                {
                    return ctx.cat_organismos2.Where(r => r.idLocalidad == _idLoc && r.idOrganismo == _idOrg && r.vigencia == _año && r.idTipoGenera == _generacion).FirstOrDefault();
                    
                }
            }
            catch (Exception) { throw; }

        }

    }
}
