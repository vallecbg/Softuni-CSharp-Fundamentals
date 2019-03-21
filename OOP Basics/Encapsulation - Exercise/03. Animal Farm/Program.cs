using System;

namespace AnimalFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var name = Console.ReadLine();
                var age = int.Parse(Console.ReadLine());
                Chicken chicken = new Chicken(name, age);
                Console.WriteLine(chicken.Print());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
