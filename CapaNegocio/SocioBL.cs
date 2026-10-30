using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaNegocio
{
    public class SocioBL
    {
        SocioDAL sociodal = new SocioDAL();
        public string Registrar(Socios osocio)
        {
            return sociodal.RegistrarSocio(osocio);
        }

        public bool ValidacionDNI(string dni)
        {
            return sociodal.ValidarDniDuplicado(dni);
        }

        public Socios BuscarSocioRenovacion(string dni)
        {
            return sociodal.BuscarSocioRenovacion(dni);
        }

        public string RenovarMembresia(Socios socio)
        {
            return sociodal.RenovarMembresia(socio);
        }
        public DataTable Listar()
        {
            return sociodal.Listar();
        }

        public string Actualizar(Socios socio)
        {
            return sociodal.Actualizar(socio);
        }

        public string Eliminar(int idSocio)
        {
            return sociodal.Eliminar(idSocio);
        }

        public DataTable Buscar(string texto)
        {
            return sociodal.Buscar(texto);
        }
    }
}

