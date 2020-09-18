using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Joke.ProjectMatrix
{
    //TODO "IOperation"?
    public interface IOperations
    {
        // TODO неоднозначный enum, непонятно какой из методов 
        // MatrixOperation/MatrixesOperation какие значения поддерживает
        // Det не обрабатывается ни в одном из них
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
        public Matrix MatrixOperation(Matrix matrix, int factor, Operation operation);
        [Obsolete("работает только с MATRIXSUM")]
        public Matrix MatrixesOperation(Matrix matrix, Matrix matrix1, Operation operation);
        public float Det(Matrix matrix);

    }
}
