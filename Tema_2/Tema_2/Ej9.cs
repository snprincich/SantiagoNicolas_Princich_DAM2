using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Haz una función que pueda tomar cualquier número entero no
negativo como argumento y devolverlo con sus dígitos en orden
descendente. Esencialmente, reordenar los dígitos para crear el
mayor número posible.
Entrada: 42145 Salida: 54421
Entrada: 145263 Salida: 654321
Entrada: 123456789 Salida: 987654321
*/

namespace Tema_2
{
    internal class Ej9 :IEjecutarEjercicio
    {

        public void Ejecutar()
        {
            int entrada1 = 42145;
            int entrada2 = 145263;
            int entrada3 = 123456789;
            Console.WriteLine($"El numero {entrada1} al reves es: {ShortDescendente(entrada1)}");
            Console.WriteLine($"El numero {entrada2} al reves es: {ShortDescendente(entrada2)}");
            Console.WriteLine($"El numero {entrada3} al reves es: {ShortDescendente(entrada3)}");
        }


        private int ShortDescendente(int numero)
        {
            int[] array = EntradaToArray(numero);
            Array.Sort(array);
            Array.Reverse(array);
            return ArrayToInt(array);
        }

        private int ArrayToInt(int[] array)
        {
            int numero = 0;
            for (int i = 0; i < array.Length; i++)
            {
                numero *= 10;
                numero += array[i];
            }
            return numero;
        }
        private int[] EntradaToArray(int entrada)
        {
            int[] array;
            String entradaString = entrada.ToString();
            array = new int[entradaString.Length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(entradaString[i].ToString());
            }

            return array;
        }
    }
}
