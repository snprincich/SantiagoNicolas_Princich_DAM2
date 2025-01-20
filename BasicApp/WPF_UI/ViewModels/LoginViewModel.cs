

using System.Windows.Controls;

namespace Wpf.Ui.Demo.Mvvm.ViewModels
{

    public partial class LoginViewModel : ViewModel
    {
        [ObservableProperty]
        private string? email;
        [ObservableProperty]
        private string? password;

        public LoginViewModel()
        {

        }

        [RelayCommand]
        public void Login(object? parameter)
        {
            Console.Write("aaaa");
        }

    }
}
