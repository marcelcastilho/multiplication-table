using System;

namespace MultiplicationTable.Models {
    public class Multiplyer : IMultiplyer {
        public string[][] GetMultiplicationTable(int matrixSize = 10, MatrixBase matrixBase = MatrixBase.Decimal) {
            if (matrixSize < 3 || matrixSize > 15) {
                throw new ArgumentException($"Matrix size {matrixSize} is invalid");
            }
            var matrix = new string[matrixSize][];
            for (var i = 0; i < matrixSize; i++) {
                var rows = new string[matrixSize];
                for (var j = 0; j < matrixSize; j++) {
                    rows[j] = Multiply(i, j, matrixBase);
                }
                matrix[i] = rows;
            }
            return matrix;
        }

        private static string Multiply(int i, int j, MatrixBase matrixBase) {
            var value = (i + 1) * (j + 1);
            switch (matrixBase) {
                case MatrixBase.Binary:
                    return Convert.ToString(value, 2).PadLeft(8, '0');
                case MatrixBase.Hex:
                    return Convert.ToString(value, 16).ToUpper();
                default:
                    return value.ToString();
            }
        }
    }
}
