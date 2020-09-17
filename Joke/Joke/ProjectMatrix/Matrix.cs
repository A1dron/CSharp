using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Joke.ProjectMatrix
{
    class Matrix: MatrixOperations
    {
        
        public readonly int rows;
        public readonly int columns;
        private float[][] matrix;

        public Matrix()
        {
            this.rows = 7;
            this.columns = 7;
            matrix = new float[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new float[columns];
            }
            generateMatrix();
        }
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new float[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new float[columns];
            }
            generateMatrix();
        }

        public Matrix(Matrix matrix)
        {
            this.matrix = matrix.matrix.Select(arr => arr.ToArray()).ToArray();
            this.rows = matrix.rows;
            this.columns = matrix.columns;
        }

        public static explicit operator float[,](Matrix matrix)
        {
            return (float[,])matrix;
        }

        public static explicit operator Matrix (float[,] matrix)
        {
            return (Matrix)matrix;
        }

        public int GetLength(int dimension)
        {
            return matrix.GetLength(dimension);
        }

        public int Length()
        {
            int lenght = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    lenght += 1;
                }
            }
            return lenght;
        }

        public float GetElement(int rows, int columns)
        {
            if (rows < 0 || rows >= this.rows || columns < 0 || columns >= this.columns) throw new Exception("Poka bratishka");
            return matrix[rows][columns];
        }

        
        public float SetElement(int rows, int columns, float newElement)
        {
            if (rows < 0 || rows >= this.rows || columns < 0 || columns >= this.columns) throw new Exception("Kriticheskaya bratishka");
            //int i = 0;
            matrix[rows][columns] = newElement;
            return matrix[rows][columns];
        }
        private void generateMatrix()
        {
            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i][j] = random.Next(0, 10);
                }
            }
            return;
        }

        public void printMatrix()
        {
            float max = MaxElement(this);
            float min = MinElement(this);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (max == matrix[i][j]) Console.ForegroundColor = ConsoleColor.Green;
                    else if (matrix[i][j] == min) Console.ForegroundColor = ConsoleColor.Red;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
