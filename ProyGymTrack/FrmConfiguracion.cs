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
    public partial class FrmConfiguracion : Form
    {
        ConfiguracionBL configBL = new ConfiguracionBL();

        public FrmConfiguracion()
        {
            InitializeComponent();
            this.Load += FrmConfiguracion_Load;
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnCancelar.Click += btnCancelar_Click;
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                Configuracion conf = configBL.Obtener();
                txtNombre.Text = conf.NombreGimnasio;
                txtDireccion.Text = conf.Direccion;
                txtTelefono.Text = conf.Telefono;
                txtHoraApertura.Text = conf.HoraApertura.ToString(@"hh\:mm\:ss");
                txtHoraCierre.Text = conf.HoraCierre.ToString(@"hh\:mm\:ss");
                txtHoraVisita.Text = conf.TiempoMaximoEstancia.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar configuración: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Configuracion conf = new Configuracion
                {
                    NombreGimnasio = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    HoraApertura = TimeSpan.Parse(txtHoraApertura.Text),
                    HoraCierre = TimeSpan.Parse(txtHoraCierre.Text),
                    TiempoMaximoEstancia = int.Parse(txtHoraVisita.Text)
                };

                string mensaje = configBL.Actualizar(conf);
                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Asegúrese de ingresar los formatos correctos para hora (HH:mm:ss) y tiempo (número entero). " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
