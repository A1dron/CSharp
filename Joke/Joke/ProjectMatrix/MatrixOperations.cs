using System;

namespace Joke.ProjectMatrix {

    //TODO в будущем по хорошему бы выделить постоянные итерации по значениям
    //     в отдельный Action/Func с передачей функции (лямбда) 
    public class MatrixOperations : IOperations {


        #region пересчитать детерминант
        public float Det(Matrix matrix) {
            //float det = 0;
            if (matrix.Length() == 4)
                return (matrix.GetElement(0, 0) * matrix.GetElement(1, 1) - matrix.GetElement(0, 1) * matrix.GetElement(1, 0));
            float sign = 1, result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++) {
                Matrix minor = GetMinor(matrix, i);
                result += sign * matrix.GetElement(0, i) * Det(minor);
                sign = -sign;

            }
            return result;
        }
        #endregion

        private static Matrix GetMinor(Matrix matrix, int n) {
            Matrix minor = new Matrix(matrix.rows - 1, matrix.columns - 1);
            for (int i = 1; i < matrix.rows; i++) {
                for (int j = 0; j < n; j++) {
                    minor.SetElement(i - 1, j, matrix.GetElement(i, j));
                }
            }
            for (int i = 1; i < matrix.rows; i++) {
                for (int j = n + 1; j < matrix.columns; j++) {
                    minor.SetElement(i - 1, j - 1, matrix.GetElement(i, j));
                }
            }
            return minor;

        }

        [Obsolete("работает только с MATRIXSUM")]
        public Matrix MatrixesOperation(Matrix matrix, Matrix matrix1, IOperations.Operation operation) {
            Matrix result = new Matrix(matrix);
            switch (operation) {
                case IOperations.Operation.MATRIXSUM:
                    for (int i = 0; i < matrix.rows; i++) {
                        for (int j = 0; j < matrix.columns; j++) {

                            result.SetElement(i, j, matrix.GetElement(i, j) + matrix1.GetElement(i, j));
                        }
                    }
                    break;
            }
            return result;
        }

        [Obsolete("работает только с MULTIPLY/SUM")]
        public Matrix MatrixOperation(Matrix matrix, int factor, IOperations.Operation operation) {
            Matrix copy = new Matrix(matrix);
            switch (operation) {
                case IOperations.Operation.MULTIPLY:
                    for (int i = 0; i < copy.rows; i++) {
                        for (int j = 0; j < copy.columns; j++) {
                            copy.SetElement(i, j, copy.GetElement(i, j) * factor);
                        }
                    }
                    break;

                case IOperations.Operation.SUM:
                    for (int i = 0; i < copy.rows; i++) {
                        for (int j = 0; j < copy.columns; j++) {
                            copy.SetElement(i, j, copy.GetElement(i, j) + factor);
                        }
                    }
                    break;

            }
            return copy;
        }

        public float MaxElement(Matrix matrix) {
            float max = int.MinValue;
            for (int i = 0; i < matrix.rows; i++) {
                for (int j = 0; j < matrix.columns; j++) {
                    if (matrix.GetElement(i, j) > max) {
                        max = matrix.GetElement(i, j);
                    }
                }
            }
            return max;
        }

        public float MinElement(Matrix matrix) {
            float min = int.MaxValue;
            for (int i = 0; i < matrix.rows; i++) {
                for (int j = 0; j < matrix.columns; j++) {
                    if (matrix.GetElement(i, j) < min) {
                        min = matrix.GetElement(i, j);
                    }
                }
            }
            return min;
        }


    }
}
