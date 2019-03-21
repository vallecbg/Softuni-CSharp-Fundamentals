using System;
using System.Collections.Generic;
using ShoppingSpree;

namespace PizzaCalories
{
    class Program
    {
        public static List<Dough> Doughs = new List<Dough>();
        public static List<Topping> Toppings = new List<Topping>();
        static void Main(string[] args)
        {
            string input;
            
            try
            {
                var inputArgs = Console.ReadLine().Split();
                if (inputArgs[0] != "Pizza")
                {
                    return;
                }
                var pizzaName = inputArgs[1];
                if (string.IsNullOrWhiteSpace(pizzaName) || pizzaName == string.Empty || 
                    pizzaName.Length < 1 || pizzaName.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                input = Console.ReadLine();
                ReadDough(input);
                while ((input = Console.ReadLine()) != "END")
                {
                    ReadTopping(input);
                }

                Pizza pizza = new Pizza(pizzaName, Toppings, Doughs);
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReadTopping(string input)
        {
            var inputArgs = input.Split();
            if (inputArgs[0] != "Topping")
            {
                return;
            }
            var toppingName = inputArgs[1];
            var weight = decimal.Parse(inputArgs[2]);
            Topping topping = new Topping(toppingName, weight);
            Toppings.Add(topping);
        }

        private static void ReadDough(string input)
        {
            var inputArgs = input.Split();
            if (inputArgs[0] != "Dough")
            {
                return;
            }
            var flourType = inputArgs[1];
            var bakingTechnique = inputArgs[2];
            var weight = decimal.Parse(inputArgs[3]);
            Dough dough = new Dough(flourType, bakingTechnique, weight);
            Doughs.Add(dough);
        }
    }
}
