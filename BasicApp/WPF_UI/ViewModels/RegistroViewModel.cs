

using System.Windows.Controls;

namespace Wpf.Ui.Demo.Mvvm.ViewModels
{

    public partial class RegistroViewModel : ViewModel
    {
        [ObservableProperty]
        private string? name;
        [ObservableProperty]
        private string? email;
        [ObservableProperty]
        private string? password;
        [ObservableProperty]
        private string? confPassword;

        public RegistroViewModel()
        {

        }

        [RelayCommand]
        public void Registro(object? parameter)
        {
            Console.Write("aaaa");
        }

    }
}
