using GestorArchivos.ViewModel;
using System.Windows.Controls;
namespace GestorArchivos.Views
{
    public partial class InicioView : UserControl
    {
        public InicioView(InicioViewModel inicioViewModel)
        {
            InitializeComponent();
            DataContext = inicioViewModel;
        }
    }
}
