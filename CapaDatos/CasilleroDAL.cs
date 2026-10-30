using Entidades;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CasilleroDAL
    {


        public List<Casillero> Listar(int idZona)             ///abad
        {

            List<Casillero> lista = new List<Casillero>();


            using (SqlConnection cn = new ConexionBD().conectar())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarCasilleros", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDZONA", idZona);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Casillero()
                    {
                        IdCasillero = Convert.ToInt32(dr["IDCASILLERO"]),
                        IdZona = Convert.ToInt32(dr["IDZONA"]),
                        IdEstadoCasillero = Convert.ToInt32(dr["IDESTADO_ACTUAL_CASILLEROS"]),
                        NumeroCasillero = Convert.ToInt32(dr["NUMERO_CASILLERO"]),
                        Zona = dr["ZONA"].ToString(),
                        EstadoCasillero = dr["ESTADO_CASILLERO"].ToString()
                    }
                    );
                }
                
            }
            return lista;
        }


        public void AgregarCasilleros(int idZona)   ///abad
        {
            
            using (SqlConnection cn = new ConexionBD().conectar())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_AgregarCasillero", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDZONA", idZona);
                cmd.ExecuteNonQuery();
            }

        }


        public void EliminarCasilleros(int idCasillero)   ///abad
        {
            using (SqlConnection cn = new ConexionBD().conectar())
            {
                cn.Open() ;
                SqlCommand cmd = new SqlCommand("sp_EliminarCasillero", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDCASILLERO", idCasillero);
                cmd.ExecuteNonQuery();

            }

        }

        public List<Casillero> BuscarCasilleroRetenido(int numero, string zona)   //bravo
        {
            List<Casillero> lista = new List<Casillero>();

            using (SqlConnection cn = new ConexionBD().conectar())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_BuscarCasillerosOcupados", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumeroCasillero", numero);
                cmd.Parameters.AddWithValue("@Zona", zona);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Casillero c = new Casillero();
                    c.Socios = new Socios();
                    c.NumeroCasillero = Convert.ToInt32(dr["NUMERO_CASILLERO"]);
                    c.Zona = dr["Zona"].ToString();
                    c.EstadoCasillero = dr["Estado"].ToString();
                    c.Socios.NombreCompleto = dr["Socio"].ToString();

                    lista.Add(c);
                }
            }
            return lista;
        }

        public List<Zona> listarZonasCBO()    ////bravo
        {
            List<Zona> lista = new List<Zona>();

            using(SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarZonas_Retenidos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Zona z = new Zona();
                    z.idZona = Convert.ToInt32(dr["IDZONA"]);
                    z.descripcion = dr["DESCRIPCION"].ToString();
                    lista.Add(z);
                }
            }
            return lista;
        }

        public List<Casillero> BuscarCasillero(int numero, int zona)  ///bravo
        {
            List<Casillero> lista = new List<Casillero>();

            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarCasillero", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NumeroCasillero", numero);
                cmd.Parameters.AddWithValue("@Zona", zona);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Casillero c = new Casillero();

                    c.NumeroCasillero = Convert.ToInt32(dr["NUMERO_CASILLERO"]);
                    c.IdZona = Convert.ToInt32(dr["IDZONA"]);
                    c.IdEstadoCasillero = Convert.ToInt32(dr["IDESTADO_ACTUAL_CASILLEROS"]);

                    c.Zona = dr["DESCRIPCION"].ToString();
                    c.EstadoCasillero = dr["ESTADO"].ToString();

                    if (dr["NOMBRES"] != DBNull.Value)
                    {
                        c.Socios = new Socios();
                        c.Socios.Nombres = dr["NOMBRES"].ToString();
                        c.Socios.Apellidos = dr["APELLIDOS"].ToString();
                    }

                    lista.Add(c);
                }
            }

            return lista;
        }

        public List<Casillero> listarEstados()     ///bravo
        {
            List<Casillero> lista = new List<Casillero>();

            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarEstados", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Casillero c = new Casillero();
                    c.IdEstadoCasillero = Convert.ToInt32(dr["idEstado"]);
                    c.EstadoCasillero = dr["descripcion"].ToString();
                    lista.Add(c);
                }
            }
            return lista;
        }

       

        public bool ModificarCasillero(Casillero c)      ///bravo
        {  
            bool respuesta = false;

            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_ModificarCasillero", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@NumeroCasillero", c.NumeroCasillero);
                cmd.Parameters.AddWithValue("@IdZona", c.IdZona);
                cmd.Parameters.AddWithValue("@IdEstado", c.IdEstadoCasillero);

                cn.Open();

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                    respuesta = true;
            }

            return respuesta;
        }
    }
}


