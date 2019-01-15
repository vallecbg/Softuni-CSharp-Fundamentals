using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[size[0], size[1]];
            for (long row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (long col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var foundSquares = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && 
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        foundSquares++;
                    }
                }
            }
            Console.WriteLine(foundSquares);
            

        }

    }
}
