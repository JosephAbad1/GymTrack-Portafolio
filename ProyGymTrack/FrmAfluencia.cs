using CapaNegocio;
using Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace ProyGymTrack
{
    public partial class FrmAfluencia : Form
    {
        
        public FrmAfluencia()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ObtenerAfluenciaBL bl = new ObtenerAfluenciaBL();
            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date;

            var lista = bl.ObtenerAfluencia(desde, hasta);

            if(lista == null || lista.Count == 0)
            {
                MessageBox.Show("No hay datos para mostrar");
                return;
            }

            CargarChart(lista);
            btnConsultar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void CargarChart(List<AfluenciaHora> lista)
        {
            chartGraficoAfluencia.Series.Clear();
            chartGraficoAfluencia.Titles.Clear();

            var serie = chartGraficoAfluencia.Series.Add("Afluencia");
            serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;

            var datos = lista.ToDictionary(x => x.Hora, x => x.Cantidad);

            foreach (var item in lista)
            {
                string horaTexto = item.Hora.ToString("00") + ":00";
                serie.Points.AddXY(horaTexto, item.Cantidad);
            }

            chartGraficoAfluencia.Titles.Add("Afluencia de Clientes por Horas");

            chartGraficoAfluencia.ChartAreas[0].AxisX.Title = "Hora del día";
            chartGraficoAfluencia.ChartAreas[0].AxisY.Title = "Cantidad de personas";

            chartGraficoAfluencia.ChartAreas[0].AxisX.Interval = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
            chartGraficoAfluencia.Series.Clear();
            btnConsultar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void FrmAfluencia_Load(object sender, EventArgs e)
        {
            btnNuevo.Enabled = false;
        }
    }
}
