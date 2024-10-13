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
    internal class Ej09 :IEjecutarEjercicio
    {

        public void Ejecutar()
        {
            //EJEMPLOS DEL EJERCICIO
            Console.WriteLine("Ejemplos del ejercicio");
            int entradaUno = 42145;
            int entradaDos = 145263;
            int entradaTres = 123456789;
            Console.WriteLine($"El numero {entradaUno} al reves es: {ShortDescendente(entradaUno)}");
            Console.WriteLine($"El numero {entradaDos} al reves es: {ShortDescendente(entradaDos)}");
            Console.WriteLine($"El numero {entradaTres} al reves es: {ShortDescendente(entradaTres)}\n");


            Utils utils = Utils.GetInstance();
            int numero = utils.EntradaNumero();
            while (numero < 0)
            {
                Console.WriteLine("No se aceptan numeros negativos");
                numero = utils.EntradaNumero();
            }
            Console.WriteLine($"El numero {numero} al reves es: {ShortDescendente(numero)}");
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
