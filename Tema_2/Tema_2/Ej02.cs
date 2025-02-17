﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Los cajeros automáticos permiten códigos PIN de 4 o 6 dígitos y los
códigos PIN no pueden contener más que exactamente 4 dígitos o
exactamente 6 dígitos. Si a la función se le pasa una cadena de PIN
válida, devuelve true, de lo contrario devuelve false.
 */
namespace Tema_2
{
    internal class Ej02 :IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Escribe un numero PIN de 4 o 6 digitos");
            string? pin = Console.ReadLine();

            Console.WriteLine(CheckPin(pin)? "PIN VALIDO":"PIN NO VALIDO");
        }
        private bool CheckPin(string pin)
        {
            if (pin.Length == 4 || pin.Length == 6) return true;
            return false;
        }
    }
}
