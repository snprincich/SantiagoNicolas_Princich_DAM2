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

namespace BasicApp.ViewModel
{
   
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        public HistoricViewModel? HistoricViewModel { get; }

        public MainViewModel(HistoricViewModel historicViewModel) { 
            SelectViewModel(historicViewModel);
            HistoricViewModel = historicViewModel;
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
        FontWeight historicWeight;
        private void pintarHeader()
        {
            HistoricWeight = FontWeight.FromOpenTypeWeight(1);
            switch (SelectedViewModel)
            {
                case HistoricViewModel _: HistoricWeight = FontWeights.Bold; break;
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
