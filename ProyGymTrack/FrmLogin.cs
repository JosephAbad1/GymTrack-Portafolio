using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyGymTrack
{
    public partial class FrmLogin : Form
    {
         AsesorBL oAsesorbll = new AsesorBL();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string usuario = txtUsuario.Text.Trim();
            string password = txtContraseña.Text.Trim();

            Asesor asesorlogueado= oAsesorbll.Login(usuario, password);
           
                if (asesorlogueado != null)
                {
                    Sesion.AsesorLogueado = asesorlogueado;
                    Sesion.HoraInicio = DateTime.Now;
                    Sesion.Activo = true;

                    MessageBox.Show("Bienvenido a GymTrack Software", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FrmPrincipal frm = new FrmPrincipal();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           

        }
    }
