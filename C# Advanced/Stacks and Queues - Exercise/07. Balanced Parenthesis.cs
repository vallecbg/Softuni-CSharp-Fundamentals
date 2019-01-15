using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            var balanced = false;
            foreach (var symbol in input)
            {
                switch (symbol)
                {
                    case '{':
                    case '[':
                    case '(':
                        stack.Push(symbol);
                        break;

                    case '}':
                        if (stack.Any() && stack.Pop() == '{')
                        {
                            balanced = true;
                        }
                        else
                        {
                            balanced = false;
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case ']':
                        if (stack.Any() && stack.Pop() == '[')
                        {
                            balanced = true;
                        }
                        else
                        {
                            balanced = false;
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case ')':
                        if (stack.Any() && stack.Pop() == '(')
                        {
                            balanced = true;
                        }
                        else
                        {
                            balanced = false;
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine("YES");
        }
    }
}