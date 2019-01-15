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
            var n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                foreach (var word in input)
                {
                    if (!set.Contains(word))
                    {
                        set.Add(word);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", set.OrderBy(x => x)));

        }
    }
}
