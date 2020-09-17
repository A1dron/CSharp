using Joke.ProjectMatrix;
using System;
using static Joke.ProjectMatrix.Utility;

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
            Matrix matrix = new Matrix(6,6);
            matrix.printMatrix();
            Console.WriteLine();
            print(matrix.Det(matrix).ToString());
            //Matrix matrix1 = new Matrix(5, 5);
            //matrix1 = matrix.GetMinor(matrix, 0);
            //matrix1.printMatrix();
            
        }
    }
}
