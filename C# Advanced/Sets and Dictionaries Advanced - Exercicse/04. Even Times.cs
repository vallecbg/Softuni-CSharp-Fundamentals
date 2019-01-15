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
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());

                if (!dict.ContainsKey(input))
                {
                    dict.Add(input, 1);
                }
                else
                {
                    dict[input]++;
                }
            }

            foreach (var num in dict)
            {
                var number = num.Key;
                var timesAppearing = num.Value;
                if (timesAppearing % 2 == 0)
                {
                    Console.WriteLine(number);
                    return;
                }
            }

        }
    }
}
