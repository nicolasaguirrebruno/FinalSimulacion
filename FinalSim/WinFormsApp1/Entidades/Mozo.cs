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

        public int numeroMesa { get; set; }

        public int colaPedidosPorEntregar { get; set; }

        public int cantidadPersonasAtendidas { get; set; }

        public void setLibre()
        {
            this.estado = "Libre";
            this.numeroMesa = 0;
            this.cantidadPersonasAtendidas = 0;
        }

        public void setTomandoPedido()
        {
            this.estado = "Tomando pedido";
            this.cantidadPersonasAtendidas = 0;
        }

        public Mozo Clone()
        {
            return new Mozo
            {
                estado = this.estado,
                numeroMesa = this.numeroMesa,
                colaPedidosPorEntregar = this.colaPedidosPorEntregar,
                cantidadPersonasAtendidas = this.cantidadPersonasAtendidas
            };
        }
    }
}
