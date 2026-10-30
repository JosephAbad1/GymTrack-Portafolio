using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class SalidaBL
    {
        private SalidaDAL dal = new SalidaDAL();

        public ControlAccesos BuscarIngresoActivo(string dni)
        {
            return dal.BuscarIngresoActivo(dni);
        }

        public string RegistrarSalida(int idAcceso, int numeroCasillero, TimeSpan horaSalida)
        {
            return dal.RegistrarSalida(idAcceso, numeroCasillero, horaSalida);
        }
    }
}
