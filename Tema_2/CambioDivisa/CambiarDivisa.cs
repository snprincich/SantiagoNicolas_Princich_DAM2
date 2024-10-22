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

        public static string Cambiar(TextBox entrada, ComboBox from, ComboBox to)
        {
            //DEFAULT 0
            int valor;
            int.TryParse(entrada.Text, out valor);

            double resultado = Divisa(from.Text) / Divisa(to.Text) * valor;
            return DateTime.Now.ToString() + " Importe " + valor + " " + from.Text + " - " + resultado.ToString("F2") + " " + to.Text;

        }
        private static double Divisa(string divisa)
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
