using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
/*
Escribe una función que tenga como parámetro un array de números
enteros. Tu trabajo es tomar esa array y encontrar un índice N en el
que la suma de los enteros a la izquierda de N sea igual a la suma de
los enteros a la derecha de N. Si no hay ningún índice que haga que
esto ocurra, devuelve -1. Si se le da un array con múltiples
respuestas, devuelve el menor índice correcto.
 */
namespace Tema_2
{
    internal class Ej7 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            int[] numero1 = { 1, 2, 3, 4, 3, 2, 1 };
            int[] numero2 = { 1, 100, 50, -51, 1, 1 };
            int[] numero3 = { 20, 10, -80, 10, 10, 15, 35 };

            Console.WriteLine($"{encontrarIndice(numero1)}\n");
            Console.WriteLine($"{encontrarIndice(numero2)}\n");
            Console.WriteLine($"{encontrarIndice(numero3)}\n");

            // EN TEORIA DEBERIA FUNCIONAR, PERO EN 4 MINUTOS DE BUCLE NO HA SALIDO
            // HAY QUE CAMBIAR LAS VARIABLES 'LEFT','RIGHT' Y LA ENTRADA DEL METODO A ARRAY DE LONGS 
            /*            
            long[] numero4 = new long [1000];
            
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                numero4[i] = rand.Next(int.MinValue, int.MaxValue);
            }
            rand.Next(int.MinValue,int.MaxValue);
            /*int indice = -1;
            do
            {
                indice = encontrarIndice (numero4);
                if (indice != -1 ) Console.WriteLine($"{indice}");
            } while (indice == -1);
            */
        }

        public int encontrarIndice(int[] numero)
        {
            int[] left = [];
            int[] right = [];

            for (int i = 0; i < numero.Length-1; i++)
            {
                if (i != 0 || i != numero.Length)
                {
                    left = numero[0..i];
                    right = numero[(i + 1)..numero.Length];
                }

                if (left.Sum() == right.Sum())
                {
                    Console.WriteLine($"{left.Sum()} -- {right.Sum()}");
                    return i;
                }

            }

            return -1;
        }

    }
}
