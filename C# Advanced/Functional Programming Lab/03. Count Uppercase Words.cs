using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => Char.IsUpper(w[0]))
                .Select(w =>
                {
                    Console.WriteLine(w);
                    return w;
                })
                .Count();
        }
        //public static Func<string, int> Parse = n => int.Parse(n);
    }
}
