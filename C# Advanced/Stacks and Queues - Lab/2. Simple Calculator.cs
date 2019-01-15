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
            var info = new Stack<string>();
            var elements = Console.ReadLine().Split().ToArray().Reverse();
            foreach (var el in elements)
            {
                info.Push(el);
            }

            while (info.Count > 1)
            {
                var leftOperand = int.Parse(info.Pop());
                var operand = info.Pop();
                var rightOperand = int.Parse(info.Pop());
                switch (operand)
                {
                    case "+":
                        var result1 = leftOperand + rightOperand;
                        info.Push(result1.ToString());
                        break;
                    case "-":
                        var result2 = leftOperand - rightOperand;
                        info.Push(result2.ToString());
                        break;
                }
            }

            Console.WriteLine(info.Peek());
        }
    }
}
