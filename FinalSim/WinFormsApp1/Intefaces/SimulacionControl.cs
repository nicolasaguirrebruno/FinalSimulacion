using FinalSim.Entidades;
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
    public partial class SimulacionControl : UserControl
    {
        private FilaSimulacion[] simulacion;

        public SimulacionControl(FilaSimulacion[] filas)
        {
            InitializeComponent();
            this.simulacion = filas;
            LoadSimulation();
            this.dgvSimulacion.AllowUserToOrderColumns = false;
        }

        Color headerColor = Color.FromArgb(158, 71, 132);

        private void LoadSimulation()
        {
            //Evento y Reloj
            this.dgvSimulacion.Columns.Add("Evento", "Evento");
            this.dgvSimulacion.Columns.Add("Reloj", "Reloj");

            // llegada_clientes
            this.dgvSimulacion.Columns.Add("TiempoEntreLLegadas", "Tiempo Entre Llegadas");
            this.dgvSimulacion.Columns.Add("Proxima Llegada", "Proxima Llegada");
            this.dgvSimulacion.Columns.Add("RNDCantidad", "RND Cantidad");
            this.dgvSimulacion.Columns.Add("CantidadPersonas", "Cantidad Personas");

            //fin_toma_pedido
            this.dgvSimulacion.Columns.Add("RNDMenu", "RND Menu");
            this.dgvSimulacion.Columns.Add("Menu", "Menu");
            this.dgvSimulacion.Columns.Add("TiempoPreparacion", "Tiempo Preparacion");
            this.dgvSimulacion.Columns.Add("FinTomaPedido", "Fin Toma Pedido");

            //fin_preparacion_pedido
            this.dgvSimulacion.Columns.Add("FinPreparacionPedido", "Fin Preparacion Pedido");
            for (int j = 1; j < 7; j++)
            {
                this.dgvSimulacion.Columns.Add("FinPreparacion" + j, j.ToString());
            }

            //fin_entrega_pedido
            this.dgvSimulacion.Columns.Add("FinEntregaPedido", "Fin Entrega Pedido");

            //fin_consumicion_pedido
            this.dgvSimulacion.Columns.Add("RNDN1", "RND 1");
            this.dgvSimulacion.Columns.Add("RNDN2", "RND 2");
            this.dgvSimulacion.Columns.Add("N1", "N1");
            this.dgvSimulacion.Columns.Add("N2", "N2");
            for (int j = 1; j < 7; j++)
            {
                this.dgvSimulacion.Columns.Add("FinConsumicion" + j, j.ToString());
            }

            //Mozo
            this.dgvSimulacion.Columns.Add("EstadoMozo", "Estado");
            this.dgvSimulacion.Columns.Add("MesaMozo", "Mesa");
            this.dgvSimulacion.Columns.Add(
                "CantPersonasAtendidas",
                "Cantidad De Personas Atendidas"
            );
            this.dgvSimulacion.Columns.Add("ColaPedidos", "Cola de Pedidos por Entregar");

            //Mesa
            for (int j = 1; j < 7; j++)
            {
                this.dgvSimulacion.Columns.Add("EstadoMesa" + j, "Estado");
                this.dgvSimulacion.Columns.Add("CantidadPersonas" + j, "Cantidad de Personas");
                this.dgvSimulacion.Columns.Add("TiempoMesa" + j, "Tiempo Preparacion");
                this.dgvSimulacion.Columns.Add(
                    "HoraInicioEsperaComida" + j,
                    "Hora de Inicio Espera Comida"
                );
                this.dgvSimulacion.Columns.Add(
                    "HoraInicioEsperaMozo" + j,
                    "Hora de Inicio Espera Mozo"
                );
            }

            // Estadistica
            this.dgvSimulacion.Columns.Add(
                "CantidadClientesNoAtendidos",
                "Cantidad Clientes No Atendidos"
            );

            int i = 1;
            var contador = 0;
            bool overflow = false;
            foreach (Cliente c in simulacion[simulacion.Length - 2].clientes)
            {
                try
                {
                    this.dgvSimulacion.Columns.Add("estado_cliente" + i.ToString(), "Estado");
                    this.dgvSimulacion.Columns.Add("numero_mesa" + i.ToString(), "Numero Mesa");
                    contador++;
                }
                catch (Exception e)
                {
                    overflow = true;
                    this.dgvSimulacion.Columns.Remove("estado_cliente" + i.ToString());
                }
                if (overflow)
                    break;
            }
            i = 0;
            if (!overflow)
            {
                foreach (Pedido p in simulacion[simulacion.Length - 2].pedidos)
                {
                    try
                    {
                        this.dgvSimulacion.Columns.Add("estado_pedido" + i.ToString(), "Estado");
                        this.dgvSimulacion.Columns.Add("id_mesa" + i.ToString(), "Numero Mesa");
                        contador++;
                    }
                    catch (Exception ex)
                    {
                        overflow = true;
                        this.dgvSimulacion.Columns.Remove("estado_pedido" + i.ToString());
                    }
                    if (overflow)
                        break;
                }
            }

            this.dgvSimulacion.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvSimulacion.ColumnHeadersHeight =
                this.dgvSimulacion.ColumnHeadersHeight * 3 + 20;
            this.dgvSimulacion.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.BottomCenter;
            this.dgvSimulacion.CellPainting += new DataGridViewCellPaintingEventHandler(
                dgvSimulacion_CellPainting
            );
            this.dgvSimulacion.Paint += new PaintEventHandler(dgvSimulacion_Paint);
            this.dgvSimulacion.Scroll += new ScrollEventHandler(dgvSimulacion_Scroll);
            this.dgvSimulacion.ColumnWidthChanged += new DataGridViewColumnEventHandler(
                dgvSimulacion_ColumnWidthChanged
            );
            this.dgvSimulacion.AllowUserToAddRows = false;
            this.dgvSimulacion.AllowUserToDeleteRows = false;

            var cantClientesTotal = simulacion[simulacion.Length - 2].clientes.Count();
            foreach (DataGridViewTextBoxColumn d in dgvSimulacion.Columns)
            {
                d.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //int counter = 0;
            //foreach (FilaSimulacion f in simulacion)
            //{
            //    counter++;
            //    this.dgvSimulacion.Rows.Add(f.ListaString(cantClientesTotal, contador));
            //}
            for (int k = 0; k < simulacion.Length - 2; k++)
            {
                this.dgvSimulacion.Rows.Add(simulacion[k].ListaString(cantClientesTotal, contador));
            }
        }

        private void dgvSimulacion_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.dgvSimulacion.DisplayRectangle;
            rtHeader.Height = this.dgvSimulacion.ColumnHeadersHeight / 2;
            this.dgvSimulacion.Invalidate(rtHeader);
            this.dgvSimulacion.AllowUserToOrderColumns = false;
        }

        private void dgvSimulacion_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.dgvSimulacion.DisplayRectangle;
            rtHeader.Height = this.dgvSimulacion.ColumnHeadersHeight / 2;
            this.dgvSimulacion.Invalidate(rtHeader);
            this.dgvSimulacion.AllowUserToOrderColumns = false;
        }

        private void dgvSimulacion_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < this.dgvSimulacion.Columns.Count; i++)
            {
                if (this.dgvSimulacion.Columns[i].Index == 2)
                {
                    CustomizeCell(i, e, "Llegada Clientes", 4);
                }
                if (this.dgvSimulacion.Columns[i].Index == 6)
                {
                    CustomizeCell(i, e, "Fin Toma Pedido", 4);
                }
                if (this.dgvSimulacion.Columns[i].Index == 10)
                {
                    CustomizeCell(i, e, "Fin Preparacion Pedido", 7);
                }
                if (this.dgvSimulacion.Columns[i].Index == 17)
                {
                    CustomizeCell(i, e, "Fin Entrega Pedido", 1);
                }
                if (this.dgvSimulacion.Columns[i].Index == 18)
                {
                    CustomizeCell(i, e, "Fin Consumicion Pedido", 10);
                }
                if (this.dgvSimulacion.Columns[i].Index == 28)
                {
                    CustomizeCell(i, e, "Mozo", 4);
                }
                if (this.dgvSimulacion.Columns[i].Index == 32)
                {
                    CustomizeCell(i, e, "Mesa", 30);
                }

                int c = 0;
                foreach (Cliente cl in simulacion[simulacion.Length - 2].clientes)
                {
                    CustomizeCell(63 + c * 2, e, "Cliente" + (c + 1).ToString(), 2);
                    c++;
                    if (62 + c * 2 > 652)
                        break;
                }
                int constante = 1;
                foreach (Pedido p in simulacion[simulacion.Length - 2].pedidos)
                {
                    if (62 + c * 2 > 652)
                        break;
                    CustomizeCell(63 + c * 2, e, "Pedido" + (constante).ToString(), 2);
                    c++;
                    constante++;
                }
                this.dgvSimulacion.AllowUserToOrderColumns = false;
            }
        }

        private void CustomizeCell(int index, PaintEventArgs e, string header, int cellsOverlapped)
        {
            Rectangle r1 = this.dgvSimulacion.GetCellDisplayRectangle(index, -1, true);

            int[] wk = new int[cellsOverlapped];
            int sum = 0;

            for (int i = 1; i < cellsOverlapped; i++)
            {
                wk[i] = this.dgvSimulacion.GetCellDisplayRectangle(index + i, -1, true).Width;
                sum += wk[i];
            }

            r1.X += 1;
            r1.Y += 1;
            r1.Width = r1.Width + sum - 2;
            r1.Height = r1.Height / 2 - 2;
            e.Graphics.FillRectangle(new SolidBrush(headerColor), r1);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(
                header,
                this.dgvSimulacion.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(this.dgvSimulacion.ColumnHeadersDefaultCellStyle.ForeColor),
                r1,
                format
            );
            this.dgvSimulacion.AllowUserToOrderColumns = false;
        }

        private void dgvSimulacion_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
            this.dgvSimulacion.AllowUserToOrderColumns = false;
        }
    }
}
