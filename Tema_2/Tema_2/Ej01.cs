using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Haz una función que calcule y devuelva el número de vocales en la
cadena dada. Consideraremos a, e, i, o, u como vocales. La cadena de
entrada sólo consta de letras minúsculas y/o espacios.
*/

namespace Tema_2
{
    internal class Ej01 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Dame una frase");
            string? texto = Console.ReadLine();
            texto=texto.ToLower();

            Console.WriteLine($"El texto tiene {ContarVocales(texto)} vocales");
        }
        private int ContarVocales(string texto)
        {
            char[] vocales = { 'a', 'e', 'i', 'o', 'u' };

            int contVocales = 0;
            for (int i = 0; i < texto.Length; i++)
            {
                if (vocales.Contains(texto[i])) contVocales++;
            }
            return contVocales;
        }
    }
}
