using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputRowsAndCols = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[,] matrix = new int[inputRowsAndCols[0], inputRowsAndCols[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var input = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int bestsum = 0;
            var bestrow = 0;
            var bestcol = 0;
            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    var currsum =
                        matrix[rows, cols] +
                        matrix[rows, cols + 1] +
                        matrix[rows + 1, cols] +
                        matrix[rows + 1, cols + 1];
                    if (currsum > bestsum)
                    {
                        bestsum = currsum;
                        bestrow = rows;
                        bestcol = cols;
                    }
                }
            }

            Console.WriteLine(matrix[bestrow, bestcol] + " " + matrix[bestrow, bestcol + 1]);
            Console.WriteLine(matrix[bestrow + 1, bestcol] + " " + matrix[bestrow + 1, bestcol + 1]);
            Console.WriteLine(bestsum);
        }
    }
}
