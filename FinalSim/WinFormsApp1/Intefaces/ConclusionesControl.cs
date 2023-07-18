using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalSim.Intefaces
{
    public partial class ConclusionesControl : UserControl
    {
        public ConclusionesControl(long metricas, long cantidadIteraciones)
        {
            InitializeComponent();
            lblConclusion.Text =
                "Luego de "
                + cantidadIteraciones.ToString()
                + " iteraciones, la cantidad de personas rechazadas fue: ";
            lblMetricas.Text = metricas.ToString() + " personas";
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void lblIteraciones_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void lblConclusion_Click(object sender, EventArgs e) { }
    }
}
