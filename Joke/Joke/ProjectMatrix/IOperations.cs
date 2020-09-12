using System;
using System.Collections.Generic;
using System.Text;

namespace Joke.ProjectMatrix
{
    interface IOperations
    {
        public enum Operation
        {
            MULTIPLY,
            SUM
        }

        int MaxElement(Matrix matrix);
        int MinElement(Matrix matrix);
        public Matrix MatrixOperation(Matrix matrix, int factor, Operation operation);


    }
}
