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
    public class ControlAccesoDAL
    {
        public Socios BuscarSocioparaIngreso(string dni)   ///abad
        {
            Socios socio = null;

            using (SqlConnection cn = new ConexionBD().conectar())
            {

                SqlCommand cmd = new SqlCommand("sp_BuscarSocioIngreso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DNI", dni);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    socio = new Socios();

                    socio.IdSocio = Convert.ToInt32(dr["IDSOCIO"]);
                    socio.Nombres = dr["NOMBRES"].ToString();
                    socio.Apellidos = dr["APELLIDOS"].ToString();
                    socio.Zona = dr["ZONA"].ToString();
                    socio.Estado = dr["ESTADO"].ToString();
                    socio.IdZona = Convert.ToInt32(dr["IDZONA"]);
                }
            }
            return socio;
        }


        public Casillero ObtenerPrimerCasilleroLibre(int idZona)    ///abad 
        {
            Casillero casillero = null;

            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerPrimerCasilleroLibre", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDZONA", idZona);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    casillero = new Casillero();

                    casillero.IdCasillero = Convert.ToInt32(dr["IDCASILLERO"]);
                    casillero.NumeroCasillero = Convert.ToInt32(dr["NUMERO_CASILLERO"]);
                }
            }
            return casillero;
        }


        public string RegistrarIngreso(ControlAcceso_ABAD acceso)   ////abad
        {
            try
            {
                string r = "";

                using (SqlConnection cn = new ConexionBD().conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarIngreso", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDSOCIO", acceso.IdSocio);

                    cmd.Parameters.AddWithValue("@IDCASILLERO", acceso.IdCasillero);

                    cmd.Parameters.AddWithValue("@IDASESOR", acceso.IdAsesor);

                    cn.Open();

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        r = "Ingreso registrado correctamente";
                    }

                    return r;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}




