using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private readonly IHotel hotel;
        private readonly IDictionary<string, List<IAnimal>> procedures;
        private readonly IDictionary<string, List<IAnimal>>
          adoptedAnimals;

        public AnimalCentre()
        {
            this.hotel = new Hotel();
            this.adoptedAnimals = new Dictionary<string, List<IAnimal>>();
            this.procedures = new Dictionary<string, List<IAnimal>>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            if (happiness < 0 || happiness > 100)
            {
                throw new ArgumentException("Invalid happiness");
            }

            if (energy < 0 || energy > 100)
            {
                throw new ArgumentException("Invalid energy");
            }

            //TODO MAKE SECOND VALIDATION
            
            IAnimal animal = null;
            switch (type)
            {
                case "Cat":
                    animal = new Cat(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    animal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Lion":
                    animal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    animal = new Pig(name, energy, happiness, procedureTime);
                    break;
            }
            if (hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} already exist");
            }
            hotel.Accommodate(animal);
            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            IProcedure procedure = new Chip();
            MakeProcedure(procedureTime, animal, procedure);
            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            IProcedure procedure = new Vaccinate();
            MakeProcedure(procedureTime, animal, procedure);
            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            IProcedure procedure = new Fitness();
            MakeProcedure(procedureTime, animal, procedure);
            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            IProcedure procedure = new Play();
            MakeProcedure(procedureTime, animal, procedure);
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            IProcedure procedure = new DentalCare();
            MakeProcedure(procedureTime, animal, procedure);
            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            IAnimal animal = GetAnimal(name);
            IProcedure procedure = new NailTrim();
            MakeProcedure(procedureTime, animal, procedure);
            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            IAnimal animal = GetAnimal(animalName);
            hotel.Adopt(animalName, owner);
            if (!this.adoptedAnimals.ContainsKey(owner))
            {
                this.adoptedAnimals.Add(owner, new List<IAnimal>());
            }
            this.adoptedAnimals[owner].Add(animal);
            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }

            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            var sb = new StringBuilder();
            List<IAnimal> procedure = procedures[type];
            //TODO CHECK FOR INVALID TYPE
            sb.AppendLine(type);
            foreach (var animal in procedure)
            {
                sb.Append(animal + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        private IAnimal GetAnimal(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }

            return hotel.Animals.First(x => x.Key == name).Value;
        }

        private void MakeProcedure(int procedureTime, IAnimal animal, IProcedure procedure)
        {
            if (!this.procedures.ContainsKey(procedure.GetType().Name))
            {
                this.procedures.Add(procedure.GetType().Name, new List<IAnimal>());
            }
            procedure.DoService(animal, procedureTime);
            this.procedures[procedure.GetType().Name].Add(animal);
        }

        public string GetAdoptedAnimals()
        {
            var sb = new StringBuilder();
            if (this.adoptedAnimals.Keys.Count == 0)
            {
                return "";
            }
            foreach (var owner in this.adoptedAnimals.OrderBy(x => x.Key))
            {
                sb.Append($"--Owner: {owner.Key}" + Environment.NewLine);
                sb.Append("    - Adopted animals: ");
                foreach (var animal in owner.Value)
                {
                    sb.Append(animal.Name + " ");
                }
                if (this.adoptedAnimals.Keys.Count > 1)
                {
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString().TrimEnd(' ', '\n');
        }
    }
}
