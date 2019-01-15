using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[]{' '},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputRow = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            var sum = 0;
            var bestrow = 0;
            var bestcol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var currSum =
                        matrix[row, col] +
                        matrix[row, col + 1] +
                        matrix[row, col + 2] +
                        matrix[row + 1, col] +
                        matrix[row + 1, col + 1] +
                        matrix[row + 1, col + 2] +
                        matrix[row + 2, col] +
                        matrix[row + 2, col + 1] +
                        matrix[row + 2, col + 2];
                    if (currSum > sum)
                    {
                        sum = currSum;
                        bestrow = row;
                        bestcol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            Console.WriteLine(matrix[bestrow, bestcol] + " " +
                              matrix[bestrow, bestcol + 1] + " " +
                              matrix[bestrow, bestcol + 2] + " ");
            Console.WriteLine(matrix[bestrow + 1, bestcol] + " " +
                              matrix[bestrow + 1, bestcol + 1] + " " +
                              matrix[bestrow + 1, bestcol + 2] + " ");
            Console.WriteLine(matrix[bestrow + 2, bestcol] + " " +
                              matrix[bestrow + 2, bestcol + 1] + " " +
                              matrix[bestrow + 2, bestcol + 2]);

        }
    }
}
