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
            var clothes = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {" -> ", ","}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var color = input[0];
                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }
                for (int j = 1; j < input.Length; j++)
                {
                    if (!clothes[color].ContainsKey(input[j]))
                    {
                        clothes[color].Add(input[j], 1);
                    }
                    else
                    {
                        clothes[color][input[j]]++;
                    }
                }
            }

            var searchedInput = Console.ReadLine().Split();
            var searchedColor = searchedInput[0];
            var searchedCloth = searchedInput[1];

            foreach (var cloth in clothes)
            {
                var color = cloth.Key;
                Console.WriteLine($"{color} clothes:");
                foreach (var i in cloth.Value)
                {
                    var type = i.Key;
                    var count = i.Value;
                    if (color == searchedColor && type == searchedCloth)
                    {
                        Console.WriteLine($"* {type} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {type} - {count}");
                    }
                }
            }

        }
    }
}
