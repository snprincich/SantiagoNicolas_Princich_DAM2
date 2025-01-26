// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows.Controls;
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


    private List<CocheDTO> listaCoches;

    private readonly IHttpJsonProvider<CocheDTO> _httpJsonService;

    public DashboardViewModel(IHttpJsonProvider<CocheDTO> httpJsonProvider)
    {
        _httpJsonService = httpJsonProvider;

        OnStart();
    }

    public void OnStart()
    {
        listaCoches = new List<CocheDTO>();
        PagedCoches = new ObservableCollection<CocheDTO>();

        ItemsPerPage = 5;
        CurrentPage = 0;
        CurrentPageView = 1;
        TotalPages = 1;
    }

    [ObservableProperty]
    private ObservableCollection<CocheDTO> pagedCoches;

    [ObservableProperty]
    private int currentPage;

    [ObservableProperty]
    private int currentPageView;

    [ObservableProperty]
    private int itemsPerPage;

    [ObservableProperty]
    public int totalPages; 

    private void SumarPages(int num)
    {
        CurrentPage += num;
        CurrentPageView += num;
    }

    public async Task CargarCoches()
    {
        if (App.Services.GetService<Credenciales>().GetCredenciales().UserName != null)
        {

            try
            {
                OnStart();

                IEnumerable<CocheDTO> coches = await _httpJsonService.GetAsync(ConstantesApi.COCHE_PATH);
                listaCoches.AddRange(coches.OrderBy(d => d.Id));
                
                TotalPages = (int)Math.Ceiling((double)listaCoches.Count / ItemsPerPage);
                UpdatePagedCoches();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al cargar datos: {ex.Message}");
            }

        }
    }

    public void MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        if (e.Row.Item is CocheDTO objeto)
        {
            // Aquí llamas al método sobre el objeto editado
            _httpJsonService.PatchAsync($"{ConstantesApi.COCHE_PATH}{"/"}{objeto.Id}", objeto);
        }
    }

    private void UpdatePagedCoches()
    {

        PagedCoches.Clear();  
        var pagedItems = listaCoches.Skip(CurrentPage * ItemsPerPage).Take(ItemsPerPage).ToList();
        foreach (var item in pagedItems)
        {
            PagedCoches.Add(item);
        }
    }


    [RelayCommand]
    public void PreviousPage()
    {
        if (CurrentPage > 0)
        {
            SumarPages(-1);
            UpdatePagedCoches();
        }
    }

    [RelayCommand]
    public void NextPage()
    {
        if (CurrentPage < TotalPages - 1)
        {
            SumarPages(1);
            UpdatePagedCoches();
        }
    }

    private bool CanGoToPreviousPage() => CurrentPage > 0;

    private bool CanGoToNextPage() => CurrentPage < TotalPages - 1;

    [RelayCommand]
    public void Add(object? parameter)
    {

        var view = App.Services.GetService<AddWindow>();
        var viewmodel = App.Services.GetService<AddViewModel>();

        viewmodel.SelectedView = view;
        view.DataContext = viewmodel;

        view.Show();
        view.Closed += View_Closed;
    }

    private void View_Closed(object sender, EventArgs e)
    {
        CargarCoches();
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
