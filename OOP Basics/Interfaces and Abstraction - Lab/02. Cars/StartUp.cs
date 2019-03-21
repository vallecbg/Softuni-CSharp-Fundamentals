using System;

namespace Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICar seat = new Seat("Leon", "Grey");
            Console.WriteLine(seat.ToString());
            Console.WriteLine(seat.Start());
            Console.WriteLine("Breaaak!");
            ICar tesla = new Tesla("Model 3", "Red", 2);
            Console.WriteLine(tesla.ToString());
            Console.WriteLine(tesla.Start());
            Console.WriteLine("Breaaak!");

            
            

        }
    }
}
