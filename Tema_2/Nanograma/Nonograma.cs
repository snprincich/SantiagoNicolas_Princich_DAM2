using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonograma
{
    internal class Nonograma
    {
        static Nonograma nonograma;
        public  int[][] Columna { get; }
        public  int[][] Fila { get; }
        public  int[,] Solucion { get; set; }

        public Nonograma() { }
        public Nonograma(int[][] fila, int[][] columna)
        {
            nonograma = this;
            this.Columna = columna;
            this.Fila = fila;
            Solucion = new int[columna.Length, fila.Length];

            Solucion[4, 0] = 1;
            Solucion[4, 1] = 1;
            Solucion[4, 2] = 1;
            Solucion[4, 3] = 1;
        }

        public static Nonograma ConsolaSingleInstance()
        {
            if (nonograma == null) nonograma =  new Nonograma();
            return nonograma;
        }
        public void Mostrar()
        {
            
            for (int i = 0; i < Solucion.GetLength(0); i++)
            {
                for (int j = 0; j < Solucion.GetLength(1); j++)
                {
                    Console.Write(Solucion[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
