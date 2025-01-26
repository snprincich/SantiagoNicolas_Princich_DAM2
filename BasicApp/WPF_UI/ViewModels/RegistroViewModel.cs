

using System.Windows.Controls;
using System.Windows.Navigation;
using WPF_UI.DTO;
using WPF_UI.Interface;
using WPF_UI.Views;
using WPF_UI.Views.Pages;

namespace Wpf.Ui.Demo.Mvvm.ViewModels
{

    public partial class RegistroViewModel : ViewModel
    {
        [ObservableProperty]
        private string? name;
        [ObservableProperty]
        private string? userName;
        [ObservableProperty]
        private string? email;
        [ObservableProperty]
        private string? password;
        [ObservableProperty]
        private string? confPassword;

       


        private INavigationService _navigationService;
        private readonly IHttpJsonProvider<RegistroDTO> _httpJsonService;
        public RegistroViewModel(IHttpJsonProvider<RegistroDTO> httpJsonProvider, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _httpJsonService = httpJsonProvider;
        }

        [RelayCommand]
        public async Task RegistroAsync(object? parameter)
        {
            if (string.IsNullOrEmpty(Name) ||
                string.IsNullOrEmpty(UserName) ||
                string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) &&
                Password.Equals(ConfPassword))
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            RegistroDTO registroDTO = new RegistroDTO
            {
                Name = this.Name,
                UserName = this.UserName,
                Email = this.Email,
                Password = this.Password,
                Role = "admin"
            };


            UserDTO userDTO = await _httpJsonService.RegistroAsync(registroDTO);

            if (userDTO.IsSuccess)
            {
                _navigationService.Navigate(typeof(LoginPage));
            }
            else
            {
                MessageBox.Show("Error en el registro. Intente de nuevo.", "Error de Registro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        [RelayCommand]
        public void ToLoginPage(object? parameter)
        {
            _navigationService.Navigate(typeof(LoginPage));
        }
    }
}
