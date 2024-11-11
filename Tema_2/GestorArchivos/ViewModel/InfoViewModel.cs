namespace GestorArchivos.ViewModel
{
    public partial class InfoViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedHeader;
        public HeaderControlViewModel HeaderControl { get; }
        public InfoViewModel(HeaderControlViewModel headerControl)
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
