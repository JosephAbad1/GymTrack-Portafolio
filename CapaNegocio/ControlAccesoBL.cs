using CapaDatos;
using Entidades;
//using ProyGymTrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ControlAccesoBL
    {
        ControlAccesoDAL caDAL = new ControlAccesoDAL();


        public Socios BuscarSocio(string dni)
        {
            return caDAL.BuscarSocioparaIngreso(dni);
        }


        public Casillero ObtenerCasilleroLibre(int zona)
        {
            return caDAL.ObtenerPrimerCasilleroLibre(zona);
        }


        public string RegistrarIngreso(ControlAcceso_ABAD acceso)
        {
            return caDAL.RegistrarIngreso(acceso);
        }

    }

}
