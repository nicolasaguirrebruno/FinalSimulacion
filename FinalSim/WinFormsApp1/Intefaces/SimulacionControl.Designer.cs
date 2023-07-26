namespace FinalSim.Intefaces
{
    partial class SimulacionControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgvSimulacion = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSimulacion).BeginInit();
            SuspendLayout();
            // 
            // dgvSimulacion
            // 
            dgvSimulacion.BackgroundColor = SystemColors.ActiveCaptionText;
            dgvSimulacion.BorderStyle = BorderStyle.None;
            dgvSimulacion.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(63, 28, 53);
            dataGridViewCellStyle1.Font = new Font("PP Radio Grotesk", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(187, 126, 169);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSimulacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSimulacion.ColumnHeadersHeight = 40;
            dgvSimulacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSimulacion.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSimulacion.Dock = DockStyle.Fill;
            dgvSimulacion.EnableHeadersVisualStyles = false;
            dgvSimulacion.GridColor = Color.FromArgb(158, 71, 132);
            dgvSimulacion.Location = new Point(0, 0);
            dgvSimulacion.Name = "dgvSimulacion";
            dgvSimulacion.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSimulacion.RowHeadersVisible = false;
            dgvSimulacion.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.Black;
            dataGridViewCellStyle3.Font = new Font("PP Radio Grotesk", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(187, 126, 169);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dgvSimulacion.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvSimulacion.RowTemplate.Height = 29;
            dgvSimulacion.Size = new Size(1205, 708);
            dgvSimulacion.TabIndex = 0;
            dgvSimulacion.CellPainting += dgvSimulacion_CellPainting;
            dgvSimulacion.ColumnWidthChanged += dgvSimulacion_ColumnWidthChanged;
            dgvSimulacion.Scroll += dgvSimulacion_Scroll;
            dgvSimulacion.Paint += dgvSimulacion_Paint;
            // 
            // SimulacionControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            Controls.Add(dgvSimulacion);
            Name = "SimulacionControl";
            Size = new Size(1205, 708);
            ((System.ComponentModel.ISupportInitialize)dgvSimulacion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSimulacion;
    }
}
