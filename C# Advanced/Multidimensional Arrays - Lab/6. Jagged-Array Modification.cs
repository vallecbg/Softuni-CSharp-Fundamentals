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
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var info = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var command = info[0];
                var searchedRow = int.Parse(info[1]);
                var searchedCol = int.Parse(info[2]);
                var value = int.Parse(info[3]);
                switch (command)
                {
                    case "Add":
                        if (CheckMatrix(matrix, searchedRow, searchedCol))
                        {
                            break;
                        }
                        if (searchedRow < matrix.GetLength(0))
                        {
                            if (searchedCol < matrix.GetLength(1))
                            {
                                matrix[searchedRow, searchedCol] += value;
                            }
                            else
                            {
                                Console.WriteLine("Invalid coordinates");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        break;
                    case "Subtract":
                        if (CheckMatrix(matrix, searchedRow, searchedCol))
                        {
                            break;
                        }
                        if (searchedRow < matrix.GetLength(0))
                        {
                            if (searchedCol < matrix.GetLength(1))
                            {
                                matrix[searchedRow, searchedCol] -= value;
                            }
                            else
                            {
                                Console.WriteLine("Invalid coordinates");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        break;
                }
            }
            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool CheckMatrix(int[,] matrix, int searchedRow, int searchedCol)
        {
            if (searchedRow < 0 || searchedRow >= matrix.GetLength(0) ||
                searchedCol < 0 || searchedCol >= matrix.GetLength(1))
            {
                Console.WriteLine("Invalid coordinates");
                return true;
            }

            return false;
        }

        private static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine()
                    .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            return matrix;
        }
    }
}