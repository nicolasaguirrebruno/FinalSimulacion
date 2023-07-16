using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class Pedido
    {
        public int idMesa { get; set; }

        public string estado { get; set; }

        public Pedido(int idMesa, string estado)
        {
            this.idMesa = idMesa;
            this.estado = estado;
        }

        public Pedido() { }

        public Pedido Clone()
        {
            return new Pedido(this.idMesa, this.estado);
        }
    }
}
