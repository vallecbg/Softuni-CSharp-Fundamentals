using System;
using System.Collections;
using System.Linq;

namespace Miner
{
    class Program
    {
        public static int minerRow;
        public static int minerCol;
        public static bool gameOver;
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var directionsInput = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var directions = new Queue(directionsInput);
            var matrix = CreateJagged(n);
            FindStartingPosition(matrix);
            gameOver = false;
            while (true)
            {
                var currDirection = directions.Dequeue();
                switch (currDirection)
                {
                    case "left":
                        MoveLeft(matrix);
                        break;
                    case "right":
                        MoveRight(matrix);
                        break;
                    case "up":
                        MoveUp(matrix);
                        break;
                    case "down":
                        MoveDown(matrix);
                        break;
                }
                if (CheckCoals(matrix) || gameOver)
                {
                    return;
                }

                if (directions.Count == 0)
                {
                    CheckCoalsAvailable(matrix);
                    return;
                }
            }
        }

        private static void MoveDown(char[,] matrix)
        {
            if (IsInside(matrix, minerRow + 1, minerCol))
            {
                if (CheckCoals(matrix))
                {
                    Console.WriteLine($"You collected all coals! ({minerRow + 1}, {minerCol})");
                    return;
                }
                if (matrix[minerRow + 1, minerCol] == 'e')
                {
                    gameOver = true;
                    Console.WriteLine($"Game over! ({minerRow + 1}, {minerCol})");
                    return;
                }
                if (matrix[minerRow + 1, minerCol] == '*' ||
                    matrix[minerRow + 1, minerCol] == 'c')
                {
                    matrix[minerRow, minerCol] = '*';
                    matrix[minerRow + 1, minerCol] = 's';
                }

                if (CheckCoals(matrix))
                {
                    Console.WriteLine($"You collected all coals! ({minerRow + 1}, {minerCol})");
                    return;
                }
                if (matrix[minerRow + 1, minerCol] == 'e')
                {
                    gameOver = true;
                    Console.WriteLine($"Game over! ({minerRow + 1}, {minerCol})");
                    return;
                }

                minerRow++;
            }
        }

        private static void MoveUp(char[,] matrix)
        {
            if (IsInside(matrix, minerRow - 1, minerCol))
            {
                if (CheckCoals(matrix))
                {
                    Console.WriteLine($"You collected all coals! ({minerRow - 1}, {minerCol})");
                    return;
                }
                if (matrix[minerRow - 1, minerCol] == 'e')
                {
                    gameOver = true;
                    Console.WriteLine($"Game over! ({minerRow - 1}, {minerCol})");
                    return;
                }
                if (matrix[minerRow - 1, minerCol] == '*' ||
                    matrix[minerRow - 1, minerCol] == 'c')
                {
                    matrix[minerRow, minerCol] = '*';
                    matrix[minerRow - 1, minerCol] = 's';
                }

                if (CheckCoals(matrix))
                {
                    Console.WriteLine($"You collected all coals! ({minerRow - 1}, {minerCol})");
                    return;
                }
                if (matrix[minerRow - 1, minerCol] == 'e')
                {
                    gameOver = true;
                    Console.WriteLine($"Game over! ({minerRow - 1}, {minerCol})");
                    return;
                }

                minerRow--;
            }
        }

        private static void MoveRight(char[,] matrix)
        {
            if (IsInside(matrix, minerRow, minerCol + 1))
            {
                if (CheckCoals(matrix))
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol + 1})");
                    return;
                }
                if (matrix[minerRow, minerCol + 1] == 'e')
                {
                    gameOver = true;
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol + 1})");
                    return;
                }
                if (matrix[minerRow, minerCol + 1] == '*' ||
                    matrix[minerRow, minerCol + 1] == 'c')
                {
                    matrix[minerRow, minerCol] = '*';
                    matrix[minerRow, minerCol + 1] = 's';
                }

                if (CheckCoals(matrix))
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol + 1})");
                    return;
                }
                if (matrix[minerRow, minerCol + 1] == 'e')
                {
                    gameOver = true;
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol + 1})");
                    return;
                }

                minerCol++;
            }
        }

        private static void CheckCoalsAvailable(char[,] matrix)
        {
            var coalsCount = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }

            Console.WriteLine($"{coalsCount} coals left. ({minerRow}, {minerCol})");
        }

        private static void MoveLeft(char[,] matrix)
        {
            if (IsInside(matrix, minerRow, minerCol - 1))
            {
                if (CheckCoals(matrix))
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol - 1})");
                    return;
                }
                if (matrix[minerRow, minerCol - 1] == 'e')
                {
                    gameOver = true;
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol - 1})");
                    return;
                }
                if (matrix[minerRow, minerCol - 1] == '*' ||
                    matrix[minerRow, minerCol - 1] == 'c')
                {
                    matrix[minerRow, minerCol] = '*';
                    matrix[minerRow, minerCol - 1] = 's';
                }

                if (CheckCoals(matrix))
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol - 1})");
                    return;
                }
                if (matrix[minerRow, minerCol - 1] == 'e')
                {
                    gameOver = true;
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol - 1})");
                    return;
                }

                minerCol--;
            }
        }

        private static bool CheckCoals(char[,] matrix)
        {
            var coalsCount = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                }
            }

            if (coalsCount == 0)
            {
                return true;
            }

            return false;

        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                   col >= 0 && col < matrix.GetLength(1);
        }

        private static void FindStartingPosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                        break;
                    }
                }
            }
        }

        private static char[,] CreateJagged(long rowsInput)
        {
            char[,] matrix = new char[rowsInput, rowsInput];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var counter = 0;
                    foreach (var i1 in input)
                    {
                        if (i1 != ' ')
                        {
                            matrix[row, counter] = i1;
                            counter++;
                        }
                    }
                }
            }

            return matrix;
        }
    }
}
