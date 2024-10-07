using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_2
{
    internal class Utils
    {
        
        public int EntradaNumero()
        {
            int i;
            string entrada;
            Boolean bucle = false;
            do
            {
                Console.WriteLine("Introduzca un numero");
                entrada = Console.ReadLine();

                if (int.TryParse(entrada, out i))
                {
                    bucle = true;
                }
                else Console.WriteLine("No se ha introducido un numero correcto.");

            } while (bucle == false);

            return i;
        }


        public string[] EntradaSplitString()
        {
            string[] spliteado;
            string entrada;

            Boolean bucle = false;
            do
            {
                Console.WriteLine("Introduzca un texto separado por comas");
                entrada = Console.ReadLine();

                if (!entrada.Contains(','))
                {
                    Console.WriteLine("El texto no contiene comas");
                }

            } while (bucle == false);

            spliteado = entrada.Split(",");
            return spliteado;
        }

        //MIERDA DE METODO
        public int[] EntradaSplitNumero()
        {
            string[] spliteado;
            string entrada;

            Boolean bucle = false;
            do
            {
                Console.WriteLine("Introduzca numeros separado por comas");
                entrada = Console.ReadLine();

                if (entrada.Contains(','))
                {
                    if (ComprobarNumeroArray(entrada.Split(',')))
                    {
                        bucle=true;
                    }
                    else Console.WriteLine("No todos los elementos son numeros");
                }
                else Console.WriteLine("El texto no contiene comas");

            } while (bucle == false);
            spliteado = entrada.Split(",");
            return ParseArray(spliteado);
        }

        //Comprueba que todos los elementos del array son numeros enteros
        public Boolean ComprobarNumeroArray(string[] entrada)
        {
            Boolean b = true;
            foreach (string ver in entrada)
            {
                if (!int.TryParse(ver, out _)) return false;
            }
            return b;
        }

        //Parsea un array
        public int[] ParseArray(string[] entrada)
        {
            int[] numero = new int [entrada.Length];
            for (int i = 0; i<entrada.Length;i++) 
            {
                int.TryParse(entrada[i], out numero[i]);
            }
            return numero;
        }
    }
}
