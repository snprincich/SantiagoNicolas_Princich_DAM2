using Microsoft.Extensions.DependencyInjection;
using BasicApp.ViewModel;
using System.Windows;
using BasicApp.Utils;
using BasicApp.Interface;
using BasicApp.DTO;

namespace BasicApp
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
            services.AddTransient<HistoricViewModel>();

            //services
            services.AddSingleton(typeof(IFileService<>), typeof(FileService<>));

            //models
            services.AddSingleton<LoginDTO>();
            services.AddTransient<UserDTO>();


            return services.BuildServiceProvider();
        }
    }

}