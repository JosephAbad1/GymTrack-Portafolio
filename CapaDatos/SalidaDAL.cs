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
    public class SalidaDAL
    {
        public ControlAccesos BuscarIngresoActivo(string dni)
        {
            ControlAccesos acceso = null;
            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_Buscar_IngresoActivo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DNI", dni);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    acceso = new ControlAccesos();
                    acceso.IdAcceso = Convert.ToInt32(dr["ID_ACCESO"]);
                    acceso.DniSocio = dr["DNI"].ToString();
                    acceso.NombreCompleto = dr["NOMBRE_COMPLETO"].ToString();
                    acceso.NumeroCasillero = Convert.ToInt32(dr["NUMERO_CASILLERO"]);
                    acceso.Zona = dr["ZONA"].ToString();
                    acceso.HoraIngreso = (TimeSpan)dr["HORA_INGRESO"];
                }
            }
            return acceso;
        }

        public string RegistrarSalida(int idAcceso, int numeroCasillero, TimeSpan horaSalida)
        {
            try
            {
                string r = "";
                using (SqlConnection cn = new ConexionBD().conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_Registrar_Salida", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_ACCESO", idAcceso);
                    cmd.Parameters.AddWithValue("@NUMERO_CASILLERO", numeroCasillero);
                    cmd.Parameters.AddWithValue("@HORA_SALIDA", horaSalida);

                    cn.Open();
                    int f = cmd.ExecuteNonQuery();
                    // Devuelve filas afectadas. Como actualiza 2 tablas (Control Accesos y Casilleros), será > 0.
                    if (f > 0)
                    {
                        r = "Salida registrada y casillero liberado correctamente.";
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
