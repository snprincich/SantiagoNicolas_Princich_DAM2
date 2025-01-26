// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Wpf.Ui.Controls;
using WPF_UI.DTO;
using WPF_UI.Interface;
using WPF_UI.Services;
using WPF_UI.Views.Pages;

namespace Wpf.Ui.Demo.Mvvm.ViewModels;

public partial class MainWindowViewModel : ViewModel
{
    private bool _isInitialized = false;

    [ObservableProperty]
    private string _applicationTitle = string.Empty;

    [ObservableProperty]
    private ObservableCollection<object> _navigationItems = [];

    [ObservableProperty]
    private ObservableCollection<object> _navigationFooter = [];

    [ObservableProperty]
    private ObservableCollection<MenuItem> _trayMenuItems = [];

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Style",
        "IDE0060:Remove unused parameter",
        Justification = "Demo"
    )]
    public MainWindowViewModel(INavigationService navigationService)
    {
        if (!_isInitialized)
        {
            InitializeViewModel();
        }
    }

    private void InitializeViewModel()
    {
        ApplicationTitle = "WPF UI - MVVM Demo";

        NavigationItems =
        [
            new NavigationViewItem()
            {
                Content = "Datos",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Database16 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
            },
        ];

        NavigationFooter =
        [

            new NavigationViewItem()
            {
                Content = "Settings",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            },



            new NavigationViewItem()
            {
                Content = "Login/Logout",
                Icon = new SymbolIcon { Symbol = SymbolRegular.SignOut24 },
                TargetPageType = typeof(LoginPage),
                Command = LogoutCommand,
            },
        ];

        TrayMenuItems = [new() { Header = "Home", Tag = "tray_home" }];

        _isInitialized = true;
    }


    

    [RelayCommand]
    public void Logout()
    {

            App.Services.GetService<Credenciales>().BorrarCredenciales();
            App.Services.GetService<IHttpJsonProvider<CocheDTO>>().RemoveToken();
            App.Services.GetService<DashboardViewModel>().OnStart();


    }
}
