using Joke.ProjectMatrix;
using System;

namespace Joke
{
    class Program
    {
        public static void print(string mes)
        {
            Console.Write(mes);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(7, 7);
            matrix.printMatrix();
            Console.WriteLine();

            Matrix matrix2 = new Matrix(7, 7);
            matrix2 = matrix.MatrixOperation(matrix, 4, IOperations.Operation.MULTIPLY);
            matrix2.printMatrix();
            Console.WriteLine();

            matrix2 = matrix.MatrixOperation(matrix, 4, IOperations.Operation.SUM);
            matrix2.printMatrix();
            Console.WriteLine();
            //print($"Element 5 5: {matrix.GetElement(5,5)}");
        }
    }
}
