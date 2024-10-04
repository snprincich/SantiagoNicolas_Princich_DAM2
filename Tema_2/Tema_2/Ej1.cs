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
    internal class Ej1 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Dame una frase");
            string texto = Console.ReadLine();
            string[] vocales = { "a", "e", "i", "o", "u" };
            texto=texto.ToLower();

            int contVocales = 0;
            for (int i = 0; i<texto.Length;i++)
            {
                for (int b = 0;b<vocales.Length;b++)
                {


                    if (vocales[b].Equals(texto.Substring(i, 1)))
                    {
                        contVocales++;
                    }
                }
            }
            Console.WriteLine($"El texto tiene {contVocales} vocales");
        }
    }
}
