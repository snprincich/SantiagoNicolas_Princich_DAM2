﻿using Microsoft.Extensions.DependencyInjection;
using PokeRogue.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PokeRogue
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = Current.Services.GetService<MainWindow>();
            mainWindow?.Show();
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //view principal
            services.AddTransient<MainWindow>();

            //view viewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<BattleViewModel>();
            services.AddTransient<TeamViewModel>();
            services.AddTransient<HistoricViewModel>();
            services.AddTransient<ImportViewModel>();

            return services.BuildServiceProvider();
        }
    }

}