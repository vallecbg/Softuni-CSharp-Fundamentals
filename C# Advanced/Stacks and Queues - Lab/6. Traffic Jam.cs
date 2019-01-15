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
            var carsCount = int.Parse(Console.ReadLine());
            var queuedCars = new Queue<string>();
            string car;
            var count = 0;
            while ((car = Console.ReadLine()) != "end")
            {
                if (car == "green")
                {
                    for (int i = 0; i < carsCount; i++)
                    {
                        if (queuedCars.Count == 0)
                        {
                            break;
                        }
                        var passedCar = queuedCars.Dequeue();
                        Console.WriteLine($"{passedCar} passed!");
                        count++;
                    }
                }
                else
                {
                    queuedCars.Enqueue(car);
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
