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
            
        }
    }
}
