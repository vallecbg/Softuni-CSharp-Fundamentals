using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = dimestions[0];
            int col = dimestions[1];

            int[,] matrix = new int[row, col];

            int value = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoDimensions = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilDimensions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int evilRow = evilDimensions[0];
                int evilCol = evilDimensions[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilCol >= 0 && evilCol < matrix.GetLength(1))
                    {
                        matrix[evilRow, evilCol] = 0;
                    }
                    evilRow--;
                    evilCol--;
                }

                int ivoRow = ivoDimensions[0];
                int ivoCol = ivoDimensions[1];

                while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
                {
                    if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoCol >= 0 && ivoCol < matrix.GetLength(1))
                    {
                        sum += matrix[ivoRow, ivoCol];
                    }

                    ivoCol++;
                    ivoRow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}
