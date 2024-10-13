using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

/*
 Dada un array de enteros, encuentra todo los números que aparecen
un número impar de veces.
 */



namespace Tema_2
{
    internal class Ej04 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Utils utils = Utils.GetInstance();

            int[] numero = utils.EntradaSplitNumero();

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

        private bool EsImpar(int i)
        {
            if (i % 2 == 0) return false;
            return true;
        }

        private void MostrarImpares(HashSet<KeyValuePair<int, int>> impares)
        {
            if (impares.Count == 0) Console.WriteLine("Ningun numero aparece un numero impar de veces");
            else
            {
                Console.WriteLine("Los numeros que aparecen un numero impar de veces son: ");
                foreach (var ver in impares)
                {
                    Console.WriteLine($"El numero {ver.Key} aparece {ver.Value} veces.");
                }
            }
        }

    }
}
