/*
 Dada un array de enteros, encuentra todo los números que aparecen
un número impar de veces.
 */

using System.Numerics;

namespace Tema_2
{
    internal class Ej4 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduzca numeros separados por una coma");
            String[] entrada = Console.ReadLine().Split(',');

            int[] numero = new int[entrada.Length];

            for (int i = 0; i < entrada.Length; i++)
            {
                numero[i] = int.Parse(entrada[i]);
            }

            MostrarImpares(GetImpares(CargarDictionary(numero)));
        }


        private Dictionary<int, int> CargarDictionary(int[] numero)
        {
            Dictionary<int, int> mapa = new Dictionary<int, int>();
            foreach (int i in numero)
            {
                if (!mapa.ContainsKey(i)) mapa.Add(i, 1);
                else mapa[i]++;
            }
            return mapa;
        }

        private HashSet<KeyValuePair<int, int>> GetImpares(Dictionary<int, int> mapa)
        {
            HashSet<KeyValuePair<int, int>> impares = new HashSet<KeyValuePair<int, int>>();

            foreach (KeyValuePair<int, int> ver in mapa)
            {
                if (EsImpar(ver.Value)) impares.Add(ver);
            }

            return impares;
        }

        private Boolean EsImpar(int i)
        {
            if (i % 2 == 0) return false;
            return true;
        }

        private void MostrarImpares(HashSet<KeyValuePair<int, int>> impares)
        {
            if (impares.Count == 0) Console.WriteLine("Ningun numero se repite un numero impar de veces");
            else
            {
                Console.WriteLine("Los numeros que se repiten un numero de veces impares son: ");
                foreach (var ver in impares)
                {
                    Console.WriteLine($"El numero {ver.Key} aparece {ver.Value} veces.");
                }
            }
        }

    }
}
