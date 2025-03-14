namespace MatrixCalc
{
    public class MatrixOperations
    {
        public static int[,] AddMatrices(int[,] matrixA, int[,] matrixB)
        {
            int rows = matrixA.GetLength(0);
            int cols = matrixA.GetLength(1);

            if (rows != matrixB.GetLength(0) || cols != matrixB.GetLength(1))
            {
                throw new ArgumentException("Matrices must have the same dimensions for addition.");
            }

            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return result;
        }

        public static int[,] MultiplyMatrixWithScalar(int[,] matrix, int scalar)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }

            return result;
        }

        public static int[,] MultiplyMatrixWithVector(int[,] matrix, int[] vector)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols != vector.Length)
            {
                throw new ArgumentException("The number of columns in the matrix must match the length of the vector.");
            }

            int[,] result = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j] * vector[j];
                }
            }

            return result;
        }

        public static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            if (colsA != rowsB)
            {
                throw new ArgumentException("Number of columns in matrix A must be equal to number of rows in matrix B.");
            }

            int[,] result = new int[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }

        public static int[,] CustomAddition(int[,] matrixA, int[,] matrixB, int[,] matrixC)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);
            int rowsC = matrixC.GetLength(0);
            int colsC = matrixC.GetLength(1);

            if (rowsA != rowsB || rowsA != rowsC || colsA != colsB || colsA != colsC)
            {
            throw new ArgumentException("All matrices must have the same dimensions.");
            }

            int[,] result = new int[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    int x = i + j; // Example of varying x
                    int y = i - j; // Example of varying y
                    result[i, j] = (x * matrixA[i, j]) + (y * (matrixB[i, j] + matrixC[i, j]));
                }
            }

            return result;
        }
        
        public static int[,] ColumnOperations(int[,] matrix, int[][] columnOperations)
        {
            int rows = matrix.GetLength(0);
            int cols = columnOperations.Length;

            int[,] result = new int[rows, cols];

            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    result[i, j] = 0;
                    foreach (int index in columnOperations[j])
                    {
                        if (index >= 0 && index < matrix.GetLength(1))
                        {
                            result[i, j] += matrix[i, index];
                        }
                        else
                        {
                            throw new ArgumentException("Index out of bounds in column operations.");
                        }
                    }
                }
            }

            return result;
        }
    }
}