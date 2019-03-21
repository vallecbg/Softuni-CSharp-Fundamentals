using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ShoppingSpree
{
    class Topping
    {
        public Topping(string type, decimal weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string type;
        public string Type
        {
            get { return type; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty ||
                    value.ToLower() != "meat" &&
                    value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" &&
                    value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }


        private decimal weight;

        public decimal Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public decimal TotalWeight()
        {
            decimal toppingCalories = 0;
            switch (this.Type.ToLower())
            {
                case "meat":
                    toppingCalories = 1.2m;
                    break;
                case "veggies":
                    toppingCalories = 0.8m;
                    break;
                case "cheese":
                    toppingCalories = 1.1m;
                    break;
                case "sauce":
                    toppingCalories = 0.9m;
                    break;
            }
            return (2 * this.Weight) * toppingCalories;
        }

    }
}
