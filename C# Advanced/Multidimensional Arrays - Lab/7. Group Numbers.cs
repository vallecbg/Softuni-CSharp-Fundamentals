using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[][] jaggedArray = new int[3][];
            var dividingOn0 = new List<int>();
            var dividingOn1 = new List<int>();
            var dividingOn2 = new List<int>();
            foreach (var num in input)
            {
                if (Math.Abs(num) % 3 == 0)
                {
                    dividingOn0.Add(num);
                }

                if (Math.Abs(num) % 3 == 1)
                {
                    dividingOn1.Add(num);
                }

                if (Math.Abs(num) % 3 == 2)
                {
                    dividingOn2.Add(num);
                }
            }

            jaggedArray[0] = dividingOn0.ToArray();
            jaggedArray[1] = dividingOn1.ToArray();
            jaggedArray[2] = dividingOn2.ToArray();

            Console.WriteLine(string.Join(" ", jaggedArray[0]));
            Console.WriteLine(string.Join(" ", jaggedArray[1]));
            Console.WriteLine(string.Join(" ", jaggedArray[2]));
        }
    }
}
