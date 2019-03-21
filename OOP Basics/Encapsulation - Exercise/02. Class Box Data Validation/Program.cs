using System;

namespace ClassBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = double.Parse(Console.ReadLine());
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            if (length <= 0)
            {
                Console.WriteLine("Length cannot be zero or negative.");
                return;
            }
            if (width <= 0)
            {
                Console.WriteLine("Width cannot be zero or negative.");
                return;
            }
            if (height <= 0)
            {
                Console.WriteLine("Height cannot be zero or negative.");
                return;
            }
            Box box = new Box(length, width, height);
            Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurface():f2}");
            Console.WriteLine($"Volume - {box.CalculateVolume():f2}");
        }
    }
}
