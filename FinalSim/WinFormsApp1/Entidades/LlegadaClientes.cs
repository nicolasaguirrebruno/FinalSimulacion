using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class LlegadaClientes
    {
        public double tiempoEntreLlegadas { get; set; }

        public double proximaLlegada { get; set; }

        public double RNDCantidadPersonas { get; set; }

        public double CantidadPersonas { get; set; }

        public double NextComing(double horaReloj)
        {
            horaReloj = (double)(horaReloj + tiempoEntreLlegadas);

            return horaReloj;
        }

        public LlegadaClientes Clone()
        {
            LlegadaClientes nuevaLlegadaClientes = new LlegadaClientes();
            // Realiza una copia de las propiedades y campos
            nuevaLlegadaClientes.tiempoEntreLlegadas = this.tiempoEntreLlegadas;
            nuevaLlegadaClientes.proximaLlegada = this.proximaLlegada;
            nuevaLlegadaClientes.RNDCantidadPersonas = this.RNDCantidadPersonas;
            nuevaLlegadaClientes.CantidadPersonas = this.CantidadPersonas;
            // ...
            return nuevaLlegadaClientes;
        }
    }
}
