using System;
using System.Collections.Generic;
using System.Text;

namespace Joke.ProjectMatrix
{

    class Utility
    {
        public static Matrix MatObr(Matrix matrix, IOperations.Operation operation)
        {
            Matrix copy = new Matrix(matrix);
            for (int i = 0; i < copy.rows; i++)
            {
                for (int j = 0; j < copy.columns; j++)
                {
                    if (copy.GetElement(i, j) != 0) copy.SetElement(i, j, (1 / copy.GetElement(i, j)));
                    else copy.SetElement(i, j, 0);
                }
            }
            return copy;
        }

        

        public static Matrix GetMinor(Matrix matrix, int column)
        {
            //float proverka = 0;
            Matrix minor = new Matrix(matrix.rows - 1, matrix.columns - 1);
            for (int i = 1; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    if (j == n) continue;
                    if (j == 0) minor.SetElement(i - 1, j, matrix.GetElement(i, j));
                    else minor.SetElement(i - 1, j - 1, matrix.GetElement(i, j));
                }
            }
            return minor;

        }

        public static float Pow(float x, float y)
        {
            for (int i = 0; i < y; i++)
            {
                x *= x;
            }
            return x;
        }
        public static void print(string mes)
        {
            Console.Write(mes);
            Console.WriteLine();
        }

        public static void line()
        {
            Console.WriteLine();
        }

    }
}
