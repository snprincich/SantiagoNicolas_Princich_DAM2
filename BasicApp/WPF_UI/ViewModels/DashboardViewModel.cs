// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using Wpf.Ui.Demo.Mvvm.Views;
using WPF_UI.Constants;
using WPF_UI.DTO;
using WPF_UI.Interface;
using WPF_UI.Services;
using WPF_UI.Views.Windows;

namespace Wpf.Ui.Demo.Mvvm.ViewModels;

public partial class DashboardViewModel : ViewModel
{
    [ObservableProperty]
    private int _counter = 0;

    [ObservableProperty]
    private ObservableCollection<CocheDTO> listaCoches;

    private readonly IHttpJsonProvider<CocheDTO> _httpJsonService;

    public DashboardViewModel(IHttpJsonProvider<CocheDTO> httpJsonProvider)
    {
        _httpJsonService = httpJsonProvider;
    }


    public async Task CargarCoches()
    {
        if (App.Services.GetService<Credenciales>().GetCredenciales().UserName != null)
        {

            IEnumerable<CocheDTO> coches = await _httpJsonService.GetAsync(ConstantesApi.COCHE_PATH);
            ListaCoches = new ObservableCollection<CocheDTO>();
            foreach (var coche in coches)
            {
                 ListaCoches.Add(coche);
            }

        }
    }


    [RelayCommand]
    public void Add(object? parameter)
    {

        var view = App.Services.GetService<AddWindow>();
        var viewmodel = App.Services.GetService<AddViewModel>();

        viewmodel.SelectedView = view;
        view.DataContext = viewmodel;

        view.Show();
    }


    public override void OnNavigatedTo()
    {



        base.OnNavigatedTo();


    }

    [RelayCommand]
    private void OnCounterIncrement()
    {
        Counter++;
    }
}
