using CapaNegocio;
using Entidades;
using System;
using System.Windows.Forms;

namespace ProyGymTrack
{
    public partial class FrmGestionSocios : Form
    {
        SocioBL socioBL = new SocioBL();
        int idSocioSeleccionado = 0;

        public FrmGestionSocios()
        {
            InitializeComponent();
        }

        private void FrmGestionSocios_Load(object sender, EventArgs e)
        {
            ListarSocios();
            cbSexo.SelectedIndex = 0;
        }

        private void ListarSocios()
        {
            dgvSocios.DataSource = socioBL.Listar();
        }

        private void Limpiar()
        {
            txtDni.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            cbSexo.SelectedIndex = 0;
            txtTelefono.Clear();
            txtIdZona.Clear();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            txtBuscar.Clear();
            idSocioSeleccionado = 0;
            txtDni.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSocios.Rows[e.RowIndex];
                idSocioSeleccionado = Convert.ToInt32(row.Cells["IDSOCIO"].Value);
                txtDni.Text = row.Cells["DNI"].Value.ToString();
                txtNombres.Text = row.Cells["NOMBRES"].Value.ToString();
                txtApellidos.Text = row.Cells["APELLIDOS"].Value.ToString();

                if (DateTime.TryParse(row.Cells["FECHA_NACIMIENTO"].Value.ToString(), out DateTime fn))
                    dtpFechaNacimiento.Value = fn;

                cbSexo.Text = row.Cells["SEXO"].Value.ToString();
                txtTelefono.Text = row.Cells["TELEFONO"].Value.ToString();
                txtIdZona.Text = row.Cells["IDZONA"].Value.ToString();

                if (DateTime.TryParse(row.Cells["FECHA_INICIO"].Value.ToString(), out DateTime fi))
                    dtpFechaInicio.Value = fi;

                if (DateTime.TryParse(row.Cells["FECHA_FIN"].Value.ToString(), out DateTime ff))
                    dtpFechaFin.Value = ff;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un socio de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Por favor, complete los campos principales.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Socios socioModificado = new Socios
            {
                IdSocio = idSocioSeleccionado,
                Dni = txtDni.Text,
                Nombres = txtNombres.Text,
                Apellidos = txtApellidos.Text,
                FechaNacimiento = dtpFechaNacimiento.Value,
                Sexo = cbSexo.Text,
                Telefono = txtTelefono.Text,
                IdZona = Convert.ToInt32(string.IsNullOrWhiteSpace(txtIdZona.Text) ? "1" : txtIdZona.Text),
                FechaInicio = dtpFechaInicio.Value,
                FechaFin = dtpFechaFin.Value
            };

            string respuesta = socioBL.Actualizar(socioModificado);
            if (respuesta == "OK")
            {
                MessageBox.Show("Socio actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarSocios();
                Limpiar();
            }
            else
            {
                MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSocioSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un socio de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este socio?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string respuesta = socioBL.Eliminar(idSocioSeleccionado);
                if (respuesta == "OK")
                {
                    MessageBox.Show("Socio eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarSocios();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvSocios.DataSource = socioBL.Buscar(txtBuscar.Text);
        }

        private void dgvSocios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
