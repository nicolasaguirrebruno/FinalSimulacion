using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class Mesa
    {
        public string estado { get; set; }

        public double tiempoPreparacion { get; set; }

        public double horaInicioEsperaMozo { get; set; }

        public int cantidadPersonas { get; set; }

        public void setTableToFree()
        {
            estado = "Libre";
            tiempoPreparacion = 0;

            horaInicioEsperaMozo = 0;
            cantidadPersonas = 0;
        }

        public void setTableToWaitingFood(double reloj)
        {
            estado = "Esperando Comida";
            tiempoPreparacion = 0;
        }

        public void setTableToRequestingOrder()
        {
            estado = "Tomando Pedido";
            horaInicioEsperaMozo = 0;
        }

        public Mesa Clone()
        {
            return new Mesa
            {
                estado = this.estado,
                tiempoPreparacion = this.tiempoPreparacion,
                horaInicioEsperaMozo = this.horaInicioEsperaMozo,
                cantidadPersonas = this.cantidadPersonas,
            };
        }
    }
}
