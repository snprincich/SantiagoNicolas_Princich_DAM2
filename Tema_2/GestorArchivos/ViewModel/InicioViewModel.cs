using System.Windows.Controls;

namespace GestorArchivos.ViewModel
{
    public partial class InicioViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedHeader;
        public HeaderControlViewModel HeaderControl { get;}
        public InicioViewModel(HeaderControlViewModel headerControl)
        {
            _selectedHeader = headerControl;
            HeaderControl = headerControl;
        }

        public ViewModelBase? SelectedHeader
        {
            get => _selectedHeader;
            set
            {
                SetProperty(ref _selectedHeader, value);

            }
        }
        public override Task LoadAsync()
        {

            return base.LoadAsync();
        }
    }
}