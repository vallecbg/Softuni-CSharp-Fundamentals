using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> SearchFunc = Search;
            var nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            SearchFunc(nums);

        }

        private static int[] Search(int[] nums)
        {
            var oddNums = new List<int>();
            var evenNums = new List<int>();

            foreach (var num in nums)
            {
                if (num % 2 == 0)
                {
                    evenNums.Add(num);
                }
                else if (num % 2 != 0)
                {
                    oddNums.Add(num);
                }
            }

            Console.WriteLine((string.Join(" ", evenNums.OrderBy(x => x))) + " " + (string.Join(" ", oddNums.OrderBy(x => x))));
            return nums;
        }
    }
}
