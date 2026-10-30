using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Asesor
    {
        public int IdAsesor {  get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string clave {  get; set; }
        public string usuario { get; set; }


        public Asesor()
        {
        }

        public Asesor(int idAsesor, string nombres, string apellidos, string clave, string usuario)
        {
            IdAsesor = idAsesor;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.clave = clave;
            this.usuario = usuario;
        }
    }

}
