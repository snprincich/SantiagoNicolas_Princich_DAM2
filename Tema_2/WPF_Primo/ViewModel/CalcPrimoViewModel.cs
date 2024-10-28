using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPF_Primo.Interfaces;
using WPF_Primo.Utils;

namespace WPF_Primo.ViewModel
{
    public partial class CalcPrimoViewModel : ViewModelBase
    {
            private readonly ICalcPrimoService _calcPrimo;

            public CalcPrimoViewModel(ICalcPrimoService calcPrimo)
            {
                _calcPrimo = calcPrimo;
            }

            [ObservableProperty]
            public string _Numero;

        /*
            public override async Task LoadAsync()
            {
                if (Divisas.Any())
                {
                    return;
                }

                var divisas = await _cambioDivisa.GetDivisas();
                if (divisas is not null)
                {
                    foreach (var divisa in divisas)
                    {
                        Divisas.Add(divisa);
                    }
                }
            }
        */
            [RelayCommand]
            private async Task Resolver(object? parameter)
            {
                if (string.IsNullOrEmpty(_Numero))
                    return;

                int numero = StringUtils.ConvertToInteger(_Numero).Value;
                bool resultado = await _calcPrimo.GetResultado(numero);

                //PONER RESULTADO EN LA WINDOW
            }
        }
    }

