using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace Practical_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var dict = new Dictionary<string, Dictionary<string, long>>();
            while ((input = Console.ReadLine()) != "end")
            {
                var userTokens = input.Split(new[] {" -> "}, StringSplitOptions.RemoveEmptyEntries);
                if (userTokens[0].Contains("ban"))
                {
                    var tokens = input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    var userNameToBan = tokens[1];
                    if (dict.ContainsKey(userNameToBan))
                    {
                        dict.Remove(userNameToBan);
                        continue;
                    }
                }
                var name = userTokens[0];
                var tag = userTokens[1];
                var likes = long.Parse(userTokens[2]);
                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, new Dictionary<string, long>());
                }

                if (!dict[name].ContainsKey(tag))
                {
                    dict[name].Add(tag, likes);
                }
                else
                {
                    dict[name][tag] += likes;
                }
            }

            foreach (var kvp in dict.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Keys.Count))
            {
                var user = kvp.Key;
                Console.WriteLine($"{user}");
                foreach (var l in kvp.Value)
                {
                    var tag = l.Key;
                    var likes = l.Value;
                    Console.WriteLine($"- {tag}: {likes}");
                }
            }
        }
    }
}
