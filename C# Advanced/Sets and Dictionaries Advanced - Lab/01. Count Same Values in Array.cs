using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            var dict = new Dictionary<string, int>();
            foreach (var i in input)
            {
                if (!dict.ContainsKey(i))
                {
                    dict.Add(i, 1);
                }
                else
                {
                    dict[i]++;
                }
            }

            foreach (var i in dict)
            {
                var num = i.Key;
                var times = i.Value;
                Console.WriteLine($"{num} - {times} times");
            }

        }
    }
}