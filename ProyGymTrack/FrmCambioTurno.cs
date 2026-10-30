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
    public partial class FrmCambioTurno : Form
    {
        public FrmCambioTurno()
        {
            InitializeComponent();
        }

        

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Sesion.Activo = false;
            Sesion.AsesorLogueado = null;
            FrmLogin login = new FrmLogin();
            login.Show();
            foreach(Form frm in Application.OpenForms.Cast<Form>().ToList())
            {
                if(frm is FrmPrincipal || frm is FrmCambioTurno)
                {
                    frm.Close();
                }
            }
            
        }

        private void FrmCambioTurno_Load(object sender, EventArgs e)
        {
            MostrarSesion();
        }

        private void MostrarSesion()
        {
            if(Sesion.AsesorLogueado != null)
            {
                txtAsesor.Text = Sesion.AsesorLogueado.nombres + " " + Sesion.AsesorLogueado.apellidos;
                TxtTurnoIncio.Text = Sesion.HoraInicio.ToString("HH:mm:ss");
                txtEstado.Text = Sesion.Activo ? "Activo" : "Inactivo";
            }
        }
    }
}
