using CommunityToolkit.Mvvm.ComponentModel;

namespace PokeRogue.ViewModel
{
    public class ViewModelBase : ObservableObject
    {
        public virtual Task LoadAsync() => Task.CompletedTask;
    }
}
