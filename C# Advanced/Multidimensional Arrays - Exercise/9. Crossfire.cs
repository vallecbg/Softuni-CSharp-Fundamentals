using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputParameters = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = inputParameters[0];
            var cols = inputParameters[1];
            var matrix = new int[rows][];

            FillMatrix(matrix, rows, cols);

            string input;
            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                var shot = input.Split().Select(int.Parse).ToArray();
                var shotRow = shot[0];
                var shotCol = shot[1];
                var shotRadius = shot[2];

                matrix = DestroyMatrix(matrix, shotRow, shotCol, shotRadius);
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }

        private static int[][] DestroyMatrix(int[][] matrix, int hitRow, int hitCol, int hitWave)
        {
            for (int row = hitRow - hitWave; row <= hitRow + hitWave; row++)
            {
                if (IsInMatrix(row, hitCol, matrix))
                {
                    matrix[row][hitCol] = -1;
                }
            }
            for (int col = hitCol - hitWave; col <= hitCol + hitWave; col++)
            {
                if (IsInMatrix(hitRow, col, matrix))
                {
                    matrix[hitRow][col] = -1;
                }
            }
            
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] < 0)
                    {
                        matrix[i] = matrix[i].Where(n => n > 0).ToArray();
                        break;
                    }
                }
                if (matrix[i].Count() < 1)
                {
                    matrix = matrix.Take(i).Concat(matrix.Skip(i + 1)).ToArray();
                    i--;
                }
            }

            return matrix;
        }

        private static int[][] FillMatrix(int[][] jagged, int rows, int cols)
        {
            var count = 1;
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                jagged[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    jagged[row][col] = count;
                    count++;
                }
            }

            return jagged;
        }
        private static bool IsInMatrix(int row, int col, int[][] matrix)
        {
            return row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length;
        }
    }
}
