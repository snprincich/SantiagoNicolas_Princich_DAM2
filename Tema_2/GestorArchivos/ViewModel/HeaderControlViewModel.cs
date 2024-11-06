using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace GestorArchivos.ViewModel
{
    public partial class HeaderControlViewModel : ViewModelBase
    {

        public HeaderControlViewModel() { }
        public override Task LoadAsync()
        {
            return base.LoadAsync();
        }


        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            
            MainViewModel mainViewModel = App.Current.Services.GetService<MainViewModel>();
            mainViewModel.SelectedViewModel = mainViewModel.InfoViewModel;
            await LoadAsync();
        }
    }

}
