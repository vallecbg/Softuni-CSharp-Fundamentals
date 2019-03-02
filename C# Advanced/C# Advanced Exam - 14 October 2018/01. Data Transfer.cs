using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Data_Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            var pattern = @"s:(?<sender>[^;]*);r:(?<receiver>[^;]*);m--""(?<message>[A-Za-z ]+)""";
            Regex regex = new Regex(pattern);
            var n = int.Parse(Console.ReadLine());
            var totalMB = 0;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                Match match = regex.Match(input);
                if (match.Success)
                {
                    var sender = match.Groups["sender"].ToString();
                    var receiver = match.Groups["receiver"].ToString();
                    var message = match.Groups["message"].ToString();
                    var sbSender = new StringBuilder();
                    var sbReceiver = new StringBuilder();
                    foreach (var w in sender)
                    {
                        if (char.IsDigit(w))
                        {
                            totalMB += int.Parse(w.ToString());
                        }

                        if (char.IsLetter(w) || w == ' ')
                        {
                            sbSender.Append(w);
                        }
                    }

                    foreach (var w in receiver)
                    {
                        if (char.IsDigit(w))
                        {
                            totalMB += int.Parse(w.ToString());
                        }

                        if (char.IsLetter(w) || w == ' ')
                        {
                            sbReceiver.Append(w);
                        }
                    }

                    Console.WriteLine($"{sbSender} says \"{message}\" to {sbReceiver} ");
                }
            }

            Console.WriteLine($"Total data transferred: {totalMB}MB");
        }
    }
}
