using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorArchivos.Services;

namespace GestorArchivos.ViewModel
{
    public class FileViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedHeader;
        private GestorFicheros gestorCarpetas;
        public HeaderControlViewModel HeaderControl { get; }
        public FileViewModel(HeaderControlViewModel headerControlViewModel, GestorFicheros gestorCarpetas) { 
            _selectedHeader = headerControlViewModel;
            HeaderControl = headerControlViewModel;
            gestorCarpetas = gestorCarpetas;
        }


        public ViewModelBase? SelectedHeader
        {
            get => _selectedHeader;
            set
            {
                SetProperty(ref _selectedHeader, value);
            }
        }

        public override Task LoadAsync()
        {
            return base.LoadAsync();
        }
    }
}
