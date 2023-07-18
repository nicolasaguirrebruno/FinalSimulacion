using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Generadores
{
    public class GeneradoresAleatorios
    {
        public static double GenerateUniformAB(double rnd, int a, int b)
        {
            return (Math.Truncate((rnd * (b - a) + a) * 100) / 100);
        }

        public static List<double> GenerateBoxMuller(
            float media,
            float deviation,
            int n,
            double rnd1,
            double rnd2
        )
        {
            List<double> numeros = new List<double>();

            var rand1 = new Random();

            double actualRand1 = 0;
            double actualRand2 = 0;

            // Genero par de randoms
            actualRand1 = Math.Truncate(rnd1 * 100) / 100;
            actualRand2 = Math.Truncate(rnd2 * 100) / 100;

            // Genero las variables aleatorias
            float number1 = (float)(
                Math.Sqrt(-2 * Math.Log(actualRand1))
                    * Math.Cos(2 * Math.PI * actualRand2)
                    * deviation
                + media
            );
            float number2 = (float)(
                Math.Sqrt(-2 * Math.Log(actualRand1))
                    * Math.Sin(2 * Math.PI * actualRand2)
                    * deviation
                + media
            );

            //Los agrego al arreglo
            numeros.Add(number1);
            numeros.Add(number2);

            // Devuelvo los numeros calculados
            return numeros;
        }
    }
}
