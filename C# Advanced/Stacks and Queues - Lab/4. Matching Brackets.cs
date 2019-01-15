using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var indexOpenBracket = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexOpenBracket.Push(i);
                }

                else if (input[i] == ')')
                {
                    var openBracketIndex = indexOpenBracket.Pop();
                    var closingBracketIndex = i;
                    var output = input.Substring(openBracketIndex, closingBracketIndex - openBracketIndex + 1);
                    Console.WriteLine(output);
                }
            }
        }
    }
}
