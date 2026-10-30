using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ControlAccesos
    {
        public int IdAcceso { get; set; }
        public string DniSocio { get; set; }
        public string NombreCompleto { get; set; }
        public int NumeroCasillero { get; set; }
        public string Zona { get; set; }
        public TimeSpan HoraIngreso { get; set; }
        public TimeSpan? HoraSalida { get; set; } 

        public ControlAccesos()
        {
        }
    }
}
