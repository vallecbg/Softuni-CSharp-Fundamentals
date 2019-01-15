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
            var followers = new Dictionary<string, List<string>>();
            var following = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                var command = input.Split();
                if (command[1] == "joined")
                {
                    var name = command[0];
                    if (!followers.ContainsKey(name) && !following.ContainsKey(name))
                    {
                        followers.Add(name, new List<string>());
                        following.Add(name, new List<string>());
                    }
                }
                else if (command[1] == "followed")
                {
                    var firstVlogger = command[0];
                    var secondVlogger = command[2];
                    if (firstVlogger == secondVlogger)
                    {
                        continue;
                    }

                    if (following.ContainsKey(firstVlogger) && following.ContainsKey(secondVlogger) &&
                        followers.ContainsKey(firstVlogger) && followers.ContainsKey(secondVlogger))
                    {
                        if (following[firstVlogger].Contains(secondVlogger))
                        {
                            continue;
                        }
                        following[firstVlogger].Add(secondVlogger);
                        followers[secondVlogger].Add(firstVlogger);
                    }

                }
            }

            Console.WriteLine($"The V-Logger has a total of {following.Count} vloggers in its logs.");
            var count = 1;
            foreach (var follower in followers.OrderByDescending(x => x.Value.Count).ThenBy(x => following[x.Key].Count))
            {
                var vloggerName = follower.Key;
                var followersList = follower.Value;
                var followingList = following[vloggerName].Count;
                Console.WriteLine($"{count}. {vloggerName} : {followersList.Count} followers, {followingList} following");
                if (count == 1 && followersList.Count > 0)
                {
                    foreach (var name in followersList.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
                count++;

            }
        }
    }
}
