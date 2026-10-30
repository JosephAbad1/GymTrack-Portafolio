using CapaDatos;
using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ProyGymTrack
{
    public partial class FrmMarcacionIngresos : Form
    {
        ControlAccesoBL caBLL = new ControlAccesoBL();
        CasilleroBL casillerobll = new CasilleroBL();

        private int idSocio;
        private int idZona;
        private int idCasilleroAsignado;
        private int numeroCasilleroAsignado;



        public FrmMarcacionIngresos()
        {
            InitializeComponent();
        }

        private bool BuscarSocio()
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Ingrese DNI", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return false;
            }

            Socios socio = caBLL.BuscarSocio(txtDni.Text.Trim());

            if (socio == null)
            {
                MessageBox.Show("Socio no encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            idSocio = socio.IdSocio;
            idZona = socio.IdZona;

            txtApellidosNombres.Text = socio.Apellidos + " " + socio.Nombres;
            txtMembresia.Text = socio.Estado;
            txtZona.Text = socio.Zona;

            if (socio.Estado.ToUpper() == "ACTIVO")
            {
                txtDni.BackColor = Color.DarkGreen;
            }
            else
            {
                txtDni.BackColor = Color.Crimson;
            }

            Casillero casillero = caBLL.ObtenerCasilleroLibre(idZona);

            if (casillero == null)
            {

                MessageBox.Show("No hay casilleros libres", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCasillero.Clear();
            }
            else
            {
                idCasilleroAsignado = casillero.IdCasillero;
                numeroCasilleroAsignado = casillero.NumeroCasillero;
                txtCasillero.Text = numeroCasilleroAsignado.ToString();
            }


            CargarCasilleros2();//PRUEBA PARA COLORES CASILLEROS
            return true;
        }
        private Color ObtenerColorEstado(int estado)//PRUEBA PARA COLORES DE CASILLEROS
        {
            switch (estado)
            {
                case 1:
                    return Color.Gray;

                case 2:
                    return Color.Crimson;

                case 3:
                    return Color.Gold;

                default:
                    return Color.Gray;
            }
        }
        private void CargarCasilleros2() /////PRUEBA
        {
            flpCasilleros.Controls.Clear();

            List<Casillero> lista = casillerobll.Listar(idZona);

            foreach (Casillero c in lista)
            {
                Button btn = new Button();
                btn.Width = 80;
                btn.Height = 80;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Arial Rounded MT Bold", 9);

                btn.Text = "Casillero\n" + c.NumeroCasillero;

                if (c.IdCasillero == idCasilleroAsignado)
                {
                    btn.BackColor = Color.DarkGreen;
                }
                else
                {
                    btn.BackColor = ObtenerColorEstado(c.IdEstadoCasillero);
                }
                //btn.BackColor = ObtenerColorEstado(c.IdEstadoCasillero);
                // btn.Click += Seleccionar;
                flpCasilleros.Controls.Add(btn);
            }
        }

        /*  private void CargarCasilleros()
          {
              flpCasilleros.Controls.Clear();

              DataTable dt = new DataTable();

              using (SqlConnection cn = new ConexionBD().conectar())
              {
                  SqlCommand cmd = new SqlCommand("sp_ListarCasilleros", cn);
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.Parameters.AddWithValue("@IDZONA", idZona);

                  SqlDataAdapter da = new SqlDataAdapter(cmd);
                  da.Fill(dt);
              }

              foreach (DataRow fila in dt.Rows)
              {
                  Button btn = new Button();

                  btn.Width = 75;
                  btn.Height = 75;
                  btn.ForeColor = Color.White;
                  btn.Font = new Font("Arial Rounded MT Bold", 15);

                  btn.Text = fila["NUMERO_CASILLERO"].ToString();
                  int idCasillero = Convert.ToInt32(fila["IDCASILLERO"]);

                  string estado = fila["ESTADO_CASILLERO"].ToString();

                  // casillero asignado al socio que quiere entrar
                  if (idCasillero == idCasilleroAsignado)
                  {
                      btn.BackColor = Color.DarkGreen;
                  }
                  // casillero libre
                  else if (estado == "Libre")
                  {
                      btn.BackColor = Color.Gray;
                  }
                  // casillero ocupado
                  else
                  {
                      btn.BackColor = Color.FromArgb(43, 102, 183);
                  }

                  flpCasilleros.Controls.Add(btn);
              }
          }///YA NO SE USA, SE CAMBIO PARA ESTANDARIZARLO CON EL DE ZONA CASILLEROS*/

        private void Limpiar()
        {
            txtDni.Clear();
            txtApellidosNombres.Clear();
            txtMembresia.Clear();
            txtZona.Clear();
            txtCasillero.Clear();

            idSocio = 0;
            idZona = 0;
            idCasilleroAsignado = 0;

            flpCasilleros.Controls.Clear();

            txtDni.BackColor = Color.FromArgb(41, 41, 41);
            txtDni.Focus();
        }


        private void FrmMarcacionIngresos_Load(object sender, EventArgs e)
        {

        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
        }


        private void btnEnter_Click(object sender, EventArgs e)
        {
            BuscarSocio();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnRegistrarIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSocio == 0)
                {
                    MessageBox.Show("Primero busque un socio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtMembresia.Text.ToUpper() != "ACTIVO")
                {
                    MessageBox.Show("La membresía se encuentra vencida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (idCasilleroAsignado == 0)
                {
                    MessageBox.Show("No existe un casillero disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ControlAcceso_ABAD acceso = new ControlAcceso_ABAD();

                acceso.IdSocio = idSocio;
                acceso.IdCasillero = idCasilleroAsignado;
                acceso.IdAsesor = Sesion.AsesorLogueado.IdAsesor;

                string mensaje = caBLL.RegistrarIngreso(acceso);

                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarCasilleros2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flpCasilleros_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
