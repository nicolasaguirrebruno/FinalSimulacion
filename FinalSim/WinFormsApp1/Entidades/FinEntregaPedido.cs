using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class FinEntregaPedido
    {
        public double horaReloj { get; set; }
        public double finEntregaPedido { get; set; }

        public FinEntregaPedido Clone()
        {
            return new FinEntregaPedido
            {
                horaReloj = this.horaReloj,
                finEntregaPedido = this.finEntregaPedido
            };
        }
    }
}
