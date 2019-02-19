using System;
using System.Reflection;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var pesho = new Person("Pesho", 20);
            var gosho = new Person("Gosho", 18);
            var stamat = new Person("stamat", 43);

            Type personType = typeof(Person);
            PropertyInfo[] fields = personType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine(fields.Length);

        }
    }
}
