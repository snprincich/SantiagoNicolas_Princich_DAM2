using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace PokeRogue.ViewModel
{
   
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public BattleViewModel? BattleViewModel { get; }

        public TeamViewModel? TeamViewModel { get; }
        public HistoricViewModel? HistoricViewModel { get; }
        public ImportViewModel? ImportViewModel { get; }

        public MainViewModel(BattleViewModel battleViewModel, TeamViewModel teamViewModel, HistoricViewModel historicViewModel, ImportViewModel importViewModel) { 
            SelectViewModel(battleViewModel);
            BattleViewModel = battleViewModel;
            TeamViewModel = teamViewModel;
            HistoricViewModel = historicViewModel;
            ImportViewModel = importViewModel;
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }



        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            pintarHeader();
            await LoadAsync();
        }


        [ObservableProperty]
        FontWeight battleWeight;
        [ObservableProperty]
        FontWeight historicWeight;
        [ObservableProperty]
        FontWeight importWeight;
        [ObservableProperty]
        FontWeight teamWeight;
        private void pintarHeader()
        {
            BattleWeight = FontWeight.FromOpenTypeWeight(1);
            ImportWeight = FontWeight.FromOpenTypeWeight(1);
            HistoricWeight = FontWeight.FromOpenTypeWeight(1);
            TeamWeight = FontWeight.FromOpenTypeWeight(1);
            switch (SelectedViewModel)
            {
                case BattleViewModel _: BattleWeight = FontWeights.Bold; break;
                case ImportViewModel _: ImportWeight = FontWeights.Bold; break;
                case HistoricViewModel _: HistoricWeight = FontWeights.Bold; break;
                case TeamViewModel _: TeamWeight = FontWeights.Bold; break;
            }
        }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
    }


}
