using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Person
    {
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        private double money;

        public double Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

    }
}
