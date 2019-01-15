using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputLength = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var n = inputLength[0];
            var m = inputLength[1];
            var nSet = new HashSet<int>();
            var mSet = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                nSet.Add(input);
            }

            for (int i = 0; i < m; i++)
            {
                var input = int.Parse(Console.ReadLine());
                mSet.Add(input);
            }

            nSet.IntersectWith(mSet);

            Console.WriteLine(string.Join(" ", nSet));
        }
    }
}