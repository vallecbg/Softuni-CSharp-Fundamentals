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
            var rotateInfo = Console.ReadLine().Split(new[] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var inputDegrees = int.Parse(rotateInfo[1]);
            var rotateDegrees = inputDegrees % 360;

            var inputParameters = new Queue<string>();
            string input;
            var rowsLength = 0;
            while ((input = Console.ReadLine()) != "END")
            {
                inputParameters.Enqueue(input);
                rowsLength++;
            }
            var jagged = new char[rowsLength][];
            var tempCount = 0;
            while (inputParameters.Count > 0)
            {
                jagged[tempCount] = inputParameters.Dequeue().ToCharArray();
                tempCount++;
            }

            var maxLength = 0;
            var currentCol = 0;

            switch (rotateDegrees)
            {
                case 0:
                    for (int rows = 0; rows < jagged.GetLength(0); rows++)
                    {
                        Console.WriteLine(string.Join("", jagged[rows]));
                    }
                    break;
                case 90:
                    maxLength = 0;
                    for (int rows = 0; rows < jagged.GetLength(0); rows++)
                    {
                        if (maxLength < jagged[rows].Length)
                        {
                            maxLength = jagged[rows].Length;
                        }
                    }

                    FillWithEmpty(jagged, maxLength);

                    for (int i = 0; i < maxLength; i++)
                    {
                        for (int rows = jagged.GetLength(0) - 1; rows >= 0; rows--)
                        {
                            Console.Write(jagged[rows][currentCol]);
                        }

                        Console.WriteLine();
                        currentCol++;
                    }

                    break;
                case 180:
                    for (int rows = jagged.GetLength(0) - 1; rows >= 0; rows--)
                    {
                        Console.WriteLine(string.Join("", jagged[rows].Reverse()));
                    }
                    break;
                case 270:
                    maxLength = 0;
                    for (int rows = 0; rows < jagged.GetLength(0); rows++)
                    {
                        if (maxLength < jagged[rows].Length)
                        {
                            maxLength = jagged[rows].Length;
                        }
                    }

                    FillWithEmpty(jagged, maxLength);

                    currentCol = maxLength - 1;
                    for (int i = 0; i < maxLength; i++)
                    {
                        for (int rows = 0; rows < jagged.GetLength(0); rows++)
                        {
                            Console.Write(jagged[rows][currentCol]);
                        }

                        Console.WriteLine();
                        currentCol--;
                    }

                    break;
            }
        }

        private static char[][] FillWithEmpty(char[][] jagged, int maxLength)
        {
            for (int rows = 0; rows < jagged.GetLength(0); rows++)
            {
                if (jagged[rows].Length < maxLength)
                {
                    Array.Resize(ref jagged[rows], maxLength);
                }
            }

            for (int rows = 0; rows < jagged.GetLength(0); rows++)
            {
                for (int cols = 0; cols < jagged[rows].Length; cols++)
                {
                    if (jagged[rows][cols] == (char)0)
                    {
                        jagged[rows][cols] = ' ';
                    }
                }
            }

            return jagged;
        }
    }
}
