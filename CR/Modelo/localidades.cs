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
        
        public List<string> getAll()
        {
            try
            {
                using (var ctx = new _Modelo())
                {
                    return ctx.localidades.Select(r => r.descripcion).ToList();
                }
            }
            catch (Exception) { throw; }
        }

        public localidades getByDescripcion(string _descripcion)
        {
            try
            {
                using (var ctx = new _Modelo())
                {
                    return ctx.localidades.Where(r => r.descripcion== _descripcion).Single();
                }
            }
            catch (Exception) { throw; }
        }




    }
}
