using System;
using System.Collections.Generic;
using System.Text;

namespace Joke.ProjectMatrix
{

    class MatrixOperations : IOperations
    {
        public float Det(Matrix matrix, IOperations.Operation operation)
        {
            //float det = 0;
            if (matrix.Length()==4)
                return (matrix.GetElement(0,0)* matrix.GetElement(1, 1) - matrix.GetElement(0, 1)* matrix.GetElement(1, 0));
            float sign = 1, result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                float[,] minor = GetMinor(matrix, i);
                result += sign * matrix.GetElement(0,i) * Det((Matrix)minor, IOperations.Operation.Det);
                sign = -sign;
            }
            return result;
        }

        private static float[,] GetMinor(Matrix matrix, int n)
        {
            float[,] result = new float[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0, col = 0; j < matrix.GetLength(0); j++)
                {
                    if (j == n)
                        continue;
                    result[i - 1, col] = matrix.GetElement(i,j);
                    col++;
                }
            }
            return result;
        }

        public Matrix MatrixesOperation(Matrix matrix, Matrix matrix1, IOperations.Operation operation)
        {
            Matrix result = new Matrix(matrix);
            switch (operation)
            {
                case IOperations.Operation.MATRIXSUM:
                    for (int i = 0; i < matrix.rows; i++)
                    {
                        for (int j = 0; j < matrix.columns; j++)
                        {
                            
                            result.SetElement(i, j, matrix.GetElement(i, j) + matrix1.GetElement(i,j));
                        }
                    }
                    break;
            }
            return result;
        }

        public Matrix MatrixOperation(Matrix matrix, int factor, IOperations.Operation operation)
        {
            Matrix copy = new Matrix(matrix);
            switch (operation)
            {
                case IOperations.Operation.MULTIPLY:
                    for (int i = 0; i < copy.rows; i++)
                    {
                        for (int j = 0; j < copy.columns; j++)
                        {
                            copy.SetElement(i, j, copy.GetElement(i, j) * factor);
                        }
                    }
                    break;

                case IOperations.Operation.SUM:
                    for (int i = 0; i < copy.rows; i++)
                    {
                        for (int j = 0; j < copy.columns; j++)
                        {
                            copy.SetElement(i, j, copy.GetElement(i, j) + factor);
                        }
                    }
                    break;
                
            }
            return copy;
        }
        
        public float MaxElement(Matrix matrix)
        {
            float max = int.MinValue;
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    if (matrix.GetElement(i, j) > max)
                    {
                        max = matrix.GetElement(i, j);
                    }
                }
            }
            return max;
        }

        public float MinElement(Matrix matrix)
        {
            float min = int.MaxValue;
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    if (matrix.GetElement(i, j) < min)
                    {
                        min = matrix.GetElement(i, j);
                    }
                }
            }
            return min;
        }

        
    }
}
