using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConfiguracionDAL
    {
        public Configuracion Obtener()
        {
            Configuracion conf = new Configuracion();
            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_Obtener_Configuracion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    conf.NombreGimnasio = dr["NOMBRE_GIMNASIO"].ToString();
                    conf.Direccion = dr["DIRECCION"].ToString();
                    conf.Telefono = dr["TELEFONO"].ToString();
                    conf.HoraApertura = (TimeSpan)dr["HORA_APERTURA"];
                    conf.HoraCierre = (TimeSpan)dr["HORA_CIERRE"];
                    conf.TiempoMaximoEstancia = Convert.ToInt32(dr["TIEMPO_MAXIMO_ESTANCIA"]);
                }
            }
            return conf;
        }

        public string Actualizar(Configuracion conf)
        {
            try
            {
                string r = "";
                using (SqlConnection cn = new ConexionBD().conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_Actualizar_Configuracion", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NOMBRE_GIMNASIO", conf.NombreGimnasio);
                    cmd.Parameters.AddWithValue("@DIRECCION", conf.Direccion);
                    cmd.Parameters.AddWithValue("@TELEFONO", conf.Telefono);
                    cmd.Parameters.AddWithValue("@HORA_APERTURA", conf.HoraApertura);
                    cmd.Parameters.AddWithValue("@HORA_CIERRE", conf.HoraCierre);
                    cmd.Parameters.AddWithValue("@TIEMPO_MAXIMO_ESTANCIA", conf.TiempoMaximoEstancia);

                    cn.Open();
                    int f = cmd.ExecuteNonQuery();
                    if (f > 0)
                    {
                        r = "Configuración Actualizada Correctamente";
                    }

                    return r;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
