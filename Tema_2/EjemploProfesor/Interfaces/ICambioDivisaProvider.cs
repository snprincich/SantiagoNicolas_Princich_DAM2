using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa.Interfaces
{
    public interface ICambioDivisaService
    {
        Task<string> GetResultado(int numero);
    }
}
