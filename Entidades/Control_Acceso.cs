using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Control_Acceso
    {
        public int IdAcceso { get; set; }

        public int IdSocio { get; set; }

        public int IdCasillero { get; set; }

        public DateTime FechaIngreso { get; set; }

        public DateTime? FechaSalida { get; set; }
    }
}
