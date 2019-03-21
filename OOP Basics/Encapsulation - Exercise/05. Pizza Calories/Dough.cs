using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    class Dough
    {
        private const string InvalidDoughType = "Invalid type of dough.";
        private const string InvalidDoughWeight = "Dough weight should be in the range [1..200].";

        

        public Dough(string flourType, string bakingTechnique, decimal weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string flourType;

        public string FlourType
        {
            get { return flourType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty ||
                    value.ToLower() != "white" &&
                    value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(InvalidDoughType);
                }
                flourType = value;
            }
        }

        private string bakingTechnique;

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value == string.Empty ||
                    value.ToLower() != "crispy" &&
                    value.ToLower() != "chewy" &&
                    value.ToLower() != "homemade")
                {
                    throw new ArgumentException(InvalidDoughType);
                }
                bakingTechnique = value;
            }
        }

        private decimal weight;

        public decimal Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(InvalidDoughWeight);
                }
                weight = value;
            }
        }

        public decimal TotalWeight()
        {
            decimal flourWeight = 0;
            switch (this.FlourType.ToLower())
            {
                case "white":
                    flourWeight = 1.5m;
                    break;
                case "wholegrain":
                    flourWeight = 1.0m;
                    break;
            }

            decimal bakingWeight = 0;
            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    bakingWeight = 0.9m;
                    break;
                case "chewy":
                    bakingWeight = 1.1m;
                    break;
                case "homemade":
                    bakingWeight = 1.0m;
                    break;
            }
            return (2 * this.Weight) * flourWeight * bakingWeight;
        }


    }
}
