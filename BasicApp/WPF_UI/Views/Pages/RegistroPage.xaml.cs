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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Controls;
using Wpf.Ui.Demo.Mvvm.ViewModels;

namespace Wpf.Ui.Demo.Mvvm.Views.Pages
{
    /// <summary>
    /// Lógica de interacción para RegistroPage.xaml
    /// </summary>
    public partial class RegistroPage : INavigableView<ViewModels.RegistroViewModel>
    {
        public ViewModels.RegistroViewModel ViewModel { get; }
        public RegistroPage(ViewModels.RegistroViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }
    }
}
