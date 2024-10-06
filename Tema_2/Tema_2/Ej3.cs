/*
Haz una función que como parámetro reciba un array de números y
obtenga el número que menos repeticiones haya tenido. En caso de
empate devuelve el número más pequeño 
*/
using System.Runtime.CompilerServices;

namespace Tema_2
{
    internal class Ej3 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce numeros separados por una coma");
            

            String [] entrada = Console.ReadLine().Split(',');
            int[] numero = new int[entrada.Length];
            for (int i = 0; i < entrada.Length; i++)
            {
                Int32.TryParse(entrada[i], out numero[i]);
            }

            KeyValuePair<int, int>  solucion = calcRepes(cargarDictionary(numero));
            Console.WriteLine($"El numero que menos se repite es {solucion.Key} con {solucion.Value} repeticiones.");
        }
        private Dictionary<int,int> cargarDictionary(int[] numero)
        {
            Dictionary<int,int> mapa = new Dictionary<int,int>();
            foreach (int i in numero)
            {
                if (!mapa.ContainsKey(i)) mapa.Add(i, 1);
                else mapa[i]++;
            }
            return mapa;
        }
        private KeyValuePair<int, int> calcRepes(Dictionary<int,int> mapa)
        {
            KeyValuePair<int, int> solucion;
            HashSet<KeyValuePair<int,int>> prueba;
            prueba = mapa.ToHashSet();

            solucion = prueba.First();
            foreach(KeyValuePair<int,int> i in prueba)
            {
                if (solucion.Value > i.Value) solucion = i;
                else
                {
                    if(solucion.Value == i.Value)
                    {
                        if (solucion.Key > i.Key) solucion = i;
                    }
                }
            }
            return solucion;
        }
    }
}
