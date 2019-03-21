using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameInfo = new Dictionary<string, Dictionary<string, string>>();

            var targetInfoIndex = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                var inputTokens = input.Split(new[]{'='},StringSplitOptions.RemoveEmptyEntries);
                var name = inputTokens[0];
                if (!nameInfo.ContainsKey(name))
                {
                    nameInfo.Add(name, new Dictionary<string, string>());
                }

                var tokens = inputTokens[1].Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var token in tokens)
                {
                    var userInput = token.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                    var key = userInput[0];
                    var value = userInput[1];
                    if (!nameInfo[name].ContainsKey(key))
                    {
                        nameInfo[name].Add(key, value);
                        continue;
                    }

                    nameInfo[name][key] = value;
                }
            }

            var killInput = Console.ReadLine().Split();
            var nameToKill = killInput[1];

            foreach (var n in nameInfo)
            {
                var infoIndex = 0;
                var userName = n.Key;
                if (userName == nameToKill)
                {
                    Console.WriteLine($"Info on {userName}:");
                    foreach (var kvp in n.Value.OrderBy(x => x.Key))
                    {
                        var k = kvp.Key;
                        var v = kvp.Value;
                        infoIndex += k.Length + v.Length;
                        Console.WriteLine($"---{k}: {v}");
                    }

                    Console.WriteLine($"Info index: {infoIndex}");
                    if (infoIndex >= targetInfoIndex)
                    {
                        Console.WriteLine("Proceed");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Need {Math.Abs(infoIndex - targetInfoIndex)} more info.");
                        return;
                    }
                }

                infoIndex = 0;
            }
        }
    }
}
