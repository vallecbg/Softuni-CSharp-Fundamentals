using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} ";
        }
    }
}
