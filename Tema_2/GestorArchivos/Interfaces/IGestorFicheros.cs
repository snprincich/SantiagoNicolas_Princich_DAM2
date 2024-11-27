using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorArchivos.Services;

namespace GestorArchivos.Interfaces
{
    public interface IGestorFicheros
    {
        public void Start(string ruta);
        public void Crear(string nombre, string tipo, string ruta);
        public Collection<Fichero> GetFicheros(string ruta);
    }
}
