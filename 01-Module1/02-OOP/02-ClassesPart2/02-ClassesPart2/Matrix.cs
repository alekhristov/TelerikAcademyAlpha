using Bytes2you.Validation;
using System;

namespace _02_ClassesPart2
{
    class Matrix<T>
    {
        private T[,] matrix;

        public Matrix(int totalRows, int totalCols)
        {
            this.matrix = new T[totalRows, totalCols];
        }

        public T this[int row, int col]
        {
            get
            {
                return this.matrix[row, col];
            }
            set
            {
                Guard.WhenArgument(row, "Row index is invalid!").IsLessThan(0).IsGreaterThan(matrix.GetLength(0) - 1).Throw();
                Guard.WhenArgument(row, "Col index is invalid!").IsLessThan(0).IsGreaterThan(matrix.GetLength(1) - 1).Throw();
                this.matrix[row, col] = value;
            }
        }

        public int TotalRows
        {
            get
            {
                return this.matrix.GetLength(0);
            }
        }
        public int TotalCols
        {
            get
            {
                return this.matrix.GetLength(1);
            }
        }

        public static T[,] operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Guard.WhenArgument(matrix1.TotalRows, "Matrixes are not with the same size!").IsNotEqual(matrix2.TotalRows).Throw();
            Guard.WhenArgument(matrix1.TotalCols, "Matrixes are not with the same size!").IsNotEqual(matrix2.TotalCols).Throw();

            var newMatrix = new T[matrix1.TotalRows, matrix1.TotalCols];

            for (int row = 0; row < matrix1.TotalRows; row++)
            {
                for (int col = 0; col < matrix1.TotalCols; col++)
                {
                    if ((!char.IsDigit(char.Parse(matrix1[row, col].ToString()))) && !char.IsDigit(char.Parse(matrix2[row, col].ToString())))
                    {
                        throw new InvalidOperationException("Can not perform this operation!");
                    }
                    newMatrix[row, col] = (dynamic)matrix1[row, col] + matrix2[row, col];
                }
            }
            return newMatrix;
        }
        public static T[,] operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Guard.WhenArgument(matrix1.TotalRows, "Matrixes are not with the same size!").IsNotEqual(matrix2.TotalRows).Throw();
            Guard.WhenArgument(matrix1.TotalCols, "Matrixes are not with the same size!").IsNotEqual(matrix2.TotalCols).Throw();

            var newMatrix = new T[matrix1.TotalRows, matrix1.TotalCols];

            for (int row = 0; row < matrix1.TotalRows; row++)
            {
                for (int col = 0; col < matrix1.TotalCols; col++)
                {
                    if ((!char.IsDigit(char.Parse(matrix1[row, col].ToString()))) && !char.IsDigit(char.Parse(matrix2[row, col].ToString())))
                    {
                        throw new InvalidOperationException("Can not perform this operation!");
                    }
                    newMatrix[row, col] = (dynamic)matrix1[row, col] - matrix2[row, col];
                }
            }
            return newMatrix;
        }
        public static T[,] operator *(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            Guard.WhenArgument(matrix1.TotalRows, "Matrixes are not with the same size!").IsNotEqual(matrix2.TotalRows).Throw();
            Guard.WhenArgument(matrix1.TotalCols, "Matrixes are not with the same size!").IsNotEqual(matrix2.TotalCols).Throw();

            var newMatrix = new T[matrix1.TotalRows, matrix1.TotalCols];

            for (int row = 0; row < matrix1.TotalRows; row++)
            {
                for (int col = 0; col < matrix1.TotalCols; col++)
                {
                    if ((!char.IsDigit(char.Parse(matrix1[row, col].ToString()))) && !char.IsDigit(char.Parse(matrix2[row, col].ToString())))
                    {
                        throw new InvalidOperationException("Can not perform this operation!");
                    }
                    newMatrix[row, col] = (dynamic)matrix1[row, col] * matrix2[row, col];
                }
            }
            return newMatrix;
        }

        //public static bool operator true(Matrix<int> matrix1)
        //{
        //    for (int row = 0; row < matrix1.TotalRows; row++)
        //    {
        //        for (int col = 0; col < matrix1.TotalCols; col++)
        //        {
        //            if ((!char.IsDigit(char.Parse(matrix1[row, col].ToString()))))
        //            {
        //                throw new InvalidOperationException("Can not perform this operation!");
        //            }
        //            if ((matrix1[row, col] != 0))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

    }
}
