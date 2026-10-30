using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDatos
{
    public class SocioDAL
    {
        public string RegistrarSocio(Socios unsocio)   ///abad
        {
            try
            {
                string r = "";
                using (SqlConnection cn = new ConexionBD().conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_Registrar_Socio", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DNI", unsocio.Dni);
                    cmd.Parameters.AddWithValue("@NOMBRES", unsocio.Nombres);
                    cmd.Parameters.AddWithValue("@APELLIDOS", unsocio.Apellidos);
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", unsocio.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@SEXO", unsocio.Sexo);
                    cmd.Parameters.AddWithValue("@TELEFONO", unsocio.Telefono);
                    cmd.Parameters.AddWithValue("@IDZONA", unsocio.IdZona);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", unsocio.FechaInicio);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", unsocio.FechaFin);

                    cn.Open();
                    int f = cmd.ExecuteNonQuery();
                    if (f > 0)
                    {
                        r = "Socio Registrado";
                    }

                    return r;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ex.Message;
            }

        }

        public bool ValidarDniDuplicado(string dni)   ///abad
        {
            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("SP_EXISTE_DNI", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DNI", dni);

                cn.Open();

                int cantidad = Convert.ToInt32(cmd.ExecuteScalar());

                return cantidad > 0;
            }
        }

        public Socios BuscarSocioRenovacion(string dni)   ///abad
        {
            Socios socio = null;

            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarSocioRenova", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@p_dni", dni);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    socio = new Socios();

                    socio.IdSocio = Convert.ToInt32(dr["IDSOCIO"]);
                    socio.Dni = dr["DNI"].ToString();
                    socio.Nombres = dr["NOMBRES"].ToString();
                    socio.Apellidos = dr["APELLIDOS"].ToString();
                    socio.FechaInicio = Convert.ToDateTime(dr["FECHA_INICIO"]);
                    socio.FechaFin = Convert.ToDateTime(dr["FECHA_FIN"]);
                    socio.Estado = dr["ESTADO"].ToString();
                }
            }

            return socio;
        }

        public string RenovarMembresia(Socios unsocio)   ///abad
        {
            try
            {
                string r = "";

                using (SqlConnection cn = new ConexionBD().conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_Renovar_Membresia", cn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDSOCIO", unsocio.IdSocio);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", unsocio.FechaInicio);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", unsocio.FechaFin);

                    cn.Open();

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        r = "Membresía renovada correctamente";
                    }

                    return r;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }

        public DataTable Listar()      /////sarai
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarSocios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public string Actualizar(Socios obj)      ///sarai
        {
            try
            {
                using (SqlConnection cn = new ConexionBD().conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarSocio", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDSOCIO", obj.IdSocio);
                    cmd.Parameters.AddWithValue("@DNI", obj.Dni);
                    cmd.Parameters.AddWithValue("@NOMBRES", obj.Nombres);
                    cmd.Parameters.AddWithValue("@APELLIDOS", obj.Apellidos);
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", obj.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@SEXO", obj.Sexo);
                    cmd.Parameters.AddWithValue("@TELEFONO", obj.Telefono);
                    cmd.Parameters.AddWithValue("@IDZONA", obj.IdZona);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", obj.FechaInicio);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", obj.FechaFin);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Eliminar(int idSocio)     ///sarai
        {
            try
            {
                using (SqlConnection cn = new ConexionBD().conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarSocio", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDSOCIO", idSocio);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public DataTable Buscar(string texto)    ///sarai
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarSocio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TEXTO", texto);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
