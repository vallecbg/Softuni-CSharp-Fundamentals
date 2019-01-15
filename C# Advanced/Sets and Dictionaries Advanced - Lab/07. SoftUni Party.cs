using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var normal = new HashSet<string>();
            var vip = new HashSet<string>();
            while ((input = Console.ReadLine()) != "PARTY")
            {
                bool guestType = int.TryParse(input[0].ToString(), out int result);
                if (guestType == true)
                {
                    vip.Add(input);
                }
                else
                {
                    normal.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                if (vip.Contains(input))
                {
                    vip.Remove(input);
                }

                if (normal.Contains(input))
                {
                    normal.Remove(input);
                }
            }

            Console.WriteLine(vip.Count + normal.Count);
            foreach (var person in vip)
            {
                Console.WriteLine(person);
            }

            foreach (var person in normal)
            {
                Console.WriteLine(person);
            }
        }
    }
}