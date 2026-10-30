using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Socios
    {       
        public int IdSocio { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public int IdZona { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        //
        public string Estado { get; set; }

        public string Zona { get; set; }
        public string NombreCompleto { get; set; }

        public Socios(int idSocio, string dni, string nombres, string apellidos,
                        DateTime fechaNacimiento, string sexo, string telefono, int idZona,
                        DateTime fechaInicio, DateTime fechaFin)
        {
            IdSocio = idSocio;
            Dni = dni;
            Nombres = nombres;
            Apellidos = apellidos;
            FechaNacimiento = fechaNacimiento;
            Sexo = sexo;
            Telefono = telefono;
            IdZona = idZona;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public Socios()
        {
        }
    }
}
