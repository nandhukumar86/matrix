using System;

namespace MatrixCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            double[,] A = new double[3, 4];
            double[,] B = new double[3, 4];
            double[,] C = new double[3, 4];
            double scalar = 0.75;
            double[] vector = new double[] { 1, 2, 3, 4 };
            double[,] D = new double[4, 1];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    A[i, j] = i + j;
                    B[i, j] = i + j;
                    C[i, j] = i + j;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                D[i, 0] = i;
            }

            int[][] jaggedArray = new int[2][];
            jaggedArray[0] = new int[] { 0, 1, 2 };
            jaggedArray[1] = new int[] { 3 };


            Console.WriteLine("--------------------");
            PrintMatrix(MatrixOperations.AddMatrices(A, B));
            Console.WriteLine("--------------------");
            PrintMatrix(MatrixOperations.MultiplyMatrixWithScalar(A, scalar));
            Console.WriteLine("--------------------");
            PrintMatrix(MatrixOperations.MultiplyMatrixWithVector(A, vector));
            Console.WriteLine("--------------------");
            PrintMatrix(MatrixOperations.MultiplyMatrices(A, D));
            Console.WriteLine("--------------------");
            PrintMatrix(MatrixOperations.CustomAddition(A, B, C));
            Console.WriteLine("--------------------");
            PrintMatrix(MatrixOperations.ColumnOperations(A, jaggedArray));

        }

        static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        
    }
}