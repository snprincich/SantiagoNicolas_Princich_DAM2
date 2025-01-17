// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.ObjectModel;
using WPF_UI.Constants;
using WPF_UI.DTO;
using WPF_UI.Interface;
using WPF_UI.Services;

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


        CargarCoches();
    }


    public async Task CargarCoches()
    {
        IEnumerable<CocheDTO> coches = await _httpJsonService.GetAsync(ConstantesApi.COCHE_PATH);
        ListaCoches = new ObservableCollection<CocheDTO>();
        foreach (var coche in coches)
        {
            ListaCoches.Add(coche);
        }
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
