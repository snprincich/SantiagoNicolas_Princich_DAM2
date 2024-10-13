using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Un triángulo de color se crea a partir de una fila de colores, cada uno de los
cuales es rojo, verde o azul. Las filas sucesivas, cada una con un color
menos que la anterior, se generan considerando los dos colores que se
tocan en la fila anterior.
Si estos colores son idénticos, se utiliza el mismo color en la nueva fila. Si
son diferentes, se utiliza el color que falta en la nueva fila. Así se continúa
hasta que se genera la última fila, con un solo color.
*/

namespace Tema_2
{
    internal class Ej12 : IEjecutarEjercicio
    {

        public void Ejecutar()
        {
            String entrada = "RRGBRGB";
            
            Console.WriteLine($"El ultimo color es : {PintarTriangulo(entrada)}");
        }

        private String PintarTriangulo(String entrada)
        {
            char[] colores = { 'R', 'G', 'B' };
            List<String> lista = new List<String>();
            lista.Add(entrada);

            int longitud = entrada.Length;
            for (int i = 0; i <= longitud-2; i++)
            {
                String nuevaLinea = String.Empty;
                for (int b = 0; b < lista[i].Length-1; b++)
                {

                    


                    // SI SON IGUALES ES EL MISMO, SI SON DIFERENTES ES EL COLOR QUE FALTA
                    if (lista[i][b] == lista[i][b + 1]) nuevaLinea += lista[i][b];
                    else
                    {
                        foreach (char ver in colores)
                        {
                            if (ver != lista[i][b] && ver != lista[i][b + 1])
                                nuevaLinea += ver;
                        }

                    }
                    
                }
                lista.Add(nuevaLinea);

            }

            return lista.Last() ;
        }
    }

}


