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
    public partial class FrmRenovacionMembresia : Form
    {
        private SocioBL oSocioBLL = new SocioBL();
        private int idSocioSeleccionado;// este paramtro servira para poder guardar la nueva membresia al mismo id del socio ya registrado en la bd
        public FrmRenovacionMembresia()
        {
            InitializeComponent();

        }

        private bool ValidacionesDNI()
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Ingrese DNI para realizar la busqueda", "Ingresar DNI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return false;
            }

            if (txtDni.Text.Trim().Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return false;
            }
            return true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void FrmRenovacionMembresia_Load(object sender, EventArgs e)
        {
        }

        private void limpiar() {
            txtDni.Clear();
            txtApellidosNombres.Clear();
            txtEstadoMembresia.Clear();
            txtFechaFin.Clear();
            txtFechaInicio.Clear();          
           
            dtpFechaFin.ResetText();
            dtpFechaInicio.ResetText();
            
            txtDni.Focus();

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!ValidacionesDNI())
                return;

            Socios socioRM = oSocioBLL.BuscarSocioRenovacion(txtDni.Text.Trim());
            try
            {
                if (socioRM != null)
                {
                    idSocioSeleccionado = socioRM.IdSocio;
                    txtApellidosNombres.Text = socioRM.Apellidos + ", " + socioRM.Nombres;
                    txtFechaInicio.Text = socioRM.FechaInicio.ToString("dd/MMMM/yyyy");
                    txtFechaFin.Text = socioRM.FechaFin.ToString("dd/MMMM/yyyy");
                    txtEstadoMembresia.Text = socioRM.Estado;
                }
                else
                {
                    MessageBox.Show("Socio NO ENCONTRADO", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private bool ValidacionesRenovar()
        {

            if (idSocioSeleccionado == 0)
            {
                MessageBox.Show("Primero busque un socio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpFechaFin.Value.Date <= dtpFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha fin debe ser mayor que la fecha inicio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpFechaInicio.Value.Date <= Convert.ToDateTime(txtFechaFin.Text).Date)
            {
                MessageBox.Show("La nueva fecha de inicio de Membresia debe ser posterior a la fecha de finalización de la Membresía actual.","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void btnRenovar_Click(object sender, EventArgs e)
        {
            if (!ValidacionesRenovar())
                return;
            try
            {               
                Socios socio = new Socios();

                socio.IdSocio = idSocioSeleccionado;
                socio.FechaInicio = dtpFechaInicio.Value.Date;
                socio.FechaFin = dtpFechaFin.Value.Date;

                string mensaje = oSocioBLL.RenovarMembresia(socio);

                MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
