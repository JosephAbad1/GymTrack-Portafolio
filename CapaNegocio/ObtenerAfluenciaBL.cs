using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ObtenerAfluenciaBL
    {
        AfluenciaPorHorasDAL oAfluencia = new AfluenciaPorHorasDAL();

        public List<AfluenciaHora> ObtenerAfluencia(DateTime desde, DateTime hasta)
        {
            return oAfluencia.ObtenerAfluencia(desde, hasta);
        }
    }
}
