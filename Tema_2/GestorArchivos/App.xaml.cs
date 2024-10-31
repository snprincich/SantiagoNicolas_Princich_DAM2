using GestorArchivos.Controls;
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
        private IServiceProvider Services { get; set; }
        public App()
        {
            Services = ConfigureServices();
            var mainWindow = Current.Services.GetService<MainWindow>();
            mainWindow?.Show();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


        }

        public new static App Current => (App)Application.Current;

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddTransient<MainWindow>();
            services.AddTransient<HeaderControl>();
            services.AddTransient<InfoControl>();

            return services.BuildServiceProvider();
        }


    }
}
