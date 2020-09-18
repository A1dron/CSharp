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
            SUM,
            MATRIXSUM,
            MATOBR,
            Det
        }

        float MaxElement(Matrix matrix);
        float MinElement(Matrix matrix);
        public Matrix MatrixOperation(Matrix matrix, float factor, Operation operation);
        public Matrix MatrixesOperation(Matrix matrix, Matrix matrix1, Operation operation);
        public float Det(Matrix matrix);

    }
}
