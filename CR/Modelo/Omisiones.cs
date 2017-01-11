namespace CR.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
    }
}
