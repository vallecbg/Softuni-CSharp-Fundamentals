using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();
            var urls = Console.ReadLine().Split();
            foreach (var number in numbers)
            {
                ICallable smartphone = new Smartphone();
                Console.WriteLine(smartphone.Call(number));
            }

            foreach (var url in urls)
            {
                IBrowsable smartphone = new Smartphone();
                Console.WriteLine(smartphone.Browse(url));
            }
        }
    }
}
