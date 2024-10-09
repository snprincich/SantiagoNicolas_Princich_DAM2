using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_2
{
    internal class Utils
    {
        //Pide numero por consola y lo devuelve parseado, si no lo consigue parsear sigue pidiendo 
        private int EntradaNumero()
        {
            int i;
            string entrada;
            Boolean bucle = false;
            do
            {
                Console.WriteLine("Introduzca un numero");
                entrada = Console.ReadLine();

                if (EsNumero(entrada)) bucle = true;
           
            } while (!bucle);

            return int.Parse(entrada);
        }


        private string[] EntradaSplitString()
        {
            string entrada;

            Boolean bucle = false;
            do
            {
                Console.WriteLine("Introduzca un texto separado por comas");
                entrada = Console.ReadLine();

                if (TieneComa(entrada)) bucle = true;

            } while (!bucle);

            return entrada.Split(",");
        }

        //Pide datos por consola hasta que se introduzca un texto con al menos una coma y numeros. Devuelve un array de enteros.
        private int[] EntradaSplitNumero()
        {
            string[] spliteado;
            string entrada;

            Boolean bucle = false;
            do
            {
                Console.WriteLine("Introduzca numeros separado por comas");
                entrada = Console.ReadLine();

                if (TieneComa(entrada) && ComprobarNumeroArray(entrada.Split(','))) bucle = true;

            } while (!bucle);

            spliteado = entrada.Split(",");
            return ParseArray(spliteado);
        }

        //Comprueba que un texto tiene coma
        private Boolean TieneComa(String texto)
        {
            if (!texto.Contains(','))
            {
                Console.WriteLine("El texto no contiene comas");
                return false;
            }
            return true;
        }

        //Recive String devuelve true:es numero / false: no es numero
        private Boolean EsNumero(string numero)
        {
            if (!int.TryParse(numero, out _))
            {
                Console.WriteLine($"'{numero}' no es un numero");
                return false;
            }

            return true;
        }

        //Comprueba que todos los elementos del array son numeros enteros
        private Boolean ComprobarNumeroArray(string[] entrada)
        {
            foreach (string ver in entrada)
            {
                if (!EsNumero(ver)) return false;
            }
            return true;
        }



        //Parsea un array de string a entero
        private int[] ParseArray(string[] entrada)
        {
            int[] numero = new int[entrada.Length];
            for (int i = 0; i < entrada.Length; i++)
            {
                int.TryParse(entrada[i], out numero[i]);
            }
            return numero;
        }
    }
}
