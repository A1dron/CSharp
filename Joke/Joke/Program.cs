using Joke.ProjectMatrix;
using System;
using static Joke.ProjectMatrix.Utility;

namespace Joke
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(3, 3);
            matrix.printMatrix();
            line();
            print(matrix.Det(matrix).ToString());
        }
    }




}
