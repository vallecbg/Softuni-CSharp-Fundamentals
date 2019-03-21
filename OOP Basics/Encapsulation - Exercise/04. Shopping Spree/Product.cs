using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    class Product
    {
        

        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        private double cost;

        public double Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }

        public Product(string name, double cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

    }
}
