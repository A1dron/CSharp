using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class MatrixOperations : IOperation
    {
        public int MaxElement(GetMatrix matrix)
        {
            int max = int.MinValue;
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    if (matrix.Get(i,j) > max)
                    {
                        max = matrix.Get(i, j);
                    }
                    
                }
            }
            return max;
        }

        
        public int MinElement(GetMatrix matrix)
        {
            int min = int.MaxValue;
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.columns; j++)
                {
                    if (matrix.Get(i, j) < min)
                    {
                        min = matrix.Get(i, j);
                    }
                }
            }
            return min;
        }

        public GetMatrix Multiply(GetMatrix matrix, int factor)
        {
            GetMatrix copyMatrix = new GetMatrix(matrix);
            for (int i = 0; i < copyMatrix.rows; i++)
            {
                for (int j = 0; j < copyMatrix.columns; j++)
                {
                    //factor *= copyMatrix.Get(i, j);
                    copyMatrix.Set(i, j, copyMatrix.Get(i, j)*factor);
                    
                }
            }
            return copyMatrix;
        }

        public GetMatrix Sum(GetMatrix matrix, int factor)
        {
            GetMatrix copyMatrix = new GetMatrix(matrix);
            for (int i = 0; i < copyMatrix.rows; i++)
            {
                for (int j = 0; j < copyMatrix.columns; j++)
                {
                    //factor *= copyMatrix.Get(i, j);
                    copyMatrix.Set(i, j, copyMatrix.Get(i, j) + factor);

                }
            }
            return copyMatrix;
        }


    }
}
