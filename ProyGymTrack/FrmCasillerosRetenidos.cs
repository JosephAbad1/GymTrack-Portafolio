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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyGymTrack
{
    public partial class FrmCasillerosRetenidos : Form
    {
        public FrmCasillerosRetenidos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCasillero.Text == "")
            {
                MessageBox.Show("Ingrese el número de casillero");
                return;
            }

            if(cboZona.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una zona");
                return;
            }

            CargarDatos();
            
        }

        

        private void cboZona_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmCasillerosRetenidos_Load(object sender, EventArgs e)
        {
            CasilleroBL bl = new CasilleroBL();
            var lista = bl.listarZonaCBO();

            cboZona.DataSource = lista;
            cboZona.DisplayMember = "descripcion";
            cboZona.ValueMember = "idZona";
            cboZona.SelectedIndex = -1;          
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCasillero.Clear();
            cboZona.SelectedIndex = -1;
            txtCasillero.Focus();
        }

        private void dgvCasillerosRetenidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCasillerosRetenidos.Columns[e.ColumnIndex].Name == "Liberar")
            {
                int numeroCasillero = Convert.ToInt32(
                    dgvCasillerosRetenidos.Rows[e.RowIndex].Cells["NUMERO_CASILLERO"].Value
                    );
                LiberarCasillero(numeroCasillero);
            }
        }

        void LiberarCasillero(int numeroCasillero)
        {

            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_LiberarCasillero", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NumeroCasillero", numeroCasillero);
                cn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Casillero liberado correctamente");
            CargarDatos();
        }

        void CargarDatos()
        {
            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_BuscarCasillerosOcupados", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                int numero = 0;

                if (!string.IsNullOrEmpty(txtCasillero.Text))
                {
                    int.TryParse(txtCasillero.Text, out numero);
                }

                cmd.Parameters.AddWithValue("@NumeroCasillero", Convert.ToInt32(txtCasillero.Text));
                cmd.Parameters.AddWithValue("@Zona", cboZona.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count == 0)
                {
                    ValidarMotivo(numero);
                    dgvCasillerosRetenidos.DataSource = null;
                    dgvCasillerosRetenidos.Columns.Clear();
                    return;
                }
                dgvCasillerosRetenidos.DataSource = null;
                dgvCasillerosRetenidos.Columns.Clear();
                dgvCasillerosRetenidos.DataSource = dt;

                AgregarBoton();
            }
        }

        void AgregarBoton()
        {
            if (dgvCasillerosRetenidos.Columns.Contains("Liberar")) return;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Liberar";
            btn.HeaderText = "Acción";
            btn.Text = "Liberar";
            btn.UseColumnTextForButtonValue = true;

            dgvCasillerosRetenidos.Columns.Add(btn);

        }

        void ValidarMotivo(int numero)
        {
            using(SqlConnection cn = new ConexionBD().conectar())
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDESTADO_ACTUAL_CASILLEROS FROM CASILLEROS WHERE NUMERO_CASILLERO = @num", cn);
                cmd.Parameters.AddWithValue("@num", numero);
                object result = cmd.ExecuteScalar();

                if(result == null)
                {
                    MessageBox.Show("El casillero no existe");
                    return;
                }

                int estado = Convert.ToInt32(result);

                if(estado == 1)
                {
                    MessageBox.Show("El casillero esta Libre");
                }
                else if(estado == 3)
                {
                    MessageBox.Show("El casillero está en Mantenimiento");
                }
           
            }

        }
    }
}
