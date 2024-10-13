using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nonograma
{
    internal class Resolver
    {
        Nonograma nonograma = Nonograma.ConsolaSingleInstance();

        public int VacioEntreNumero(int[] array)
        {
            List<int> numeros = new List<int>();
            foreach (var item in array)
            {
                if (item != 0) numeros.Add(item);
            }
            return numeros.Count - 1;
        }
        public int Ocupa(int[] array)
        {

            return array.Sum() + VacioEntreNumero(array);

        }

        public Boolean EstaCompletadoColumna(int[] array, int posicion)
        {
            int numero = array.Sum();
            int cont = 0;

            for (int i = 0; i < 5; i++)
            {
                if (nonograma.Solucion[i, posicion] == 1) cont++;
            }
            if (cont == numero) return true;
            return false;
        }
        public Boolean EstaCompletadoFila(int[] array, int posicion)
        {

            int numero = array.Sum();
            int cont = 0;

            for (int i = 0; i < 5; i++)
            {
                if (nonograma.Solucion[posicion, i] == 1) cont++;
            }
            if (cont == numero) return true;
            return false;
        }

        public int EmpiezaEn(int[] array, int posicion)
        {
            int cont = 0;
            for (int i = 0; i < posicion; i++)
            {
                cont += array[i];
                cont++;
            }
            return cont;
        }

        //PINTA LAS CASILLAS QUE SE PUEDEN DEDUCIR DESDE EL INICIO
        public void PrimeraPasada()
        {
            //COLUMNAS
            for (int i = 0; i < nonograma.Columna.Length;i++)
            {
                for(int b = 0; b < nonograma.Columna[i].Length; b++)
                {
                    int borrar = nonograma.Fila.Length - Ocupa(nonograma.Columna[i]);

                    if (borrar < nonograma.Columna[i][b])
                    {
                    int empieza = EmpiezaEn(nonograma.Columna[i],b);
                        empieza += borrar;

                        int pintar = nonograma.Columna[i][b] - borrar;

                        for (int j = 0; j < pintar; j++)
                        {
                            //AHORA SE PINTA COLUMNA[I][B] - BORRAR POSICIONES
                            nonograma.Solucion[empieza+j, i] = 1;
                            
                            Console.WriteLine($"En la columna {i} pista {nonograma.Columna[i][b]} se pinta {empieza+j}-{i}");
                        }
                        
                    }

                }
            }
            //FILAS
            for (int i = 0; i < nonograma.Fila.Length; i++)
            {
                for (int b = 0; b < nonograma.Fila[i].Length; b++)
                {
                    int borrar = nonograma.Columna.Length - Ocupa(nonograma.Fila[i]);

                    if (borrar < nonograma.Fila[i][b])
                    {
                        int empieza = EmpiezaEn(nonograma.Fila[i], b);
                        empieza += borrar;

                        int pintar = nonograma.Fila[i][b] - borrar;

                        for (int j = 0; j < pintar; j++)
                        {
                            //AHORA SE PINTA FILA[I][B] - BORRAR POSICIONES
                            nonograma.Solucion[i,empieza + j] = 1;

                            Console.WriteLine($"En la Fila {i} pista {nonograma.Fila[i][b]} se pinta {i}-{empieza + j}");
                        }



                    }

                }
            }
        }


        public void ComprobarTerminadas()
        {
            //COMPRUEBA SI LA COLUMNA ESTA TERMINADA Y PINTA LOS RESTANTES COMO 2 (IMPOSIBLE)
            for (int i = 0; i < nonograma.Columna.Length; i++)
            {
                if (EstaCompletadoColumna(nonograma.Columna[i], i))
                {
                    for (int b = 0; b < nonograma.Fila.Length; b++)
                    {
                        if (nonograma.Solucion[b, i] == 0) nonograma.Solucion[b, i] = 2;
                    }
                }
            }

            for (int i = 0; i < nonograma.Fila.Length; i++)
            {
                if (EstaCompletadoFila(nonograma.Fila[i], i))
                {
                    for (int b = 0; b < nonograma.Columna.Length; b++)
                    {
                        if (nonograma.Solucion[i, b] == 0) nonograma.Solucion[i, b] = 2;
                    }
                }
            }
        }


        public void Ejecutar()
        {
            PrimeraPasada();

            ComprobarTerminadas();
            /*while (true)
            {


            }*/

        }
    }
}
