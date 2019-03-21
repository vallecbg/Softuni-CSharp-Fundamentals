using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;
using MilitaryElite.Enums;

namespace MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstname, string lastname, decimal salary, Corps corps) : base(id, firstname, lastname, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; }
    }
}
