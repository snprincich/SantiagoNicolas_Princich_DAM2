using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Nonograma
{
    internal class Resolver
    {
        Nonograma nonograma = Nonograma.ConsolaSingleInstance();

        private int VacioEntreNumero(int[] array)
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

            for (int i = 0; i < nonograma.Fila.Length; i++)
            {
                if (nonograma.Solucion[i, posicion] == 1) cont++;
            }
            if (cont == numero)
            {
                for (int i = 0; i < nonograma.ColumnaCompletados[posicion].Length; i++)
                {
                    nonograma.ColumnaCompletados[posicion][i] = true;
                }
                return true;
            }
            return false;
        }
        public Boolean EstaCompletadoFila(int[] array, int posicion)
        {

            int numero = array.Sum();
            int cont = 0;

            for (int i = 0; i < nonograma.Columna.Length; i++)
            {
                if (nonograma.Solucion[posicion, i] == 1) cont++;
            }
            if (cont == numero)
            {
                for (int i = 0; i < nonograma.FilaCompletados[posicion].Length; i++)
                {
                    nonograma.FilaCompletados[posicion][i] = true;

                }

                return true;
            }
            return false;
        }

        //INDICA EN CUAL POSICION SE EMPIEZA A PINTAR UN NUMERO
        //RECIBE UN ARRAY CON LAS PISTAS Y LA POSICION DE LA PISTA QUE QUEREMOS SABER
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
        public void DeducirPrimerosPosibles()
        {
            //COLUMNAS
            for (int i = 0; i < nonograma.Columna.Length; i++)
            {
                for (int b = 0; b < nonograma.Columna[i].Length; b++)
                {
                    int borrar = nonograma.Fila.Length - Ocupa(nonograma.Columna[i]);

                    if (borrar < nonograma.Columna[i][b])
                    {
                        int empieza = EmpiezaEn(nonograma.Columna[i], b);
                        empieza += borrar;

                        int pintar = nonograma.Columna[i][b] - borrar;

                        for (int j = 0; j < pintar; j++)
                        {
                            //AHORA SE PINTA COLUMNA[I][B] - BORRAR POSICIONES
                            nonograma.Solucion[empieza + j, i] = 1;

                            Console.WriteLine($"En la columna {i} pista {nonograma.Columna[i][b]} se pinta {empieza + j}-{i}");
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
                            nonograma.Solucion[i, empieza + j] = 1;

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

        

        //COMPRUEBA SI HAY CASILLAS SUFICIENTES PARA QUE ENTREN LAS PISTAS QUE ENTRAN POR PARAMETRO
        //QUIZAS DA EXCEPCION POR SALIRSE DEL ARRAY
        public bool HayHueco(int[] array, int ocupa, int[] pistas)
        {
            int cont = 0;
            int pistaIndice = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 2)
                {

                    cont++;
                    for (int b = 1; b < pistas[pistaIndice]; b++)
                    {
                        if (array[i+b]!=2) cont++;
                        else
                        {
                            i = i + b + 1;
                            cont = 0;
                        }
                    }
                    if (cont == pistas[pistaIndice])
                    {
                        i = pistas[pistaIndice] + 1;
                        pistaIndice++;
                        cont = 0;
                    }

                }
            }

            if (pistaIndice == pistas.Length) return true;

            return false;
        }

        
        

        public int[] CrearArrayUnidimensionalFila(int posicion)
        {
            int[] array = new int[nonograma.Columna.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = nonograma.Solucion[posicion,i];
            }
            return array;
        }

        public List<int[]> PosiblesPosicionesColumna(int[] array, int posicion)
        {
            List<int[]> posiciones = new List<int[]>();
            int inicio;
            int final;

            for (int i = 0; i < array.Length; i++)
            {
                inicio = EmpiezaEn(array, i);
                final = inicio + (nonograma.Fila.Length - Ocupa(array));
                posiciones.Add([inicio, final]);
            }

            return posiciones;
        }
        //ABANDONADA POR AHORA
        //SIN TERMINAR
        //LA IDEA ES HACER LO MISMO QUE CON LA PRIMERA DEDUCCION PERO EN VEZ DE USAR LA LONGITUD DEL ARRAY USAR LA LONGITUD ENTRE 2 CASILLAS IMPOSIBLES
        public void SegundaPasada()
        {
            for (int i = 0; i < nonograma.Fila.Length; i++)
            {
                List<int> imposibles = VerImposibles(i);


                for (int j = 1; j < imposibles.Count; j++)
                {
                    //LA DIFERENCIA ENTRE DOS NUMEROS ES LA RESTA DE AMBOS PASADA A VALOR ABSOLUTO
                    int hueco = Math.Abs((imposibles[j] - 1) - imposibles[j]);

                    for (int k = 1; k < nonograma.Fila.Length; k++)
                    {
                        if (hueco >= nonograma.Fila[i][k])
                        {

                        }
                    }
                }
            }
        }

        //DEVUELVE LAS POSICIONES DE LAS CASILLAS IMPOSIBLES
        public List<int> VerImposibles(int fila)
        {
            List<int> posiciones = new List<int>();
            posiciones.Add(-1);


            for (int i = 0; i < nonograma.Fila.Length; i++)
            {

                if (nonograma.Solucion[fila, i] == 2) posiciones.Add(i);
            }
            posiciones.Add(nonograma.Fila.Length);

            return posiciones;
        }

        public void Ejecutar()
        {
            DeducirPrimerosPosibles();
            ComprobarTerminadas();
        }

        public void AreaPruebas()
        {
            //PROBANDO ComprobarTerminadaIndividual()
            int[] pistas = {4,2};
            bool[] pistasCompletadas = [false, false];
            int[] mapa = {0,1,1,1,1,1,1,1,0,0};

            Console.WriteLine(ComprobarCasillasAlrededor(mapa, pistas[0], 1));

            //MostrarPruebas(mapa);
        }

        //SIN TERMINAR
        //EN PROCESO
        //COMPRUEBA SI UNA PISTA ESTA TERMINADA
        //PARAMETROS ARRAY DE PISTAS (FILA) Y POSICION DE LA FILA
        public void ComprobarTerminadaIndividual(int[] mapa, int[] pistas, bool[] pistasCompletadas)
        {
            List<int[]> posiciones = PosiblesPosiciones(pistas,mapa);
            //RECORRE LAS PISTAS
            for (int i = 0; i < mapa.Length; i++)
            {
                //RECORRE LAS CASILLAS
                for (int b = 0; b < mapa.Length; b++)
                {
                    //SI ENCONTRAMOS UNA CASILLA PINTADA 
                    if (mapa[b] == 1)
                    {
                        //SE COMPRUEBA QUE ESTE DENTRO DE LA POSICION MINIMA Y MAXIMA DE LA PISTA
                        if (posiciones[i].Min() <= b && posiciones[i].Max() >= b)
                        {
                            //COMPRUEBA QUE A PARTIR DEL INDICE B HAYA CASILLAS PINTADAS EQUIVALENTE A LA PISTA
                            if (ComprobarCasillasAlrededor(mapa, pistas[i], b))
                            {
                                //SE CREA UN ARRAY CON LAS PISTAS POSTERIORES A LA ACTUAL
                                int[] arrayCortado = new int[pistas.Length - i];
                                Array.Copy(pistas, i + 1, arrayCortado, 0, ((pistas.Length - i) - 1));

                                //CUANTO ESPACIO NECESITAMOS PARA LAS PISTAS
                                //+ 1 (ESPACIO PROHIBIDO ENTRE PISTA Y PISTA)
                                int ocupa = Ocupa(arrayCortado) + 1;

                                //HAY HUECO SOLO COMPRUEBA HACIA LA DERECHA
                                if (HayHueco(mapa, ocupa, arrayCortado))
                                {
                                    pistasCompletadas[i] = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        //FUNCIONA
        //DE CADA PISTA TE DICE LA POSICION MINIMA Y MAXIMA EN LA QUE PUEDE ESTAR
        //DEVUELVE UNA LISTA DE ARRAYS CON LA POSICION MINIMA Y MAXIMA CORRESPONDIENTE
        public List<int[]> PosiblesPosiciones(int[] pista, int[] mapa)
        {
            List<int[]> posiciones = new List<int[]>();
            int inicio;
            int final;

            for (int i = 0; i < pista.Length; i++)
            {

                    //LO QUE OCUPAN LAS PISTAS ANTERIORES +1 (CASILLA IMPOSIBLE)
                    inicio = Ocupa(pista[0..i])+1;


                    //(INICIO + PISTA) + (DESPLAZAMIENTO) -1 = POSICION MAXIMA
                    final = inicio + pista[i] + (mapa.Length - Ocupa(pista)-1);
                    Console.WriteLine(final);
                
                
                
                posiciones.Add([inicio, final]);
            }

            return posiciones;
        }

        //FUNCIONA
        //COMPRUEBA SI HAY CASILLAS PINTADAS EQUIVALENTES A LA PISTA A LA DERECHA y IZQUIERDA DEL INDICE
        //SI DETECTA UNA CASILLA QUE NO ESTE PINTADA PARA DE CONTAR EN ESA DIRECCION
        //MAPA EN EL QUE BUSCAR
        //PISTA A BUSCAR
        //INDICE DE LA CASILLA EN LA CUAL BUSCAS ALREDEDOR
        public bool ComprobarCasillasAlrededor(int [] mapa, int pista, int indice)
        {
            //HA ENCONTRADO LA PISTA COMPLETA A PARTIR DE ESE INDICE?
            bool encontrado = false;

            //PARA DE BUSCAR EN ESTA DIRECCION SI ENCUENTRA UNA CASILLA QUE NO ESTA PINTADA
            bool buscIzq = true;
            bool buscDer = true;

            //CUANTOS PINTADOS ENCUENTRA INMEDIATAMENTE ANTES Y DESPUES DEL INDICE
            int contIzq = 0;
            int contDer = 0;

            //SEGUN QUE TAN GRANDE SEA LA PISTA SE MUEVE MAS O MENOS CASILLAS
            for (int b = 1; b < pista; b++)
            {
                //INDICE-(PISTA-1) EVITA SALIRSE DEL RANGO DEL ARRAY y B POSICIONES HACIA ATRAS HAY UN 1
                if ((indice - b > -1) && (mapa[indice - b] == 1) && buscIzq)
                {
                    contIzq++;
                }
                else buscIzq=false;
                //SI LA PISTA ENTRA ENTRE EL INDICE Y PISTA+1 POSICIONES A LA DERECHA (EVITAR SALIRSE DEL RANGO DEL ARRAY) y B POSICIONES HACIA ADELANTE HAY UN 1
                if ((indice + b < mapa.Length) && (mapa[indice + b] == 1) && buscDer)
                {
                    contDer++;
                }
                else buscDer=false;
            }

            /*
             * SI HA ENCONTRADO A LA IZQUIERDA y A LA DERECHA SUFICIENTE PINTADOS PARA FORMAR LA PISTA y
             * EL LA SIGUIENTE CASILLA TANTO A LA IZQUIERDA COMO A LA DERECHA NO ESTA PINTADA O SE SALE DEL MAPA, ES VERDADERO
            */
            //SI HAY MAS, LAS CASILLAS NO LE PERTENECEN A LA PISTA
            //SI HAY MENOS PUEDE SER QUE LE PERTENEZCAN
            int indiceIzq = indice - contIzq - 1;
            int indiceDer = indice + contDer + 1;
            if (contIzq+contDer+1 == pista && (indiceIzq < 0 || mapa[indice - contIzq - 1] != 1) && (indiceDer > mapa.Length + 1 || mapa[indice + contDer + 1] != 1))
            {
                encontrado = true;
            }


            
            
            return encontrado;
        }
        public void MostrarPruebas(int[] mapa)
        {

            for (int j = 0; j < mapa.Length; j++)
            {
                
                if (mapa[j] == 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("  ");
                    Console.ResetColor();

                }
                else if (mapa[j] == 2)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write("  ");
                    Console.ResetColor();

                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("  ");
                    Console.ResetColor();

                }
                

            }

        }
    }
}
