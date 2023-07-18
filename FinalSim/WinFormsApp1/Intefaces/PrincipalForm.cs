using FinalSim.Controlador;
using FinalSim.Entidades;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using WinFormsApp1.Intefaces;

namespace WinFormsApp1
{
    public partial class PrincipalForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeft,
            int nTop,
            int nRight,
            int nBottom,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public PrincipalForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(
                CreateRoundRectRgn(0, 0, Width, Height, 20, 20)
            );
        }

        private void superiorPanel_Paint(object sender, PaintEventArgs e) { }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
            btnMinimize.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnMinimize.Width, btnMinimize.Height, 30, 30)
            );
            btnMaximize.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnMinimize.Width, btnMinimize.Height, 30, 30)
            );
            btnClose.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnMinimize.Width, btnMinimize.Height, 30, 30)
            );

            txtTomaPedido.Text = "1";
            txtEntregaPedido.Text = "1";
            txtMediaConsumicion.Text = "60";
            txtDesviacion.Text = "20";
            txtPreparacionM1.Text = "10";
            txtPreparacionM2.Text = "18";
            txtProbabilidadM1.Text = "0,5";
            txtProbabilidadM2.Text = "0,5";
            txtLlegadaClientes.Text = "10";
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                this.Region = System.Drawing.Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, Width, Height, 0, 0)
                );
            }
            else
            {
                WindowState = FormWindowState.Normal;
                this.Region = System.Drawing.Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, Width, Height, 20, 20)
                );
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGenerateSimulation_Click(object sender, EventArgs e)
        {
            if (ValidateParameters())
            {
                var param = new Parametros();

                param.TiempoTomaPedido = double.Parse(txtTomaPedido.Text);
                param.TiempoEntregaPedido = double.Parse(txtEntregaPedido.Text);
                param.MediaConsumicionPedido = double.Parse(txtMediaConsumicion.Text);
                param.DesviacionConsumicionPedido = double.Parse(txtDesviacion.Text);
                param.TiempoPreparacionMenu1 = double.Parse(txtPreparacionM1.Text);
                param.TiempoPreparacionMenu2 = double.Parse(txtPreparacionM2.Text);
                param.ProbabilidadMenu1 = double.Parse(txtProbabilidadM1.Text);
                param.ProbabilidadMenu2 = double.Parse(txtProbabilidadM2.Text);
                param.TiempoLlegadaClientes = double.Parse(txtLlegadaClientes.Text);
                param.CantidadIteraciones = double.Parse(txtCantIteraciones.Text);
                param.Desde = double.Parse(txtDesde.Text);

                ControladorSimulacion controlador = new ControladorSimulacion(this, param);
                controlador.GenerateSimulation();
            }
        }

        public bool ValidateParameters()
        {
            try
            {
                var tiempoTomaPedido = double.Parse(txtTomaPedido.Text);
                var tiempoEntregaPedido = double.Parse(txtEntregaPedido.Text);
                var mediaConsumicion = double.Parse(txtMediaConsumicion.Text);
                var desviacionConsumicion = double.Parse(txtDesviacion.Text);
                var tiempoPreparacionM1 = double.Parse(txtPreparacionM1.Text);
                var tiempoPreparacionM2 = double.Parse(txtPreparacionM2.Text);
                var probabilidadM1 = double.Parse(txtProbabilidadM1.Text);
                var probabilidadM2 = double.Parse(txtProbabilidadM2.Text);
                var tiempoLlegadaCliente = double.Parse(txtLlegadaClientes.Text);
                var cantIter = double.Parse(txtCantIteraciones.Text);
                var desde = double.Parse(txtDesde.Text);

                if (probabilidadM1 > 1 || probabilidadM2 > 1)
                {
                    MessageBox.Show("El valor de la probabilidad del menu debe estar entre 0 y 1");
                    return false;
                }
                if ((probabilidadM1 + probabilidadM2) != 1)
                {
                    MessageBox.Show("La suma de las probabilidades debe ser 1");
                    return false;
                }

                if (desde > cantIter)
                {
                    MessageBox.Show(
                        "La cantidad de iteraciones debe ser mayor a la cantidad de iteraciones desde"
                    );
                    return false;
                }
                if (desde <= 0)
                {
                    MessageBox.Show("La cantidad de iteraciones desde debe ser mayor 0");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Verifique los valores ingresados");
                return false;
            }
            //programar


            return true;
        }

        private void txtTomaPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ','
                && e.KeyChar != '.'
            )
            {
                e.Handled = true;
            }
        }

        private void txtEntregaPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ','
                && e.KeyChar != '.'
            )
            {
                e.Handled = true;
            }
        }

        private void txtMediaConsumicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ','
                && e.KeyChar != '.'
            )
            {
                e.Handled = true;
            }
        }

        private void txtPreparacionM2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ','
                && e.KeyChar != '.'
            )
            {
                e.Handled = true;
            }
        }

        private void txtProbabilidadM2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ','
                && e.KeyChar != '.'
            )
            {
                e.Handled = true;
            }
        }

        private void txtProbabilidadM1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ','
                && e.KeyChar != '.'
            )
            {
                e.Handled = true;
            }
        }

        private void txtLlegadaClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ','
                && e.KeyChar != '.'
            )
            {
                e.Handled = true;
            }
        }

        private void txtCantIteraciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ','
                && e.KeyChar != '.'
            )
            {
                e.Handled = true;
            }
        }

        private void txtDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (
                !char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != ','
                && e.KeyChar != '.'
            )
            {
                e.Handled = true;
            }
        }

        public void CargarResultados(
            FilaSimulacion[] simulacion,
            long metricas,
            long cantIteraciones
        )
        {
            //programar
            //el controlador llama a este metodo para mostrar los resultados
            //limpiamos el panel
            this.pnResultados.Controls.Clear();
            // creamos el control de resultados
            var res = new ResultadosControl(simulacion, metricas, cantIteraciones);
            res.Dock = DockStyle.Fill;

            //lo mostramos
            this.pnResultados.Controls.Add(res);
        }

        private void btnGenerateSimulation_Click_1(object sender, EventArgs e)
        {
            if (ValidateParameters())
            {
                var param = new Parametros();

                param.TiempoTomaPedido = double.Parse(txtTomaPedido.Text);
                param.TiempoEntregaPedido = double.Parse(txtEntregaPedido.Text);
                param.MediaConsumicionPedido = double.Parse(txtMediaConsumicion.Text);
                param.DesviacionConsumicionPedido = double.Parse(txtDesviacion.Text);
                param.TiempoPreparacionMenu1 = double.Parse(txtPreparacionM1.Text);
                param.TiempoPreparacionMenu2 = double.Parse(txtPreparacionM2.Text);
                param.ProbabilidadMenu1 = double.Parse(txtProbabilidadM1.Text);
                param.ProbabilidadMenu2 = double.Parse(txtProbabilidadM2.Text);
                param.TiempoLlegadaClientes = double.Parse(txtLlegadaClientes.Text);
                param.CantidadIteraciones = double.Parse(txtCantIteraciones.Text);
                param.Desde = double.Parse(txtDesde.Text);

                ControladorSimulacion controlador = new ControladorSimulacion(this, param);
                controlador.GenerateSimulation();
            }
        }
    }
}
