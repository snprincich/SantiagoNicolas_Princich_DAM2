using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WPF_FirstAPP
{
    internal class Calculadora
    {
        public String Calcular(String text)
        {
            int numero1 = 0;
            int numero2 = 0;
            double resultado = 0;

            if (text.IndexOfAny(['x', '÷']) != -1)
            {
                numero1 = numeroIzq(text, text.IndexOfAny(['x', '÷']));
                numero2 = numeroDer(text, text.IndexOfAny(['x', '÷']));

            }


            return resultado.ToString();
        }

        private int numeroIzq(String text, int indice)
        {
            int num = 0;



            return num;
        }
        private int numeroDer(String text, int indice)
        {
            int num = 0;



            return num;
        }
    }

}
