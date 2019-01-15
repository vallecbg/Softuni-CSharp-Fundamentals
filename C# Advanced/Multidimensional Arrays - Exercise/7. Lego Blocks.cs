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
            var length = int.Parse(Console.ReadLine());
            var jagged1 = new int[length][];
            var jagged2 = new int[length][];
            FillMatrix(jagged1, jagged2);
            CalculateAndPrint(jagged1, jagged2);
        }

        private static void CalculateAndPrint(int[][] jagged1, int[][] jagged2)
        {
            var maxLength = jagged1[0].Length + jagged2[0].Length;
            var unsymetric = false;
            for (int row = 1; row < jagged1.GetLength(0); row++)
            {
                if (maxLength != jagged1[row].Length + jagged2[row].Length)
                {
                    unsymetric = true;
                }
            }
            if (unsymetric)
            {
                var cells = 0;
                for (int row = 0; row < jagged1.GetLength(0); row++)
                {
                    for (int col = 0; col < jagged1[row].Length; col++)
                    {
                        cells++;
                    }
                }

                for (int row = 0; row < jagged2.GetLength(0); row++)
                {
                    for (int col = 0; col < jagged2[row].Length; col++)
                    {
                        cells++;
                    }
                }

                Console.WriteLine($"The total number of cells is: {cells}");
            }
            else
            {
                for (int row = 0; row < jagged1.GetLength(0); row++)
                {
                    Console.WriteLine("[" + string.Join(", ", jagged1[row]) + ", " +
                                      string.Join(", ", jagged2[row].Reverse()) + "]");
                }

                return;
            }
        }

        private static void FillMatrix(int[][] jagged1, int[][] jagged2)
        {
            for (int row = 0; row < jagged1.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                jagged1[row] = input;
            }

            for (int row = 0; row < jagged2.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                jagged2[row] = input;
            }
        }
    }
}
