namespace ProyGymTrack
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCambioTurno = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.aseorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGestionarAsesores = new System.Windows.Forms.ToolStripMenuItem();
            this.sociosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRegistrar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRenovacionMembresia = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGestionarSocios = new System.Windows.Forms.ToolStripMenuItem();
            this.instalacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.menuZonas = new System.Windows.Forms.ToolStripMenuItem();
            this.controlDiarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIngresos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalidas = new System.Windows.Forms.ToolStripMenuItem();
            this.estadísticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAfluencia = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCasillerosRetenidos = new System.Windows.Forms.ToolStripMenuItem();
            this.informaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abadCurayJosephAlexanderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.huancaAbarcaSaraiBriggiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bravoBenitoJaquelynMariaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sistemaToolStripMenuItem,
            this.aseorToolStripMenuItem,
            this.sociosToolStripMenuItem,
            this.instalacionesToolStripMenuItem,
            this.controlDiarioToolStripMenuItem,
            this.estadísticasToolStripMenuItem,
            this.informaciónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1118, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuConfiguracion,
            this.menuCambioTurno,
            this.menuSalir});
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(75, 26);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // menuConfiguracion
            // 
            this.menuConfiguracion.Name = "menuConfiguracion";
            this.menuConfiguracion.Size = new System.Drawing.Size(211, 26);
            this.menuConfiguracion.Text = "Configuración";
            this.menuConfiguracion.Click += new System.EventHandler(this.menuConfiguracion_Click);
            // 
            // menuCambioTurno
            // 
            this.menuCambioTurno.Name = "menuCambioTurno";
            this.menuCambioTurno.Size = new System.Drawing.Size(211, 26);
            this.menuCambioTurno.Text = "Cambiar de Turno";
            this.menuCambioTurno.Click += new System.EventHandler(this.menuCambioTurno_Click);
            // 
            // menuSalir
            // 
            this.menuSalir.Name = "menuSalir";
            this.menuSalir.Size = new System.Drawing.Size(211, 26);
            this.menuSalir.Text = "Salir";
            this.menuSalir.Click += new System.EventHandler(this.menuSalir_Click);
            // 
            // aseorToolStripMenuItem
            // 
            this.aseorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGestionarAsesores});
            this.aseorToolStripMenuItem.Name = "aseorToolStripMenuItem";
            this.aseorToolStripMenuItem.Size = new System.Drawing.Size(67, 26);
            this.aseorToolStripMenuItem.Text = "Asesor";
            // 
            // menuGestionarAsesores
            // 
            this.menuGestionarAsesores.Name = "menuGestionarAsesores";
            this.menuGestionarAsesores.Size = new System.Drawing.Size(217, 26);
            this.menuGestionarAsesores.Text = "Gestionar Asesores";
            this.menuGestionarAsesores.Click += new System.EventHandler(this.menuGestionarAsesores_Click);
            // 
            // sociosToolStripMenuItem
            // 
            this.sociosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRegistrar,
            this.menuRenovacionMembresia,
            this.menuGestionarSocios});
            this.sociosToolStripMenuItem.Name = "sociosToolStripMenuItem";
            this.sociosToolStripMenuItem.Size = new System.Drawing.Size(66, 26);
            this.sociosToolStripMenuItem.Text = "Socios";
            // 
            // menuRegistrar
            // 
            this.menuRegistrar.Name = "menuRegistrar";
            this.menuRegistrar.Size = new System.Drawing.Size(344, 26);
            this.menuRegistrar.Text = "Registrar Socio";
            this.menuRegistrar.Click += new System.EventHandler(this.menuRegistrar_Click);
            // 
            // menuRenovacionMembresia
            // 
            this.menuRenovacionMembresia.Name = "menuRenovacionMembresia";
            this.menuRenovacionMembresia.Size = new System.Drawing.Size(344, 26);
            this.menuRenovacionMembresia.Text = "Renovación de Estados de Membresía";
            this.menuRenovacionMembresia.Click += new System.EventHandler(this.menuRenovacionMembresia_Click);
            // 
            // menuGestionarSocios
            // 
            this.menuGestionarSocios.Name = "menuGestionarSocios";
            this.menuGestionarSocios.Size = new System.Drawing.Size(344, 26);
            this.menuGestionarSocios.Text = "Gestionar Socios";
            this.menuGestionarSocios.Click += new System.EventHandler(this.menuGestionarSocios_Click);
            // 
            // instalacionesToolStripMenuItem
            // 
            this.instalacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMantenimiento,
            this.menuZonas});
            this.instalacionesToolStripMenuItem.Name = "instalacionesToolStripMenuItem";
            this.instalacionesToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.instalacionesToolStripMenuItem.Text = "Instalaciones";
            // 
            // menuMantenimiento
            // 
            this.menuMantenimiento.Name = "menuMantenimiento";
            this.menuMantenimiento.Size = new System.Drawing.Size(281, 26);
            this.menuMantenimiento.Text = "Mantenimiento de Casilleros";
            this.menuMantenimiento.Click += new System.EventHandler(this.menuMantenimiento_Click);
            // 
            // menuZonas
            // 
            this.menuZonas.Name = "menuZonas";
            this.menuZonas.Size = new System.Drawing.Size(281, 26);
            this.menuZonas.Text = "Distribución por Zonas";
            this.menuZonas.Click += new System.EventHandler(this.menuZonas_Click);
            // 
            // controlDiarioToolStripMenuItem
            // 
            this.controlDiarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuIngresos,
            this.menuSalidas});
            this.controlDiarioToolStripMenuItem.Name = "controlDiarioToolStripMenuItem";
            this.controlDiarioToolStripMenuItem.Size = new System.Drawing.Size(117, 26);
            this.controlDiarioToolStripMenuItem.Text = "Control Diario";
            // 
            // menuIngresos
            // 
            this.menuIngresos.Name = "menuIngresos";
            this.menuIngresos.Size = new System.Drawing.Size(301, 26);
            this.menuIngresos.Text = "Panel de Marcación de Ingresos";
            this.menuIngresos.Click += new System.EventHandler(this.menuIngresos_Click);
            // 
            // menuSalidas
            // 
            this.menuSalidas.Name = "menuSalidas";
            this.menuSalidas.Size = new System.Drawing.Size(301, 26);
            this.menuSalidas.Text = "Registrar Salidas y Liberación";
            this.menuSalidas.Click += new System.EventHandler(this.menuSalidas_Click);
            // 
            // estadísticasToolStripMenuItem
            // 
            this.estadísticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAfluencia,
            this.menuCasillerosRetenidos});
            this.estadísticasToolStripMenuItem.Name = "estadísticasToolStripMenuItem";
            this.estadísticasToolStripMenuItem.Size = new System.Drawing.Size(99, 26);
            this.estadísticasToolStripMenuItem.Text = "Estadísticas";
            // 
            // menuAfluencia
            // 
            this.menuAfluencia.Name = "menuAfluencia";
            this.menuAfluencia.Size = new System.Drawing.Size(303, 26);
            this.menuAfluencia.Text = "Gráficos de Afluencia por Horas";
            this.menuAfluencia.Click += new System.EventHandler(this.menuAfluencia_Click);
            // 
            // menuCasillerosRetenidos
            // 
            this.menuCasillerosRetenidos.Name = "menuCasillerosRetenidos";
            this.menuCasillerosRetenidos.Size = new System.Drawing.Size(303, 26);
            this.menuCasillerosRetenidos.Text = "Listado de Casilleros Retenidos";
            this.menuCasillerosRetenidos.Click += new System.EventHandler(this.menuCasillerosRetenidos_Click);
            // 
            // informaciónToolStripMenuItem
            // 
            this.informaciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abadCurayJosephAlexanderToolStripMenuItem,
            this.huancaAbarcaSaraiBriggiteToolStripMenuItem,
            this.bravoBenitoJaquelynMariaToolStripMenuItem});
            this.informaciónToolStripMenuItem.Name = "informaciónToolStripMenuItem";
            this.informaciónToolStripMenuItem.Size = new System.Drawing.Size(103, 26);
            this.informaciónToolStripMenuItem.Text = "Información";
            // 
            // abadCurayJosephAlexanderToolStripMenuItem
            // 
            this.abadCurayJosephAlexanderToolStripMenuItem.Name = "abadCurayJosephAlexanderToolStripMenuItem";
            this.abadCurayJosephAlexanderToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.abadCurayJosephAlexanderToolStripMenuItem.Text = "Abad Curay, Joseph Alexander";
            this.abadCurayJosephAlexanderToolStripMenuItem.Click += new System.EventHandler(this.abadCurayJosephAlexanderToolStripMenuItem_Click);
            // 
            // huancaAbarcaSaraiBriggiteToolStripMenuItem
            // 
            this.huancaAbarcaSaraiBriggiteToolStripMenuItem.Name = "huancaAbarcaSaraiBriggiteToolStripMenuItem";
            this.huancaAbarcaSaraiBriggiteToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.huancaAbarcaSaraiBriggiteToolStripMenuItem.Text = "Huanca Abarca, Sarai Briggite";
            // 
            // bravoBenitoJaquelynMariaToolStripMenuItem
            // 
            this.bravoBenitoJaquelynMariaToolStripMenuItem.Name = "bravoBenitoJaquelynMariaToolStripMenuItem";
            this.bravoBenitoJaquelynMariaToolStripMenuItem.Size = new System.Drawing.Size(292, 26);
            this.bravoBenitoJaquelynMariaToolStripMenuItem.Text = "Bravo Benito, Jaquelyn Maria";
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 30);
            this.panelPrincipal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1118, 653);
            this.panelPrincipal.TabIndex = 1;
            this.panelPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPrincipal_Paint);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 683);
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gym Track";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sociosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instalacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlDiarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem menuCambioTurno;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.ToolStripMenuItem menuRegistrar;
        private System.Windows.Forms.ToolStripMenuItem menuRenovacionMembresia;
        private System.Windows.Forms.ToolStripMenuItem menuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem menuZonas;
        private System.Windows.Forms.ToolStripMenuItem menuIngresos;
        private System.Windows.Forms.ToolStripMenuItem menuSalidas;
        private System.Windows.Forms.ToolStripMenuItem estadísticasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAfluencia;
        private System.Windows.Forms.ToolStripMenuItem menuCasillerosRetenidos;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.ToolStripMenuItem informaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abadCurayJosephAlexanderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem huancaAbarcaSaraiBriggiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bravoBenitoJaquelynMariaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuGestionarSocios;
        private System.Windows.Forms.ToolStripMenuItem aseorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuGestionarAsesores;
    }
}

