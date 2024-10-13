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
        public bool[][] ColumnaCompletados { get; set; }
        public  int[][] Fila { get; }
        public bool[][] FilaCompletados { get; set; }
        public  int[,] Solucion { get; set; }



        public Nonograma() { }
        public Nonograma(int[][] fila, int[][] columna)
        {
            nonograma = this;

            this.Columna = columna;
            this.Fila = fila;
            CargarArraysCompletados();

            Solucion = new int[columna.Length, fila.Length];
        }

        public static Nonograma ConsolaSingleInstance()
        {
            if (nonograma == null) nonograma =  new Nonograma();
            return nonograma;
        }


        public void CargarArraysCompletados()
        {
            ColumnaCompletados = new bool[Columna.Length][];
            for (int i = 0; i < Columna.Length; i++)
            {
                for (int j = 0; j < Columna[i].Length; j++)
                {
                    ColumnaCompletados[i] = new bool[Columna[0].Length];
                }
                
            }

            FilaCompletados = new bool[Fila.Length][];
            for (int i = 0; i < Fila.Length; i++)
            {
                FilaCompletados[i] = new bool[Fila[0].Length];
            }
        }

        public void Mostrar()
        {
            
            for (int i = 0; i < Solucion.GetLength(0); i++)
            {
                for (int j = 0; j < Solucion.GetLength(1); j++)
                {
                    if (Solucion[i,j]== 1)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        //Console.ForegroundColor = ConsoleColor.White;
                        //Console.Write(Solucion[i, j]);
                        Console.Write("  ");

                        Console.ResetColor();
                        
                    }
                    else if (Solucion[i, j] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        //Console.ForegroundColor = ConsoleColor.DarkRed;
                        //Console.Write(Solucion[i, j]);
                        Console.Write("  ");
                        Console.ResetColor();
                        
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        //Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("  ");
                        Console.ResetColor();
                        
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
