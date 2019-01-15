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
            var dict = new Dictionary<string, Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var continent = input[0];
                var country = input[1];
                var city = input[2];
                if (!dict.ContainsKey(continent))
                {
                    dict.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!dict[continent].ContainsKey(country))
                {
                    dict[continent].Add(country, new List<string>());
                }

                dict[continent][country].Add(city);
            }

            foreach (var continent in dict)
            {
                var continentName = continent.Key;
                Console.WriteLine($"{continentName}:");
                foreach (var kvp in continent.Value)
                {
                    var country = kvp.Key;
                    var cities = kvp.Value;
                    Console.WriteLine($"{country} -> {string.Join(", ", cities)}");
                }
            }

        }
    }
}