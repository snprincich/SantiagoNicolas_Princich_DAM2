﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Escribe una función que tome un parámetro positivo num y devuelva
su persistencia multiplicativa, que es el número de veces que debes
multiplicar los dígitos de num hasta llegar a un solo dígito.
Por ejemplo (Entrada --> Salida):
39 --> 3 (porque 3*9 = 27, 2*7 = 14, 1*4 = 4 y el 4 sólo tiene un dígito)
999 --> 4 (porque 9*9*9 = 729, 7*2*9 = 126, 1*2*6 = 12, y finalmente 1*2 =
2)
4 --> 0 (porque el 4 ya es un número de un dígito)
 */

namespace Tema_2
{
    internal class Ej6 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            int numero = Utils.EntradaNumero();
            Console.WriteLine(PersistenciaMultiplicativa(numero));
        }

        private int PersistenciaMultiplicativa(int num)
        {
            int cont=0;
            int[] digito;
            while (num > 9)
            {
                digito=GetDigitos(num);
                num = 1;
                for (int i=0; i<digito.Length; i++)
                {
                    num= num * digito[i];
                }
                cont++;
            }

            return cont;
        }

        private int CuantosDigitos(int num)
        {
            int NumDigitos = 1;

            if (num >= 0)
            {
                while (num > 9)
                {
                    num = num / 10;
                    NumDigitos++;
                }
            }

            else
            {
                while (num < -9)
                {
                    num = num / 10;
                    NumDigitos++;
                }
            }
            return NumDigitos;
        }

        private int[] GetDigitos(int num)
        {
            int[] digitos = new int[CuantosDigitos(num)];

            for (int i = digitos.Length-1; i >=0; i--)
            {
                digitos[i] = num % 10;
                num=num / 10;
            }

            return digitos;
        }
    }
}
