using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.VisualBasic;
using Microsoft.Win32;
using PokeRogue.Interface;
using PokeRogue.Models;
using PokeRogue.Services;
using PokeRogue.Utils;
using System.Collections.ObjectModel;
using static PokeRogue.Interface.IFileService;

namespace PokeRogue.ViewModel
{
    public partial class HistoricViewModel : ViewModelBase
    {

        private readonly IGestorAPIService gestorAPIService;
        private readonly IFileService<HistoricPokemonDTO> fileService;


        public HistoricViewModel(IGestorAPIService gestorAPIService, IFileService<HistoricPokemonDTO> fileService)
        {
            this.fileService = fileService;
            this.gestorAPIService = gestorAPIService;
            Pokemons = new ObservableCollection<HistoricPokemonDTO>();
        }

        [ObservableProperty]
        private ObservableCollection<HistoricPokemonDTO> pokemons;

        public override async Task LoadAsync()
        {
            Pokemons.Clear();
            List<HistoricPokemonDTO>? listaPokemon = await HttpJsonClient<List<HistoricPokemonDTO>>.Get(Constantes.MI_POKEAPI_URL);
            foreach (HistoricPokemonDTO pokemon in listaPokemon ?? [])
            {
                Pokemons.Add(pokemon);
            }
        }
    

        [RelayCommand]
        public async void SaveToFile()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Constantes.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                fileService.Save(saveFileDialog.FileName, Pokemons);
            }
        }

    }
}
