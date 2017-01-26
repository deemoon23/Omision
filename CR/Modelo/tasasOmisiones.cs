namespace CR.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Globalization;
    using System.Linq;

    public partial class tasasOmisiones
    {
        public long id { get; set; }

        public DateTime fecha { get; set; }

        public decimal tasa { get; set; }


        /// <summary>
        /// Obtiene una lista con toda la información de las tasas.
        /// </summary>
        /// <returns></returns>
        public List<tasasOmisiones> getAll()
        {


            try
            {
                using (var ctx = new _Modelo())
                {
                    return ctx.tasasOmisiones.ToList();
                }
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Calcula la tasa desde la fecha indicada como parametro hastala última encontrada en la base de datos.
        /// </summary>
        /// <param name="_inicio">Fecha desde la que se deasea calcular la tasa.</param>
        /// <returns></returns>
        public double getTasa(DateTime _inicio)
         {
            DateTime inicio = new DateTime();
            if (_inicio.Month == 12)
            {
                int año = _inicio.Year+1;

                 inicio = new DateTime(año, 1, 1,0,0,0);
            }
            else
            {
                inicio = new DateTime(_inicio.Year, _inicio.Month + 1, 1,0,0,0);
            }
            

            try
            {
                using (var ctx = new _Modelo())
                {
                    var y = ctx.tasasOmisiones.Where(r => r.fecha >= inicio).ToList();
                    if (y.Count == 0)
                    {
                        Modelo.tasasOmisiones tasas = new tasasOmisiones();
                        double ultimaTasa = Convert.ToDouble(tasas.getUltimaTasa().tasa);
                        return ultimaTasa * 100 * .8;
                    }               
                    else{
                        return Convert.ToDouble(ctx.tasasOmisiones.Where(r => r.fecha >= inicio).Select(r => r.tasa).Sum()) * 100 * .8;
                    }
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
            DateTime inicio = new DateTime();
            DateTime final = new DateTime();
            if (_inicio.Month == 12)
            {
                int año = _inicio.Year + 1;

                inicio = new DateTime(año, 1, 1,0,0,0);
            }
            else
            {
                inicio = new DateTime(_inicio.Year, _inicio.Month + 1, 1,0,0,0);
            }
         
                final = new DateTime(_final.Year, _final.Month, DateTime.DaysInMonth(_final.Year,_final.Month),23,59,59);
         

            try
            {
                using (var ctx = new _Modelo())
                {
                    var y = ctx.tasasOmisiones.Where(r => r.fecha >= inicio).ToList();
                    if (y.Count == 0)
                    {
                        Modelo.tasasOmisiones tasas = new tasasOmisiones();
                        double ultimaTasa = Convert.ToDouble(tasas.getUltimaTasa().tasa);
                        return ultimaTasa * 100 * .8;
                    }
                   
                    else
                    {
                        return Convert.ToDouble(ctx.tasasOmisiones.Where(r => r.fecha >= inicio && r.fecha <= final).Select(r => r.tasa).Sum()) * 100 * .8;
                    }
                }
            }
            catch (Exception) { throw; }
            
        }

        /// <summary>
        /// Obtiene Diccionario de la tasa junto con la fecha.
        /// </summary>
        /// <param name="_inicio">Fecha desde la que se desea buscar la tasa</param>
        /// <param name="_final">Ultima fecha que se desea para buscar la tasa</param>
        /// <returns></returns>
        public Dictionary<DateTime, double> getLstTasas(DateTime _inicio, DateTime _final)
        {
            int contador = 0;
            List<double> tasas = new List<double>();
            Dictionary<DateTime, double> data = new Dictionary<DateTime, double>();
            DateTime inicio = new DateTime(_inicio.Year, _inicio.Month, 1);
            DateTime final = new DateTime(_final.Year, _final.Month, DateTime.DaysInMonth(_final.Year, _final.Month));
            try
            {
                using (var ctx = new _Modelo())
                {
                    var meses = MonthsBetween(inicio, final);
                  //  var query = ctx.tasasOmisiones.Where(r => r.fecha >= inicio && r.fecha <= final).Select(r => new { r.tasa, r.fecha }).OrderBy(r => r.fecha).ToList();

                    var query = ctx.tasasOmisiones.OrderBy(r => r.fecha).Where(r => r.fecha >= inicio && r.fecha <= final).Select(r => r.tasa).ToList();
                     do
                    {
                        if (query.Count() != meses.Count())
                        {
                            query.Add(getUltimaTasa().tasa);
                        }
                        
                    }
                    while (query.Count != meses.Count());
                    foreach (var item in meses)
                    {
                        tasas.Add(Convert.ToDouble(query[0]));
                        var mes = DateTime.ParseExact(item.Item1, "MMMM", CultureInfo.CurrentCulture).Month;
                        DateTime fecha = new DateTime(item.Item2, mes, 1);

                        data.Add(fecha, Convert.ToDouble(query[contador]));
                        contador++;
                    }
                    return data;
                    //return data;
                }
            }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Obtiene Diccionario de la tasa junto con la fecha, se usa cuando el calculo es por quincenas.
        /// </summary>
        /// <param name="_inicio">Fecha desde la que se desea buscar la tasa</param>
        /// <param name="_final">Ultima fecha que se desea para buscar la tasa</param>
        /// <param name="_quincenainicial">Número de la quincena en la que inicia | 1 ó 2</param>
        /// <param name="_quincenafinal">Número de la quincena en la que finaliza | 1 ó 2</param>
        /// <returns></returns>
        public Dictionary<DateTime, double> getLstTasas(DateTime _inicio, DateTime _final, int _quincenainicial, int _quincenafinal)
        {
            List<double> tasas = new List<double>();
            Dictionary<DateTime, double> data = new Dictionary<DateTime, double>();
            DateTime inicio = new DateTime(_inicio.Year, _inicio.Month, 1);
            DateTime final = new DateTime(_final.Year, _final.Month, DateTime.DaysInMonth(_final.Year, _final.Month));
            int count = 0;
            try
            {
                using (var ctx = new _Modelo())
                {
                    var query = ctx.tasasOmisiones.Where(r => r.fecha >= inicio && r.fecha <= final).Select(r => new { r.tasa, r.fecha }).OrderBy(r => r.fecha).ToList();
                    foreach (var item in query)
                    {
                        count++;
                        int aux=0;

                        if (count == 1 && _quincenainicial == 1)
                        {
                            tasas.Add(Convert.ToDouble(item.tasa));
                            data.Add(item.fecha, Convert.ToDouble(item.tasa));
                            tasas.Add(Convert.ToDouble(item.tasa));
                            data.Add(item.fecha.AddMinutes(1), Convert.ToDouble(item.tasa));

                            aux++;
                        }
                        else if (count == query.Count() && _quincenafinal == 2)
                        {
                            tasas.Add(Convert.ToDouble(item.tasa));
                            data.Add(item.fecha, Convert.ToDouble(item.tasa));
                            tasas.Add(Convert.ToDouble(item.tasa));
                            data.Add(item.fecha.AddMinutes(1), Convert.ToDouble(item.tasa));
                            aux++;
                        }
                        else
                        {
                            if (_quincenainicial == 2 && count == 1)
                            {
                                tasas.Add(Convert.ToDouble(item.tasa));
                                data.Add(item.fecha.AddMinutes(1), Convert.ToDouble(item.tasa));
                                aux++;

                            }
                            else if (_quincenafinal == 1 && count == query.Count())
                            {
                                tasas.Add(Convert.ToDouble(item.tasa));
                                data.Add(item.fecha, Convert.ToDouble(item.tasa));
                                aux++;
                            }else
                            
                            {
                                tasas.Add(Convert.ToDouble(item.tasa));
                                data.Add(item.fecha, Convert.ToDouble(item.tasa));
                            }
                        }
                        if (count != 1 && count != query.Count())
                        {
                            tasas.Add(Convert.ToDouble(item.tasa));
                            data.Add(item.fecha.AddMinutes(1), Convert.ToDouble(item.tasa));
                        }






                    }
                    return data;
                }
            }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Obtiene Diccionario de la tasa junto con la fecha, desde la fecha indicado como parametro hasta el ultimo registro encontrado en la base de datos.
        /// </summary>
        /// <param name="_inicio">Fecha desde la que se desea buscar la tasa</param
        /// <returns></returns>
        public Dictionary<DateTime, double> getLstTasas(DateTime _inicio)
        {
            List<double> tasas = new List<double>();
            Dictionary<DateTime, double> data = new Dictionary<DateTime, double>();
            DateTime inicio = new DateTime(_inicio.Year, _inicio.Month, 1);
            try
            {
                using (var ctx = new _Modelo())
                {
                    var query = ctx.tasasOmisiones.Where(r => r.fecha > _inicio).Select(r => new { r.tasa, r.fecha }).OrderBy(r => r.fecha).ToList();
                    foreach (var item in query)
                    {
                        tasas.Add(Convert.ToDouble(item.tasa));
                        data.Add(item.fecha, Convert.ToDouble(item.tasa));

                    }

                    return data;
                }
            }
            catch (Exception) { throw; }

        }

        /// <summary>
        /// Obtiene la última tasa registrada en la base de datos.
        /// </summary>
        /// <returns></returns>
        public tasasOmisiones getUltimaTasa()
        {
             try
            {
                using (var ctx = new _Modelo())
                {
                    tasasOmisiones query = ctx.tasasOmisiones.OrderByDescending(r => r.fecha).Take(1).FirstOrDefault();
                    return query;
                }
            }
            catch (Exception) { throw; }

        }
      
        public static IEnumerable<Tuple<string, int>> MonthsBetween( DateTime startDate, DateTime endDate)
        {
            DateTime iterator;
            DateTime limit;

            if (endDate > startDate)
            {
                iterator = new DateTime(startDate.Year, startDate.Month, 1);
                limit = endDate;
            }
            else
            {
                iterator = new DateTime(endDate.Year, endDate.Month, 1);
                limit = startDate;
            }

            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            while (iterator <= limit)
            {
                yield return Tuple.Create(
                    dateTimeFormat.GetMonthName(iterator.Month),
                    iterator.Year);
                iterator = iterator.AddMonths(1);
            }
        }


    }


}