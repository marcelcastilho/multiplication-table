namespace MultiplicationTable.Models {
    public interface IMultiplyer {
        string[][] GetMultiplicationTable(int matrixSize = 10, MatrixBase matrixBase = MatrixBase.Decimal);
    }
}
