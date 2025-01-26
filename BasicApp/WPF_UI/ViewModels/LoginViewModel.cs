

using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;
using System.Xml.Linq;
using WPF_UI.Constants;
using WPF_UI.DTO;
using WPF_UI.Interface;

namespace Wpf.Ui.Demo.Mvvm.ViewModels
{

    public partial class LoginViewModel : ViewModel
    {
        [ObservableProperty]
        private string? name;
        [ObservableProperty]
        private string? password;


        private INavigationService _navigationService;
        private readonly IHttpJsonProvider<UserDTO> _httpJsonService;
        public LoginViewModel(IHttpJsonProvider<UserDTO> httpJsonProvider, INavigationService navigationService)
        {
            _httpJsonService = httpJsonProvider;
            _navigationService = navigationService;
        }



        [RelayCommand]
        public async Task Login(object? parameter)
        {

            if (string.IsNullOrEmpty(this.Name) || string.IsNullOrEmpty(this.Password))
            {
                MessageBox.Show("Por favor, rellene ambos campos.", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            LoginDTO loginDTO = new LoginDTO
            {
                UserName = this.Name,
                Password = this.Password
            };



            UserDTO userDTO = await _httpJsonService.LoginAsync(loginDTO);
            
            if (userDTO.IsSuccess)
            {
                _navigationService.Navigate(typeof(Views.Pages.DashboardPage));
                App.Services.GetService<DashboardViewModel>().CargarCoches();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Intente de nuevo.", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

            
        }

        [RelayCommand]
        public void ToRegisterPage(object? parameter)
        {
            _navigationService.Navigate(typeof(Views.Pages.RegistroPage));
        }


    }
}
