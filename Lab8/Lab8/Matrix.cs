using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    public static class Matrix
    {
        public static int DotProduct(int[] inVector1, int[] inVector2)
        {
            int sum = 0;

            for (int i = 0; i < inVector1.Length; i++)
            {
                sum += inVector1[i] * inVector2[i];
            }

            return sum;
        }

        public static int[,] Transpose(int[,] inMatrix)
        {
            int[,] transposed = new int[inMatrix.GetLength(1), inMatrix.GetLength(0)];

            for (int i = 0; i <= inMatrix.GetUpperBound(0); i++)
            {
                for (int k = 0; k <= inMatrix.GetUpperBound(1); k++)
                {
                    transposed.SetValue(inMatrix.GetValue(i, k), k, i);
                }
            }

            return transposed;
        }

        public static int[,] GetIdentityMatrix(int size)
        {
            int[,] identityMatrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                identityMatrix.SetValue(1, i, i);
            }

            return identityMatrix;
        }

        public static int[] GetRowOrNull(int[,] inMatrix, int rowIndex)
        {
            if (rowIndex < 0 || inMatrix.GetUpperBound(0) < rowIndex)
            {
                return null;
            }

            int[] row = new int[inMatrix.GetLength(1)];

            for (int i = 0; i < row.Length; i++)
            {
                row[i] = inMatrix[rowIndex, i];
            }

            return row;
        }

        public static int[] GetColumnOrNull(int[,] inMatrix, int columnIndex)
        {
            if (columnIndex < 0 || inMatrix.GetUpperBound(1) < columnIndex)
            {
                return null;
            }

            int[] column = new int[inMatrix.GetLength(0)];

            for (int i = 0; i < column.Length; i++)
            {
                column[i] = inMatrix[i, columnIndex];
            }

            return column;
        }

        public static int[] MultiplyMatrixVectorOrNull(int[,] inMatrix, int[] inVector)
        {
            if (inMatrix.GetLength(1) != inVector.Length)
            {
                return null;
            }

            int[] product = new int[inMatrix.GetLength(0)];

            for (int i = 0; i <= inMatrix.GetUpperBound(0); i++)
            {
                for (int k = 0; k <= inMatrix.GetUpperBound(1); k++)
                {
                    product[i] += inMatrix[i, k] * inVector[k];
                }
            }

            return product;
        }

        public static int[] MultiplyVectorMatrixOrNull(int[] inVector, int[,] inMatrix)
        {
            if (inVector.Length != inMatrix.GetLength(0))
            {
                return null;
            }

            int[] product = new int[inMatrix.GetLength(1)];

            for (int i = 0; i <= inMatrix.GetUpperBound(1); i++)
            {
                for (int k = 0; k <= inMatrix.GetUpperBound(0); k++)
                {
                    product[i] += inVector[k] * inMatrix[k, i];
                }
            }

            return product;
        }

        public static int[,] MultiplyOrNull(int[,] inMatrix1, int[,] inMatrix2)
        {
            if (inMatrix1.GetLength(1) != inMatrix2.GetLength(0))
            {
                return null;
            }

            int[,] product = new int[inMatrix1.GetLength(0), inMatrix2.GetLength(1)];

            for (int i = 0; i <= inMatrix1.GetUpperBound(0); i++)
            {
                var row = GetRowOrNull(inMatrix1, i);

                for (int k = 0; k <= inMatrix2.GetUpperBound(1); k++)
                {
                    var column = GetColumnOrNull(inMatrix2, k);
                    product[i, k] = DotProduct(row, column);
                }
            }

            return product;
        }

    }
}
