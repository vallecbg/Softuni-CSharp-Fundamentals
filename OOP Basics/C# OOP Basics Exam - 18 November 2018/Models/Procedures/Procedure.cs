using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }
        //TODO CHECK
        protected List<IAnimal> procedureHistory;
        public IReadOnlyCollection<IAnimal> ProcedureHistory
        {
            get { return this.procedureHistory; }
        }

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            foreach (var animal in procedureHistory)
            {
                Console.WriteLine(animal);
            }

            return sb.ToString();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
    }
}
