using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using BasicApp.Utils;
using System.Collections.ObjectModel;
using BasicApp.Models;
using System.Windows;
using BasicApp.Interface;

namespace BasicApp.ViewModel
{
    public partial class ImportViewModel : ViewModelBase
    {
        private readonly IFileService<HistoricPokemonDTO> _fileService;

        [ObservableProperty]
        public Visibility _checkVisibility;

        [ObservableProperty]
        public Visibility _errorVisibility;


        [ObservableProperty]
        private ObservableCollection<HistoricPokemonDTO> pokemons;
        public ImportViewModel(IFileService<HistoricPokemonDTO> fileService)
        {
            _fileService = fileService;
            CheckVisibility = Visibility.Hidden;
            ErrorVisibility = Visibility.Hidden;
        }


        [RelayCommand]
        public async Task LoadFromFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = Constantes.JSON_FILTER
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var datos = _fileService.Load(openFileDialog.FileName);
                bool respuesta = await HttpJsonClient<HistoricPokemonDTO>.DeleteAll(Constantes.MI_POKEAPI_URL + "deleteAll");
                CambiarVisibility(respuesta);

                foreach (var pokemon in datos)
                {
                    HttpJsonClient<HistoricPokemonDTO>.Post(Constantes.MI_POKEAPI_URL, pokemon);
                }

            }
        }

        private void CambiarVisibility(bool respuesta)
        {
            if (respuesta)
            {
                CheckVisibility = Visibility.Visible;
                ErrorVisibility = Visibility.Hidden;
            }
            else
            {
                CheckVisibility = Visibility.Hidden;
                ErrorVisibility = Visibility.Visible;
            }
        }
    }
}

