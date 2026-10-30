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
    public class AsesorBL
    {
        AsesorDAL oAsesordal = new AsesorDAL();
        public Asesor Login(string usuario, string password)
        {
            return oAsesordal.login(usuario, password);
        }

        public DataTable Listar()
        {
            return oAsesordal.Listar();
        }

        public string Insertar(Entidades.Asesor obj)
        {
            return oAsesordal.Insertar(obj);
        }

        public string Actualizar(Entidades.Asesor obj)
        {
            return oAsesordal.Actualizar(obj);
        }

        public string Eliminar(int idAsesor)
        {
            return oAsesordal.Eliminar(idAsesor);
        }

        public DataTable Buscar(string texto)
        {
            return oAsesordal.Buscar(texto);
        }


    }
}
