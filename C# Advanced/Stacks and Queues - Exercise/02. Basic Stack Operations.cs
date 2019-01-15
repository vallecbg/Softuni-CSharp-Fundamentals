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
            var operations = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stacklength = operations[0];
            var poplength = operations[1];
            var searchedElement = operations[2];
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>();
            for (int i = 0; i < stacklength; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < poplength; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(searchedElement))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
