using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var prize = int.Parse(Console.ReadLine());
            var bulletCount = 0;
            var firedBulletsCount = 0;
            while (bullets.Any() && locks.Any())
            {
                bulletCount++;
                
                var currentBullet = bullets.Peek();
                var currentLock = locks.Peek();
                if (currentBullet <= currentLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    firedBulletsCount++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    firedBulletsCount++;
                }
                if (bulletCount == barrelSize && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    bulletCount = 0;
                }

            }

            
            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                var bulletTotalCost = firedBulletsCount * bulletPrice;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${prize - bulletTotalCost}");
            }

        }
    }
}
