namespace Tema_2
{
    internal class Program
    {
        public static void Main()
        {
            IEjecutarEjercicio ejercicio;
            /*Utils prueba = new Utils();
            Console.WriteLine(prueba.EntradaSplitNumero());*/

           ejercicio = new Ej9();
            ejercicio.Ejecutar();
        }
    }
}
