﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using GestorArchivos.Services;
using GestorArchivos.Views;
using GestorArchivos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GestorArchivos.ViewModel
{
    public partial class FileViewModel : ViewModelBase
    {
        public const string RUTA = "FILES";

        private ViewModelBase? _selectedHeader;
        public HeaderControlViewModel HeaderControl { get; }

        private IGestorFicheros _gestorFicheros;
        public ObservableCollection<Fichero> Ficheros { get; set; }
        public FileViewModel(HeaderControlViewModel headerControlViewModel, IGestorFicheros gestorFicheros) { 
            _selectedHeader = headerControlViewModel;
            HeaderControl = headerControlViewModel;

            this._gestorFicheros = gestorFicheros;
            gestorFicheros.Start(RUTA);
            CargarFicheros(RUTA);
        }



        public ViewModelBase? SelectedHeader
        {
            get => _selectedHeader;
            set
            {
                SetProperty(ref _selectedHeader, value);
            }
        }


        [RelayCommand]
        private void CrearDirectorio(string tipo)
        {
            ViewCrear(tipo);
        }

        [RelayCommand]
        private void CrearFichero(string tipo)
        {
            ViewCrear(tipo);
        }

        private void ViewCrear(string tipo)
        {
            var view = App.Current.Services.GetService<CrearView>();
            var viewModel = App.Current.Services.GetService<CrearViewModel>();
            viewModel.SelectedView = view;
            viewModel.Tipo = tipo;
            viewModel.Ruta = RUTA;
            view.DataContext = viewModel;
            view.Show();
            view.Closed += View_Closed;
        }

        private void View_Closed(object sender, EventArgs e)
        {
            CargarFicheros(RUTA);
        }

        public void CargarFicheros(string ruta)
        {
            var fich = _gestorFicheros.GetFicheros(ruta);
            if (Ficheros != null) Ficheros.Clear();
            else Ficheros = new ObservableCollection<Fichero>();
            foreach (var ver in fich)
            {
                Ficheros.Add(ver);
            }
        }

        public override Task LoadAsync()
        {
            return base.LoadAsync();
        }
    }
}
