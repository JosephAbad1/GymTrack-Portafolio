using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConexionBD
    {
        private readonly string cadenaConexion = ConfigurationManager.ConnectionStrings["gymtrack"].ConnectionString;

        public SqlConnection conectar()
        {
            return new SqlConnection(cadenaConexion);
        }

    }
}
