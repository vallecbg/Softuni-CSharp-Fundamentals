using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[0];
            int[,] matrix = CreateMatrix(rows, cols);
            var currCol = 0;
            var leftSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (currCol == matrix.GetLength(1))
                {
                    currCol = 0;
                    break;
                }

                leftSum += matrix[row, currCol];
                currCol++;
            }

            Console.WriteLine(leftSum);
        }

        private static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }
    }
}