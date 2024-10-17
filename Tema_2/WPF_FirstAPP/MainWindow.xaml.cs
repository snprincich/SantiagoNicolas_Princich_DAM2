using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_FirstAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            resultado.Content += ((Button)e.Source).Content.ToString();
            
        }

        private void Calc_Click (object sender, RoutedEventArgs e)
        {
            
            Calculadora calculadora = new Calculadora();
            resultado.Content =calculadora.Calcular(resultado.Content.ToString());
            //resultado.Content = calculadora.Calcular("10x(5x5+(2x3-1))+10x10");

        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            if (resultado.Content.ToString().Length > 0)
            {
                resultado.Content = resultado.Content.ToString()[..^1];
            }
        }
    }
}