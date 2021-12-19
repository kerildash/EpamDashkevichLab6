using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamDashkevichLab6.Models
{
    class ArrayMethods
    {

        public double OddIndexedElementsSum(double[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException("Array is Null");
            }
            if (array.Length <= 1) // no elements => no odd-indexed elements
                                   // 1 element is 0st => no odd-indexed elements
            {
                throw new Exception("No odd-indexed elements");
            }

            double sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 1)
                {
                    sum += array[i];
                }
            }
            return sum;
        }
        public double ProductOfElementsBetweenZeros(double[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException("Array is Null");
            }
            if (array.Length <= 2) // no elements => no zeros
                                   // need for two zeros, so 1-2 elements => no elements between zeros (if zeros even exist)
            {
                throw new Exception("Array with no data to handle");
            }
            int IndexOfFirstZero = Array.FindIndex(array, x => x == 0);
            int IndexOfLastZero = Array.FindLastIndex(array, x => x == 0);
            if (IndexOfFirstZero == -1 || IndexOfLastZero == IndexOfFirstZero
                || IndexOfLastZero == IndexOfFirstZero + 1)
            {
                throw new Exception("Array with no data to handle");
            }
            int betweenZerosLength = (IndexOfLastZero - 1) - (IndexOfFirstZero + 1) + 1;
            double[] betweenZeros = new double[betweenZerosLength];
            Array.Copy(array, IndexOfFirstZero + 1, betweenZeros, 0, betweenZerosLength);

            double product = 1;
            if (Array.FindIndex(betweenZeros, x => x == 0) != -1)
            {
                return product = 0; // 0 in array => prod. = 0 
            }
            foreach (double number in betweenZeros)
            {
                product *= number;
            }
            return product;
        }
        public double NumberOfColumnsWithZero(double[,] matrix)
        {
            if (matrix == null)
            {
                throw new NullReferenceException("Matrix is Null");
            }
            if (matrix.Length == 0)
            {
                throw new Exception("Empty matrix");
            }
            int zeroedColumns = 0;

            for (int j = 0; j <= matrix.GetUpperBound(1); j++)
            {
                bool isZeroed = false;
                for (int i = 0; i <= matrix.GetUpperBound(0); i++)
                {

                    if (matrix[i, j] == 0)
                    {
                        isZeroed = true;
                    }
                }
                if (isZeroed)
                {
                    zeroedColumns++;
                }
            }

            return zeroedColumns;
        }
    }
}
