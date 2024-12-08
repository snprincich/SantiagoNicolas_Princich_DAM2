using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace PokeRogue.Services
{
public class ColorShinyService : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // Verifica si el valor es true (shiny)
        if (value is bool isShiny && isShiny)
        {
            // Si es shiny, devuelve el color morado
            return new SolidColorBrush(Colors.MediumPurple);
        }

        // Si no es shiny, mantiene el color predeterminado (negro)
        return new SolidColorBrush(Colors.Black);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // No es necesario para este caso, así que devuelve el valor original
        return value;
    }
}
}
