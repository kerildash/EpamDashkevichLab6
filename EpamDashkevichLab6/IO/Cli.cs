using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamDashkevichLab6.Models;


namespace EpamDashkevichLab6.IO
{
    class Cli
    {
        ArrayMethods methods = new ArrayMethods();
        public void Menu()
        {
            bool isExit = false;
            while (!isExit)
            {
                try
                {
                    Console.WriteLine("\n   MENU");
                    Console.WriteLine("1. Sum of elements in array with odd indexes.");
                    Console.WriteLine("2. Product of elenents between last and first zero in array.");
                    Console.WriteLine("3. Number of columns with at least one zero.");
                    Console.WriteLine("4. Cinema.");
                    Console.WriteLine("0. Exit.");
                    Console.Write("Choose what to do: ");
                    int menuItem = int.Parse(Console.ReadLine());
                    
                    switch (menuItem)
                    {
                        case 1:
                            OddIndexedElementsSum();
                            break;
                        case 2:
                            ProductOfElementsBetweenZeros();
                            break;
                        case 3:
                            NumberOfColumnsWithZero();
                            break;
                        case 4:
                            throw new NotImplementedException();
                        case 0:
                            isExit = true;
                            break;
                        default:
                            Console.WriteLine("Incorrect input");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }
        }
        public void OddIndexedElementsSum()
        {
            double[] array = InputArray();
            double sum = methods.OddIndexedElementsSum(array);
            Console.WriteLine($"Sum of elements with odd indexes: {sum}");
        }
        public void ProductOfElementsBetweenZeros()
        {
            double[] array = InputArray();
            double product = methods.ProductOfElementsBetweenZeros(array);
            Console.WriteLine($"Product of elenents between last and first zero: {product}");
        }
        public void NumberOfColumnsWithZero()
        {
            double[,] matrix = InputMatrix();
            double result = methods.NumberOfColumnsWithZero(matrix);
            Console.WriteLine($"Number of columns with zero: {result}");
        }
        public double[] InputArray()
        {
            int length;
            double[] array;

            Console.Write("Enter length of array: ");
            length = int.Parse(Console.ReadLine());
            array = new double[length];

            Console.WriteLine("Enter elements of array.");
            for (int i = 0; i< array.Length; i++)
            {
                Console.Write($"{i}: ");
                array[i] = double.Parse(Console.ReadLine());
            }

            return array;
        }
        public double[,] InputMatrix()
        {
            int numberOfRows;
            int numberOfColumns;
            double[,] matrix;

            Console.Write("Enter number of rows: ");
            numberOfRows = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns: ");
            numberOfColumns = int.Parse(Console.ReadLine());

            matrix = new double[numberOfRows,numberOfColumns];

            Console.WriteLine("\nInput of matrix.\n");
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                Console.WriteLine($"Enter elements of {i}th row.");
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    Console.Write($"[{i},{j}]: ");
                    matrix[i,j] = double.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }

            return matrix;
        }
    }
}
