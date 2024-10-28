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
        private const double DOLAR= 1;
        private const double EURO = 1.05;
        private const double LIBRA = 1.30;
        private const string STRING_EURO = "Euros";
        private const string STRING_DOLARES = "Dolares";
        private const string STRING_LIBRAS = "Libras";

        public static string Cambiar(double entrada, ComboBox from, ComboBox to)
        {            
            double resultado = Divisa(from.Text) / Divisa(to.Text) * entrada;
            return DateTime.Now.ToString() + " Importe " + entrada.ToString("F2") + " " + from.Text + " - " + resultado.ToString("F2") + " " + to.Text;
        }
        private static double Divisa(string divisa)
        {
            switch (divisa)
            {
                case STRING_EURO: return EURO;

                case STRING_DOLARES: return DOLAR;

                case STRING_LIBRAS: return LIBRA;

                default: return 0;
            }
        }

    }
}
