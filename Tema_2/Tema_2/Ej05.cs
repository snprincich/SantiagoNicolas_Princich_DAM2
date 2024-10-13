using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_2
{
    internal class Ej05 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Utils utils = Utils.GetInstance();
            string? [] texto = utils.EntradaSplitString();
            MostrarLista(QuitarRepetidos(texto));

            int[] numeros = utils.EntradaSplitNumero();
            MostrarLista(QuitarRepetidos(numeros));
        }

        private List<string> QuitarRepetidos(string? [] texto)
        {
            List<string> textoLimpio = new List<string>();

            foreach (string ver in texto)
            {
                if (!textoLimpio.Contains(ver))
                {
                    textoLimpio.Add(ver);
                }

            }

            return textoLimpio;
        }

        private List<int> QuitarRepetidos(int [] numeros)
        {
            Utils utils = Utils.GetInstance();

            List<int> numeroSinRepetidos = new List<int>();

            foreach (int ver in numeros)
            {
                if (!numeroSinRepetidos.Contains(ver))
                {
                    numeroSinRepetidos.Add(ver);
                }

            }

            return numeroSinRepetidos;
        }
        private void MostrarLista<T>(List<T> textoLimpio)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var ver in textoLimpio)
            {
                sb.Append(ver);
                sb.Append(" ");
            }
            sb.Remove(sb.Length-1, 1);

            Console.WriteLine(sb.ToString());
        }
    }
}
