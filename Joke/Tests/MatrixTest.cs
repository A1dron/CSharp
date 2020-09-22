using Joke.ProjectMatrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {

    [TestClass]
    public class MatrixTest {

        [TestMethod]
        public void shouldSucccessCreateMatrix() {
            Matrix matrix = new Matrix();

            Assert.AreEqual(7, matrix.rows);
            Assert.AreEqual(7, matrix.columns);
        }

        [TestMethod]
        public void shouldSuccessSummaryTwoMatrix() {
            Matrix first = new Matrix(3, 3);
            Matrix second = new Matrix(3, 3);

            Matrix result = first.MatrixesOperation(first, second, IOperations.Operation.MATRIXSUM);
            Assert.AreEqual(result.GetElement(0, 0), first.GetElement(0, 0) + second.GetElement(0, 0));
            Assert.AreEqual(result.GetElement(0, 1), first.GetElement(0, 1) + second.GetElement(0, 1));
            Assert.AreEqual(result.GetElement(0, 2), first.GetElement(0, 2) + second.GetElement(0, 2));
        }
    }
}
