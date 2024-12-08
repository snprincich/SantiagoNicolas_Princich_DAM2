using Microsoft.Extensions.DependencyInjection;
using PokeRogue.ViewModel;
using PokeRogue.Services;
using System.Windows;
using PokeRogue.Models;
using PokeRogue.Utils;
using static PokeRogue.Interface.IFileService;

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
            services.AddSingleton<BattleViewModel>();
            services.AddTransient<TeamViewModel>();
            services.AddTransient<HistoricViewModel>();
            services.AddTransient<ImportViewModel>();

            //services
            services.AddSingleton<GenerarPokemonService>();
            services.AddSingleton<GestorAPIService>();
            services.AddSingleton(typeof(IFileService<>), typeof(FileService<>));
            services.AddTransient<ColorShinyService>();

            //models
            services.AddSingleton<Jugador>();
            services.AddTransient<Batalla>();


            return services.BuildServiceProvider();
        }
    }

}