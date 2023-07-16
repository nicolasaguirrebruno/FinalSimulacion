namespace WinFormsApp1.Intefaces
{
    partial class ResultadosControl
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
            tableLayoutPanel1 = new TableLayoutPanel();
            btnConclusion = new Button();
            btnSimulacion = new Button();
            pnResultados = new Panel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnConclusion, 1, 0);
            tableLayoutPanel1.Controls.Add(btnSimulacion, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1213, 59);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnConclusion
            // 
            btnConclusion.BackColor = Color.FromArgb(63, 28, 53);
            btnConclusion.Dock = DockStyle.Fill;
            btnConclusion.Font = new Font("PP Radio Grotesk", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            btnConclusion.ForeColor = Color.White;
            btnConclusion.Location = new Point(609, 3);
            btnConclusion.Name = "btnConclusion";
            btnConclusion.Size = new Size(601, 53);
            btnConclusion.TabIndex = 3;
            btnConclusion.Text = "Conclusion";
            btnConclusion.UseVisualStyleBackColor = false;
            btnConclusion.Click += btnConclusion_Click_1;
            // 
            // btnSimulacion
            // 
            btnSimulacion.BackColor = Color.FromArgb(63, 28, 53);
            btnSimulacion.Dock = DockStyle.Fill;
            btnSimulacion.Font = new Font("PP Radio Grotesk", 16.1999989F, FontStyle.Regular, GraphicsUnit.Point);
            btnSimulacion.ForeColor = Color.White;
            btnSimulacion.Location = new Point(3, 3);
            btnSimulacion.Name = "btnSimulacion";
            btnSimulacion.Size = new Size(600, 53);
            btnSimulacion.TabIndex = 2;
            btnSimulacion.Text = "Simulacion";
            btnSimulacion.UseVisualStyleBackColor = false;
            btnSimulacion.Click += btnSimulacion_Click_1;
            // 
            // pnResultados
            // 
            pnResultados.Dock = DockStyle.Fill;
            pnResultados.Location = new Point(0, 59);
            pnResultados.Name = "pnResultados";
            pnResultados.Padding = new Padding(10);
            pnResultados.Size = new Size(1213, 609);
            pnResultados.TabIndex = 1;
            // 
            // ResultadosControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            Controls.Add(pnResultados);
            Controls.Add(tableLayoutPanel1);
            Name = "ResultadosControl";
            Size = new Size(1213, 668);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnResultados;
        private Button btnConclusion;
        private Button btnSimulacion;
    }
}
