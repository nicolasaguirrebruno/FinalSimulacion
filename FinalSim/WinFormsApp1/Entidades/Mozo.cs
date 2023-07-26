using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class Mozo
    {
        public string estado { get; set; }

        public int mesaActual { get; set; }

        public int colaPedidosPorEntregar { get; set; }

        public int cantidadPersonasAtendidas { get; set; }

        public void setLibre()
        {
            this.estado = "Libre";
            this.mesaActual = 0;
            this.cantidadPersonasAtendidas = 0;
        }

        public void setTomandoPedido()
        {
            this.estado = "Tomando Pedido";
            this.cantidadPersonasAtendidas = 0;
        }

        public Mozo Clone()
        {
            return new Mozo
            {
                estado = this.estado,
                mesaActual = this.mesaActual,
                colaPedidosPorEntregar = this.colaPedidosPorEntregar,
                cantidadPersonasAtendidas = this.cantidadPersonasAtendidas,
            };
        }
    }
}
