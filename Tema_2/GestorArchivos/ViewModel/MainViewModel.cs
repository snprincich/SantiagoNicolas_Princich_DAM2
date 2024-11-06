using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace GestorArchivos.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;   
        public InfoViewModel? InfoViewModel { get; }
        public FileViewModel? FileViewModel {get;} 
        public MainViewModel(InfoViewModel infoViewModel, FileViewModel fileViewModel)
        {
            _selectedViewModel = null;
            InfoViewModel = infoViewModel;
            FileViewModel = fileViewModel;
        }


        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }

        /*
        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            _selectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
        */

        public override async Task LoadAsync()
        {
            if (_selectedViewModel != null)
            {
                await _selectedViewModel.LoadAsync();
            }
        }
    }
}
