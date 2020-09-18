using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class GetMatrix: MatrixOperations
    {

        public enum Operation
        {
            MULTIPLY,
            SUM
        }

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
        public GetMatrix(GetMatrix matrix)
        {
            this.matrix = matrix.matrix.Select(arr => arr.ToArray()).ToArray();
            this.rows = matrix.rows;
            this.columns = matrix.columns;
        }
        public GetMatrix(GetMatrix matrix, int factor, Operation operation)
        {
            switch (operation)
            {
                case Operation.MULTIPLY:
                    GetMatrix matrix1 = Multiply(matrix, factor);
                    this.matrix = matrix1.matrix.Select(arr => arr.ToArray()).ToArray();
                    this.rows = matrix1.rows;
                    this.columns = matrix1.columns;
                    break;
                case Operation.SUM:
                    GetMatrix matrix2 = Sum(matrix, factor);
                    this.matrix = matrix2.matrix.Select(arr => arr.ToArray()).ToArray();
                    this.rows = matrix2.rows;
                    this.columns = matrix2.columns;
                    break;
                default:
                    break;
            }
            
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
