namespace CR.Modelo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tasasOmisiones
    {
        public long id { get; set; }

        public DateTime fecha { get; set; }

        public decimal tasa { get; set; }

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
        public double getTasa(DateTime _inicio)
         {
            DateTime inicio = new DateTime(_inicio.Year, _inicio.Month+1, 1);

            try
            {
                using (var ctx = new _Modelo())
                {
                    var y = ctx.tasasOmisiones.Where(r => r.fecha >= _inicio).ToList();
                    var x = Convert.ToDouble(ctx.tasasOmisiones.Where(r => r.fecha >= _inicio).Select(r => r.tasa).Sum());

                    return Convert.ToDouble(ctx.tasasOmisiones.Where(r => r.fecha >= _inicio).Select(r => r.tasa).Sum()) * 100 * .8;

                }
            }
            catch (Exception) { throw; }
        }

        public double getTasa(DateTime _inicio, DateTime _final)
        {
            DateTime inicio = new DateTime(_inicio.Year, _inicio.Month + 1, 1);
            DateTime final = new DateTime(_final.Year, _final.Month + 1, 1);
            try
            {
                using (var ctx = new _Modelo())
                {
                    var y = ctx.tasasOmisiones.Where(r => r.fecha >= _inicio).ToList();
                    var x = Convert.ToDouble(ctx.tasasOmisiones.Where(r => r.fecha >= _inicio && r.fecha <= _final).Select(r => r.tasa).Sum());

                    return Convert.ToDouble(ctx.tasasOmisiones.Where(r => r.fecha >= _inicio && r.fecha <= _final).Select(r => r.tasa).Sum()) * 100 * .8;

                }
            }
            catch (Exception) { throw; }
        }

        public Dictionary<DateTime, double> getLstTasas(DateTime _inicio, DateTime _final)
        {
            List<double> tasas = new List<double>();
            Dictionary<DateTime, double> data = new Dictionary<DateTime, double>();
            DateTime inicio = new DateTime(_inicio.Year, _inicio.Month, 1);
            DateTime final = new DateTime(_final.Year, _final.Month, DateTime.DaysInMonth(_final.Year, _final.Month));
            try
            {
                using (var ctx = new _Modelo())
                {
                    var query = ctx.tasasOmisiones.Where(r => r.fecha >= inicio && r.fecha <= final).Select(r => new { r.tasa, r.fecha }).OrderBy(r => r.fecha).ToList();
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


    }
}