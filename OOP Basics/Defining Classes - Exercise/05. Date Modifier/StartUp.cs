using System;
using System.Linq;
using System.Reflection;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstDate = DateTime.Parse(Console.ReadLine());
            var secondDate = DateTime.Parse(Console.ReadLine());
            var difference = DateModifier.GetDifference(firstDate, secondDate);
            Console.WriteLine(difference);

        }
    }
}
