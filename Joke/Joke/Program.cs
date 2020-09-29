using Joke.Other;
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
            /*
            Matrix matrix = new Matrix(6, 6);
            matrix.printMatrix();
            line();
            print(matrix.Det(matrix).ToString());
            */
            Fibonachi fib = new Fibonachi(10);
            //int[] spiral = new int[10];
            fib.printFibonachi();
            line();
            fib.spiralFibonachi();
            //printMass(spiral);
        }
    }
}
