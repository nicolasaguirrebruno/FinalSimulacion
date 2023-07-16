using FinalSim.Entidades;
using FinalSim.Intefaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.Intefaces
{
    public partial class ResultadosControl : UserControl
    {
        private SimulacionControl simulacion;
        private ConclusionesControl conclusion;

        public ResultadosControl(FilaSimulacion[] filas)
        {
            InitializeComponent();
            simulacion = new SimulacionControl(filas);
            simulacion.Dock = DockStyle.Fill;
            conclusion = new ConclusionesControl();
            conclusion.Dock = DockStyle.Fill;
        }

        private void ShowSimulation()
        {
            pnResultados.Controls.Clear();
            pnResultados.Controls.Add(simulacion);
            // cambiar el backcolor del boton simulacion
            btnSimulacion.BackColor = Color.FromArgb(230, 230, 240);
            btnSimulacion.ForeColor = Color.FromArgb(28, 30, 40);
            // cambiar el backcolor del boton conclusion
            btnConclusion.BackColor = Color.FromArgb(28, 30, 40);
            btnConclusion.ForeColor = Color.FromArgb(230, 230, 240);
        }

        private void ShowConclusion()
        {
            pnResultados.Controls.Clear();
            pnResultados.Controls.Add(conclusion);
            // cambiar el backcolor del boton simulacion
            btnConclusion.BackColor = Color.FromArgb(230, 230, 240);
            btnConclusion.ForeColor = Color.FromArgb(28, 30, 40);

            // cambiar el backcolor del boton conclusion
            btnSimulacion.BackColor = Color.FromArgb(28, 30, 40);
            btnSimulacion.ForeColor = Color.FromArgb(230, 230, 240);
        }

        private void btnSimulacion_Click_1(object sender, EventArgs e)
        {
            ShowSimulation();
        }

        private void btnConclusion_Click_1(object sender, EventArgs e)
        {
            ShowConclusion();
        }
    }
}
