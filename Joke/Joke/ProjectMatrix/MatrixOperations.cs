using System;
using System.Collections.Generic;
using System.Text;

namespace Joke.ProjectMatrix
{

    class MatrixOperations : IOperations
    {
        
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
        
        public int MaxElement(Matrix matrix)
        {
            int max = int.MinValue;
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

        public int MinElement(Matrix matrix)
        {
            int min = int.MaxValue;
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
