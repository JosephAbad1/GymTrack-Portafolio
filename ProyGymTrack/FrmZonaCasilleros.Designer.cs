namespace ProyGymTrack
{
    partial class FrmZonaCasilleros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCasAgrMuj = new System.Windows.Forms.Button();
            this.flpMujeres = new System.Windows.Forms.FlowLayoutPanel();
            this.btnElimCasMuj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnElimCasVar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCasAgrVar = new System.Windows.Forms.Button();
            this.flpVarones = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnCasAgrMuj);
            this.splitContainer1.Panel1.Controls.Add(this.flpMujeres);
            this.splitContainer1.Panel1.Controls.Add(this.btnElimCasMuj);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnElimCasVar);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.btnCasAgrVar);
            this.splitContainer1.Panel2.Controls.Add(this.flpVarones);
            this.splitContainer1.Size = new System.Drawing.Size(1421, 976);
            this.splitContainer1.SplitterDistance = 688;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // btnCasAgrMuj
            // 
            this.btnCasAgrMuj.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCasAgrMuj.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCasAgrMuj.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCasAgrMuj.ForeColor = System.Drawing.Color.White;
            this.btnCasAgrMuj.Location = new System.Drawing.Point(134, 78);
            this.btnCasAgrMuj.Name = "btnCasAgrMuj";
            this.btnCasAgrMuj.Size = new System.Drawing.Size(169, 71);
            this.btnCasAgrMuj.TabIndex = 2;
            this.btnCasAgrMuj.Text = "Agregar Casillero";
            this.btnCasAgrMuj.UseVisualStyleBackColor = false;
            this.btnCasAgrMuj.Click += new System.EventHandler(this.btnCasAgrMuj_Click);
            // 
            // flpMujeres
            // 
            this.flpMujeres.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpMujeres.AutoScroll = true;
            this.flpMujeres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpMujeres.Location = new System.Drawing.Point(12, 171);
            this.flpMujeres.Name = "flpMujeres";
            this.flpMujeres.Size = new System.Drawing.Size(640, 779);
            this.flpMujeres.TabIndex = 1;
            this.flpMujeres.Paint += new System.Windows.Forms.PaintEventHandler(this.flpMujeres_Paint);
            // 
            // btnElimCasMuj
            // 
            this.btnElimCasMuj.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnElimCasMuj.BackColor = System.Drawing.Color.Crimson;
            this.btnElimCasMuj.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElimCasMuj.ForeColor = System.Drawing.Color.White;
            this.btnElimCasMuj.Location = new System.Drawing.Point(382, 78);
            this.btnElimCasMuj.Name = "btnElimCasMuj";
            this.btnElimCasMuj.Size = new System.Drawing.Size(169, 71);
            this.btnElimCasMuj.TabIndex = 3;
            this.btnElimCasMuj.Text = "Eliminar Casillero";
            this.btnElimCasMuj.UseVisualStyleBackColor = false;
            this.btnElimCasMuj.Click += new System.EventHandler(this.btnElimCasMuj_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepPink;
            this.label1.Location = new System.Drawing.Point(261, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zona Mujeres";
            // 
            // btnElimCasVar
            // 
            this.btnElimCasVar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnElimCasVar.BackColor = System.Drawing.Color.Crimson;
            this.btnElimCasVar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElimCasVar.ForeColor = System.Drawing.Color.White;
            this.btnElimCasVar.Location = new System.Drawing.Point(405, 78);
            this.btnElimCasVar.Name = "btnElimCasVar";
            this.btnElimCasVar.Size = new System.Drawing.Size(169, 71);
            this.btnElimCasVar.TabIndex = 7;
            this.btnElimCasVar.Text = "Eliminar Casillero";
            this.btnElimCasVar.UseVisualStyleBackColor = false;
            this.btnElimCasVar.Click += new System.EventHandler(this.btnElimCasVar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.YellowGreen;
            this.label2.Location = new System.Drawing.Point(274, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Zona Varones";
            // 
            // btnCasAgrVar
            // 
            this.btnCasAgrVar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCasAgrVar.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCasAgrVar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCasAgrVar.ForeColor = System.Drawing.Color.White;
            this.btnCasAgrVar.Location = new System.Drawing.Point(152, 78);
            this.btnCasAgrVar.Name = "btnCasAgrVar";
            this.btnCasAgrVar.Size = new System.Drawing.Size(169, 71);
            this.btnCasAgrVar.TabIndex = 6;
            this.btnCasAgrVar.Text = "Agregar Casillero";
            this.btnCasAgrVar.UseVisualStyleBackColor = false;
            this.btnCasAgrVar.Click += new System.EventHandler(this.btnCasAgrVar_Click);
            // 
            // flpVarones
            // 
            this.flpVarones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpVarones.AutoScroll = true;
            this.flpVarones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpVarones.Location = new System.Drawing.Point(42, 171);
            this.flpVarones.Name = "flpVarones";
            this.flpVarones.Size = new System.Drawing.Size(647, 779);
            this.flpVarones.TabIndex = 5;
            // 
            // FrmZonaCasilleros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1421, 976);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmZonaCasilleros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Casilleros - Distribución por Zonas";
            this.Load += new System.EventHandler(this.FrmZonaCasilleros_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnElimCasMuj;
        private System.Windows.Forms.Button btnCasAgrMuj;
        private System.Windows.Forms.FlowLayoutPanel flpMujeres;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnElimCasVar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCasAgrVar;
        private System.Windows.Forms.FlowLayoutPanel flpVarones;
    }
}