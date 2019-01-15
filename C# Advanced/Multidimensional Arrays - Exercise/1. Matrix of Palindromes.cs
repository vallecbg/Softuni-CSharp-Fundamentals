using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputRows = input[0];
            var inputCols = input[1];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string[,] matrix = new string[inputRows, inputCols];
            for (int row = 0; row < inputRows; row++)
            {
                var middleChar = row;
                for (int col = 0; col < inputCols; col++)
                {
                  matrix[row, col] = alphabet[row].ToString() + alphabet[middleChar].ToString() + alphabet[row].ToString();
                    middleChar++;
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }

            
        }
    }
}
