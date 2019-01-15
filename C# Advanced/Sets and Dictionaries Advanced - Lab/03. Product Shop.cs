using System;
using System.Collections.Generic;
using System.Linq;

namespace Stacks_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var dict = new Dictionary<string, Dictionary<string, double>>();
            while ((input = Console.ReadLine()) != "Revision")
            {
                var info = input.Split(new []{' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                var shopName = info[0];
                var product = info[1];
                var price = double.Parse(info[2]);
                if (!dict.ContainsKey(shopName))
                {
                    dict.Add(shopName, new Dictionary<string, double>());
                }

                if (!dict[shopName].ContainsKey(product))
                {
                    dict[shopName].Add(product, price);
                }
            }

            foreach (var shop in dict.OrderBy(x => x.Key))
            {
                var shopName = shop.Key;
                Console.WriteLine($"{shopName}->");
                foreach (var product in shop.Value)
                {
                    var productName = product.Key;
                    var price = product.Value;
                    Console.WriteLine($"Product: {productName}, Price: {price}");
                }
            }

        }
    }
}