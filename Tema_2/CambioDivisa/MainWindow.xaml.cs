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

namespace CambioDivisa
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_Calcular_Click(object sender, RoutedEventArgs e)
        {
            CambiarDivisa.Calcular(TextBox_Entrada, ComboBox_From, ComboBox_To);
            TextBox_Historico.Text = LecturaEscritura.Leer();
            //CambiarDivisa.Calcular(TextBox_Entrada, ComboBox_From, ComboBox_To);
        }
    }
}