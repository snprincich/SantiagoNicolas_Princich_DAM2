using GestorArchivos.DataContext;
using GestorArchivos.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
