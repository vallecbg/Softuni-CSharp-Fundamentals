using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var jagged = CreateJagged();
            var directions = ReadDirections();
            var startingRow = GetStartingRow(jagged);
            var length = directions.Count;
            for (int i = 0; i < length; i++)
            {
                MovePatrols(jagged, startingRow);
                CheckPatrols(jagged);
                var currDirection = directions.Dequeue();
                switch (currDirection)
                {
                    case 'U':
                        MoveUp(jagged);
                        break;
                    case 'D':
                        MoveDown(jagged);
                        break;
                    case 'L':
                        MoveLeft(jagged);
                        break;
                    case 'R':
                        MoveRight(jagged);
                        break;
                    case 'W':
                        break;
                }

                if (CheckNikoladze(jagged))
                {
                    return;
                }
            }

        }
        //Nikoladze
        private static bool CheckNikoladze(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                if (jagged[row].Contains('S') && jagged[row].Contains('N'))
                {
                    var nikoladzeIndex = Array.IndexOf(jagged[row], 'N');
                    jagged[row][nikoladzeIndex] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    PrintMatrix(jagged);
                    return true;
                }
            }

            return false;
        }

        //Moves
        private static void MoveRight(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                if (jagged[row].Contains('S'))
                {
                    var sIndex = Array.IndexOf(jagged[row], 'S');
                    jagged[row][sIndex] = '.';
                    jagged[row][sIndex + 1] = 'S';
                    break;
                }
            }
        }

        private static void MoveLeft(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                if (jagged[row].Contains('S'))
                {
                    var sIndex = Array.IndexOf(jagged[row], 'S');
                    jagged[row][sIndex] = '.';
                    jagged[row][sIndex - 1] = 'S';
                    break;
                }
            }
        }

        private static void MoveDown(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                if (jagged[row].Contains('S'))
                {
                    var sIndex = Array.IndexOf(jagged[row], 'S');
                    jagged[row][sIndex] = '.';
                    jagged[row + 1][sIndex] = 'S';
                    break;
                }
            }
        }

        private static void MoveUp(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                if (jagged[row].Contains('S'))
                {
                    var sIndex = Array.IndexOf(jagged[row], 'S');
                    jagged[row][sIndex] = '.';
                    jagged[row - 1][sIndex] = 'S';
                    break;
                }
            }
        }



        //Patrols//
        private static void CheckPatrols(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                if (jagged[row].Contains('S'))
                {
                    var sIndex = Array.IndexOf(jagged[row], 'S');
                    if (jagged[row].Contains('b'))
                    {
                        var bIndex = Array.IndexOf(jagged[row], 'b');
                        if (bIndex < sIndex)
                        {
                            jagged[row][sIndex] = 'X';
                            Console.WriteLine($"Sam died at {row}, {sIndex}");
                            PrintMatrix(jagged);
                            return;
                        }
                    }

                    if (jagged[row].Contains('d'))
                    {
                        var dIndex = Array.IndexOf(jagged[row], 'd');
                        if (sIndex < dIndex)
                        {
                            jagged[row][sIndex] = 'X';
                            Console.WriteLine($"Sam died at {row}, {sIndex}");
                            PrintMatrix(jagged);
                            return;
                        }
                    }
                }
            }
        }
        private static void MovePatrols(char[][] jagged, int startingRow)
        {
            if (startingRow == 0)
            {
                for (int row = startingRow; row < jagged.GetLength(0); row++)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        if (jagged[row][col] == 'b')
                        {
                            if (col + 1 <= jagged[row].Length - 1)
                            {
                                jagged[row][col] = '.';
                                jagged[row][col + 1] = 'b';
                            }

                            if (col + 1 == jagged[row].Length)
                            {
                                jagged[row][col] = 'd';
                            }

                            break;
                        }

                        if (jagged[row][col] == 'd')
                        {
                            if (col - 1 >= 0)
                            {
                                jagged[row][col] = '.';
                                jagged[row][col - 1] = 'd';
                            }

                            if (col - 1 == -1)
                            {
                                jagged[row][col] = 'b';
                            }

                            break;
                        }
                    }
                }
            }
            else
            {
                for (int row = startingRow; row >= 0; row--)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        if (jagged[row][col] == 'b')
                        {
                            if (col + 1 <= jagged[row].Length - 1)
                            {
                                jagged[row][col] = '.';
                                jagged[row][col + 1] = 'b';
                            }

                            if (col + 1 == jagged[row].Length)
                            {
                                jagged[row][col] = 'd';
                            }

                            break;
                        }

                        if (jagged[row][col] == 'd')
                        {
                            if (col - 1 >= 0)
                            {
                                jagged[row][col] = '.';
                                jagged[row][col - 1] = 'd';
                            }

                            if (col - 1 == -1)
                            {
                                jagged[row][col] = 'b';
                            }

                            break;
                        }
                    }
                }
            }
        }



        //*********************************************//
        private static int GetStartingRow(char[][] jagged)
        {
            int samRow = 0;
            int nikoladzeRow = 0;
            int startingRow;
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                if (jagged[row].Contains('S'))
                {
                    samRow = row;
                }

                if (jagged[row].Contains('N'))
                {
                    nikoladzeRow = row;
                }
            }
            if (samRow - nikoladzeRow >= 0)
            {
                startingRow = 0;
            }
            else
            {
                startingRow = jagged.GetLength(0) - 1;
            }

            return startingRow;
        }
        private static Queue<char> ReadDirections()
        {
            var commands = Console.ReadLine().ToCharArray();
            var queue = new Queue<char>();
            foreach (var command in commands)
            {
                queue.Enqueue(command);
            }

            return queue;
        }
        private static char[][] CreateJagged()
        {
            var rowsInput = int.Parse(Console.ReadLine());

            char[][] jagged = new char[rowsInput][];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();
                jagged[row] = input;
            }

            return jagged;
        }
        private static void PrintMatrix(char[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                Console.WriteLine(string.Join("", jagged[row]));
            }
        }
    }
}
