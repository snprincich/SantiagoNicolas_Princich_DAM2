using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Implementa una función de diferencia, que devuelva un array que
tenga todos los valores de la lista pasada como primer parámetro
que no están presentes en la lista b manteniendo su orden. Si un
valor está presente en b, todas sus apariciones deben ser eliminadas
de la otra:

arrayDiff([1, 2], [1]) == [2]
arrayDiff([1, 2, 2, 2, 3], [2]) == [1, 3]

*/

namespace Tema_2
{
    internal class Ej8 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Utils utils = Utils.GetInstance();
            int[] a = utils.EntradaSplitNumero();
            int[] b = utils.EntradaSplitNumero();

            //FORMA DE PRINTEAR ARRAYS
            Console.WriteLine(String.Join(", ", arrayDiff(a.ToList(), b.ToList())));
        }

        //PIDE POR PARAMETRO LISTAS Y DEVUELVE UN ARRAY. LO DEJO ASI PORQUE LO PONE EN EL ENUNCIADO
        private int[] arrayDiff(List<int> a, List<int> b)
        {
            //EXCEPT TAMBIEN FUNCIONA CON ARRAYS, NO SOLO CON LISTAS
            return a.Except(b).ToArray();
        }

    }

}
