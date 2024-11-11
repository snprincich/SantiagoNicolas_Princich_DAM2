using System.Text;
using System.Windows;
using GestorArchivos.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace GestorArchivos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _mainWindow;
        public MainWindow(MainViewModel mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            DataContext = _mainWindow;
            Loaded += MainWindow_Loaded;

        }


        private async void MainWindow_Loaded(Object sender, RoutedEventArgs e)
        {
            await _mainWindow.LoadAsync();
        }
    }
}