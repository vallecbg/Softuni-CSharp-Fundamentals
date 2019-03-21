using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
        }
        public string Name { get; }

        private int happiness;
        public int Happiness
        {
            get { return happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }

        private int energy;
        public int Energy
        {
            get { return energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }

        public int ProcedureTime { get; set; }
        public string Owner { get; set; } = "Centre";
        public bool IsAdopt { get; set; } = false;
        public bool IsChipped { get; set; } = false;
        public bool IsVaccinated { get; set; } = false;

        public override string ToString()
        {
            return $" - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
