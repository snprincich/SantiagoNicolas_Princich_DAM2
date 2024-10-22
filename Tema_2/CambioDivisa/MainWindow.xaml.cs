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
            
            if (double.TryParse(TextBox_Entrada.Text, out double entrada) && entrada>0)
            {
                string log = (CambiarDivisa.Cambiar(entrada, ComboBox_From, ComboBox_To)).Trim();
                LecturaEscritura.Escribir(log);
                ListBox_Historico.Items.Add(log);
            }
            else
            {
                MessageBox.Show("No has introducido un numero valido");
            }
        }

        private void Click_IntercambioDivisas(object sender, MouseButtonEventArgs e)
        {
            int aux;
            aux = ComboBox_From.SelectedIndex;
            ComboBox_From.SelectedIndex = ComboBox_To.SelectedIndex;
            ComboBox_To.SelectedIndex = aux;
        }

        private void TextBox_Entrada_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (double.TryParse(TextBox_Entrada.Text, out double numero) && numero>0)
            {
                TextBox_Entrada.Background = new SolidColorBrush(Colors.White);
                Label_error.Visibility = Visibility.Hidden;
                Label_flechita.Visibility = Visibility.Hidden;
            }
            else
            {
                TextBox_Entrada.Background = new SolidColorBrush(Color.FromRgb(255,50,50));
                Label_error.Visibility = Visibility.Visible;
                Label_flechita.Visibility = Visibility.Visible;
            }
        }
    }
}