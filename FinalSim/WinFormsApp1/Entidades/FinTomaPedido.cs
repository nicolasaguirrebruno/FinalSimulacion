using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class FinTomaPedido
    {
        public double horaReloj { get; set; }
        public double RNDMenu { get; set; }
        public double menu { get; set; }
        public double tiempoPreparacion { get; set; }
        public double finTomaPedido { get; set; }

        public FinTomaPedido() { }

        public double nextOrder(double reloj, Parametros param)
        {
            return reloj = param.TiempoTomaPedido + reloj;
        }

        public FinTomaPedido Clone()
        {
            FinTomaPedido nuevoFinTomaPedido = new FinTomaPedido();
            // Realiza una copia de las propiedades y campos
            nuevoFinTomaPedido.horaReloj = this.horaReloj;
            nuevoFinTomaPedido.RNDMenu = this.RNDMenu;
            nuevoFinTomaPedido.menu = this.menu;
            nuevoFinTomaPedido.tiempoPreparacion = this.tiempoPreparacion;
            nuevoFinTomaPedido.finTomaPedido = this.finTomaPedido;

            // ...
            return nuevoFinTomaPedido;
        }
    }
}
