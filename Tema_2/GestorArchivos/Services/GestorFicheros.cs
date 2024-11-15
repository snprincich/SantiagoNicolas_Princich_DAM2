using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorArchivos.Services
{
    public class GestorFicheros
    {
        private const string RUTA = "FILES";

        public GestorFicheros()
        {
            onStart();
            getFicheros(RUTA);
        }

        private void onStart()
        {
            if (!Directory.Exists(RUTA))
            {
                Directory.CreateDirectory(RUTA);
                File.Create(RUTA+"/default1.txt");
                File.Create(RUTA + "/default2.txt");
                Directory.CreateDirectory(RUTA + "/carpeta_default");
            }
        }

        private List<KeyValuePair<string, bool>> getFicheros(string ruta)
        {
            List<KeyValuePair<string, bool>> ficheros = new List<KeyValuePair<string, bool>>();

            

            string[] dir = Directory.GetFileSystemEntries(ruta);
            foreach (string ver in dir) {
                if (FileAttributes.Directory == File.GetAttributes(ver))
                {
                    ficheros.Add(new KeyValuePair<string, bool>(ver, true));
                }
                else
                {
                    ficheros.Add(new KeyValuePair<string, bool>(ver, false));
                }
            }


            return ficheros;
        }
    }
}
