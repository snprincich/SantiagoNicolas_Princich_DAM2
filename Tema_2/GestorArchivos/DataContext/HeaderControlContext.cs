using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorArchivos.ViewModel;

namespace GestorArchivos.DataContext
{
    public class HeaderControlContext
    {
        public MainViewModel MainViewModel { get; }
        public HeaderControlViewModel HeaderControlViewModel { get; }
        public HeaderControlContext(MainViewModel mainViewModel, HeaderControlViewModel headerControlViewModel) 
        { 
            MainViewModel = mainViewModel;
            HeaderControlViewModel = headerControlViewModel;
        }
    }
}
