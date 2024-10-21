using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CambioDivisa
{
    
    internal class CambiarDivisa
    {
        //FALTA CAMBIAR
        private const double DOLAR= 1;
        private const double EURO = 1;
        private const double LIBRA = 1;

        public static void Calcular(TextBox entrada, ComboBox from, ComboBox to)
        {
            double resultado = Divisa(from.Text) * Divisa(to.Text) * int.Parse(entrada.Text);
            LecturaEscritura.Escribir(DateTime.Today.ToString()+ " Importe " + entrada.Text + from.Text +" - " +resultado.ToString() +to.Text);
        }
        private static double Divisa(String divisa)
        {
            switch (divisa)
            {
                case "Euros": return EURO;

                case "Dolares": return DOLAR;

                case "Libras": return LIBRA;

                default: return 0;
            }
        }

    }
}
