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
    public partial class FrmPrincipal : Form
    {
       
        public FrmPrincipal()
        {
            InitializeComponent();
            

        }

        private void AbrirFormularioHijo(Form formHijo)
        {
            if (this.panelPrincipal.Controls.Count > 0)
            {
                foreach (Control c in this.panelPrincipal.Controls)
                {
                    c.Dispose();
                }
                this.panelPrincipal.Controls.Clear();
            }

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            this.panelPrincipal.Controls.Add(formHijo);
            this.panelPrincipal.Tag = formHijo;
            this.Text = formHijo.Text;
            formHijo.Show();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new FrmSistemInicio());
        }

        private void menuRegistrar_Click(object sender, EventArgs e)
        {
            //  AbrirFormularioHijo(new FrmRegistrarSocio());

            FrmRegistrarSocio form = new FrmRegistrarSocio();
            form.ShowDialog();


        }

        private void menuMantenimiento_Click(object sender, EventArgs e)
        {
            FrmMantenimientoCasilleros frm = new FrmMantenimientoCasilleros();
            frm.ShowDialog();
        }

        private void menuZonas_Click(object sender, EventArgs e)
        {
            FrmZonaCasilleros frm = new FrmZonaCasilleros();
            frm.ShowDialog();
        }

        private void menuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuIngresos_Click(object sender, EventArgs e)
        {
            FrmMarcacionIngresos frm = new FrmMarcacionIngresos();
            frm.ShowDialog();
        }

        private void menuSalidas_Click(object sender, EventArgs e)
        {
            FrmSalida frm = new FrmSalida();
            frm.ShowDialog();
        }

        private void menuRenovacionMembresia_Click(object sender, EventArgs e)
        {
            FrmRenovacionMembresia form = new FrmRenovacionMembresia();
            form.ShowDialog();
        }

        private void menuAfluencia_Click(object sender, EventArgs e)
        {
            FrmAfluencia frm = new FrmAfluencia();
            frm.ShowDialog();
        }

        private void menuCasillerosRetenidos_Click(object sender, EventArgs e)
        {
            FrmCasillerosRetenidos frm = new FrmCasillerosRetenidos();
            frm.ShowDialog();
        }

        private void menuConfiguracion_Click(object sender, EventArgs e)
        {
            FrmConfiguracion frm= new FrmConfiguracion();
            frm.ShowDialog();
        }

        private void menuCambioTurno_Click(object sender, EventArgs e)
        {
            FrmCambioTurno frm = new FrmCambioTurno();
            frm.ShowDialog();
        }

        private void abadCurayJosephAlexanderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuGestionarSocios_Click(object sender, EventArgs e)
        {
            FrmGestionSocios frm  = new FrmGestionSocios();
            frm.ShowDialog();
        }

        private void menuGestionarAsesores_Click(object sender, EventArgs e)
        {
            FrmGestionAsesor frm = new FrmGestionAsesor();
            frm.ShowDialog();
        }
    }
}
