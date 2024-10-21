using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa
{
    internal class LecturaEscritura
    {
        public static void Escribir(String texto)
        {
            StreamWriter escribir = new StreamWriter("log_CambioDivisa.txt",true);
            escribir.WriteLine(texto);
            escribir.Close();
        }
        public static String Leer()
        {
            
            return  File.ReadAllText("log_CambioDivisa.txt");
        }
    }
}
