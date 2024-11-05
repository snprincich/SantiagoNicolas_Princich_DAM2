using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorArchivos.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase? _selectedViewModel;
        private InfoViewModel? InfoViewModel { get; }
        public MainViewModel(InfoViewModel infoViewModel)
        {
            _selectedViewModel = infoViewModel;
            InfoViewModel = infoViewModel;
        }

        public override async Task LoadAsync()
        {
            if (_selectedViewModel != null)
            {
                await _selectedViewModel.LoadAsync();
            }
        }
    }
}
