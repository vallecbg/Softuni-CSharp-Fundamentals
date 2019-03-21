using System.Collections;
using System.Collections.Generic;
using AnimalCentre.Models.Animals;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        //TODO CHECK
        IReadOnlyCollection<IAnimal> ProcedureHistory { get; }
        string History();
        void DoService(IAnimal animal, int procedureTime);
    }
}
