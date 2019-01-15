using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                if (!set.Contains(input))
                {
                    set.Add(input);
                }
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}