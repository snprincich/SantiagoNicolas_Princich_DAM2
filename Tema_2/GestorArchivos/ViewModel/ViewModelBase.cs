using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace GestorArchivos.ViewModel
{
    public class ViewModelBase : ObservableObject
    {
        public virtual Task LoadAsync() {return Task.CompletedTask; }
    }
}
