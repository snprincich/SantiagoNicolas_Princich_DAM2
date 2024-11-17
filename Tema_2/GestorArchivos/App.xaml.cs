using GestorArchivos.Controls;
using GestorArchivos.Services;
using GestorArchivos.ViewModel;
using GestorArchivos.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace GestorArchivos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; set; }
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

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<InfoControl>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<InfoViewModel>();
            services.AddSingleton<FileViewModel>();
            services.AddSingleton<HeaderControl>();
            services.AddTransient<InicioViewModel>();
            services.AddSingleton<HeaderControlViewModel>();
            services.AddSingleton<GestorFicheros>();
            services.AddTransient<CrearView>();
            services.AddTransient<CrearViewModel>();
            return services.BuildServiceProvider();
        }


    }
}
