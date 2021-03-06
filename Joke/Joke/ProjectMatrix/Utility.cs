﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Joke.ProjectMatrix
{

    class Utility
    {
        //TODO Неиспользуемый параметр
        public static Matrix MatObr(Matrix matrix)
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

        public static Matrix GetMinor(Matrix matrix, int columns)
        {
            Matrix minor = new Matrix(matrix.rows - 1, matrix.columns - 1);
            for (int i = 1; i < matrix.rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    minor.SetElement(i - 1, j, matrix.GetElement(i, j));
                }
            }
            for (int i = 1; i < matrix.rows; i++)
            {
                for (int j = columns + 1; j < matrix.columns; j++)
                {
                    minor.SetElement(i - 1, j - 1, matrix.GetElement(i, j));
                }
            }
            return minor;

        }

        public static void printMass(int[] mass)
        {
            for (int i = 0; i < mass.Length; i++)
            {
                Console.Write($"{mass[i]} ");
            }
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
