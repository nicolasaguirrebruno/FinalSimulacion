namespace FinalSim.Intefaces
{
    partial class ConclusionesControl
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            lblConclusion = new Label();
            lblIteraciones = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // lblConclusion
            // 
            lblConclusion.Anchor = AnchorStyles.None;
            lblConclusion.AutoSize = true;
            lblConclusion.Font = new Font("PP Radio Grotesk", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            lblConclusion.ForeColor = Color.White;
            lblConclusion.Location = new Point(57, 236);
            lblConclusion.Name = "lblConclusion";
            lblConclusion.Size = new Size(761, 33);
            lblConclusion.TabIndex = 1;
            lblConclusion.Text = "Luego de      iteraciones la cantidad de personas rechazadas fue:";
            lblConclusion.Click += lblConclusion_Click;
            // 
            // lblIteraciones
            // 
            lblIteraciones.Anchor = AnchorStyles.None;
            lblIteraciones.AutoSize = true;
            lblIteraciones.Font = new Font("PP Radio Grotesk", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            lblIteraciones.ForeColor = Color.White;
            lblIteraciones.Location = new Point(178, 236);
            lblIteraciones.Name = "lblIteraciones";
            lblIteraciones.Size = new Size(30, 33);
            lblIteraciones.TabIndex = 2;
            lblIteraciones.Text = "n";
            lblIteraciones.Click += lblIteraciones_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("PP Radio Grotesk", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(371, 280);
            label2.Name = "label2";
            label2.Size = new Size(144, 33);
            label2.TabIndex = 3;
            label2.Text = "0 Personas";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("PP Radio Grotesk Black", 19.7999973F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(226, 114);
            label3.Name = "label3";
            label3.Size = new Size(406, 40);
            label3.TabIndex = 4;
            label3.Text = "Metricas de la Simulacion";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("PP Radio Grotesk", 11.999999F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Silver;
            label4.Location = new Point(312, 389);
            label4.Name = "label4";
            label4.Size = new Size(237, 24);
            label4.TabIndex = 5;
            label4.Text = "Nicolas Aguirre Leg: 87642";
            label4.Click += label4_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lblIteraciones);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(lblConclusion);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(875, 563);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // ConclusionesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "ConclusionesControl";
            Size = new Size(875, 563);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblConclusion;
        private Label lblIteraciones;
        private Label label2;
        private Label label3;
        private Label label4;
        private Panel panel1;
    }
}
