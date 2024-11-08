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
        public InicioViewModel? InicioViewModel { get; }

        public MainViewModel(InicioViewModel inicioViewModel, InfoViewModel infoViewModel, FileViewModel fileViewModel)
        {
            _selectedViewModel = inicioViewModel;
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

        

        

        public override async Task LoadAsync()
        {
            if (SelectedViewModel != null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
    }
}
