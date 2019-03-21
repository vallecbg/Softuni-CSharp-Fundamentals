using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair(string partname, int hoursWorked)
        {
            this.PartName = partname;
            this.HoursWorked = hoursWorked;
        }
        public string PartName { get; }
        public int HoursWorked { get; }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {HoursWorked}";
        }
    }
}
