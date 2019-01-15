using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Stacks_Exercise
{
    class Program
    {

        static void Main(string[] args)
        {
            var inputDimensions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var rows = inputDimensions[0];
            var columns = inputDimensions[1];

            var snake = Console.ReadLine();

            var shot = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] stairs = FillMatrix(snake, rows, columns);

            stairs = FireShot(shot, stairs);

            stairs = Gravity(stairs);

            
        }

        private static char[,] Gravity(char[,] stairs)
        {
            var chars = new Queue<char>();
            var spaceFound = false;
            var refresh = false;
            for (int col = 0; col < stairs.GetLength(1); col++)
            {
                for (int row = stairs.GetLength(0) - 1; row >= 0; row--)
                {
                    if (stairs[row, col] == ' ')
                    {
                        spaceFound = true;
                    }

                    if (spaceFound)
                    {
                        if (stairs[row, col] != ' ')
                        {
                            chars.Enqueue(stairs[row, col]);
                        }
                    }
                }
                spaceFound = false;

                for (int row = stairs.GetLength(0) - 1; row >= 0; row--)
                {
                    if (stairs[row, col] == ' ')
                    {
                        for (int i = row; i >= 0; i--)
                        {
                            stairs[i, col] = ' ';
                        }

                        break;
                    }
                }

                for (int row = stairs.GetLength(0) - 1; row >= 0; row--)
                {
                    if (stairs[row, col] == ' ' && chars.Count > 0)
                    {
                        stairs[row, col] = chars.Dequeue();
                    }
                }
            }

            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    Console.Write(stairs[row, col]);
                }

                Console.WriteLine();
            }

            return stairs;
        }

        private static char[,] FireShot(int[] shot, char[,] stairs)
        {
            var rows = shot[0];
            var columns = shot[1];
            var radius = shot[2];

            for (int row = 0; row < stairs.GetLength(0); row++)
            {
                for (int col = 0; col < stairs.GetLength(1); col++)
                {
                    var a = rows - row;
                    var b = columns - col;

                    double distance = Math.Sqrt(a * a + b * b);

                    if (radius >= distance)
                    {
                        stairs[row, col] = ' ';
                    }
                }
            }

            

            return stairs;
        }

        private static char[,] FillMatrix(string snake, int rows, int columns)
        {
            var matrix = new char[rows, columns];

            bool isGoingLeft = true;
            
            var snakeIndex = 0;

            for (int row = rows - 1; row >= 0; row--)
            {
                var index = isGoingLeft ? matrix.GetLength(1) - 1 : 0;
                var increment = isGoingLeft ? -1 : 1;
                for (int i = 0; i < columns; i++)
                {
                    if (snakeIndex >= snake.Length)
                    {
                        snakeIndex = 0;
                    }
                    matrix[row, index] = snake[snakeIndex];
                    index += increment;
                    snakeIndex++;
                }

                isGoingLeft = !isGoingLeft;
            }

            return matrix;
        }
    }
}