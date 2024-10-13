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
using System.Runtime.CompilerServices;

namespace Tema_2
{
    internal class Ej03 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Utils utils = Utils.GetInstance();


            int[] numero = utils.EntradaSplitNumero();

            KeyValuePair<int, int>  solucion = CalcRepes(CargarDictionary(numero));
            Console.WriteLine($"El numero que menos se repite es {solucion.Key} con {solucion.Value} aparicion/es.");
        }
        private Dictionary<int,int> CargarDictionary(int[] numero)
        {
            Dictionary<int,int> mapa = new Dictionary<int,int>();
            foreach (int i in numero)
            {
                if (!mapa.ContainsKey(i)) mapa.Add(i, 1);
                else mapa[i]++;
            }
            return mapa;
        }
        private KeyValuePair<int, int> CalcRepes(Dictionary<int,int> mapa)
        {
            KeyValuePair<int, int> solucion;

            HashSet<KeyValuePair<int,int>> hashSetMapa;
            hashSetMapa = mapa.ToHashSet();

            solucion = hashSetMapa.First();
            foreach(KeyValuePair<int,int> i in hashSetMapa)
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
