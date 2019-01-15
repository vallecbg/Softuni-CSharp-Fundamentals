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
            var info = new Stack<char>();
            var input = Console.ReadLine().ToCharArray();
            foreach (var i in input)
            {
                info.Push(i);
            }

            while (info.Count != 0)
            {
                Console.Write(info.Pop());
            }

            Console.WriteLine();
        }
    }
}
