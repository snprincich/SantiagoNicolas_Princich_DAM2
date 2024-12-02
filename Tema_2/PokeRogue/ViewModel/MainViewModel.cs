using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _selectedViewModel = battleViewModel;
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
            await LoadAsync();
        }

    }
}
