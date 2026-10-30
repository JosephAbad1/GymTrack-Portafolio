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
    public class AsesorDAL
    {
        public Asesor login(string usuario, string password)
        {
            Asesor asesor = null;

            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_Login", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Password", password);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    asesor = new Asesor();

                    asesor.IdAsesor = Convert.ToInt32(dr["IDASESOR"]);
                    asesor.nombres = dr["NOMBRES"].ToString();
                    asesor.apellidos = dr["APELLIDOS"].ToString();
                    asesor.usuario = dr["USUARIO"].ToString();
                }
            }
            return asesor;
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarAsesores", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public string Insertar(Entidades.Asesor obj)
        {
            try
            {
                using (SqlConnection cn = new ConexionBD().conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarAsesor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRES", obj.nombres);
                    cmd.Parameters.AddWithValue("@APELLIDOS", obj.apellidos);
                    cmd.Parameters.AddWithValue("@CLAVE", obj.clave);
                    cmd.Parameters.AddWithValue("@USUARIO", obj.usuario);
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

        public string Actualizar(Entidades.Asesor obj)
        {
            try
            {
                using (SqlConnection cn = new ConexionBD().conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_ActualizarAsesor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDASESOR", obj.IdAsesor);
                    cmd.Parameters.AddWithValue("@NOMBRES", obj.nombres);
                    cmd.Parameters.AddWithValue("@APELLIDOS", obj.apellidos);
                    cmd.Parameters.AddWithValue("@CLAVE", obj.clave);
                    cmd.Parameters.AddWithValue("@USUARIO", obj.usuario);
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

        public string Eliminar(int idAsesor)
        {
            try
            {
                using (SqlConnection cn = new ConexionBD().conectar())
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarAsesor", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDASESOR", idAsesor);
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

        public DataTable Buscar(string texto)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarAsesor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TEXTO", texto);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

    }
}
