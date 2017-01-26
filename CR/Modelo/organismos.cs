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

        /// <summary>
        /// Obtiene una lista con todos los organismos.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Obtiene un organismo buscado por la descripción el cual se indica en el parametro
        /// </summary>
        /// <param name="_descripcion">Descripción del organismo que se desea buscar</param>
        /// <returns></returns>
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
