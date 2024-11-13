
using GestorArchivos.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;


namespace GestorArchivos.Controls
{
    /// <summary>
    /// Lógica de interacción para HeaderControl.xaml
    /// </summary>
    public partial class HeaderControl : UserControl
    {

        public HeaderControl()
        {
            InitializeComponent();
            DataContext = new
            {
                mainViewModel = App.Current.Services.GetService<MainViewModel>(),
                headerControlViewModel = App.Current.Services.GetService<HeaderControlViewModel>()
            };
        }

            


    }
}
