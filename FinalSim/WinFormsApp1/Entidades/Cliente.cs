using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class Cliente
    {
        public string estado { get; set; }
        public int numeroMesa { get; set; }

        public Cliente(string est, int numero)
        {
            this.estado = est;
            this.numeroMesa = numero;
        }

        public Cliente(string est)
        {
            this.estado = est;
        }

        public Cliente()
        {
            // Constructor sin argumentos
        }

        public Cliente Clone()
        {
            return new Cliente { estado = this.estado, numeroMesa = this.numeroMesa };
        }
    }
}
