using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Haz una función que como parámetro reciba un array de números y
obtenga el número que menos repeticiones haya tenido. En caso de
empate devuelve el número más pequeño 
*/
namespace Tema_2
{
    internal class Ej3 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce numeros separados por una coma");
            int[] numero = [];


            Console.ReadLine().Split().Select( c => 
            {
                int cont = 0;
                int.TryParse(c, out numero[cont]);
                cont++;
                return 0;
            });
            Console.WriteLine(numero.ToString());
        }
    }
}
