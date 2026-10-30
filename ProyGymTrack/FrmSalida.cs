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
    public partial class FrmSalida : Form
    {
        SalidaBL salidaBL = new SalidaBL();
        int idAccesoActual = 0;

        public FrmSalida()
        {
            InitializeComponent();
            this.btnBuscar.Click += btnBuscar_Click;
            this.btnRegistrarSalida.Click += btnRegistrarSalida_Click;
            this.btnCancelar.Click += btnCancelar_Click;
            
            // Initial state
            lblTiempo.Text = "0 horas";
            dtpSalida.Value = DateTime.Now;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Ingrese un DNI válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ControlAccesos acceso = salidaBL.BuscarIngresoActivo(txtDni.Text);

                if (acceso != null)
                {
                    idAccesoActual = acceso.IdAcceso;
                    txtApellidosNombres.Text = acceso.NombreCompleto;
                    txtCasillero.Text = acceso.NumeroCasillero.ToString();
                    txtZona.Text = acceso.Zona;
                    txtHorarioIngreso.Text = acceso.HoraIngreso.ToString(@"hh\:mm\:ss");
                    dtpSalida.Value = DateTime.Now;

                    TimeSpan tiempoTranscurrido = dtpSalida.Value.TimeOfDay - acceso.HoraIngreso;
                    lblTiempo.Text = $"{tiempoTranscurrido.Hours} horas, {tiempoTranscurrido.Minutes} minutos";
                }
                else
                {
                    MessageBox.Show("No se encontró ingreso activo para este DNI.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar socio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (idAccesoActual == 0)
            {
                MessageBox.Show("Primero busque un socio con ingreso activo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int numCasillero = int.Parse(txtCasillero.Text);
                TimeSpan horaSalida = dtpSalida.Value.TimeOfDay;

                string mensaje = salidaBL.RegistrarSalida(idAccesoActual, numCasillero, horaSalida);
                MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                LimpiarFormulario();
                this.Close(); // Opcional: Cerrar después de registrar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar salida: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarFormulario()
        {
            idAccesoActual = 0;
            txtApellidosNombres.Text = "";
            txtCasillero.Text = "";
            txtZona.Text = "";
            txtHorarioIngreso.Text = "";
            lblTiempo.Text = "0 horas";
            txtDni.Text = "";
            txtDni.Focus();
        }
    }
}
