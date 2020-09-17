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
        


    }
}
