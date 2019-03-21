using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstname, string lastname, decimal salary)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Salary = salary;
        }
        public decimal Salary { get; }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {this.Salary:F2}";
        }
    }
}
