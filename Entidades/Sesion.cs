using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Sesion
    {
        public static Asesor AsesorLogueado { get; set; }
        public static DateTime HoraInicio { get; set; }
        public static bool Activo {  get; set; }
    }
}
