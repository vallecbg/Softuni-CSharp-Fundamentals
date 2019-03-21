using System;
using System.Linq;
using MordorCruelPlan.Factories;

namespace MordorCruelPlan
{
    class Program
    {
        public static void Main()
        {
            var player = new Player();
            player.Eat(Console.ReadLine()
                .Split()
                .Where(fn => fn != string.Empty)
                .Select(fn => FoodFactory.GetFood(fn)));

            Console.WriteLine(player);
        }
    }
}
