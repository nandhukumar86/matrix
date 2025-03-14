namespace MatrixCalc
{
    public static class MatrixOperations
    {
        public static double[,] AddMatrices(double[,] matrixA, double[,] matrixB)
        {
            int rows = matrixA.GetLength(0);
            int cols = matrixA.GetLength(1);

            if (rows != matrixB.GetLength(0) || cols != matrixB.GetLength(1))
            {
                throw new ArgumentException("Matrices must have the same dimensions for addition.");
            }

            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }

            return result;
        }   

        public static double[,] MultiplyMatrixWithScalar(double[,] matrix, double scalar)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j] * scalar;
                }
            }

            return result;
        }

        public static double[,] MultiplyMatrixWithVector(double[,] matrix, double[] vector)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols != vector.Length)
            {
                throw new ArgumentException("The number of columns in the matrix must match the length of the vector.");
            }

            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix[i, j] * vector[j];
                }
            }

            return result;
        }

        public static double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            if (colsA != rowsB)
            {
                throw new ArgumentException("Number of columns in matrix A must be equal to number of rows in matrix B.");
            }

            double[,] result = new double[rowsA, colsB];

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

        public static double[,] CustomAddition(double[,] matrixA, double[,] matrixB, double[,] matrixC)
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

            double[,] result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsA; j++)
                {
                    double x = 0; // Example of varying x
                    double y = 0; // Example of varying y

                    (x, y) = CalculateWeights(matrixA[i, j], matrixB[i, j], matrixC[i, j]);

                    result[i, j] = (x * matrixA[i, j]) + (y * ((matrixB[i, j] + matrixC[i, j])/2));
                }
            }

            return result;
        }
        
        public static (double x, double y) CalculateWeights(double a, double b, double c)
        {
            if(a == 0 && b + c > 0)
            {
                return (0, 1);
            }
            else if(a > 0 && b + c == 0)
            {
                return (1, 0);
            }
            else if(a > 0 && b + c > 0)
            {
                return (0.5, 0.5);
            }
            else
            {
                return (0, 0);
            }

        }
        
        public static double[,] ColumnOperations(double[,] matrix, int[][] columnOperations)
        {
            int rows = matrix.GetLength(0);
            int cols = columnOperations.Length;

            double[,] result = new double[rows, cols];

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

        public static double[,] TransposeMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] result = new double[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }
    }
}