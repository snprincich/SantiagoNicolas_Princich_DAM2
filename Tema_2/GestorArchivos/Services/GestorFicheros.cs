using System.Collections.ObjectModel;
using System.IO;
using GestorArchivos.Interfaces;


namespace GestorArchivos.Services
{
    public class GestorFicheros : IGestorFicheros
    {
        private const string FICHERO = "\\Resources\\fileTxt.png";
        private const string CARPETA = "\\Resources\\folder.png";



        public void Start(string ruta)
        {
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
                File.Create(ruta+"/default1.txt");
                File.Create(ruta + "/default2.txt");
                Directory.CreateDirectory(ruta + "/carpeta_default");
            }
        }

        public void Crear(string nombre, string tipo, string ruta)
        {
            switch (tipo)
            {
                case "Crear Directorio":
                    Directory.CreateDirectory(ruta+"/"+nombre);
                    break;
                case "Crear Fichero":
                    File.Create(ruta+"/"+nombre+".txt");
                    break;
                default:
                    break;
            }
        }
        public  Collection<Fichero> GetFicheros(string ruta)
        {
            Collection<Fichero> ficheros = new Collection<Fichero>();

            string[] dir = Directory.GetFileSystemEntries(ruta);
            foreach (string ver in dir) {
                if (FileAttributes.Directory == File.GetAttributes(ver))
                {
                    ficheros.Add(new Fichero(ver.Split('\\')[1],ver,CARPETA));
                }
                else
                {
                    ficheros.Add(new Fichero(ver.Split('\\')[1], ver, FICHERO));
                }
            }

            return ficheros;
        }
    }
}
