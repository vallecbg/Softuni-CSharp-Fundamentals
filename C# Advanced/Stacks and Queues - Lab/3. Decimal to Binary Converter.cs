using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            if (num == 0)
            {
                Console.WriteLine(0);
                return;
            }
            var stack = new Stack<int>();
            while (num > 0)
            {
                stack.Push(num % 2);
                num /= 2;
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();

        }
    }
}
