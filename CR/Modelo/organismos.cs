namespace CR.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class organismos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short codigo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(110)]
        public string descripcion { get; set; }

        public List<organismos> getAll()
        {
            try
            {
                using (var ctx = new _Modelo())
                {
                    return ctx.organismos.OrderBy(r=>r.descripcion).ToList();
                }
            }
            catch (Exception) { throw; }
        }
        public organismos getByDescripcion(string _descripcion)
        {
            try
            {
                using (var ctx = new _Modelo())
                {
                    return ctx.organismos.Where(r => r.descripcion == _descripcion).Single();
                }
            }
            catch (Exception) { throw; }
        }



    }
}
