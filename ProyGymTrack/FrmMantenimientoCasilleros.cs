using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using Entidades;

namespace ProyGymTrack
{
    public partial class FrmMantenimientoCasilleros : Form
    {
        CasilleroBL cn = new CasilleroBL();
        public FrmMantenimientoCasilleros()
        {
            InitializeComponent();
        }

        private void FrmMantenimientoCasilleros_Load(object sender, EventArgs e)
        {
            DeshabilitarCampos();

            CasilleroBL bl = new CasilleroBL();
            var lista = bl.listarZonaCBO();

            cboBuscarZona.DataSource = lista;
            cboBuscarZona.DisplayMember = "descripcion";
            cboBuscarZona.ValueMember = "idZona";
            cboBuscarZona.SelectedIndex = -1;

            cboInfoZona.DataSource = cn.listarZonaCBO();
            cboInfoZona.DisplayMember = "descripcion";
            cboInfoZona.ValueMember = "IdZona";

            cboEstado.DataSource = cn.listarEstados();
            cboEstado.DisplayMember = "EstadoCasillero";
            cboEstado.ValueMember = "IdEstadoCasillero";

            cboInfoZona.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
        }

    

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int numero = Convert.ToInt32(txtBuscarNumero.Text);
            int zona = Convert.ToInt32(cboBuscarZona.SelectedValue);

            var lista = cn.BuscarCasillero(numero, zona);

            if (lista.Count > 0)
            {
                var c = lista[0];

                txtInfoCasillero.Text = c.NumeroCasillero.ToString();
                cboInfoZona.SelectedValue = c.IdZona;
                cboEstado.SelectedValue = c.IdEstadoCasillero;
                if (c.Socios != null && !string.IsNullOrEmpty(c.Socios.Nombres))
                {
                    txtAsignado.Text = c.Socios.Nombres + " " + c.Socios.Apellidos;
                }
                else
                {
                    txtAsignado.Text = "No asignado";
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos");
            }
        }


        private void DeshabilitarCampos()
        {
            txtInfoCasillero.Enabled = false;
            cboInfoZona.Enabled = false;
            cboEstado.Enabled = false;
            txtAsignado.Enabled = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            cboInfoZona.Enabled = true;
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            cboEstado.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtInfoCasillero.Text, out int numero))
            {
                MessageBox.Show("Número inválido");
                return;
            }

            Casillero c = new Casillero();

            c.NumeroCasillero = numero;
            c.IdZona = Convert.ToInt32(cboInfoZona.SelectedValue);
            c.IdEstadoCasillero = Convert.ToInt32(cboEstado.SelectedValue);

            CasilleroBL logica = new CasilleroBL();
            bool resultado = logica.ModificarCasillero(c);

            if (resultado)
            {
                MessageBox.Show("Datos actualizados correctamente");
                cboInfoZona.Enabled = false;
                cboEstado.Enabled = false;
            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
            DeshabilitarCampos();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtInfoCasillero.Clear();
            cboInfoZona.SelectedIndex = -1;
            cboEstado.SelectedIndex = -1;
            txtAsignado.Clear();
            txtBuscarNumero.Clear();
            cboBuscarZona.SelectedIndex = -1;
        }
    }
}
