using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Primo.Interfaces
{
    public interface ICalcPrimoService
    {
        Task<bool> GetResultado(int numero);
    }
}
