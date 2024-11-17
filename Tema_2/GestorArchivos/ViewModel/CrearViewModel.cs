using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorArchivos.Services;
using GestorArchivos.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace GestorArchivos.ViewModel
{
    public partial class CrearViewModel : ViewModelBase
    {
        private GestorFicheros _gestorFicheros;
        public CrearViewModel(GestorFicheros gestorFicheros) 
        {
            this._gestorFicheros = gestorFicheros;
        }

        [ObservableProperty]
        private string _nombre = string.Empty;


        [RelayCommand]
        private void Crear(Window vista)
        {
            CrearView crearView = (CrearView)vista;
            string? ruta = crearView.Ruta.Content.ToString();
            string? tipo = ((CrearView)vista).TituloLabel.Content.ToString();
            _gestorFicheros.Crear(Nombre,tipo, ruta);
            vista.Close();
        }

        [RelayCommand]
        private void Cancel(Window vista)
        {
            vista.Close(); 
        }

        [ObservableProperty]
        private bool _puedeCrear;
        partial void OnNombreChanged(string value)
        {
            if (!Regex.IsMatch(value ?? string.Empty, @"^[a-zA-Z]*$"))
            {
                Nombre = new string(value?.Where(char.IsLetter).ToArray() ?? Array.Empty<char>());
            }
            PuedeCrear = !string.IsNullOrEmpty(Nombre);
        }

        public override Task LoadAsync()
        {

            return base.LoadAsync();
        }
    }
}
