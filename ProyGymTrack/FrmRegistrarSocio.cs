using CapaDatos;
using CapaNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyGymTrack
{
    public partial class FrmRegistrarSocio : Form
    {
        private SocioBL oSocioBLL = new SocioBL();
        public FrmRegistrarSocio()
        {
            InitializeComponent();
            CargarZona();
            cboZona.SelectedItem = null;
        }

        //metodo para validar los campos, tanto de duplicidad de dni, campos vacios y fecha de fin menor a la de inicio//
        private bool ValidacionParaLosCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(cboSexo.Text) ||
                string.IsNullOrWhiteSpace(cboZona.Text))
            {
                MessageBox.Show("Complete todos los campos, por favor.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (oSocioBLL.ValidacionDNI(txtDni.Text.Trim()))
            {
                MessageBox.Show("El DNI ingresado ya se encuentra registrado, porfavor ingrese otro DNI", "DNI Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDni.Focus();
                return false;
            }

            if (txtDni.Text.Trim().Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return false;
            }

            if (txtTelefono.Text.Trim().Length != 9)
            {
                MessageBox.Show("El teléfono debe tener 9 dígitos.", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }

            if (dtpFechaFin.Value.Date <= dtpFechaInicio.Value.Date)
            {
                MessageBox.Show("La fecha de fin debe ser mayor que la fecha de inicio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaFin.Focus();
                return false;
            }

            return true;

        }

        //metodos para filtrar los campos que solo usan numeros//
        private void CampoSoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        //metodo para filtrar los campos que usaran solo letras
        private void CampoSoloLetras(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        //metodo para cargar el combo de zona con la info de la tabla zona de la base de datos 
        private void CargarZona()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = new ConexionBD().conectar())
            {
                SqlCommand cmd = new SqlCommand("sp_CargarZona", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            cboZona.DataSource = dt;
            cboZona.DisplayMember = "DESCRIPCION";
            cboZona.ValueMember = "IDZONA";
        }


        //metodo para limpiar todos los campos y usarlo en el boton nuevo
        private void nuevo()
        {
            txtDni.Clear();
            txtApellido.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            cboSexo.SelectedItem = null;
            cboZona.SelectedItem = null;
            dtpFechaFin.ResetText();
            dtpFechaInicio.ResetText();
            dtpFechaNacimiento.ResetText();
            txtDni.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

            private void btnGuardar_Click(object sender, EventArgs e)
            {
                if (!ValidacionParaLosCampos())
                    return;

                try
                {
                    Socios gsocio = new Socios();

                    gsocio.Dni = txtDni.Text.Trim();
                    gsocio.Nombres = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNombre.Text.Trim().ToLower()); //esto lo uso para mantener la primera letra
                                                                                                                       //en mayuscula y lo demas en minuscula, para que haya un orden en la bd
                    gsocio.Apellidos = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtApellido.Text.Trim().ToLower()); 
                    gsocio.FechaNacimiento = dtpFechaNacimiento.Value;
                    gsocio.Sexo = cboSexo.Text.Trim();
                    gsocio.Telefono = txtTelefono.Text.Trim();
                    gsocio.IdZona = Convert.ToInt32(cboZona.SelectedValue);

                    gsocio.FechaInicio = dtpFechaInicio.Value;
                    gsocio.FechaFin = dtpFechaFin.Value;

                    string mensaje = oSocioBLL.Registrar(gsocio);

                    MessageBox.Show(mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void cboSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSexo.Text == "Masculino")
            {
                cboZona.SelectedValue = 1; // este es el id de la zona en la tabla zona de la bd
            }
            else if (cboSexo.Text == "Femenino")                              // hombres 1 , mujeres 2
            {
                cboZona.SelectedValue = 2; // este es el id de la zona en la tabla zona de la bd
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoSoloNumeros(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoSoloLetras(e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoSoloLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            CampoSoloNumeros(e);
        }

        private void FrmRegistrarSocio_Load(object sender, EventArgs e)
        {

        }
    }
}
