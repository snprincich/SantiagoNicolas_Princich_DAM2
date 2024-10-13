using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Escriba una función que tome un número decimal como entrada, y
devuelva el número de bits que son iguales a uno en la
representación binaria de ese número. Comprueba que la entrada no
sea negativa.
*/
//La representación binaria de 1234 es 10011010010, por lo que la función
//debería devolver 5 en este caso

namespace Tema_2
{
    internal class Ej10 : IEjecutarEjercicio
    {

        public void Ejecutar()
        {
            //EJEMPLO EJERCICIO
            Console.WriteLine("Ejemplos del ejercicio");
            int entradaUno = 1234;
            Console.WriteLine($"El numero {entradaUno} en binario tiene {CantidadBitsUno(entradaUno)} unos\n");

            Utils utils = Utils.GetInstance();
            int numero = utils.EntradaNumero();
            while (numero < 0)
            {
                Console.WriteLine("No se aceptan numeros negativos");
                numero = utils.EntradaNumero();
            }
            Console.WriteLine($"El numero {numero} en binario tiene {CantidadBitsUno(numero)} unos");
        }

        private int CantidadBitsUno(int numero)
        {
            //CONVIERTE EL NUMERO A STRING, OPCIONALMENTE SE LE PUEDE AÑADIR LA BASE NUMERICA
            String numeroBinario = Convert.ToString( numero, 2);
            int cont = 0;

            for (int i = 0; i < numeroBinario.Length; i++)
            {
                if (Char.GetNumericValue(numeroBinario[i]) == 1) cont++;
            }
            return cont;
        }
    }
}
