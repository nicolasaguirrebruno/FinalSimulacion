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

        public double horaFinalizacion { get; set; }

        public Pedido(int idMesa, string estado, double horaFinalizacion)
        {
            this.idMesa = idMesa;
            this.estado = estado;
            this.horaFinalizacion = horaFinalizacion;
        }

        public Pedido() { }

        public Pedido Clone()
        {
            return new Pedido(this.idMesa, this.estado, this.horaFinalizacion);
        }
    }
}
