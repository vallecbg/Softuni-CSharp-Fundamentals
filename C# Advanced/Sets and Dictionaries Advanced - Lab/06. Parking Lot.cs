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
            var set = new HashSet<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                var info = input.Split(new [] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);
                var command = info[0];
                var plateNumber = info[1];
                if (command == "IN")
                {
                    set.Add(plateNumber);
                }

                if (command == "OUT")
                {
                    set.Remove(plateNumber);
                }
            }

            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var plateNumber in set)
            {
                Console.WriteLine(plateNumber);
            }
        }
    }
}