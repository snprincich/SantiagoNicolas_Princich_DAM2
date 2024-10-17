using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

//EN TODO ESTA CLASE UTILIZO 'REPLACE' PARA REMPLAZAR EL STRING, ENTIENDO QUE ESTO PUEDE LLEGAR A CAUSAR PROBLEMAS
//INVESTIGANDO HE VISTO QUE 'REMOVE' E 'INSERT' SON UNA MEJOR OPCION YA QUE TRABAJAN CON INDICES
//FALTA 'PI', DIVIDIR ENTRE 0 Y OTRAS FORMAS DE ROMPER LA CALCULADORA
//FALTA OPERACIONES CON NUMEROS DECIMALES
//SI LA OPERACION ES POR EJEMPLO -20, SE QUEDA EN BUCLE HACIENDO 0-20 = -20
namespace WPF_FirstAPP
{
    internal class Calculadora
    {
        public string Calcular(string text)
        {
            return GestorPrioridades(text);
        }

        private string GestorPrioridades(string text)
        {
            bool bucle = true;
            while (bucle)
            {
                if (text.IndexOf('(') != -1)
                {
                    int index = text.IndexOf('(');
                    //LLAMA A 'CALCULAR' DE FORMA RECURSIVA MANDANDOLE SOLO EL CONTENIDO QUE HAY ENTE PARENTESIS
                    text = text.Replace(text.Substring(index, CalcIndexCerrarParentesis(text, index) - index + 1), GestorPrioridades(text.Substring(index + 1, CalcIndexCerrarParentesis(text, text.IndexOf('(')) - index - 1)));
                }
                else if (text.IndexOfAny(['x', '÷']) != -1) text = GestorOperacion(text, text.IndexOfAny(['x', '÷']));
                else if (text.IndexOfAny(['+', '-']) != -1) text = GestorOperacion(text, text.IndexOfAny(['+', '-']));
                else bucle = false;
            }



            return text;
        }
        private int CalcIndexCerrarParentesis(String text, int index)
        {
            int indexCerrar = 0;
            int cont = 0;
            for (int i = index; i < text.Length; i++)
            {
                if (text[i] == '(') cont++;
                if (text[i] == ')') cont--;
                if (cont == 0)
                {
                    indexCerrar = i;
                    break;
                }
            }
            return indexCerrar;

        }
        private String GestorOperacion(String text, int index)
        {

            long numIzq = 0;
            int indexIzq = 0;
            long numDer = 0;
            int indexDer = 0;

            bool bucle = true;
            bool izq = true;
            bool der = true;


            int cont = 0;
            while (bucle)
            {
                cont++;
                if (izq)
                {
                    //FALTA AGREGAR PI
                    //if (text[index-1]== 'π')
                    // {
                    // numIzq = Math.PI;
                    //}
                    if (index - cont < 0) izq = false;
                    else
                    {
                        if (char.IsNumber(text[index - cont]))
                        {
                            numIzq = long.Parse(text.Substring(index - cont, cont));
                            indexIzq = index - cont;
                        }
                        else izq = false;

                    }
                }

                if (der)
                {
                    if (index + 1 + cont > text.Length) der = false;
                    else
                    {
                        if (char.IsNumber(text[index + cont]))
                        {
                            numDer = long.Parse(text.Substring(index + 1, cont));
                            indexDer = index + cont;
                        }
                        else der = false;

                    }

                }



                if (!izq && !der) bucle = false;
            }

            return text.Replace(text.Substring(indexIzq, indexDer - indexIzq + 1), (Operacion(text[index],numIzq, numDer)).ToString());
        }

        private double Operacion(char operador,long numIzq, long numDer)
        {
            switch (operador)
            {
                case 'x':
                    return numIzq * numDer;
                case '÷':
                    return numIzq / numDer;
                case '+':
                    return numIzq + numDer;
                case '-':
                    return numIzq - numDer;
                default: return 0;
            }
        }
    }
}


