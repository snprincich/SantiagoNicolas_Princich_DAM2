using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GestorArchivos.Controls;
using GestorArchivos.ViewModel;

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
            //HeaderContainer.Content = headerControl;
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