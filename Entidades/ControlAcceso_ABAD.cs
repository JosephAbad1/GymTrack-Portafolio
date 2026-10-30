using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ControlAcceso_ABAD
    {
        public int IdAcceso { get; set; }

        public int IdSocio { get; set; }

        public int IdCasillero { get; set; }

        public int IdAsesor { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan HoraIngreso { get; set; }

        public TimeSpan? HoraSalida { get; set; }

        public ControlAcceso_ABAD()
        {
        }

        public ControlAcceso_ABAD(int idAcceso, int idSocio, int idCasillero,
                             int idAsesor, DateTime fecha,
                             TimeSpan horaIngreso, TimeSpan? horaSalida)
        {
            IdAcceso = idAcceso;
            IdSocio = idSocio;
            IdCasillero = idCasillero;
            IdAsesor = idAsesor;
            Fecha = fecha;
            HoraIngreso = horaIngreso;
            HoraSalida = horaSalida;
        }
    }
}

