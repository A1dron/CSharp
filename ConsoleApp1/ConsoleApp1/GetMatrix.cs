using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class GetMatrix
    {
        public readonly int rows;
        public readonly int columns;
        private int[][] matrix { get; set; }
        public GetMatrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[columns];
            }
            fillMatrix();
        }


        public int Get(int rows, int columns)
        {
            if (rows < 0 || rows >= this.rows || columns < 0 || columns >= this.columns) throw new Exception("Poka bratishka");
            return matrix[rows][columns];
        }


        public int Set(int rows, int columns, int newElement)
        {
            if (rows < 0 || rows >= this.rows || columns < 0 || columns >= this.columns) throw new Exception("Kriticheskaya bratishka");
            matrix[rows][columns] = newElement;
            return matrix[rows][columns];
        }

        private void fillMatrix()
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
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
