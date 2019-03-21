using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingSpree;

namespace PizzaCalories
{
    class Pizza
    {
        public Pizza(string name, List<Topping> toppings, List<Dough> doughs)
        {
            this.Name = name;
            this.Toppings = toppings;
            this.Doughs = doughs;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        private List<Topping> toppings;

        public List<Topping> Toppings
        {
            get { return toppings; }
            set
            {
                if (value.Count > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                toppings = value;
            }
        }



        private List<Dough> doughs;
        public List<Dough> Doughs { get; }

        public decimal TotalCalories()
        {
            return this.Toppings.Sum(x => x.TotalWeight()) + this.Doughs.Sum(x => x.TotalWeight());
        }


    }
}
