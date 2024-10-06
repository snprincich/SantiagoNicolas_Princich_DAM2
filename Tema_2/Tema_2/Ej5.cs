using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_2
{
    internal class Ej5 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduzca un texto y se eliminaran los elementos repetidos");
            string texto = Console.ReadLine();
            MostrarLista(QuitarRepetidos(texto));
        }

        private List<string> QuitarRepetidos(string texto)
        {
            List<string> textoLimpio = new List<string>();

            foreach (string ver in texto.Split(" "))
            {
                if (!textoLimpio.Contains(ver))
                {
                    textoLimpio.Add(ver);
                }

            }

            return textoLimpio;
        }
        private void MostrarLista(List<string> textoLimpio)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string ver in textoLimpio)
            {
                sb.Append(ver);
                sb.Append(" ");
            }
            sb.Remove(sb.Length-1, 1);

            Console.WriteLine(sb.ToString());
        }
    }
}
