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
            var dict = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().ToArray();
                var name = input[0];
                var grade = double.Parse(input[1]);
                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new List<double>());
                }

                dict[name].Add(grade);
            }

            foreach (var name in dict)
            {
                var studentName = name.Key;
                var grades = name.Value;
                Console.Write($"{studentName} -> ");
                foreach (var g in grades)
                {
                    Console.Write("{0:F2} ", g);
                }

                Console.Write($"(avg: {grades.Average():F2})");
                Console.WriteLine();
            }

        }
    }
}