namespace CR.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class localidades
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public localidades()
        {
            cat_organismos2 = new HashSet<cat_organismos2>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string descripcion { get; set; }

        [StringLength(1)]
        public string zona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cat_organismos2> cat_organismos2 { get; set; }
        /// <summary>
        /// Obtiene una lista con todas las localidades.
        /// </summary>
        /// <returns></returns>
        public List<localidades> getAll()
        {
            try
            {
                using (var ctx = new mIngresos())
                {
                  
                    localidades tod = new localidades();
                    tod.codigo = 0;
                    tod.descripcion = "---TODOS---";
                    List<localidades> loc = new List<localidades>();
                    loc.Add(tod);
                    loc.AddRange(ctx.localidades.OrderBy(r => r.descripcion).ToList());
                    return loc;
                }



            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Obtiene una localidad buscada por la descripción la cual se indica en el parametro
        /// </summary>
        /// <param name="_descripcion">Descripción de la localidad que se desea buscar</param>
        /// <returns></returns>
        public localidades getByDescripcion(string _descripcion)
        {
            try
            {
                using (var ctx = new mIngresos())
                {
                    return ctx.localidades.Where(r => r.descripcion == _descripcion).Single();
                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Obtiene una localidad buscada por el id
        /// </summary>
        /// <param name="_id">id de la localidad</param>
        /// <returns></returns>
        public localidades getById(int _id)
        {
            try
            {
                using (var ctx = new mIngresos())
                {
                    return ctx.localidades.Where(r => r.codigo == _id).Single();
                }
            }
            catch (Exception) { throw; }
        }



    }
}

