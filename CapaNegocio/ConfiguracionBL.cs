using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ConfiguracionBL
    {
        private ConfiguracionDAL dal = new ConfiguracionDAL();

        public Configuracion Obtener()
        {
            return dal.Obtener();
        }

        public string Actualizar(Configuracion conf)
        {
            // Validaciones básicas de negocio si es necesario
            if (string.IsNullOrWhiteSpace(conf.NombreGimnasio))
            {
                return "El nombre del gimnasio no puede estar vacío.";
            }

            return dal.Actualizar(conf);
        }
    }
}
