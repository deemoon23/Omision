namespace CR.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("tasasOmisionesInterinato")]
    public partial class tasasOmisionesInterinato
    {
        public long id { get; set; }

        public DateTime? fecha { get; set; }

        public decimal? tasa { get; set; }
        /// <summary>
        /// Calcula la tasa desde la fecha indicada como parametro hasta la ultima registrada en la base de datos.
        /// </summary>
        /// <param name="_inicio">Fecha desde la que se desea calcular la tasa.</param>
        /// <returns></returns>
        public double getTasa(DateTime _inicio)
        {
            DateTime inicio = new DateTime(_inicio.Year, _inicio.Month, 1);

            try
            {
                using (var ctx = new _Modelo())
                {

                    return Convert.ToDouble(ctx.tasasOmisionesInterinato.Where(r => r.fecha >= _inicio).Select(r => r.tasa).Sum()) * 100 * .8;

                }
            }
            catch (Exception) { throw; }
        }
        
        /// <summary>
        /// Calcula la tasa entre las fechas indicadas como parametros.
        /// </summary>
        /// <param name="_inicio">Fecha desde la que se desea calcular la tasa</param>
        /// <param name="_final">Ultima fecha que se desea para calcular la tasa</param>
        /// <returns></returns>
        public double getTasa(DateTime _inicio, DateTime _final)
        {
            DateTime inicio = new DateTime(_inicio.Year, _inicio.Month, 1);
            DateTime final = new DateTime(_final.Year, _final.Month, 1);
            try
            {
                using (var ctx = new _Modelo())
                {

                    return Convert.ToDouble(ctx.tasasOmisionesInterinato.Where(r => r.fecha >= _inicio && r.fecha <= final).Select(r => r.tasa).Sum()) * 100 * .8;

                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Obtiene una lista de las Omisiones de Interinato con todos  sus datos.
        /// </summary>
        /// <returns></returns>
        public List<tasasOmisionesInterinato> getAll()
        {
           

            try
            {
                using (var ctx = new _Modelo())
                {
                    return ctx.tasasOmisionesInterinato.ToList();
                }
            }
            catch (Exception) { throw; }
        }
    }
}
