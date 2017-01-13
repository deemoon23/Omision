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

        public double sueldo { get; set; }

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

        public double csm { get; set; }

        public double cfp { get; set; }

        public double ccp { get; set; }

        public double cpren { get; set; }

        public double  csv { get; set; }
               
        public double  csr { get; set; }
               
        public double  cgi { get; set; }
               
        public double  tcuotas { get; set; }
               
        public double  importeC { get; set; }
               
        public double  asm { get; set; }
               
        public double  afp { get; set; }
               
        public double  acp { get; set; }
               
        public double  apren { get; set; }
               
        public double  asv { get; set; }
               
        public double  asr { get; set; }
               
        public double  agi { get; set; }
                
        public double  afovi { get; set; }
               
        public double  apm { get; set; }
               
        public double  aaf { get; set; }
               
        public double  aig { get; set; }
               
        public double  aga { get; set; }
              
        public double  taporta { get; set; }
              
        public double  importeA { get; set; }
        public double  tasa { get; set; }
                
        public double  tmoratorio { get; set; }
                
        public double  tmes { get; set; }

        public DateTime? TasaCalculada { get; set; }

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
    }
}
