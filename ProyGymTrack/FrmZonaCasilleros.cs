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
    public partial class FrmZonaCasilleros : Form
    {
        CasilleroBL casillerobll = new CasilleroBL();
        int zonaHombres = 1;  //cambiar 2
        int zonaMujeres = 2; //cambiar a 1

        Button seleccionado = null;
        int zonaSeleccionada = 0;
        FlowLayoutPanel flpseleccionado = null;

        public FrmZonaCasilleros()
        {
            InitializeComponent();
        }

        private void FrmZonaCasilleros_Load(object sender, EventArgs e)
        {
            MostrarCasilleros(flpMujeres, zonaMujeres);
            MostrarCasilleros(flpVarones, zonaHombres);

            /*Button btn = new Button(); ///PRUEBA PARA CARGAR CASILLEROS BOTONES
            btn.Text = "001";
            btn.Width = 80;
            btn.Height = 80;
            btn.ForeColor = Color.White;
            flpMujeres.Controls.Add(btn);*/
        }


        private Color ObtenerColorEstado(int estado)
        {
            switch (estado)
            {
                case 1:
                    return Color.Gray;

                case 2:
                    return Color.Crimson;

                case 3:
                    return Color.Gold;

                default:
                    return Color.Gray;
            }
        }

        private void MostrarCasilleros(FlowLayoutPanel flp, int zona)
        {
            flp.Controls.Clear();

            List<Casillero> lista = casillerobll.Listar(zona);

            foreach (Casillero c in lista)
            {
                Button btn = new Button();
                btn.Width = 80;
                btn.Height = 80;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Arial Rounded MT Bold", 9);

                btn.Text = "Casillero\n" + c.NumeroCasillero;
                btn.Tag = c; // aca usamos el tag para guardar la informacion del casillero traida desde la bd y poder usarla al momento de seleccionar,etc.

                btn.BackColor = ObtenerColorEstado(c.IdEstadoCasillero);
                btn.Click += Seleccionar;
                flp.Controls.Add(btn);
            }
        }


        private void Seleccionar(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (seleccionado != null)
            {
                Casillero casAnterior = (Casillero)seleccionado.Tag;
                seleccionado.BackColor = ObtenerColorEstado(casAnterior.IdEstadoCasillero);
            }
            //seleccionado.BackColor = Color.White;// esto es para deseleccionar el anterior

            seleccionado = btn;
            seleccionado.BackColor = Color.DarkBlue;//esto es para seleccion actual 

            Casillero cas = (Casillero)btn.Tag;


            if (btn.Parent == flpMujeres)
            {
                zonaSeleccionada = zonaMujeres;
                flpseleccionado = flpMujeres;
            }
            else
            {
                zonaSeleccionada = zonaHombres;
                flpseleccionado = flpVarones;
            }
        }

        private void eliminar()
        {

            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un casillero");
                return;
            }

            DialogResult r = MessageBox.Show("¿Desea eliminar el casillero?", "Confirmar", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                try
                {
                    Casillero cas = (Casillero)seleccionado.Tag;
                    casillerobll.Eliminar(cas.IdCasillero);
                    MostrarCasilleros(flpseleccionado, zonaSeleccionada);
                    seleccionado = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

        }
        private void flpMujeres_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnCasAgrVar_Click(object sender, EventArgs e)
        {
            casillerobll.Agregar(zonaHombres);
            MostrarCasilleros(flpVarones, zonaHombres);
        }

        private void btnCasAgrMuj_Click(object sender, EventArgs e)
        {
            casillerobll.Agregar(zonaMujeres);
            MostrarCasilleros(flpMujeres, zonaMujeres);
        }

        private void btnElimCasMuj_Click(object sender, EventArgs e)
        {
            eliminar();

        }

        private void btnElimCasVar_Click(object sender, EventArgs e)
        {
            eliminar();
        }
    }
}
