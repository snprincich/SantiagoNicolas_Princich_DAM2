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
            int lado1;
            int.TryParse(texto1.Text, out lado1);

            int lado2;
            int.TryParse(texto2.Text, out lado2);

            int lado3;
            int.TryParse(texto3.Text, out lado3);

            principal.Content = principal.Content.ToString().Split(":")[0]+=": ";

            if (lado1 == lado2 && lado1 == lado3)
            {
                principal.Content += "Equilatero";
            }
            else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
            {
                principal.Content += "Isosceles";
            }
            else principal.Content += "Escaleno";

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}