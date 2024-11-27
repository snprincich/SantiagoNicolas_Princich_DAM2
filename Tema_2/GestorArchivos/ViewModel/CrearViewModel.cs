using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorArchivos.Interfaces;
using GestorArchivos.Services;
using GestorArchivos.Views;
using System.Text.RegularExpressions;
using System.Windows;

namespace GestorArchivos.ViewModel
{
    public partial class CrearViewModel : ViewModelBase
    {
        private IGestorFicheros _gestorFicheros;
        private CrearView? _crearView;
        public CrearViewModel(IGestorFicheros gestorFicheros) 
        {
            this._gestorFicheros = gestorFicheros;
        }

        public CrearView? SelectedView
        {
            get => _crearView;
            set
            {
                SetProperty(ref _crearView, value);
            }
        }

        [ObservableProperty]
        private string _nombre = string.Empty;
        [ObservableProperty]
        private string _ruta = string.Empty;
        [ObservableProperty]
        private string tipo = string.Empty;

        [RelayCommand]
        private void Crear()
        {
            _gestorFicheros.Crear(Nombre,Tipo, Ruta);
            _crearView.Close();
        }

        [RelayCommand]
        private void Cancel()
        {
            _crearView.Close();
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
