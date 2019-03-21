using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] commandArgs = command.Split();
                var department = commandArgs[0];
                var firstName = commandArgs[1];
                var secondName = commandArgs[2];
                var patient = commandArgs[3];
                var fullName = firstName + secondName;

                if (!doctors.ContainsKey(firstName + secondName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<List<string>>();
                    for (int stai = 0; stai < 20; stai++)
                    {
                        departments[department].Add(new List<string>());
                    }
                }

                bool hasPlace = departments[department].SelectMany(x => x).Count() < 60;
                if (hasPlace)
                {
                    int room = 0;
                    doctors[fullName].Add(patient);
                    for (int st = 0; st < departments[department].Count; st++)
                    {
                        if (departments[department][st].Count < 3)
                        {
                            room = st;
                            break;
                        }
                    }
                    departments[department][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
