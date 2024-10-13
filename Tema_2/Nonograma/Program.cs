namespace Nonograma
{
    public class Program()
    {


        public static void Main(String[] args)
        {
            //int [,] columna = { {1,1,0},{4,0,0},{1,1,1}, {3,0,0}, {1,0,0} };
            int[][] columna = new int[5][];
            columna[0] = [1, 1, 0];
            columna[1] = [4, 0, 0];
            columna[2] = [1, 1, 1];
            columna[3] = [3, 0, 0];
            columna[4] = [1,0,0];

            Console.WriteLine(columna[0]);
            


            //int[,] fila = { {1,0 }, {2,0}, {3,0}, {1,2}, {4,0} };

            int[][] fila = new int[5][];
            fila[0] = [1,0];
            fila[1] = [2,0];
            fila[2] = [3,0];
            fila[3] = [1,2];
            fila[4] = [4,0];

            Nonograma consola = new Nonograma(fila, columna);
            consola.Mostrar();
            Resolver resolver = new Resolver();


            resolver.Ejecutar();
            Console.WriteLine();
            consola.Mostrar();
           
        }
    }

}