

using System.Windows.Controls;
using System.Windows.Navigation;
using WPF_UI.DTO;
using WPF_UI.Interface;

namespace Wpf.Ui.Demo.Mvvm.ViewModels
{

    public partial class RegistroViewModel : ViewModel
    {
        [ObservableProperty]
        private string? name = "pruebita";
        [ObservableProperty]
        private string? userName = "prueba";
        [ObservableProperty]
        private string? email = "prueba@email.net";
        [ObservableProperty]
        private string? password = "wnD/LbJq?9t,}-628%)";
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
                _navigationService.Navigate(typeof(Views.Pages.LoginPage));
            }
            else
            {

            }
        }

        [RelayCommand]
        public void ToLoginPage(object? parameter)
        {
            _navigationService.Navigate(typeof(Views.Pages.LoginPage));
        }
    }
}
