using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace CapaDatos
{
    public class AfluenciaPorHorasDAL
    {
        public List<AfluenciaHora> ObtenerAfluencia(DateTime desde, DateTime hasta)
        {
            List<AfluenciaHora> lista = new List<AfluenciaHora>();

            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_AfluenciaPorHoras", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Desde", desde);
                cmd.Parameters.AddWithValue("@Hasta", hasta);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new AfluenciaHora
                    {
                        Hora = Convert.ToInt32(dr["Hora"]),
                        Cantidad = Convert.ToInt32(dr["Cantidad"])
                    });
                }
            }
            return lista;
        }
    }
}
