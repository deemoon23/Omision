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

        public virtual localidades localidades { get; set; }


        public Dictionary<int, cat_organismos2> getData(localidades _localidad, organismos _organismo, string _tipoGenera, DateTime _inicio, DateTime _final)
        {
            Dictionary<int, cat_organismos2> data = new Dictionary<int, cat_organismos2>();
            int inicio = _inicio.Year;
            int final = _final.Year;
            Dictionary<int, cat_organismos2> empty = null;
                try
            {
                using (var ctx = new _Modelo())
                {
                var query=ctx.cat_organismos2.Where(r => r.idLocalidad == _localidad.codigo && r.idOrganismo == _organismo.codigo && r.idTipoGenera == _tipoGenera && r.vigencia >= inicio && r.vigencia <= final).ToList();
                    foreach (var item in query)
                    {
                                        
                        data.Add(item.vigencia.Value,item);
                    }

                    return data;

                }
            }
            catch (InvalidOperationException) {
                MessageBox.Show("No hay datos");
                return empty;
            }


        }
    }
}
