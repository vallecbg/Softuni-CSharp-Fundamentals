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
            var input = Console.ReadLine().Split().ToArray();
            var queue = new Queue<string>(input);
            var time = int.Parse(Console.ReadLine());
            var count = 0;
            while (queue.Count != 1)
            {
                count++;
                if (time == count)
                {
                    var removedName = queue.Dequeue();
                    Console.WriteLine($"Removed {removedName}");
                    count = 0;
                }
                else
                {
                    var name = queue.Dequeue();
                    queue.Enqueue(name);
                }
            }

            var lastName = queue.Dequeue();
            Console.WriteLine($"Last is {lastName}");
        }
    }
}
