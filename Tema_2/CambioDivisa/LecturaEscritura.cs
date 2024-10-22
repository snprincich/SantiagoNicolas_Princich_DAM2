using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CambioDivisa
{
    internal class LecturaEscritura
    {
        public static void Escribir(string texto)
        {
            StreamWriter escribir = new StreamWriter("log_CambioDivisa.txt",true);
            escribir.WriteLine(texto);
            escribir.Close();
        }
        private static string Leer()
        {
            return File.ReadAllText("log_CambioDivisa.txt");
        }
        public static void CargarListBox(ListBox historico)
        {
            //No se carga el contenido del ultimo array ya que esta vacio
            foreach (string ver in Leer().Split("\n")[0..^1])
            {
                historico.Items.Add(ver.Trim());
            }

        }
    }
}
