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
            var sb = new StringBuilder();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                sb.Append(Console.ReadLine());
            }

            var pattern = @"(?:(?<bracket>{)|\[)[^0-9]*(?<digits>[0-9]*)[^0-9]*(?(bracket)}|\])";

            Regex regex = new Regex(pattern);

            var word = "";

            foreach (Match match in regex.Matches(sb.ToString()))
            {
                string digits = match.Groups["digits"].Value;

                if (digits.Length == 0 || digits.Length % 3 != 0)
                {
                    continue;
                }

                for (int numberIndex = 0; numberIndex < digits.Length / 3; numberIndex++)
                {
                    word += ((char)(int.Parse(digits.Substring(3 * numberIndex, 3)) - match.Value.Length));
                }
            }

            Console.WriteLine(word);
        }
    }
}
