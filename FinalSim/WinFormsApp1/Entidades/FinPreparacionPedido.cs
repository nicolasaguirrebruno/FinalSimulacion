using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class FinPreparacionPedido
    {
        public double finPreparacionPedido { get; set; }
        public double[] finesPreparacion { get; set; }

        public FinPreparacionPedido()
        {
            this.finesPreparacion = new double[6];
        }

        public double nextFin()
        {
            double horaFin = (double)this.finesPreparacion[0];
            for (int i = 1; i < 5; i++)
            {
                if ((finesPreparacion[i] < horaFin && finesPreparacion[i] != 0) || horaFin == 0)
                {
                    horaFin = (double)finesPreparacion[i];
                }
            }
            return horaFin;
        }

        public FinPreparacionPedido Clone()
        {
            FinPreparacionPedido nuevaFinPreparacion = new FinPreparacionPedido();
            nuevaFinPreparacion.finPreparacionPedido = this.finPreparacionPedido;

            // Realiza una copia profunda del arreglo finesPreparacion
            nuevaFinPreparacion.finesPreparacion = new double[this.finesPreparacion.Length];
            Array.Copy(
                this.finesPreparacion,
                nuevaFinPreparacion.finesPreparacion,
                this.finesPreparacion.Length
            );

            return nuevaFinPreparacion;
        }
    }
}
