using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            var personInput = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in personInput)
            {
                try
                {
                    var inputArgs = s.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                    var name = inputArgs[0];
                    var money = double.Parse(inputArgs[1]);
                    Person person = new Person(name, money);
                    persons.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            var productsInput = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in productsInput)
            {
                try
                {
                    var inputArgs = s.Split(new[] {'='}, StringSplitOptions.RemoveEmptyEntries);
                    var name = inputArgs[0];
                    var cost = double.Parse(inputArgs[1]);
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputArgs = input.Split();
                var name = inputArgs[0];
                var productName = inputArgs[1];
                Person person = persons.First(p => p.Name == name);
                Product product = products.First(p => p.Name == productName);
                if (person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.Products.Add(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
            }

            foreach (Person person in persons)
            {
                var personProducts = person.Products;
                if (personProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    var list = new List<string>();
                    foreach (Product pr in personProducts)
                    {
                        var productName = pr.Name;
                        list.Add(productName);
                    }
                    Console.WriteLine($"{person.Name} - {string.Join(", ", list)}");
                }
            }
        }
    }
}
