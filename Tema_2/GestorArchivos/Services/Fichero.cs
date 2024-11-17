﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorArchivos.Services
{
    public class Fichero
    {
        public string? Name {  get; set; }
        public string? Ruta {  get; set; }
        public string? Imagen { get; set; }

        public Fichero(string name, string ruta, string imagen) { 
            this.Name = name;
            this.Ruta = ruta;
            this.Imagen = imagen;
        }



    }
}
