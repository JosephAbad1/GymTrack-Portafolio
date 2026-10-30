using CapaNegocio;
using Entidades;
using System;
using System.Windows.Forms;

namespace ProyGymTrack
{
    public partial class FrmGestionAsesor : Form
    {
        AsesorBL asesorBL = new AsesorBL();
        int idAsesorSeleccionado = 0;

        public FrmGestionAsesor()
        {
            InitializeComponent();
        }

        private void FrmGestionAsesor_Load(object sender, EventArgs e)
        {
            ListarAsesores();
        }

        private void ListarAsesores()
        {
            dgvAsesores.DataSource = asesorBL.Listar();
        }

        private void Limpiar()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtUsuario.Clear();
            txtClave.Clear();
            txtBuscar.Clear();
            idAsesorSeleccionado = 0;
            txtNombres.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) || string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Asesor nuevoAsesor = new Asesor
            {
                nombres = txtNombres.Text,
                apellidos = txtApellidos.Text,
                usuario = txtUsuario.Text,
                clave = txtClave.Text
            };

            string respuesta = asesorBL.Insertar(nuevoAsesor);
            if (respuesta == "OK")
            {
                MessageBox.Show("Asesor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarAsesores();
                Limpiar();
            }
            else
            {
                MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAsesores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAsesores.Rows[e.RowIndex];
                idAsesorSeleccionado = Convert.ToInt32(row.Cells["IDASESOR"].Value);
                txtNombres.Text = row.Cells["NOMBRES"].Value.ToString();
                txtApellidos.Text = row.Cells["APELLIDOS"].Value.ToString();
                txtUsuario.Text = row.Cells["USUARIO"].Value.ToString();
                txtClave.Text = row.Cells["CLAVE"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idAsesorSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un asesor de la lista para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Asesor asesorModificado = new Asesor
            {
                IdAsesor = idAsesorSeleccionado,
                nombres = txtNombres.Text,
                apellidos = txtApellidos.Text,
                usuario = txtUsuario.Text,
                clave = txtClave.Text
            };

            string respuesta = asesorBL.Actualizar(asesorModificado);
            if (respuesta == "OK")
            {
                MessageBox.Show("Asesor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListarAsesores();
                Limpiar();
            }
            else
            {
                MessageBox.Show(respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idAsesorSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un asesor de la lista para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar este asesor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                string respuesta = asesorBL.Eliminar(idAsesorSeleccionado);
                if (respuesta == "OK")
                {
                    MessageBox.Show("Asesor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarAsesores();
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
            dgvAsesores.DataSource = asesorBL.Buscar(txtBuscar.Text);
        }

        private void dgvAsesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
