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
        public InicioViewModel InicioViewModel { get; }
        public InfoViewModel InfoViewModel { get; }
        public FileViewModel FileViewModel { get; }

        public MainViewModel(InicioViewModel inicioViewModel, FileViewModel fileViewModel, InfoViewModel infoViewModel)
        {
            _selectedViewModel = inicioViewModel;

            InicioViewModel = inicioViewModel;
            FileViewModel = fileViewModel;
            InfoViewModel = infoViewModel;
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
