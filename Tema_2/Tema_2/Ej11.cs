using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

//El teorema de los cuatro cuadrados de Lagrange, también conocido
//como conjetura de Bachet, afirma que todo número natural puede
//representarse como la suma de cuatro cuadrados enteros.

//Haz una función que devuelva un array con los cuatro números naturales
//que cumplan el teorema dado un número natural pasado como argumento.

namespace Tema_2
{
    internal class Ej11 : IEjecutarEjercicio
    {

        public void Ejecutar()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
                Mostrar(CalcLagrange(i));
            }
            
        }

        static int[] CalcLagrange(int numero)
        {
            
            for (int i = 0; i * i <= numero; i++)
            {

                for (int b = 0; b * b <= numero - i * i; b++)
                {

                    for (int c = 0; c * c <= numero - i * i - b * b; c++)
                    {


                        int numeroFinal = numero - (i * i + b * b + c * c);

                        int d = (int)Math.Sqrt(numeroFinal);

                        if (d * d == numeroFinal)
                        {
                            return [i, b, c, d];
                        }
                    }
                }
            }

            return null;
        }


        private void Mostrar(int[] array)
        {
           

                Console.Write(string.Join("^2 + ", array ));
            Console.Write("^2");
            Console.WriteLine();
        }
    }
}
