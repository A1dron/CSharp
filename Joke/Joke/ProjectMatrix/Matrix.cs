using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joke.ProjectMatrix
{
    class Matrix: MatrixOperations
    {
        public readonly int rows;
        public readonly int columns;
        private int[][] matrix;

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[columns];
            }
            generateMatrix();
        }

        public Matrix(Matrix matrix)
        {
            this.matrix = matrix.matrix.Select(arr => arr.ToArray()).ToArray();
            this.rows = matrix.rows;
            this.columns = matrix.columns;
        }

        public int GetElement(int rows, int columns)
        {
            if (rows < 0 || rows >= this.rows || columns < 0 || columns >= this.columns) throw new Exception("Poka bratishka");
            return matrix[rows][columns];
        }

        public int SetElement(int rows, int columns, int newElement)
        {
            if (rows < 0 || rows >= this.rows || columns < 0 || columns >= this.columns) throw new Exception("Kriticheskaya bratishka");
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
            int max = MaxElement(this);
            int min = MinElement(this);
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
