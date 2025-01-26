using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WPF_UI.Constants;
using WPF_UI.DTO;
using WPF_UI.Interface;
using WPF_UI.Services;
using WPF_UI.Views.Windows;

namespace Wpf.Ui.Demo.Mvvm.ViewModels
{
    public partial class AddViewModel : ViewModel
    {
        [ObservableProperty]
        private string? marca = "pruebita";
        [ObservableProperty]
        private string? modelo = "prueba";
        [ObservableProperty]
        private int precio = 999;



        private readonly IHttpJsonProvider<CocheDTO> _httpJsonService;
        private AddWindow? _addWindow;
        public AddViewModel(IHttpJsonProvider<CocheDTO> httpJsonProvider) 
        {
            _httpJsonService = httpJsonProvider;
        }

        [RelayCommand]
        public async Task Post(object? parameter)
        {
            CocheDTO cocheDTO = new CocheDTO
            {
                Marca = Marca,
                Modelo = Modelo,
                Precio = Precio
            };

            

            if (await _httpJsonService.PostAsync(ConstantesApi.COCHE_PATH, cocheDTO) !=null)
            {
                _addWindow.Close();
            }
            else
            {

            }
        }

        [RelayCommand]
        public async Task Back(object? parameter)
        {
            //_addWindow.Visibility = Visibility.Hidden;
            _addWindow.Close();
        }


        public AddWindow? SelectedView
        {
            get => _addWindow;
            set
            {
                SetProperty(ref _addWindow, value);
            }
        }
    }


}
