/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/


/*
 Dada un array de enteros, encuentra todo los números que aparecen
un número impar de veces.
 */

namespace Tema_2
{
    internal class Ej4 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            string texto = "HOLA K ASE";
            List<string> axdd = new List<string>();

            texto.ToList().ForEach(x => axdd.Add(x.ToString()));
         

            Console.WriteLine(string.Join("",axdd));
            
        }

        private Boolean esImpar(int i)
        {
            if (i % 2 == 0) return false;
            return true;
        }
    }
}
