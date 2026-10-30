using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CasilleroBL
    {
        CasilleroDAL casillerodal = new CasilleroDAL();

        public List<Casillero> Listar(int zona)
        {
            return casillerodal.Listar(zona);
        }

        public void Agregar(int zona)
        {
            casillerodal.AgregarCasilleros(zona);
        }

        public void Eliminar(int id)
        {
            casillerodal.EliminarCasilleros(id);
        }

        public List<Casillero> BuscarCasilleroRetenido(int numero, string zona)
        {
            return casillerodal.BuscarCasilleroRetenido(numero, zona);
        }

        public List<Zona> listarZonaCBO()
        {
            CasilleroDAL datos = new CasilleroDAL();
            return datos.listarZonasCBO();
        } 

        public List<Casillero> listarEstados()
        {
            return casillerodal.listarEstados();
        }

        public List<Casillero> BuscarCasillero(int numero, int zona)
        {
            return casillerodal.BuscarCasillero(numero, zona);
        }


        public bool ModificarCasillero(Casillero c)
        {
            return casillerodal.ModificarCasillero(c);
        }
    }
}
