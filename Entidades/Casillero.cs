using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Casillero
    {
     
        public int IdCasillero { get; set; }

        public int IdZona { get; set; }

        public int IdEstadoCasillero { get; set; }

        public int NumeroCasillero { get; set; }

        public string Zona { get; set; }

        public string EstadoCasillero { get; set; }

        public Socios Socios { get; set; }

        public Casillero(int idCasillero, int idZona, int idEstadoCasillero, int numeroCasillero, string zona, string estadoCasillero)
        {
            IdCasillero = idCasillero;
            IdZona = idZona;
            IdEstadoCasillero = idEstadoCasillero;
            NumeroCasillero = numeroCasillero;
            Zona = zona;
            EstadoCasillero = estadoCasillero;
        }

        public Casillero(int idCasillero, int idZona, int idEstadoCasillero, int numeroCasillero)
        {
            IdCasillero = idCasillero;
            IdZona = idZona;
            IdEstadoCasillero = idEstadoCasillero;
            NumeroCasillero = numeroCasillero;
        }

        public Casillero()
        {
            Socios = new Socios();
        }

    }
}
