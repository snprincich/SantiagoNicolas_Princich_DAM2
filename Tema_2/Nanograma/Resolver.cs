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

        public int VacioEntreNumero(int [] array )
        {
            List<int> numeros = new List<int> ();
            foreach (var item in array)
            {
                if (item != 0) numeros.Add (item);
            }
            return numeros.Count-1;
        }
        public int Ocupa(int[] array)
        {

            return array.Sum()+VacioEntreNumero(array);

        }

        public Boolean EstaCompletadoColumna(int[] array, int posicion)
        {
            int numero = array.Sum();
            int cont = 0;

            for (int i = 0; i < 5; i++) {
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

        // PISTA - LONGITUD * 2 SI ES MENOR QUE LA LONGITUD SE PUEDEN PONER PROVISIONALES
        // SI EL RESULTADO ES 0 SE PUEDE COMPLETAR
        /* 
         PARA PINTAR HACEMOS LONGITUD - PISTA, EMPEZAMOS A PINTAR DESDE LA IZQUIERDA/ARRIBA Y BORRAMOS EL RESULTADO DE LA OPERACION DESDE DONDE HEMOS EMPEZADO A PINTAR CADA NUMERO
         (SI EL RESULTADO DE LA OPERACION ES MAS GRANDE QUE EL NUMERO, SE BORRA EL NUMERO ENTERO, PERO CUIDADO DE NO BORRAR EL SIGUIENTE NUMERO)
        */
        // SI TENGO UNA CASILLA PINTADA EN EL BORDE  ARRIBA/IZQUIERDA DEL ARRAY o EN UNA IMPOSIBLE  Y LA PRIMERA PISTA ES MAYOR QUE 1 COLOREO EL RESTO, HACER LO MISMO SI ESTA EN EL BORDE DE ABAJO/DERECHA CON EL ULTIMO NUMERO

        //MARCAR NUMEROS COMPLETADOS:
        //SI ESTA EN UN BORDE Y ESTA EL NUMERO COMPLETO PINTADO, ESTA TERMINADO.
        /*SI HAY UN NUMERO PINTADO , SABEMOS QUE NUESTRO NUMERO TIENE QUE ESTAR UNIDO, POR EJEMPLO:
         TENEMOS UNA CASILLA PINTADA, Y TENEMOS UN 5, A PARTIR DE ESA CASILLA, NOS VAMOS 4 HACIA ARRIBA Y HACIA ABAJO Y LAS CASILLAS DE FUERA DE ESE RANGO SON IMPOSIBLES
        */


        //SI ENTRE UN BORDE Y UN IMPOSIBLE HAY UN NUMERO PINTADO Y SOLO HAY UN NUMERO DE PISTA SE HACE LA OPERACION DE LONGITUD-PISTA PARA SACAR LOS PINTADOS
    }   //SI HAY DOS CASILLAS PINTADAS Y SOLO HAY UN NUMERO LOS NUMEROS DEL MEDIO SE PINTAN
        //SI LA PISTA YA ESTA COMPLETADA, TODO LO DEMAS DE IMPOSIBLE
        //SI ENTRE UN IMPOSIBLE Y EL BORDE NO ENTRA EL NUMERO, ESAS CASILLAS SON IMPOSIBLE
        //SI ENTRE DOS CASILLAS PINTADAS, LAS DISTANCIA ES MAYOR QUE EL NUMERO, CADA UNA DE ESAS CASILLAS PERTENECE A OTRO NUMERO
        //SI HAY DOS CASILLAS PINTADAS Y LA DISTANCIA ENTRE LAS DOS NOS PERMITE FORMAR EL PRIMER NUMERO, PERO FORMANDO EL SEGUNDO NOS IMPEDIRIA EL SEGUNDO, SABEMOS QUE ES EL PRIMER NUMERO
        //SI HAY UN NUMERO COMPLETADO Y TENEMOS UNA CASILLA PINTADA INMEDIATAMENTE DESPUES DE LA SEPARACION POR EL IMPOSIBLE, SABEMOS QUE PERTENECE AL SIGUIENTE NUMERO PISTA
        //SI LAS CASILLAS COLOREADAS EQUIVALEN AL MAYOR NUMERO PISTA, ESTA COMPLETADO
}       
