using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class FinConsumicion
    {
        public double RND1 { get; set; }
        public double RND2 { get; set; }
        public double N1 { get; set; }
        public double N2 { get; set; }

        public double[] finesConsumicion { get; set; }

        public FinConsumicion()
        {
            this.finesConsumicion = new double[6];
        }

        public double nextFin()
        {
            double horaFin = this.finesConsumicion[0];
            for (int i = 1; i < 5; i++)
            {
                if ((finesConsumicion[i] < horaFin && finesConsumicion[i] != 0) || horaFin == 0)
                {
                    horaFin = finesConsumicion[i];
                }
            }
            return horaFin;
        }

        public FinConsumicion Clone()
        {
            FinConsumicion nuevaFinConsumicion = new FinConsumicion();

            nuevaFinConsumicion.RND1 = this.RND1;
            nuevaFinConsumicion.RND2 = this.RND2;
            nuevaFinConsumicion.N1 = this.N1;
            nuevaFinConsumicion.N2 = this.N2;

            // Realiza una copia profunda del arreglo finesConsumicion
            nuevaFinConsumicion.finesConsumicion = new double[this.finesConsumicion.Length];
            Array.Copy(
                this.finesConsumicion,
                nuevaFinConsumicion.finesConsumicion,
                this.finesConsumicion.Length
            );

            return nuevaFinConsumicion;
        }
    }
}
