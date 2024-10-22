using System.IO;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("log_CambioDivisa.txt"))
            {
                LecturaEscritura.CargarListBox(ListBox_Historico);
            }
        }

        private void Btn_Calcular_Click(object sender, RoutedEventArgs e)
        {
            string log = (CambiarDivisa.Cambiar(TextBox_Entrada, ComboBox_From, ComboBox_To)).Trim();
            LecturaEscritura.Escribir(log);
            ListBox_Historico.Items.Add(log);
        }

        private void Click_IntercambioDivisas(object sender, MouseButtonEventArgs e)
        {
            int aux;
            aux = ComboBox_From.SelectedIndex;
            ComboBox_From.SelectedIndex = ComboBox_To.SelectedIndex;
            ComboBox_To.SelectedIndex = aux;
        }
    }
}