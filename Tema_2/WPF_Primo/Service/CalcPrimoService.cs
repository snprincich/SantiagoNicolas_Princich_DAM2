using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Primo.Interfaces;

namespace WPF_Primo.Service
{
    public class CalcPrimoService : ICalcPrimoService
    {

        public Task<bool> GetResultado(int numero)
        {
            for (int i = 0; i <= numero; i++)
            {
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        Task.FromResult(false);
                        break;
                    }
                }
            }
            return Task.FromResult(true);
        }
    }
}
