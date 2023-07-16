using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class Parametros
    {
        //Mozo
        public double TiempoTomaPedido { get; set; }
        public double TiempoEntregaPedido { get; set; }

        // Consumicion Pedido
        public double MediaConsumicionPedido { get; set; }
        public double DesviacionConsumicionPedido { get; set; }

        // Preparacion Pedido
        public double TiempoPreparacionMenu1 { get; set; }
        public double TiempoPreparacionMenu2 { get; set; }

        // Probabilidad Menu
        public double ProbabilidadMenu1 { get; set; }
        public double ProbabilidadMenu2 { get; set; }

        // Llegada Clientes
        public double TiempoLlegadaClientes { get; set; }

        // Simulacion
        public double CantidadIteraciones { get; set; }

        public double Desde { get; set; }

        public Parametros Clone()
        {
            Parametros nuevoParametros = new Parametros();
            // Realiza una copia de las propiedades y campos
            nuevoParametros.TiempoTomaPedido = this.TiempoTomaPedido;
            nuevoParametros.TiempoEntregaPedido = this.TiempoEntregaPedido;
            nuevoParametros.MediaConsumicionPedido = this.MediaConsumicionPedido;
            nuevoParametros.DesviacionConsumicionPedido = this.DesviacionConsumicionPedido;
            nuevoParametros.TiempoPreparacionMenu1 = this.TiempoPreparacionMenu1;
            nuevoParametros.TiempoPreparacionMenu2 = this.TiempoPreparacionMenu2;
            nuevoParametros.ProbabilidadMenu1 = this.ProbabilidadMenu1;
            nuevoParametros.ProbabilidadMenu2 = this.ProbabilidadMenu2;
            nuevoParametros.TiempoLlegadaClientes = this.TiempoLlegadaClientes;
            nuevoParametros.CantidadIteraciones = this.CantidadIteraciones;
            nuevoParametros.Desde = this.Desde;
            // ...
            return nuevoParametros;
        }
    }
}
