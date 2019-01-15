using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            var stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);
            stack.Push(1);

            for (long i = 1; i <= n - 2; i++)
            {
                var num1 = stack.Pop();
                var num2 = stack.Pop();
                stack.Push(num1);
                stack.Push(num1 + num2);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}