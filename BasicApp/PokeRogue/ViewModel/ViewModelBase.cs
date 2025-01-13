using CommunityToolkit.Mvvm.ComponentModel;

namespace BasicApp.ViewModel
{
    public class ViewModelBase : ObservableObject
    {
        public virtual Task LoadAsync() => Task.CompletedTask;
    }
}
