

using System.Windows.Controls;
using WPF_UI.Constants;
using WPF_UI.DTO;
using WPF_UI.Interface;

namespace Wpf.Ui.Demo.Mvvm.ViewModels
{

    public partial class LoginViewModel : ViewModel
    {
        [ObservableProperty]
        private string? email;
        [ObservableProperty]
        private string? password = "wnD/LbJq?9t,}-628%)";


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
            LoginDTO loginDTO = new LoginDTO
            {
                UserName = this.Email,
                Password = this.Password
            };



            UserDTO userDTO = await _httpJsonService.LoginAsync(loginDTO);
            
            if (userDTO.IsSuccess)
            {
                _navigationService.Navigate(typeof(Views.Pages.DashboardPage));
            }
            else
            {
                
            }
            

            
        }

    }
}
