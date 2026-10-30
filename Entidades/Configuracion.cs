using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Configuracion
    {
        public int IdConfiguracion { get; set; }
        public string NombreGimnasio { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public TimeSpan HoraApertura { get; set; }
        public TimeSpan HoraCierre { get; set; }
        public int TiempoMaximoEstancia { get; set; }

        public Configuracion()
        {
        }
    }
}
