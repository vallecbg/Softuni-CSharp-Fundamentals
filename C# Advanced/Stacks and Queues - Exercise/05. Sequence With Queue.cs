using System;
using System.Collections.Generic;
 
namespace P5CalculateSequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
 
            var queue = new Queue<long>();
            Console.Write(n + " ");
 
            for (int i = 0; i < 17; i++)
            {
                queue.Enqueue(n + 1);
                queue.Enqueue(2*n+1);
                queue.Enqueue(n+2);
                n = queue.Dequeue();
                Console.Write(n + " ");
            }
            for (int i = 0; i < 32; i++)
            {
                Console.Write(queue.Dequeue() + " ");
            }
        }
    }
}