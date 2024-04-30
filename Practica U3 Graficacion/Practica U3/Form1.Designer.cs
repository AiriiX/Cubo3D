namespace Practica_U3
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PanelCubo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BarraRotacionX = new System.Windows.Forms.TrackBar();
            this.BarraRotacionZ = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.BarraRotacionY = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.BtnColor = new System.Windows.Forms.Button();
            this.BtnReiniciar = new System.Windows.Forms.Button();
            this.BtnRellenar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BarraRotacionX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraRotacionZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraRotacionY)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCubo
            // 
            this.PanelCubo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCubo.Location = new System.Drawing.Point(12, 12);
            this.PanelCubo.Name = "PanelCubo";
            this.PanelCubo.Size = new System.Drawing.Size(585, 275);
            this.PanelCubo.TabIndex = 0;
            this.PanelCubo.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelCubo_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rotacion X";
            // 
            // BarraRotacionX
            // 
            this.BarraRotacionX.Location = new System.Drawing.Point(12, 341);
            this.BarraRotacionX.Maximum = 180;
            this.BarraRotacionX.Name = "BarraRotacionX";
            this.BarraRotacionX.Size = new System.Drawing.Size(134, 45);
            this.BarraRotacionX.SmallChange = 5;
            this.BarraRotacionX.TabIndex = 2;
            this.BarraRotacionX.Scroll += new System.EventHandler(this.Rotacionx_Scroll);
            // 
            // BarraRotacionZ
            // 
            this.BarraRotacionZ.Location = new System.Drawing.Point(172, 373);
            this.BarraRotacionZ.Maximum = 180;
            this.BarraRotacionZ.Name = "BarraRotacionZ";
            this.BarraRotacionZ.Size = new System.Drawing.Size(121, 45);
            this.BarraRotacionZ.SmallChange = 5;
            this.BarraRotacionZ.TabIndex = 4;
            this.BarraRotacionZ.Scroll += new System.EventHandler(this.BarraRotacionZ_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rotacion Z";
            // 
            // BarraRotacionY
            // 
            this.BarraRotacionY.Location = new System.Drawing.Point(12, 430);
            this.BarraRotacionY.Maximum = 180;
            this.BarraRotacionY.Name = "BarraRotacionY";
            this.BarraRotacionY.Size = new System.Drawing.Size(134, 45);
            this.BarraRotacionY.SmallChange = 5;
            this.BarraRotacionY.TabIndex = 6;
            this.BarraRotacionY.Scroll += new System.EventHandler(this.BarraRotacionY_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rotacion Y";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.Location = new System.Drawing.Point(321, 322);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(86, 32);
            this.BtnGenerar.TabIndex = 7;
            this.BtnGenerar.Text = "Generar cubo";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // BtnColor
            // 
            this.BtnColor.Location = new System.Drawing.Point(464, 322);
            this.BtnColor.Name = "BtnColor";
            this.BtnColor.Size = new System.Drawing.Size(86, 32);
            this.BtnColor.TabIndex = 8;
            this.BtnColor.Text = "Color";
            this.BtnColor.UseVisualStyleBackColor = true;
            this.BtnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // BtnReiniciar
            // 
            this.BtnReiniciar.Location = new System.Drawing.Point(464, 416);
            this.BtnReiniciar.Name = "BtnReiniciar";
            this.BtnReiniciar.Size = new System.Drawing.Size(86, 32);
            this.BtnReiniciar.TabIndex = 9;
            this.BtnReiniciar.Text = "Reiniciar";
            this.BtnReiniciar.UseVisualStyleBackColor = true;
            this.BtnReiniciar.Click += new System.EventHandler(this.BtnReiniciar_Click);
            // 
            // BtnRellenar
            // 
            this.BtnRellenar.Location = new System.Drawing.Point(321, 416);
            this.BtnRellenar.Name = "BtnRellenar";
            this.BtnRellenar.Size = new System.Drawing.Size(86, 32);
            this.BtnRellenar.TabIndex = 10;
            this.BtnRellenar.Text = "Rellenar";
            this.BtnRellenar.UseVisualStyleBackColor = true;
            this.BtnRellenar.Click += new System.EventHandler(this.BtnRellenar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 500);
            this.Controls.Add(this.BtnRellenar);
            this.Controls.Add(this.BtnReiniciar);
            this.Controls.Add(this.BtnColor);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.BarraRotacionY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BarraRotacionZ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BarraRotacionX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PanelCubo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Practica U3";
            ((System.ComponentModel.ISupportInitialize)(this.BarraRotacionX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraRotacionZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraRotacionY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelCubo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar BarraRotacionX;
        private System.Windows.Forms.TrackBar BarraRotacionZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar BarraRotacionY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.Button BtnColor;
        private System.Windows.Forms.Button BtnReiniciar;
        private System.Windows.Forms.Button BtnRellenar;
    }
}

